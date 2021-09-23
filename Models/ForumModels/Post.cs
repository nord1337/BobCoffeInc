using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BobCoffeInc.Models.ForumModels
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        
        public int? ForumCategoriesId { get; set; }

       
        //public ForumCategories ForumCategories { get; set; }

    }
}