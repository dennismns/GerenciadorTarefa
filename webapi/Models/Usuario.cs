using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    [Table("TBUsuario", Schema = "dbo")]
    public class Usuario
    {
        
        public int  Id  { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }
        
        public string Telefone { get; set; }               

        public int CargoId { get; set; } // Chave estrangeira para o cargo do usuário

        public Cargo Cargo { get; set; } // Propriedade de navegação para o cargo do usuário

        public ICollection<Historico> Historico { get; set; }

    }
}
