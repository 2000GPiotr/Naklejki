using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    public class DocumentType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Symbol { get; set; }
        public string Description { get; set; }

        //Relations
        public List<DocumentHeader> DocumentHeaders = new List<DocumentHeader>();
    }
}
