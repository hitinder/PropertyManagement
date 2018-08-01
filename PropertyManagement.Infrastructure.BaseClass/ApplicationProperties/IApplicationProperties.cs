using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyManagement.Infrastructure.BaseClass.ApplicationProperties
{
    public interface IApplicationProperties
    {
        string ConnectionString { get; }
        string Environment { get; }
    }

}

