﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class LabelType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Symbol { get; set; }
        public string? Description { get; set; }
        public int Count { get; set; }

        //Relations
        public List<Item> Items { get; set; } = new List<Item>();
        public List<RegistryItem> Registries { get; set; } = new List<RegistryItem>();
    }
}
