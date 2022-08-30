using System.ComponentModel.DataAnnotations;

namespace BadAssDogTreats_Website.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Created")]
        public DateTime CreationDate { get; set; }
        [DataType(dataType:DataType.MultilineText)]
        public string Details { get; set; }
        public float Cost { get; set; }
        public bool Completed { get; set; }
#nullable enable
        [Display(Name = "Completion Notes")]
        [DataType(dataType: DataType.MultilineText)]
        public string? CompletionNotes { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Due Date")]
        public DateTime? DueDate { get; set; }
#nullable disable


    }
}
