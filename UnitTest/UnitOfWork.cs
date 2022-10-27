using Common;
using DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;
using Services;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Token.Interface;

namespace UnitTest
{
    public class UnitOfWork
    {
        private IAuthenticationServices _authService;
        [SetUp]
        public void SetUp()
        {
            _authService = new Mock<IAuthenticationServices>().Object;
        }
        [Test]
        public async Task Login()
        {
            var request = new LoginDTO
            {
                UserName = "thuong",
                Password = "123",
                IsRemember = true,
                Email= "asd"
            };
           var result = await _authService.Login(request);
            Assert.Pass(JSONManager.ConvertToJson(result));
        }
    }
    
}
