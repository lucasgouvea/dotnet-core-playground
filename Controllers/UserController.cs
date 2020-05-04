using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnet_playground.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public User Get()
        {
            User user = new User { Id = 1, Name = "José" };
            user.Contact = new UserContact { Id = 1, Email = "jose@gmei.com", UserId = user.Id };
            user.Document = new UserDocument{ Id = 1, Code = "444-444-444-44", UserId = user.Id };

            User user2 = new User { Id = 2, Name = "Maria" };
            user2.Contact = new UserContact { Id = 2, Email = "maria@gmei.com", UserId = user2.Id };
            user2.Document = new UserDocument{ Id = 2, Code = "555-555-555-55", UserId = user2.Id };

            string[] props = { "Contact", "Document" };

            foreach(string prop in props)
            {
                var value = user2.GetType().GetProperty(prop).GetValue(user2);
                user.GetType().GetProperty(prop).SetValue(user, value, null);
            }

            return user;
        }
    }
}
;