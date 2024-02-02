using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Tests.FakeService
{
    internal class FakeStudentService : IStudentService
    {
        public IEnumerable<ClientDto> GetAll()
        {
             
            return new List<ClientDto>()
            {
                new ClientDto() { IdNom=1, Nom="Riri"},
                 new ClientDto() { IdNom=2, Nom="Fifi"},
                new ClientDto() { IdNom=1, Nom="Loulou"},
            };
        }
    }
}
