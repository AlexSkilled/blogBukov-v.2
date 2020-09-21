using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogBukov.Domain.DB;
using blogBukov.Domain.Model;
using blogBukov.Models;
using blogBukov.ViewModels;
using BlogForStudents.Security.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blogBukov.Controllers
{
    public class BlogController : Controller
    {

        private readonly BlogDbContext _blogDbContext;

        public BlogController(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext ?? throw new ArgumentNullException(nameof(blogDbContext));
        }

        public IActionResult Index()
        {
            var posts = _blogDbContext.BlogPost
                .Select(x => new BlogPostItemViewModel
                {
                    Author = x.Owner.FullName,
                    Created = x.Created,
                    Data = x.Data,
                    Title = x.Title
                }).OrderByDescending(x => x.Created);
            return View();
        }

        [Authorize]
        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult AddPost(NewPostViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var user = this.GetAuthorizedUser();
            var post = new BlogPost
            {
                Created = DateTime.Now,
                Data = model.Data,
                Title = model.Title,
                Owner = user.Employee
            };
            return View();
        }
    }
}
