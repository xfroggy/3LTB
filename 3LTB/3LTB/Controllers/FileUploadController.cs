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

namespace _3LTB.Controllers
{

    public class FileUploadController : Controller
    {
        private _3LTBContext context;
        //private readonly _3LTBContext context;
        public FileUploadController(_3LTBContext dbContext)
        {
            context = dbContext;
        }
        // GET: Home
        public ActionResult Index()
        {

            return View();
        }



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
                        var parser = new CsvParser(reader, CultureInfo.InvariantCulture);
                        while (true)
                        {

                            var row = parser.Read();
                            if (row[0] != "" && row[0] != "BaseName")
                            {
                                Base currentBase = context.Bases.Single(c => c.BaseName == row[0]);
                                Sequence newSequence = new Sequence
                                {
                                    BaseID = currentBase.ID
                                };
                            }
                            else
                            {
                                if (row[1] != "" && row[1] != "SeqNum")
                                {
                                    Sequence newSequence = new Sequence
                                    {

                                    };

                                }
                            }



                                    //var tBase = row[0];
                                    //var tSeq = row[1];
                                    //var tRPTday = row[2];
                                    if (row == null)
                                    {
                                        break;
                                    }
                            
                        }
                    }

                        //TextReader reader = new StreamReader(filePath);
                        //var csvReader = new CsvReader(reader);
                        //var records = csvReader.GetRecords<SeqNum>();

                        //using (var reader = new StreamReader(filePath))
                        //using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                        //{
                        //    //csv.Configuration.AutoMap<Sequence>();
                        //    csv.Configuration.IgnoreQuotes = true;
                        //    csv.Configuration.HeaderValidated = null;
                        //    csv.Configuration.MissingFieldFound = null;
                        //    var records = csv.GetRecords<Sequence>();

                        //        Console.WriteLine(records.SeqNum);

                        //}

                }
            }

                // process uploaded files
                // Don't rely on or trust the FileName property without validation.

        return Ok(new { count = files.Count, size, filePaths });
        }

            //[HttpPost]
            //public ActionResult Index(HttpPostedFileBase postedFile)
            //{
            //    string filePath = string.Empty;
            //    if (postedFile != null)
            //    {
            //        string path = Server.MapPath("~/Uploads/");
            //        if (!Directory.Exists(path))
            //        {
            //            Directory.CreateDirectory(path);
            //        }

            //        filePath = path + Path.GetFileName(postedFile.FileName);
            //        string extension = Path.GetExtension(postedFile.FileName);
            //        postedFile.SaveAs(filePath);

            //        string conString = string.Empty;
            //        switch (extension)
            //        {
            //            case ".xls": //Excel 97-03.
            //                conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
            //                break;
            //            case ".xlsx": //Excel 07 and above.
            //                conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
            //                break;
            //        }

            //        DataTable dt = new DataTable();
            //        conString = string.Format(conString, filePath);

            //        using (OleDbConnection connExcel = new OleDbConnection(conString))
            //        {
            //            using (OleDbCommand cmdExcel = new OleDbCommand())
            //            {
            //                using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
            //                {
            //                    cmdExcel.Connection = connExcel;

            //                    //Get the name of First Sheet.
            //                    connExcel.Open();
            //                    DataTable dtExcelSchema;
            //                    dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            //                    string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            //                    connExcel.Close();

            //                    //Read Data from First Sheet.
            //                    connExcel.Open();
            //                    cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
            //                    odaExcel.SelectCommand = cmdExcel;
            //                    odaExcel.Fill(dt);
            //                    connExcel.Close();
            //                }
            //            }
            //        }

            //        //Insert records to database table.
            //        CustomersEntities entities = new CustomersEntities();
            //        foreach (DataRow row in dt.Rows)
            //        {
            //            entities.Customers.Add(new Customer
            //            {
            //                Name = row["Name"].ToString(),
            //                Country = row["Country"].ToString()
            //            });
            //        }
            //        entities.SaveChanges();
            //    }

            //    return View();
            //}
        
    } 
}