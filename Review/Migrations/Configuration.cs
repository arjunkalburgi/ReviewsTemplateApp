namespace Review.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Review.Models;
    using Review.DAL;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<Review.DAL.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Review.DAL.AppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var items = new List<Item>
            {
                new Item {Title="Inception" },
                new Item {Title="Avengers" }
            };
            items.ForEach(s => context.Items.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();


            var itemreviews = new List<Itemreview>
            {
                new Itemreview {
                    ItemID = items.Single(s => s.Title == "Inception").ID,
                    WrittenReview = "what a film",
                    Grade = Grade.A
                },
                new Itemreview {
                    ItemID = items.Single(s => s.Title == "Inception").ID,
                    WrittenReview = "hate this film",
                    Grade = Grade.F
                },
                new Itemreview {
                    ItemID = items.Single(s => s.Title == "Avengers").ID,
                    WrittenReview = "THEBEST",
                    Grade = Grade.A
                }
            };

            foreach (Itemreview e in itemreviews)
            {
                var itemreviewInDataBase = context.Itemreviews.Where(
                    s => 
                        s.Item.ID == e.ItemID).SingleOrDefault();
                if (itemreviewInDataBase == null)
                {
                    context.Itemreviews.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}
