using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wallet_project_WPF {
    public class User {
        public int UserId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Wallet>? Wallets { get; set; }
            = new ObservableCollection<Wallet>();

    }
}
