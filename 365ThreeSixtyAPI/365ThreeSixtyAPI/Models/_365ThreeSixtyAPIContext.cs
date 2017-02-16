using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _365ThreeSixtyAPI.Models
{
    public class _365ThreeSixtyAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public _365ThreeSixtyAPIContext() : base("name=_365ThreeSixtyAPIContext")
        {
        }

        public System.Data.Entity.DbSet<_365ThreeSixtyAPI.Models.employee> employee { get; set; }
        public System.Data.Entity.DbSet<_365ThreeSixtyAPI.Models.vote> vote { get; set; }
        public System.Data.Entity.DbSet<_365ThreeSixtyAPI.Models.mission> mission { get; set; }
        public System.Data.Entity.DbSet<_365ThreeSixtyAPI.Models.keywordDictionary> keywordDictionary { get; set; }
        public System.Data.Entity.DbSet<_365ThreeSixtyAPI.Models.exclusions> exclusions { get; set; }
    }
}
