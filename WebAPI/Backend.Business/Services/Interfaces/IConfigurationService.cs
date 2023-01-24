using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Business.Services.Interfaces
{
    public interface IConfigurationService
    {
        string JWTTokenKey { get; }
        string ValidIssuer { get; }
        string ValidAudience { get; }
    }
}
