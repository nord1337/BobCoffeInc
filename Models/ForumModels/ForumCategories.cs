using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BobCoffeInc.Models.ForumModels
{
    public class ForumCategories
    {
        public int Id { get; set; }
        public string MainTitle { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }


        public  ICollection<Post> Posts { get; set; }

        public ForumCategories()
        {
            Posts = new List<Post>();
        }
    }
    public class CoffeCategories : IEnumerable
    {
        public string[] categories = { "Американо", "Эспрессо", "Латте", "Раф-кофе",
                         "Прочее" };

        public IEnumerator GetEnumerator()
        {
            return categories.GetEnumerator();
        }
    }
}