﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Comment
    {
        /// <summary>
        /// The identifier of the article this comment belongs to.
        /// </summary>
        public int ArticleId { get; set; }

        /// <summary>
        /// The content of the comment.
        /// </summary>
        [Required(ErrorMessage = "El comentario no puede estar vacío")]
        [StringLength(2000, ErrorMessage = "El comentario no puede superar los 2000 caracteres")]
        public string Content { get; set; }

        /// <summary>
        /// Represents the moment the comment was posted.
        /// </summary>
        public DateTimeOffset PublishedDate { get; set; }
    }
}