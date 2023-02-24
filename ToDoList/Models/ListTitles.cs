using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Models
{
    public class ListTitles
    {
        [Key]
        public string? ListId { get; set; }
        public string ListName { get; set; }
        [ForeignKey("Users")]
        public string? UserId { get; set; }
        public Users Users { get; set; }

        public ICollection<ListItems>ListItems { get; set; }
    }
}
