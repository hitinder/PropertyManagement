using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace PropertyManagement.Infrastructure.BaseClass.ApplicationProperties
{
   public class ApplicationProperties: IApplicationProperties
    {
        public ApplicationProperties(IConfiguration configuration)
        {
            this.ConnectionString = configuration.GetSection("ConnectionStrings").GetSection("DatabaseConnection").Value;
            this.Environment = configuration.GetSection("Environment").GetSection("Development").Value;
        }
        public string ConnectionString { get; set; }
        public string Environment { get; set; }

    }
}
