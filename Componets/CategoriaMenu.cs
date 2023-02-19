using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using supermercadoMVC.context;

namespace supermercadoMVC.Componets
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly AppDbContext _context;
        //construtor
        public CategoriaMenu(AppDbContext context)
        {
            _context = context;
        }
        
        public IViewComponentResult Invoke()
        {
            var categorias = _context.Produtos.Select(p => p.Categoria).Distinct().OrderBy(p => p);
            return View(categorias);
        }

        
    }
}