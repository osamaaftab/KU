using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBContext.Data
{
    public partial class Account
    {
        public Account()
        {
            Transactions = new HashSet<Transaction>();
        }

        [Key]
        [Column("account_id")]
        public Guid AccountId { get; set; }
        [Column("customer_id")]
        public Guid CustomerId { get; set; }
        [Column("account_name")]
        [StringLength(10)]
        public string AccountName { get; set; } = null!;
        [Column("date_opned", TypeName = "datetime")]
        public DateTime DateOpned { get; set; }
        [Column("date_closed", TypeName = "datetime")]
        public DateTime? DateClosed { get; set; }
        [Column("current_balance", TypeName = "decimal(18, 0)")]
        public decimal? CurrentBalance { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Accounts")]
        public virtual Customer Customer { get; set; } = null!;
        [InverseProperty(nameof(Transaction.Account))]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
