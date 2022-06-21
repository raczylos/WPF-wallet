using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wallet_project_WPF {
    public class Wallet {
        public int WalletId { get; set; }
        public string WalletName { get; set; }
        public double Balance { get; set; }

        public int UserOwnerId { get; set; }
        public virtual User UserOwner { get; set; }
        public virtual ICollection<Transaction>? Transactions { get; set; }
            = new ObservableCollection<Transaction>();

    }
}
