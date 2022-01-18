using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBContext.Data
{
    public partial class Transaction
    {
        [Key]
        [Column("transaction_id")]
        public Guid TransactionId { get; set; }
        [Column("account_id")]
        public Guid AccountId { get; set; }
        [Column("date_of_transaction", TypeName = "datetime")]
        public DateTime DateOfTransaction { get; set; }
        [Column("amount", TypeName = "decimal(18, 0)")]
        public decimal Amount { get; set; }
        [Column("balance", TypeName = "decimal(18, 0)")]
        public decimal? Balance { get; set; }
        [Column("transaction_type_id")]
        public Guid? TransactionTypeId { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("Transactions")]
        public virtual Account Account { get; set; } = null!;
        [ForeignKey(nameof(TransactionTypeId))]
        [InverseProperty("Transactions")]
        public virtual TransactionType? TransactionType { get; set; }
    }
}
