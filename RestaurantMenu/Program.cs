namespace RestaurantMenu
{
    using System;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MenuContext())
            {
                // Note: This sample requires the database to be created before running.
                Console.WriteLine($"Database path: {db.DbPath}.");

                // Create
                Console.WriteLine("Inserting a new blog");
                db.Add(new Menu { Name = "TestMenu" });
                db.SaveChanges();

                // Read
                Console.WriteLine("Querying for a blog");
                var menu = db.Menus
                    .OrderBy(b => b.MenuId)
                    .First();
                Console.WriteLine(menu.Name);

                // Update
                Console.WriteLine("Updating the blog and adding a post");
                menu.Name = "TstMenuUpdate";
                menu.Items.Add(
                    new Item { Name = "TestItem", Price = 9.99m });
                db.SaveChanges();

                // Delete
                Console.WriteLine("Delete the blog");
                db.Remove(menu);
                db.SaveChanges();
            }
        }
    }
}
