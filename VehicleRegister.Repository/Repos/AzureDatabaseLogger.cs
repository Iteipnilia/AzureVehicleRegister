using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRegister.Repository.Interfaces;

namespace VehicleRegister.Repository.Repos
{
    class AzureDatabaseLogger : ILogger
    {
        public void LogCriticalError(string description, string errormessage)
        {
            throw new NotImplementedException();
        }

        public void LogError(string description, string errormessage)
        {
            throw new NotImplementedException();
        }

        public void LogInfo(string description)
        {
            throw new NotImplementedException();
        }
    }
}
