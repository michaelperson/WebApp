using Microsoft.Data.SqlClient;

namespace WebApp.Models
{
    public class StudentService : IStudentService
    {
        private readonly IConfiguration _configuration;

        public StudentService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<ClientDto> GetAll()
        {
            //NORMALEMENT c'est dans les repos, dal, services...
            List<ClientDto> retour = new List<ClientDto>();

#if DEBUG
            string cnst = _configuration.GetConnectionString("Dev");
#else
            string cnst = _configuration.GetConnectionString("Prod");
#endif

            SqlConnection oconn = new SqlConnection(cnst);
            try
            {
                oconn.Open();
                SqlCommand sqlCommand = oconn.CreateCommand();
                sqlCommand.CommandText = "Select * from Client";
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    ClientDto dto = new ClientDto();
                    dto.IdNom = (int)reader["idNom"];
                    dto.Nom = reader["Nom"].ToString();
                    retour.Add(dto);
                }
                return retour;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
