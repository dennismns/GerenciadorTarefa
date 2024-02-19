using Microsoft.AspNetCore.Http.HttpResults;
using webapi.Data;
using webapi.Models;

namespace webapi
{
    public class ProjetoEndpoint
    {

        public static Created<Projeto> AddProjeto(Projeto projeto, DataContext db)
        {
            db.Projeto.Add(projeto);
            db.SaveChanges();
            return TypedResults.Created($"/projetos/{projeto.Id}",projeto);
        }


       
    }
}
