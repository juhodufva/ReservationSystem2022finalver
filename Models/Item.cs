﻿using System.ComponentModel.DataAnnotations;

namespace ReservationSystem2022.Models
{
    public class Item
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public String? Description { get; set; }
        public string? Owner { get; set; }
        public virtual List<Image> Images { get; set; }
        public long accessCount { get; set; } //sisäinen kenttä 

    }
    public class ItemDTO
    {
        public long Id { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public String Name { get; set; }
        public String? Description { get; set; }
        [Required]
        public string Owner { get; set; }

        public virtual List<ImageDTO>? Images { get; set; }

    }
}
