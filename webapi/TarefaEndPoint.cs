using Microsoft.AspNetCore.Http.HttpResults;
using webapi.Data;
using webapi.Models;

namespace webapi
{
    public class TarefaEndPoint
    {
        public static Created<Tarefa> AddProjeto(Tarefa tarefa, DataContext db)
        {
            db.Tarefas.Add(tarefa);
            db.SaveChanges();
            return TypedResults.Created($"/tarefa/{tarefa.Id}", tarefa);
        }

        public static Created<Tarefa> RemoveTarefa(Tarefa tarefa, DataContext db)
        {
            db.Tarefas.Remove(tarefa);
            db.SaveChanges();
            return TypedResults.Created($"/tarefa/{tarefa.Id}", tarefa);
        }
    }
}
