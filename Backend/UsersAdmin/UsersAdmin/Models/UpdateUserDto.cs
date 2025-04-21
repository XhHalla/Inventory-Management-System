namespace UsersAdmin.Models
{
    public class UpdateUserDto
    {
        // Mund te shtojm te gjith ato gjera qe ne duam te bejm update 

        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string UserName { get; set; }

    }
}
