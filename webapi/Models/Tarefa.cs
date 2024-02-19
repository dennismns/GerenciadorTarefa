using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    [Table("TBTarefa", Schema = "dbo")]
    public class Tarefa
    {

        public int Id { get; set; }

        public int ProjetoId { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string comentario { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataConlusao { get; set; }

        public DateTime DataVencimento { get; set; }

        [NotMapped]
        public int usuarioId { get; set; }

        public StatusTarefa Status { get; set; }

        public PrioridadeTarefa prioridade { get; set; }    
       
        public Projeto Projeto { get; set; }

        

        public ICollection<Historico>? Historico { get; set; }



        public enum StatusTarefa
        {
            Pendente,
            EmAndamento,
            Concluída
        }

        public enum PrioridadeTarefa
        {
            Baixa,
            Média,
            Alta
        }

    }
}
