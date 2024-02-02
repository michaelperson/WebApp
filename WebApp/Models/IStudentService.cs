
namespace WebApp.Models
{
    public interface IStudentService
    {
        IEnumerable<ClientDto> GetAll();
    }
}