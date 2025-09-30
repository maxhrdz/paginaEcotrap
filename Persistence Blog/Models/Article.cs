using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    /// <summary>
    /// Represents a blog article
    /// </summary>
    public class Article
    {
        /// <summary>
        /// The unique identifier for the article. Assigned at creation.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the author who wrote the article.
        /// </summary>
        [Required(ErrorMessage = "El nombre del autor es obligatorio")]
        public string AuthorName { get; set; }

        /// <summary>
        /// The email of the author who wrote the article.
        /// </summary>
        [Required(ErrorMessage = "El correo del autor es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
        public string AuthorEmail { get; set; }

        /// <summary>
        /// The title of the article. Specified by the user.
        /// It is limited to 100 characters.
        /// </summary>
        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(100, ErrorMessage = "El título no puede superar los 100 caracteres")]
        public string Title { get; set; }

        /// <summary>
        /// The full content of the article. 
        /// </summary>
        [Required(ErrorMessage = "El contenido es obligatorio")]
        public string Content { get; set; }

        /// <summary>
        /// Represents the moment the article was published
        /// </summary>
        public DateTimeOffset PublishedDate { get; set; }
    }
}