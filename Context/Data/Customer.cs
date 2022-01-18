using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBContext.Data
{
    public partial class Customer
    {
        public Customer()
        {
            Accounts = new HashSet<Account>();
            Addresses = new HashSet<Address>();
        }

        [Key]
        [Column("customer_id")]
        public Guid CustomerId { get; set; }
        [Column("customer_name")]
        [StringLength(50)]
        public string CustomerName { get; set; } = null!;
        [Column("customer_phone")]
        [StringLength(10)]
        public string? CustomerPhone { get; set; }
        [Column("customer_email")]
        [StringLength(50)]
        public string? CustomerEmail { get; set; }
        [Column("customer_dob")]
        [StringLength(10)]
        public string? CustomerDob { get; set; }

        [InverseProperty(nameof(Account.Customer))]
        public virtual ICollection<Account> Accounts { get; set; }
        [InverseProperty(nameof(Address.Customer))]
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
