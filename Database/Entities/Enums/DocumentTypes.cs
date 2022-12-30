using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities.Enums
{
    public enum DocumentTypes
    {
        [Description("Przyjęcie na stan")]
        Przyjecie,

        [Description("Wydanie pracownikowi")]
        Wydanie,
        
        [Description("Rozliczenie zuzycia od pracownika")]
        Rozliczenie,
        
        [Description("Likwidacja ze stanu stan")]
        Likwidacja 
    }
}
