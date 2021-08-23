using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Review
    {
        public int Id { get; set; }
        public decimal Rating { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }
        public int RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual User User { get; set; }
    }
}
