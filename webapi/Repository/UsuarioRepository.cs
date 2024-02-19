using System;
using webapi.Data;
using webapi.Models;

namespace webapi.Repository
{
    public class UsuarioRepository
    {
        //private readonly DataContext _context;
        //public UsuarioRepository(DataContext context)
        //{
        //    // _dataContext = new DataContext();
            
        //}

        public List<Usuario> Get()
        {
            var users = new List<Usuario>
            {
                new Usuario { Id = 1,Nome="Bruno", Telefone="11933359985", Email = "Bruno@teste.com", Senha="123456", Cargo =
                 new Cargo {Id=1,DescricaoCargo="Gerente"}
                },
                new Usuario { Id = 2,Nome="Italo",  Telefone="11933459985", Email = "Italo@teste.com", Senha="123456", Cargo =
                 new Cargo {Id=2,DescricaoCargo="Programador"}}
            };

           // var usuario = users.Where(x => x.Email == email && x.Senha == senha).FirstOrDefault();

            return users;
        }
    }
}
