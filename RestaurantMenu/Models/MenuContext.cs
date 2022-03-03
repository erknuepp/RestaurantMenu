namespace RestaurantMenu
{
    using Microsoft.EntityFrameworkCore;

    using System;
    using System.Collections.Generic;

    internal class MenuContext:DbContext

    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Item> Items { get; set; }

        public string DbPath { get; }

        public MenuContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "menu.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }

    public class Menu
    {
        public int MenuId { get; set; }
        public string Name { get; set; }

        public List<Item> Items { get; } = new();
    }

    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int MenuId { get; set; }
        public Menu Menu { get; set; }

        public override string ToString()
        {
            return $"{Name} {Price.ToString("C2")}";
        }
    }
}
