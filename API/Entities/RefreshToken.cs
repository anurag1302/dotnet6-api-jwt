namespace API.Entities
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string TokenHash { get; set; }
        public string TokenSalt { get; set; }
        public DateTime TimeStamp { get; set; }
        public DateTime ExpiryDate { get; set; }
        public virtual User User { get; set; }
    }
}
