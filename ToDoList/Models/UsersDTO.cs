namespace ToDoList.Models
{
    public class UsersDTO
    {
        public string? UserId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email_Id { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string jwtToken { get; set; }
    }
}
