using ToDoList.Models;

namespace ToDoList.Services
{
    public interface ITokenService
    {
        public string CreateToken(UsersDTO usersDTO);
    }
}
