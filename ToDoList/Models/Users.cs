using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class Users
    {
        [Key]
        public string? UserId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Name { get; set; }
        public string Email_Id { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }

        public ICollection<ListTitles> ListTitles { get; set; }
        public ICollection<ListItems> ListItems { get; set; }
    }
}
