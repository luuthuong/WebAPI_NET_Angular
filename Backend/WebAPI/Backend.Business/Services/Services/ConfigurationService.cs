using Backend.Business.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Business.Services.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfiguration _configuration;
        public ConfigurationService(IConfiguration configuration) {
            _configuration = configuration;
        }
        public string JWTTokenKey => _configuration["JWT:JWTTokenKey"];

        public string ValidIssuer => _configuration["JWT:ValidIssuer"];

        public string ValidAudience => _configuration["JWT:ValidAudience"];
    }
}
