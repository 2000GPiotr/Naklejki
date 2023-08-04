using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class LabelStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Symbol { get; set; }
        public string? Description { get; set; }

        // Relations
        public List<RegistryItem> Registries { get; set; } = new List<RegistryItem>();
    }
}

//        Dostepna,
//        Wydana,
//        Zuzyta,
//        Zniszczona,
//        Zwrocona