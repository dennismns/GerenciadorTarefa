using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    [Table("TBStatus", Schema = "dbo")]
    public class Status
    {
        public int Id { get; set; } 

        public string Descricao { get; set; }
    }
}
