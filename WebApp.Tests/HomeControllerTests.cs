using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging; 
using WebApp.Controllers;
using WebApp.Models;
using WebApp.Tests.FakeService;
using WebApp.Tests.Models;

namespace WebApp.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void ListStudentsTest()
        {
            //Arrange
            //ILogger
            ILogger<HomeController> logger = new MonLogger();
            //Iconfiguration
            Dictionary<string, string> inMemory = new Dictionary<string, string>();
            inMemory.Add("ConnectionStrings:Dev", "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=IF3;User ID=WebIF3User;Password=Test1234=;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            inMemory.Add("ConnectionStrings:Prod", "Data Source=LenoMike\\TFTIC2022;Initial Catalog=IF3;User ID=WebIF3User;Password=Test1234=;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

            IConfiguration configuration = new ConfigurationBuilder().AddInMemoryCollection(inMemory).Build();
            //IstudentService
            IStudentService Fake = new FakeStudentService();

            HomeController hc = new HomeController(logger, configuration,Fake );
            //Act
            IActionResult reponse = hc.ListStudents();
            //Assert
            Assert.NotNull(reponse);
            Assert.IsType<ViewResult>( reponse);
            Assert.IsAssignableFrom<IEnumerable<ClientDto>>((reponse as ViewResult).Model);
            List<ClientDto> list = ((reponse as ViewResult).Model as IEnumerable<ClientDto>).ToList();
            Assert.Equal(3, list.Count());
            Assert.Equal("Riri", list[0].Nom);
            Assert.Equal("Fifi", list[1].Nom);
            Assert.Equal("Loulou", list[2].Nom);
        }
    }
}