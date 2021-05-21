using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRegister.Repository.Interfaces
{
    interface ILogger
    {
        void LogInfo(string description);
        void LogError(string description, string errormessage);
        void LogCriticalError(string description, string errormessage);
    }
}
