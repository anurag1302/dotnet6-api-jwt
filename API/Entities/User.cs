namespace API.Entities
{
    public class User
    {
        public User()
        {
            RefreshTokens = new HashSet<RefreshToken>();
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
