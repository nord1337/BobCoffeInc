using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BobCoffeInc.Models
{
    public class CoffeContext:DbContext
    {
        public DbSet<Coffe>Coffes { get; set; }
    }
    public class CoffeDbInitialize : DropCreateDatabaseAlways<CoffeContext>
    {
       

        protected override void Seed(CoffeContext db)
        {
            db.Coffes.Add(new Coffe { Name = "Tatar Americano", About = "Delicious Tatar Americano", Price = 399, ImagePath = @"Content/CoffeImages/Coffe1.jpg", Id = 1 });
            db.Coffes.Add(new Coffe { Name = "Russian Americano", About = "Beautiful Russian Americano", Price = 599, ImagePath = @"Content/CoffeImages/Coffe1.jpg", Id = 2 });
            db.Coffes.Add(new Coffe { Name = "USA Americano", About = "Awful American Americano", Price = 499, ImagePath = @"Content/CoffeImages/Coffe1.jpg", Id = 3 });
            db.Coffes.Add(new Coffe { Name = "European Americano", About = "Delusional European Americano", Price = 699, ImagePath = @"Content/CoffeImages/Coffe1.jpg", Id = 4 });
            //db.Books.Add(new Book { Name = "Война и мир", Author = "Л. Толстой", Price = 220, ID = 1 });
            //db.Books.Add(new Book { Name = "Отцы и дети", Author = "И. Тургенев", Price = 180, ID = 2 });
            //db.Books.Add(new Book { Name = "Чайка", Author = "А. Чехов", Price = 150, ID = 3 });

            base.Seed(db);
        }
    }
}