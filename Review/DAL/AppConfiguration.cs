using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.SqlServer; 

namespace Review.DAL
{
    public class AppConfiguration : DbConfiguration
    {
        public AppConfiguration()
        {
            //SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy()); 
        }
    }
}