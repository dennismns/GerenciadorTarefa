using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers
{
    [ApiController]
    [Route("Historico/v1")]
    public class HistoricoController : Controller
    {

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll([FromServices] DataContext context)
        {

            try
            {
                var historico = context.Historico.ToList();
                context.Dispose();
                return Ok(historico);

            }
            catch (Exception ex)
            {

                return Ok(new Message { message = "Parametros não estão no padrão da api: " + ex.Message, sucesso = false });
            }

        }


        [HttpGet]
        [Route("GetAllHistoricoTarefa/{id}")]
        public async Task<IActionResult> GetAllHistorico(int id, DataContext context)
        {

            try
            {
                var historico = context.Historico.Where(x=>x.TarefaId==id).ToList();    
                context.Dispose();
                return Ok(historico);

            }
            catch (Exception ex)
            {

                return Ok(new Message { message = "Parametros não estão no padrão da api: " + ex.Message, sucesso = false });
            }

        }

        [HttpPost]
        [Route("Cadastro")]
        public async Task<IActionResult> Cadastro([FromBody] Historico model, [FromServices] DataContext context)
        {

            try
            {

                Historico h = new Historico();

                h.TarefaId = model.TarefaId;    
                h.descricaoAlteracao=model.descricaoAlteracao;                    
                h.dataCriacao= DateTime.Now;    


              
                context.Add(h);

                



                context.Add(h);
                context.SaveChanges();
                context.Dispose();



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
                var his = context.Historico.Where(x => x.Id == id).First();
                context.Dispose();
                return Ok(his);

            }
            catch (Exception ex)
            {

                return Ok(new Message { message = "Parametros não estão no padrão da api: " + ex.Message, sucesso = false });
            }

        }

        [HttpPost]
        [Route("Alterar")]
        public async Task<IActionResult> Alterar([FromBody] Historico model, [FromServices] DataContext context)
        {

            try
            {

                //Projeto p = new Projeto();

                Historico h = context.Historico.Where(x => x.Id ==model.Id).First();

                
              
                h.TarefaId = model.TarefaId;
                h.descricaoAlteracao = model.descricaoAlteracao;
                h.dataCriacao = DateTime.Now;



                context.Update(h);
                context.SaveChanges();
                context.Dispose();

                return Ok(new Message { message = "Cadastro Alterado com sucesso", sucesso = true });

            }
            catch (Exception ex)
            {

                return Ok(new Message { message = "Parametros não estão no padrão da api: " + ex.Message, sucesso = false });
            }

        }
    }
}
