using System.Security.Cryptography;
using System.Text;
using ToDoList.Models;

namespace ToDoList.Services
{
    public class UserService
    {
        private readonly ToDoListContext _context;
        private readonly ITokenService _tokenService;

        public UserService(ToDoListContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public UsersDTO Register(UsersDTO usersDTO)
        {
            try
            {
                using var hmac = new HMACSHA512();
                var users = new Users()
                {
                    UserId = usersDTO.UserId,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(usersDTO.Password)),
                    PasswordSalt = hmac.Key,
                    Name = usersDTO.Name,
                    Email_Id = usersDTO.Email_Id,
                    Location = usersDTO.Location,
                    Contact = usersDTO.Contact

                };
                _context.Users.Add(users);
                _context.SaveChanges();
                usersDTO.jwtToken = _tokenService.CreateToken(usersDTO);
                usersDTO.Password = "";

                return usersDTO;


            }
            catch(Exception E)
            {
                Console.WriteLine(E.Message);
            }
            return null;
        }

        public UsersDTO Login(UsersDTO usersDTO)
        {
            try
            {
                var myUser = FindUser(usersDTO);
                if(myUser != null)
                {
                    using var hmac = new HMACSHA512(myUser.PasswordSalt);
                    var usrPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(usersDTO.Password));

                    for (int i = 0; i < usrPassword.Length; i++)
                    {
                        if (usrPassword[i] != myUser.PasswordHash[i])
                        return null;
                    }
                    usersDTO.jwtToken = _tokenService.CreateToken(usersDTO);
                    usersDTO.Password = "";
                    return usersDTO;
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public Users FindUser(UsersDTO usersDTO)
        {
            foreach(var item in _context.Users)
            {
                if(item.Email_Id == usersDTO.Email_Id)
                {
                    return item;
                }
            }
            return null;
        }


    }
}
