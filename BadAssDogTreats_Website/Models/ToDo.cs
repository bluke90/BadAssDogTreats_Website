namespace BadAssDogTreats_Website.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public bool Completed { get; set; }
        public float Cost { get; set; }
#nullable enable
        public DateTime? DueDate { get; set; }
#nullable disable


    }
}
