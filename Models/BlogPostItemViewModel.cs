using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogBukov.Models
{
    /// <summary>
    /// Модель поста
    /// </summary>
    public class BlogPostItemViewModel
    {
        /// <summary>
        /// Автор поста
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// Дата создания поста
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Статья
        /// </summary>
        public string Data { get; set; }


    }
}
