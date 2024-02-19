using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;

namespace webapi.Repository
{
    public class ProjetoRepository
    {
        private readonly DataContext _context;
      
        public ProjetoRepository(DataContext context) {
        
            _context = context; 
        }

        public  List<Projeto> GetAll()
        {

            try
            {
                var projeto =  _context.Projeto.ToList();
                _context.Dispose();
                return projeto.ToList();

            }
            catch (Exception ex)
            {

                return null;

            }

        }


    }
}
