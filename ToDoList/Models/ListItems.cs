using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Models
{
    public class ListItems
    {
        [Key]
        public string ListItemId { get; set; }
        public string ListItemName { get; set; }
        [ForeignKey("Users")]
        
        public string? UserId { get; set; }
        public Users Users { get; set; }
        [ForeignKey("ListTitles")]
        public string? ListId { get; set; }
        public ListTitles ListTitles { get; set; }
    }
}
