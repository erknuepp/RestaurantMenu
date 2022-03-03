namespace RestaurantMenu
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    internal class Program
    {
        static async Task Main(string[] args)
        {
            using (var db = new MenuContext())
            {
                // Note: Requires the database to be created before running.
                //Console.WriteLine($"Database path: {db.DbPath}.");

                //Clear database
                db.Menus.RemoveRange(db.Menus);
                db.Items.RemoveRange(db.Items);
                await db.SaveChangesAsync();

                // Create Breakfast Menu
                db.Add(new Menu { Name = "Breakfast" });
                await db.SaveChangesAsync();

                // Read
                var menu = db.Menus
                    .Where(b => b.Name == "Breakfast").Single();

                // Update
                menu.Items.Add(
                    new Item { Name = "Eggs", Price = 7.99m });
                menu.Items.Add(
                    new Item { Name = "Omelette", Price = 9.99m });
                menu.Items.Add(
                    new Item { Name = "Pancakes", Price = 5.99m });
                await db.SaveChangesAsync();

                // Create Lunch Menu
                db.Add(new Menu { Name = "Lunch" });
                await db.SaveChangesAsync();

                // Read
                menu = db.Menus
                    .Where(b => b.Name == "Lunch").Single();

                // Update
                menu.Items.Add(
                    new Item { Name = "Rueben", Price = 5.99m });
                menu.Items.Add(
                    new Item { Name = "Club", Price = 5.99m });
                menu.Items.Add(
                    new Item { Name = "Chicken Tenders", Price = 6.99m });
                await db.SaveChangesAsync();

                // Create Dinner Menu
                db.Add(new Menu { Name = "Dinner" });
                await db.SaveChangesAsync();

                // Read
                menu = db.Menus
                    .Where(b => b.Name == "Dinner").Single();

                // Update
                menu.Items.Add(
                    new Item { Name = "Steak", Price = 12.99m });
                menu.Items.Add(
                    new Item { Name = "Seafood", Price = 13.99m });
                menu.Items.Add(
                    new Item { Name = "Spaghetti", Price = 10.99m });
                await db.SaveChangesAsync();


                // Delete
                //Console.WriteLine("Delete the blog");
                //db.Remove(menu);
                //db.SaveChanges();
                Console.WriteLine("Welcome to Que Rico!");
                Console.WriteLine("Please choose a menu");
                var menus = db.Menus.Select(x => x.Name).ToList();
                for (int i = 0; i < menus.Count; i++)
                {
                    Console.Write($"{i + 1}) {menus[i]} ");
                }
                Console.Write("\n");
                var menuChoice = Console.ReadLine();
                int choice = 0;
                while(!int.TryParse(menuChoice, out choice) && choice > 0 && choice <= menus.Count)
                {
                    Console.WriteLine("Opps! Try again.");
                    menuChoice = Console.ReadLine();
                }
                // Read
                menu = db.Menus
                    .Where(b => b.Name == menus[choice - 1]).Single();

                foreach (var item in menu.Items)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
