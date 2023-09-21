using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TheBlogProject.Data;
using TheBlogProject.Models;
using TheBlogProject.Services.Interfaces;
using TheBlogProject.ViewModels;
using X.PagedList;

namespace TheBlogProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogEmailSender _emailSender;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, IBlogEmailSender emailSender, ApplicationDbContext context)
        {
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }

        public async Task<IActionResult> Index(int? page)
        {
            //var blogs = await _context.Blogs.ToListAsync();


            //return View(blogs);

            var pageNumber = page ?? 1;
            var pageSize = 3;

            var blogs = _context.Blogs
                .Include(b => b.Author)
                //.Where(b => b.Posts.Any(p => p.ProductionStatus == Enums.ProductionStatus.ProductionReady))
                .OrderByDescending(b => b.CreatedDate)
                .ToPagedListAsync(pageNumber, pageSize);

            return View(await blogs);


        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(ContactMe model)
        {
            await _emailSender.SendContactEmailAsync(model.Email, model.Name, model.Subject, model.Message);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}