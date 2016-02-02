using System;
using System.ComponentModel.DataAnnotations;

namespace NewsSystem.Services.Models.BindingModels
{
    public class PostNewsBindingModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }
    }

    public class EditNewsBindingModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}