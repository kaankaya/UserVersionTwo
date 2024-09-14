namespace UserVersionTwo.Entities
{
    public class UserEntity
    {
        public UserEntity()
        {
            CreatedAt = DateTime.Now;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string Role { get; set; }
        public bool IsLogin { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
