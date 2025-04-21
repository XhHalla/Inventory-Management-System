namespace UsersAdmin.Models.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string UserName { get; set; }
        public DateTime? Birthday {  get; set; }
        public required Role UserRole{ get; set; }

        public enum Role
        {
            Finance,
            IT,
            ServiceDepartment,
            UniversityStaff,
            ClubCoordinator
        }

    }
}
