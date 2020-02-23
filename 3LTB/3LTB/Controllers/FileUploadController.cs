using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using _3LTB.Data;
using _3LTB.Models;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                            if (row[0] != "" && row[0] != "BaseName") 
                            {
                                if (currentBase.ID != 0)
                                {
                                    currentBase = new Base();
                                }
                                
                                currentBase = context.Bases.Single(c => c.BaseName == row[0]);
                         
                            }
                            
                            //Get [1] Sequence start
                            if (row[1] != "" && row[1] != "SeqNum")
                            {                          
                                if (currentBase.ID != 0)
                                {
                                    currentSequence.BaseID = currentBase.ID;
                                }
                                
                                currentSequence.SeqNum = Int32.Parse(row[1]);
                                currentSequence.DaysOp = Int32.Parse(row[24]);                               
                            }

                            //get [2] duty period start
                            if (row[2] != "" && row[2] != "RPTdayNum" && row[3] !="")
                            {
                                //currentDutyPeriod = new DutyPeriod();//start a new Duty Period
                                
                                currentDutyPeriod.SequenceID = currentSequence.ID;
                                currentDutyPeriod.DPnum = Int32.Parse(row[2]);
                                currentDutyPeriod.RPTdepLCL = row[3];
                                currentDutyPeriod.RPTdepHBT = row[4];

                            }

                            //get [5] Leg
                            if (row[5] != "" && row[5] != "DPnum")
                            {
                                //currentLeg = new Leg();//start a new Leg
                               
                                currentLeg.DutyPeriodID = currentDutyPeriod.ID;
                                currentLeg.DPnum = Int32.Parse(row[5]);
                                currentLeg.DayNumStart = Int32.Parse(row[6]);
                                currentLeg.DayNumEnd = Int32.Parse(row[7]);
                                currentLeg.EQP = row[8];
                                currentLeg.FLTnum = Int32.Parse(row[9]);
                                currentLeg.DEPcity = row[10];
                                currentLeg.DEPlcl = row[11];
                                currentLeg.DEPhbt = row[12];
                                currentLeg.ARRcity = row[13];
                                currentLeg.ARRlcl = row[14];
                                currentLeg.ARRhbt = row[15];
                                currentLeg.LEGblock = float.Parse(row[16]);

                                DutyPeriodLegs.Add(currentLeg);
                                currentLeg = new Leg();
                            }

                            //get [18] duty period end
                            if (row[18] != "" && row[18] != "RLSarrLCL" )
                            {
                                
                                currentDutyPeriod.RLSarrLCL = row[18];
                                currentDutyPeriod.RLSarrHBT = row[19];
                                currentDutyPeriod.DPblock = float.Parse(row[20]);
                                sequenceDutyPeriods.Add(currentDutyPeriod);

                                //start a new Duty Period
                                currentDutyPeriod = new DutyPeriod();
                            }


                            //Get [21] Sequence end
                            if (row[21] != "" && row[21] != "TTL")
                            {
                                
                                currentSequence.TTL = float.Parse(row[21]);
                                currentSequence.RIG = float.Parse(row[22]);
                                currentSequence.GTTL = float.Parse(row[23]);


                                
                                try
                                {
                                    context.Database.OpenConnection();
                                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Sequences ON");

                                    // add sequence to database
                                    context.Sequences.Add(currentSequence);
                                    context.SaveChanges();

                                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Sequences OFF");
                                   
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
                                }

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