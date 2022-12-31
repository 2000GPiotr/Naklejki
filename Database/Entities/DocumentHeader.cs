using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class DocumentHeader
    {
        [Key]
        public int Id { get; set; }
        public Enums.DocumentTypes DocumentType { get; set; }
        public int Year { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;

        //Relations 
        public User User { get; set; }
        public int UserId { get; set; }
        public List<Items> Items { get; set; } = new List<Items>();
    }
}
