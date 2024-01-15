using introASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace introASP.Controllers
{
    public class BrandController1 : Controller
    {
        private readonly TareaContext _context;

        public BrandController1(TareaContext context)
        {
            _context = context;
        }
        
        public async Task <IActionResult> Index()
        {
            return View(await _context.Brandld.ToListAsync());
        }
    }
}
