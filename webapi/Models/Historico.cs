using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    [Table("TBHistorico", Schema = "dbo")]
    public class Historico
    {
        public int Id { get; set; }

        public int TarefaId { get; set; }

        public int usuarioId { get; set; }

        public string descricaoAlteracao { get; set; }

        public DateTime dataCriacao { get; set; }

        public DateTime? dataAltracao { get; set; }
       
        public Tarefa Tarefa { get; set; }

        public Usuario Usuario { get; set; }


    }
}
