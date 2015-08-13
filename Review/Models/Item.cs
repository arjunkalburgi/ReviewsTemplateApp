using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Review.Models
{
    public class Item
    {
        public int ID { get; set; }


        [Required]
        [StringLength(50, ErrorMessage = "The title cannot be longer than 50 characters.")]
        [Column("ItemName")]
        public string Title { get; set; }

        public virtual ICollection<Itemreview> Itemreviews { get; set; }
    }
}
