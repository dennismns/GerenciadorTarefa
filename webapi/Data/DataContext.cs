using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data
{
    public class DataContext : DbContext    
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Historico>()
             .HasOne(h => h.Usuario)
             .WithMany(u => u.Historico)
             .HasForeignKey(h => h.usuarioId);

            modelBuilder.Entity<Tarefa>()
            .HasOne(t => t.Projeto)
            .WithMany(p => p.Tarefas)
            .HasForeignKey(t => t.ProjetoId);

            
            

            modelBuilder.Entity<Historico>()
                .HasOne(ht => ht.Tarefa)
                .WithMany(t => t.Historico)
                .HasForeignKey(ht => ht.TarefaId);



            modelBuilder.Entity<Usuario>()            
                 .Property(e => e.Nome)
                  .IsRequired() 
                   .HasMaxLength(150); 


            modelBuilder.Entity<Usuario>()
                 .Property(e => e.Email)
                  .IsRequired() 
                   .HasMaxLength(200); 

           
            modelBuilder.Entity<Usuario>()
                 .Property(e => e.Senha)
                  .IsRequired() 
                   .HasMaxLength(8);

                       

            modelBuilder.Entity<Usuario>()
                 .Property(e => e.Telefone)
                  .IsRequired()
                   .HasMaxLength(11);

            modelBuilder.Entity<Projeto>()
                 .Property(e => e.Titulo)                 
                  .IsRequired()
                   .HasMaxLength(100);

            modelBuilder.Entity<Projeto>()
                 .Property(e => e.NomeProjeto)
                  .IsRequired()
                   .HasMaxLength(100);

            modelBuilder.Entity<Projeto>()
                .Property(e => e.Descricao)
                 .IsRequired();

            modelBuilder.Entity<Projeto>()
                .Property(e => e.DataCriacao)
                 .IsRequired();

            modelBuilder.Entity<Projeto>()
                .Property(e => e.DataAlteracao)
                 .IsRequired(false);


            modelBuilder.Entity<Tarefa>()
                 .Property(e => e.Titulo)
                  .IsRequired()
                   .HasMaxLength(100);

            modelBuilder.Entity<Tarefa>()
                 .Property(e => e.Descricao)
                  .IsRequired();

            modelBuilder.Entity<Tarefa>()
                 .Property(e => e.DataVencimento)
                  .IsRequired();


            modelBuilder.Entity<Tarefa>()
                 .Property(e => e.prioridade)
                  .IsRequired();

            modelBuilder.Entity<Tarefa>()
               .Property(e => e.Status)
                .IsRequired();

            modelBuilder.Entity<Historico>()
                 .Property(e => e.descricaoAlteracao)
                  .IsRequired();

            modelBuilder.Entity<Historico>()
                 .Property(e => e.dataCriacao)
                  .IsRequired();

            modelBuilder.Entity<Historico>()
                 .Property(e => e.dataAltracao)
                  .IsRequired(false);

        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //   // optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Projetos;Integrated Security=true;TrustServerCertificate=true;");
        //}





        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Projeto> Projeto { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        //public DbSet<Prioridade> Prioridade { get; set; }
        //public DbSet<Status> Status { get; set; }
        public DbSet<Historico> Historico { get; set; }
    }
}
