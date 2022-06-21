using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wallet_project_WPF {
    public class Transaction {
        public int TransactionId { get; set; }
        public double? MoneyAmount { get; set; }
        public bool? isIncoming { get; set; } // incoming: ++money | outgoing: --money
        public bool? isCycle { get; set; } // transaction repeats every month
        public DateTime? date { get; set; } // day of the month
        public virtual Category? Category { get; set; }
        public virtual Wallet? Wallet { get; set; }
    }
}
