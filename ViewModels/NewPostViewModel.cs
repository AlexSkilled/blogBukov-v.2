using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogBukov.ViewModels
{
    /// <summary>
    /// Модель поста
    /// </summary>
    public class NewPostViewModel
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Содержание
        /// </summary>
        public string Data { get; set; }

    }
}
