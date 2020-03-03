using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _3LTB.Helpers;
using _3LTB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.IO;
using CsvHelper;
using System.Text;
using System.Reflection;

namespace _3LTB.Data
{
    public class _3LTBContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Sequence> Sequences { get; set; }
        public virtual DbSet<Base> Bases { get; set; }

        public virtual DbSet<DutyPeriod> DutyPeriods { get; set; }
        public virtual DbSet<Leg> Legs { get; set; }
        public virtual DbSet<OpDate> OpDates { get; set; }
        public virtual DbSet<Post> Posts { get; set; }

      

        public _3LTBContext(DbContextOptions<_3LTBContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SequenceOpDate>()
                .HasKey(c => new { c.SequenceID, c.OpDateID });
            builder.Entity<Base>().HasData(new Base
            {
                ID = 1,
                BaseName = "BOS",
            }, new Base
            { 
                ID = 2,
                BaseName = "CLT",
            }, new Base
            { 
                ID = 3,
                BaseName = "DCA",
            }, new Base
            { 
                ID = 4,
                BaseName = "DFW",
            },  new Base
            { 
                ID = 5,
                BaseName = "LAX",
            },  new Base
            { 
                ID = 6,
                BaseName = "LGA",
            },  new Base
            { 
                ID = 7,
                BaseName = "MIA",
            },  new Base
            { 
                ID = 8,
                BaseName = "ORD",
            },  new Base
            { 
                ID = 9,
                BaseName = "PHL",
            },  new Base
            { 
                ID = 10,
                BaseName = "PHX",
            },  new Base
            { 
                ID = 11,
                BaseName = "RDU",
            },  new Base
            { 
                ID = 12,
                BaseName = "SFO",
            },  new Base
            { 
                ID = 13,
                BaseName = "SLT",
            }); 


    builder.Entity<OpDate>().HasData(new OpDate
            {
                ID = 1,
                DateOp = 31,
            }, new OpDate
            {
                ID = 2,
                DateOp = 1,
            }, new OpDate
            {
                ID = 3,
                DateOp = 2,
            }, new OpDate
            {
                ID = 4,
                DateOp = 3,
            }, new OpDate
            {
                ID = 5,
                DateOp = 4,
            }, new OpDate
            {
                ID = 6,
                DateOp = 5,
            }, new OpDate
            {
                ID = 7,
                DateOp = 6,
            }, new OpDate
            {
                ID = 8,
                DateOp = 7,
            }, new OpDate
            {
                ID = 9,
                DateOp = 8,
            }, new OpDate
            {
                ID = 10,
                DateOp = 9,
            }, new OpDate
            {
                ID = 11,
                DateOp = 10,
            }, new OpDate
            {
                ID = 12,
                DateOp = 11,
            }, new OpDate
            {
                ID = 13,
                DateOp = 12,
            }, new OpDate
            {
                ID = 14,
                DateOp = 13,
            }, new OpDate
            {
                ID = 15,
                DateOp = 16,
            }, new OpDate
            {
                ID = 16,
                DateOp = 15,
            }, new OpDate
            {
                ID = 17,
                DateOp = 16,
            }, new OpDate
            {
                ID = 18,
                DateOp = 17,
            }, new OpDate
            {
                ID = 19,
                DateOp = 18,
            }, new OpDate
            {
                ID = 20,
                DateOp = 19,
            }, new OpDate
            {
                ID = 21,
                DateOp = 20,
            }, new OpDate
            {
                ID = 22,
                DateOp = 21,
            }, new OpDate
            {
                ID = 23,
                DateOp = 22,
            }, new OpDate
            {
                ID = 24,
                DateOp = 23,
            }, new OpDate
            {
                ID = 25,
                DateOp = 24,
            }, new OpDate
            {
                ID = 26,
                DateOp = 25,
            }, new OpDate
            {
                ID = 27,
                DateOp = 26,
            }, new OpDate
            {
                ID = 28,
                DateOp = 29,
            }, new OpDate
            {
                ID = 29,
                DateOp = 28,
            }, new OpDate
            {
                ID = 30,
                DateOp = 29,
            }, new OpDate
            {
                ID = 31,
                DateOp = 30,
            }, new OpDate
            {
                ID = 32,
                DateOp = 31,
            }, new OpDate
            {
                ID = 33,
                DateOp = 1,
            });
        
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }


        
        //protected override void Seed(_3LTB.Areas.Identity.Data._3LTBContext context)
        //{
        //    System.Reflection.Assembly assembly = Assembly.GetExecutingAssembly();
        //    string resourceName = "3LTB.SeedData.BulkData.txt";
        //    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
        //    {
        //        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
        //        {
        //            CsvReader csvReader = new CsvReader(reader);
        //            csvReader.Configuration.WillThrowOnMissingField = false;
        //            var countries = csvReader.GetRecords<Base>().ToArray();
        //            context.Countries.AddOrUpdate(c => c.Code, countries);
        //        }
        //    }

        //    resourceName = "SeedingDataFromCSV.Domain.SeedData.provincestates.csv";
        //    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
        //    {
        //        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
        //        {
        //            CsvReader csvReader = new CsvReader(reader);
        //            csvReader.Configuration.WillThrowOnMissingField = false;
        //            while (csvReader.Read())
        //            {
        //                var SeqNum = csvReader.GetRecord<Sequence>();
        //                var BaseName = csvReader.GetField<string>("BaseName");
        //                SeqNum.BaseID = context.Countries.Local.Single(c => c.Code == countryCode);
        //                context.ProvinceStates.AddOrUpdate(p => p.Code, provinceState);
        //            }
        //        }
        //    }
        //}
    }
}
