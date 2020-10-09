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
    /// <summary>
    /// Контроллер блога
    /// </summary>
    public class BlogController : Controller
    {

        private readonly BlogDbContext _blogDbContext;

        public BlogController(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext ?? throw new ArgumentNullException(nameof(blogDbContext));
        }
        /// <summary>
        /// Получение главной страницы постов
        /// </summary>
        /// <returns></returns>
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
            return View(posts);
        }

        [HttpGet]
        public IActionResult AddPost()
        {
            return View();
        }
        /// <summary>
        /// Добавление поста
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPostAsync(NewPostViewModel model)
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
            _blogDbContext.BlogPost.Add(post);
            _blogDbContext.SaveChanges();
            return View();
        }
    }
}
