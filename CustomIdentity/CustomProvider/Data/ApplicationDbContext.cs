using CustomORM.ORM;
using CustomORM.Repository;
using System.Data.SqlClient;

namespace CustomIdentity.CustomProvider.Data
{
    public class ApplicationDbContext : DbManager
    {
        public GenericRepository<ApplicationUser> Users { get; set; }

        public ApplicationDbContext(SqlConnection connection) : base(connection.ConnectionString)
        {
            Users = new GenericRepository<ApplicationUser>(connection.ConnectionString);
        }


    }
}
