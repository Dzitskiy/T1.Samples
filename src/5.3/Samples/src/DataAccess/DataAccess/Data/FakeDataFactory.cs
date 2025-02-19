using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public static class FakeDataFactory{
        public static IList<User> Users => new List<User>()
        {
            new User()
            {
                Id = Guid.NewGuid(),
                Email = "admin@mail.ru",
                Name = "Admin",                
            }        
        };
    }
}
