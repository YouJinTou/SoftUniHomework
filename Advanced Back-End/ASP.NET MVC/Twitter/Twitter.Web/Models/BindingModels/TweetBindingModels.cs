using System.ComponentModel.DataAnnotations;

namespace Twitter.Web.Models.ViewModels.BindingModels
{
    public class PostTweetBindingModel
    {
        [Required]
        [MinLength(0), MaxLength(140)]
        public string Content { get; set; }
    }
}