namespace Entities.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using static Entities.FilmDbContext;

    internal sealed class Configuration : DbMigrationsConfiguration<Entities.FilmDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Entities.FilmDbContext context)
        {
            // add users
            IList<User> users = new List<User>();
            users.Add(new User()
            {
                Username = "admin1",
                Password = "minhduong1",
                Name = "Dương",
                BirthDay = DateTime.Parse("2002-07-18"),
                CreatedDate = DateTime.Parse(DateTime.Today.ToString()),
                Phone = "0862883237",
                Sex = true,
                Email = "minhduong180702@gmail.com",
                UserType = 1,
                Status = 1,
                IsDeleted = false,
                IsActive = true,
            });
            users.Add(new User()
            {
                Username = "admin2",
                Password = "minhduong2",
                Name = "Dương",
                BirthDay = DateTime.Parse("2002-07-18"),
                CreatedDate = DateTime.Parse(DateTime.Today.ToString()),
                Phone = "0862883237",
                Sex = true,
                Email = "minhduong18072002@gmail.com",
                UserType = 1,
                Status = 1,
                IsDeleted = false,
                IsActive = true,
            });
            foreach (User user in users)
                context.Users.Add(user);

            var db = new FilmDbContext();
            db.SaveChanges();
        }
    }
}
