using DatabaseFirst_Initial.Models;

namespace DatabaseFirst_Initial.Services
{
    internal interface IDatabaseService
    {
        Database Database { get; set; }
        Server Server { get; set; }
        User User { get; set; }

        string ConnectionString { get; }
    }
}