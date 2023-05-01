using System.Data.SqlClient;
namespace ADONET;
class Program
{
    static void Main(string[] args)
    {
        HelperSQL helperSQL = new HelperSQL();
        DateOnly date = new DateOnly(2002, 12, 13);
        //helperSQL.AddArtists("Burak","Bulut",date,"Man");
        TimeOnly time = new TimeOnly(00,03,02);
        //helperSQL.AddMusics("Cano",time,1);

        UniversalService service = new UniversalService(helperSQL);
        service.GetAllShow();
    }
}

