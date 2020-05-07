using _3LTB.Data;
using _3LTB.Models;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _3LTB.Controllers
{

    public class FileUploadController : Controller
    {
        private _3LTBContext context;
        public FileUploadController(_3LTBContext dbContext)
        {
            context = dbContext;
        }
        // GET: Home
        public ActionResult Index()
        {

            return View();
        }


        //upload csv file and process into the database - Bases/Sequences/DutyPeriods/Legs
        [HttpPost("FileUpload")]
        public async Task<IActionResult> Index(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);
            List<Base> bases = context.Bases.ToList();
            var filePaths = new List<string>();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    // full path to file in temp location
                    var filePath = Path.GetTempFileName(); //we are using Temp file name just for the example. Add your own file path.
                    filePaths.Add(filePath);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }

                    using (var reader = new StreamReader(filePath))
                    {
                        List<DutyPeriod> sequenceDutyPeriods = new List<DutyPeriod>();
                        SequenceOpDate sequenceOpDate = new SequenceOpDate();
                        String[] DateArrayFirst = null;
                        String[] DateArray = null;
                        int dtId;
                        List<Leg> DutyPeriodLegs = new List<Leg>();
                        Base currentBase = new Base();
                        Sequence currentSequence = new Sequence();
                        DutyPeriod currentDutyPeriod = new DutyPeriod();
                        Leg currentLeg = new Leg();
                        var parser = new CsvParser(reader, CultureInfo.InvariantCulture);
                        while (true)
                        {

                            var row = parser.Read();
                            if (row == null)
                            {
                                break;
                            }
                            //Get [0] Base

                            //currentBase = Base.GetInstance(row);
                            if (row[1] != "" && row[1] != "BaseName")
                            {
                                
                                if (currentBase.ID != 0 && currentBase.BaseName != row[1])
                                {
                                    currentBase = new Base();
                                }

                                currentBase = context.Bases.Single(c => c.BaseName == row[1]);

                            }

                            //Get [1] Sequence start
                            if (row[2] != "" && row[2] != "SeqNum" )
                               
                            {
                                if (currentSequence.SeqNum != 0 && currentSequence.SeqNum != Int32.Parse(row[2]))
                                {                                    
                                    try
                                    {
                                        context.Database.OpenConnection();
                                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Sequences ON");

                                        // add sequence to database
                                        context.Sequences.Add(currentSequence);
                                        context.SaveChanges();
                                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Sequences OFF");

                                        // add DaysOp to joining table between Sequence/OpDate and joining table SequenceOpDate
                                        if (DateArrayFirst != null)
                                        { 
                                            foreach (var dtf in DateArrayFirst)
                                            {
                                                if (dtf == "31")
                                                {
                                                    dtId = 1;
                                                }
                                                else dtId = 2;

                                                SequenceOpDate DateItem = new SequenceOpDate
                                                {
                                                    OpDate = context.OpDates.Single(o => o.ID == dtId),
                                                    Sequence = context.Sequences.Single(s => s.ID == currentSequence.ID)
                                                };

                                                // add sequence to database
                                                context.SequenceOpDates.Add(DateItem);
                                                context.SaveChanges();
                                            }
                                        }
                                        if (DateArray != null)
                                        {
                                            foreach (var dt in DateArray)
                                            {

                                                if (dt == "1")
                                                {
                                                    dtId = 33;
                                                }
                                                else dtId = int.Parse(dt) + 1;

                                                SequenceOpDate DateItem = new SequenceOpDate
                                                {
                                                    OpDate = context.OpDates.Single(o => o.ID == dtId),
                                                    Sequence = context.Sequences.Single(s => s.ID == currentSequence.ID)
                                                };

                                                // add sequence to database
                                                context.SequenceOpDates.Add(DateItem);
                                                context.SaveChanges();
                                            }
                                        }

                                        foreach (DutyPeriod DP in sequenceDutyPeriods.Where(n => n.SequenceID == currentSequence.ID))

                                        //foreach (DutyPeriod DP in sequenceDutyPeriods) - add to database
                                        {
                                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.DutyPeriods ON");
                                            context.DutyPeriods.Add(DP);
                                            context.SaveChanges();
                                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.DutyPeriods OFF");

                                            // for each leg in the DP, add the leg to databse
                                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Legs ON");
                                            foreach (Leg leg in DutyPeriodLegs.Where(n => n.ID == DP.ID))

                                            {
                                                context.Legs.Add(leg);
                                            }

                                            context.SaveChanges();
                                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Legs OFF");
                                        }
                                    }
                                    finally
                                    {
                                        context.Database.CloseConnection();

                                        //initialize next sequence
                                        currentSequence = new Sequence();
                                        DateArrayFirst = null;
                                        DateArray = null;

                                    }

                                }

                                if (currentSequence.SeqNum != Int32.Parse(row[2]))
                                {
                                    //currentSequence = new Sequence();
                                    if (currentBase.ID != 0)
                                    {
                                        currentSequence.BaseID = currentBase.ID;
                                    }
                                    
                                    currentSequence.SeqNum = Int32.Parse(row[2]);
                                    currentSequence.DaysOp = Int32.Parse(row[3]);

                                    currentSequence.TTL = float.Parse(row[6]);
                                    currentSequence.RIG = float.Parse(row[7]);
                                    currentSequence.GTTL = float.Parse(row[8]);
                                    if (row[4] != "")
                                    {
                                        DateArrayFirst = row[4].Split(",");
                                    }
                                    if (row[5] != "")
                                    {
                                        DateArray = row[5].Split(",");
                                    }
                             

                                }
                            }

                            //get [2] duty period start
                            if (row[9] != "" && row[9] != "RPTdepLCL")
                            {
                                //currentDutyPeriod = new DutyPeriod();//start a new Duty Period

                                currentDutyPeriod.SequenceID = currentSequence.ID;                               
                                currentDutyPeriod.RPTdepLCL = row[9];
                                currentDutyPeriod.RPTdepHBT = row[10];

                            }

                            //get [5] Leg
                            if (row[17] != "" && row[17] != "DPnum")
                            {
                                //currentLeg = new Leg();//start a new Leg

                                currentLeg.DutyPeriodID = currentDutyPeriod.ID;
                                currentLeg.DPnum = Int32.Parse(row[17]);
                                currentDutyPeriod.DPnum = Int32.Parse(row[17]);
                                currentLeg.DayNumStart = Int32.Parse(row[18]);
                                currentLeg.DayNumEnd = Int32.Parse(row[19]);
                                currentLeg.EQP = row[20];
                                currentLeg.FLTnum = row[21];
                                currentLeg.DEPcity = row[22];
                                currentLeg.DEPlcl = row[23];
                                currentLeg.DEPhbt = row[24];
                                currentLeg.ARRcity = row[25];
                                currentLeg.ARRlcl = row[26];
                                currentLeg.ARRhbt = row[27];
                                currentLeg.LEGblock = float.Parse(row[28]);

                                DutyPeriodLegs.Add(currentLeg);
                                currentLeg = new Leg();
                            }

                            //get [10] duty period end
                            if (row[11] != "" && row[11] != "RLSarrLCL")
                            {

                                currentDutyPeriod.RLSarrLCL = row[11];
                                currentDutyPeriod.RLSarrHBT = row[12];
                                currentDutyPeriod.DPblock = float.Parse(row[13]);
                                currentDutyPeriod.DPrig = float.Parse(row[14]);
                                currentDutyPeriod.dpTOD = float.Parse(row[15]);
                                sequenceDutyPeriods.Add(currentDutyPeriod);

                                //start a new Duty Period
                                currentDutyPeriod = new DutyPeriod();
                            }

                        }
                    }
                }
            }

            // Don't rely on or trust the FileName property without validation.
            return Redirect("/Home");
        }




    }
}