using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
    public class ToDoListContext:DbContext
    {
        public ToDoListContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<ListItems> Listitems { get; set; }
        public DbSet<ListTitles> ListTitles { get; set; }
    }
}
