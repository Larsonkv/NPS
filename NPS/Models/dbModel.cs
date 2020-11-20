using System.Data.Entity;
using MySql.Data.Entity;

namespace NPS.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class dbModel : DbContext
    {
        public dbModel()
             : base("DefaultConnection") //This 'DefaultConnection' should be equal to the connection string name on Web.config.
        {
            this.Configuration.ValidateOnSaveEnabled = false;
        }

        public virtual DbSet<Setor> Setores { get; set; }
        public virtual DbSet<Voto> Votos { get; set; }
    }
}