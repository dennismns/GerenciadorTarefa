using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers
{
    [ApiController]
    [Route("Tarefa/v1")]
    public class TarefaController : Controller
    {
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll([FromServices] DataContext context)
        {

            try
            {
                var tarefas = context.Tarefas.ToList();
                context.Dispose();
                return Ok(tarefas);

            }
            catch (Exception ex)
            {

                return Ok(new Message { message = "Parametros não estão no padrão da api: " + ex.Message, sucesso = false });
            }

        }

        [HttpPost]
        [Route("Cadastro")]
        public async Task<IActionResult> Cadastro([FromBody] Tarefa model, [FromServices] DataContext context)
        {

            try
            {


                var quantidadeTarefas = context.Tarefas
                   .Include(x => x.Projeto)
                   .Where(x => x.Projeto.Id == model.Projeto.Id).Count();

                if(quantidadeTarefas>=20)
                    return Ok(new Message { message = "Infelizmente o numero de tarefas para ese projeto foi atingido", sucesso = true });  

                Tarefa tarefa = new Tarefa();

                tarefa.Titulo = model.Titulo;
                tarefa.Descricao = model.Descricao;
                tarefa.DataVencimento = model.DataVencimento;
                tarefa.comentario = model.comentario;
                tarefa.Status = model.Status;
                tarefa.prioridade = model.prioridade;
                tarefa.DataCriacao= DateTime.Now;
                tarefa.DataConlusao = model.DataConlusao;   
                tarefa.ProjetoId = context.Projeto.Where(p => p.Id == model.Projeto.Id).First().Id;
                


                context.Add(tarefa);
                        
                context.SaveChanges();
                int lastProductId = context.Tarefas.Max(item => item.Id);

                Historico h = new Historico();
                h.TarefaId = lastProductId;
                h.descricaoAlteracao = "Alterando a tarefa";
                h.usuarioId = model.usuarioId;
                h.dataCriacao = DateTime.Now;
                context.Add(h);
                context.SaveChanges();
                context.Dispose();

                return Ok(new Message { message = "Cadastro salvo com sucesso", sucesso = true });

            }
            catch (Exception ex)
            {

                return Ok(new Message { message = "Parametros não estão no padrão da api: " + ex.Message, sucesso = false });
            }



        }

        [HttpPost]
        [Route("BuscarPorId/{id}")]
        public async Task<IActionResult> BuscarPorId(int id, [FromServices] DataContext context)
        {

            try
            {
                var tarefas = context.Tarefas.Where(x => x.Id == id).First();
                context.Dispose();
                return Ok(tarefas);

            }
            catch (Exception ex)
            {

                return Ok(new Message { message = "Parametros não estão no padrão da api: " + ex.Message, sucesso = false });
            }

        }

        [HttpPost]
        [Route("Alterar")]
        public async Task<IActionResult> Alterar([FromBody] Tarefa model, [FromServices] DataContext context)
        {

            try
            {

                var user = context.Usuarios.Where(x => x.Id == model.Id).First();
                if (user == null)
                {
                    Ok(new Message { message = "Usuario não existe no siatema", sucesso = true });
                }

                Tarefa tarefa = context.Tarefas.Where(x => x.Id == model.Id).First();

                if (tarefa.prioridade != model.prioridade)
                    return Ok(new Message { message = "O status não pode ser alterado ", sucesso = true });

                tarefa.Titulo = model.Titulo;
                tarefa.Descricao = model.Descricao;
                tarefa.DataVencimento = model.DataVencimento;
                tarefa.comentario = model.comentario;
                tarefa.Status = model.Status;
                tarefa.prioridade = model.prioridade;               
                tarefa.DataConlusao = model.DataConlusao;
                tarefa.ProjetoId = context.Projeto.Where(p => p.Id == model.Projeto.Id).First().Id;
               


                context.Update(tarefa);
                context.SaveChanges();


                Historico h = new Historico();

                h.TarefaId = model.Id;
                h.descricaoAlteracao = "Alterando a tarefa";
                h.usuarioId = model.usuarioId;
                h.dataCriacao = DateTime.Now;
                context.Add(h); 
                context.SaveChanges();
                context.Dispose();

                return Ok(new Message { message = "Tarefa alterado com sucesso", sucesso = true });

            }
            catch (Exception ex)
            {

                return Ok(new Message { message = "Parametros não estão no padrão da api: " + ex.Message, sucesso = false });
            }



        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeletarTarefa(int id, [FromServices] DataContext context)
        {

            try
            {
            
              
                var projeto = context.Projeto.Where(x => x.Id == id).First();
                context.Remove(projeto);
                context.SaveChanges();
                context.Dispose();
                return Ok(new Message { message = "Tarefa Deletada !", sucesso = true });

            }
            catch (Exception ex)
            {

                return Ok(new Message { message = "Parametros não estão no padrão da api: " + ex.Message, sucesso = false });
            }

        }
    }
}
