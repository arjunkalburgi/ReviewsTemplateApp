using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Review.Models;
using System.Data.Entity; 


namespace Review.DAL
{
    public class AppInit : System.Data.Entity. DropCreateDatabaseIfModelChanges<AppContext>
    {
        protected override void Seed(AppContext context)
        {
            //base.Seed(context);

            var items = new List<Item>
            {
                new Item {Title="Inception" }
            };
            items.ForEach(s => context.Items.Add(s));
            context.SaveChanges();


            var itemreviews = new List<Itemreview>
            {
                new Itemreview { ItemID=1, WrittenReview="what a film", Grade=Grade.A},
                new Itemreview { ItemID=1, WrittenReview="hate this film", Grade=Grade.F}
            };
            itemreviews.ForEach(s => context.Itemreviews.Add(s));
            context.SaveChanges(); 
        }
    }
}