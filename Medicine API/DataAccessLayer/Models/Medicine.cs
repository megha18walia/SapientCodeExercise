using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class Medicine
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Notes { get; set; }
    }
}
