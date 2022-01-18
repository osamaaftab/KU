using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBContext.Data
{
    public partial class Address
    {
        [Key]
        [Column("address_id")]
        public Guid AddressId { get; set; }
        [Column("line_1")]
        [StringLength(50)]
        public string Line1 { get; set; } = null!;
        [Column("line_2")]
        [StringLength(50)]
        public string Line2 { get; set; } = null!;
        [Column("city")]
        [StringLength(10)]
        public string? City { get; set; }
        [Column("post_code")]
        [StringLength(10)]
        public string? PostCode { get; set; }
        [Column("state")]
        [StringLength(10)]
        public string? State { get; set; }
        [Column("country")]
        [StringLength(10)]
        public string? Country { get; set; }
        [Column("customer_id")]
        public Guid CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Addresses")]
        public virtual Customer Customer { get; set; } = null!;
    }
}
