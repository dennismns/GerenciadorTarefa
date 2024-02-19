using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    [Table("TBProjeto", Schema = "dbo")]
    public class Projeto
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string NomeProjeto { get; set; }

        public string Descricao { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataAlteracao { get; set; }
                   
        public ICollection<Tarefa>? Tarefas { get; set; }
    }
}
