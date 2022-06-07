using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wallet_project_WPF {

    [Index(nameof(Name), IsUnique=true)]
    public class User {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set;}

        public virtual ICollection<Wallet>? Wallets { get; set; }
            = new ObservableCollection<Wallet>();

    }
}
