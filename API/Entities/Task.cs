namespace API.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime Ts { get; set; }

        public virtual User User { get; set; }
    }
}
