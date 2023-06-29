using System.ComponentModel.DataAnnotations;

namespace Database.Entities
{
    public class DocumentHeader
    {
        [Key]
        public int Id { get; set; }
        public int Year { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public int? UserId { get; set; }
        public string DocumentTypeId { get; set; }

        //Relations 
        public User? User { get; set; }
        public DocumentType DocumentType { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
    }
}
