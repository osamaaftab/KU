using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBContext.Data
{
    [Table("Transaction_types")]
    public partial class TransactionType
    {
        public TransactionType()
        {
            Transactions = new HashSet<Transaction>();
        }

        [Key]
        [Column("transaction_type_id")]
        public Guid TransactionTypeId { get; set; }
        [Column("transaction_code")]
        [StringLength(10)]
        public string TransactionCode { get; set; } = null!;
        [Column("transaction_label")]
        [StringLength(10)]
        public string TransactionLabel { get; set; } = null!;

        [InverseProperty(nameof(Transaction.TransactionType))]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
