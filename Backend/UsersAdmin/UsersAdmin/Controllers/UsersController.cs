using Microsoft.AspNetCore.Mvc;
using UsersAdmin.Data;
using UsersAdmin.Models;
using UsersAdmin.Models.Entities;

namespace UsersAdmin.Controllers
{
    //localhost:xxxx/api/users
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public UsersController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]

        public IActionResult GetAllUsers()
        {
            var allUsers = dbContext.Users.ToList();

            return Ok(allUsers);
        }

        [HttpGet]
        [Route("{id:guid}")]

        public IActionResult GetUserById(Guid id)
        {
            var user = dbContext.Users.Find(id);

            if (user is null)
            {
                return NotFound();
            }
            else return Ok(user);
        }

        [HttpPut]
        [Route("{id:guid}")]

        public IActionResult UpdateUser(Guid id, UpdateUserDto updateUserDto)
        {
            var findUser = dbContext.Users.Find(id);

            if(findUser is null)
            {
                return NotFound();
            }
            
            findUser.Name = updateUserDto.Name;
            findUser.Email = updateUserDto.Email;
            findUser.Password= updateUserDto.Password;
            findUser.UserName= updateUserDto.UserName;

            dbContext.SaveChanges();

            return Ok(findUser);


        }

        [HttpPost]

        public IActionResult AddUser(AddUserDto addUserDto )
        {
            var userEntity = new User()
            {
                Name = addUserDto.Name,
                Email = addUserDto.Email,
                Password = addUserDto.Password,
                UserName = addUserDto.UserName,
                Birthday = addUserDto.Birthday,
                UserRole = (User.Role)addUserDto.UserRole
            };

            dbContext.Users.Add(userEntity);
            dbContext.SaveChanges();
            return Ok(userEntity);
        }

        [HttpDelete]
        [Route("{id:guid}")]

        public IActionResult DeleteUser(Guid id)
        {
            var user = dbContext.Users.Find(id);
            
            if(user is null)
            {
                return NotFound();
            }

            dbContext.Users.Remove(user);

            dbContext.SaveChanges();

            return Ok();
        }

    }
}
