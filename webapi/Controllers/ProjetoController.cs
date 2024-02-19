using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using webapi.Data;
using webapi.Models;
using webapi.Repository;

namespace webapi.Controllers
{
    [ApiController] 
    [Route("Projeto/v1")]
    public class ProjetoController : Controller
    {
        


            [HttpGet]
            [Route("GetAll")]
            public async Task<IActionResult> GetAll([FromServices] DataContext context)
            {

                try
                {
                var Projeto = context.Projeto.ToList();
                    context.Dispose();
                    return Ok(Projeto);

                }
                catch (Exception ex)
                {

                    return Ok(new Message { message = "Parametros não estão no padrão da api: " + ex.Message, sucesso = false });
                }

            }


        [HttpPost]
        [Route("Cadastro")]
        public async Task<IActionResult> Cadastro([FromBody] Projeto model, [FromServices] DataContext context)
        {

            try
            {

                Projeto p = new Projeto();

                p.Titulo = model.Titulo;   
                p.NomeProjeto = model.NomeProjeto;
                p.Descricao=model.Descricao;                             
                p.DataCriacao = DateTime.Now;
                p.DataAlteracao = null;
              
                context.Add(p);
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
                var projeto = context.Projeto.Where(x => x.Id == id).First();
                context.Dispose();
                return Ok(projeto);

            }
            catch (Exception ex)
            {

                return Ok(new Message { message = "Parametros não estão no padrão da api: " + ex.Message, sucesso = false });
            }

        }


        [HttpPost]
        [Route("Alterar")]
        public async Task<IActionResult> Alterar([FromBody]  Projeto model, [FromServices] DataContext context)
        {

            try
            {

                //Projeto p = new Projeto();

                Projeto p= context.Projeto.Where(x => x.Id==model.Id).First();
               
                p.Titulo = model.Titulo;
                p.NomeProjeto = model.NomeProjeto;
                p.Descricao = model.Descricao;               
                p.DataAlteracao = null;

                //p.DataCriacao = DateTime.Now;
                p.DataAlteracao = DateTime.Now; ;
                //context.Entry(p).Property(u => u.DataCriacao).IsModified =false; 
            
                context.Update(p);
                context.SaveChanges();
                context.Dispose();

                return Ok(new Message { message = "Cadastro Alterado com sucesso", sucesso = true });

            }
            catch (Exception ex)
            {

                return Ok(new Message { message = "Parametros não estão no padrão da api: " + ex.Message, sucesso = false });
            }

        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeletarProjeto(int id, [FromServices] DataContext context)
        {

            try
            {

                var quantidadeTarefapendente= context.Tarefas.Where(x=>x.Status.Equals("Pendente")).Count();
                if (quantidadeTarefapendente > 0)
                    Ok(new Message { message = "Não pode deletar, ainda existe tarfa pendente !", sucesso = true });

                var projeto = context.Projeto.Where(x => x.Id == id).First();
                context.Remove(projeto);
                context.SaveChanges();
                context.Dispose();
                return Ok(new Message { message = "Projeto Deletado !", sucesso = true });

            }
            catch (Exception ex)
            {

                return Ok(new Message { message = "Parametros não estão no padrão da api: " + ex.Message, sucesso = false });
            }

        }





    }
    }

