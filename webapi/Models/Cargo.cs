using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    [Table("TBCargo", Schema = "dbo")]
    public class Cargo
    {
        public int Id { get; set; }

        public string DescricaoCargo { get; set; }

        //public ICollection<Usuario> Usuarios { get; set; }
    }
}
