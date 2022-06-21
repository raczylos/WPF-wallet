using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wallet_project_WPF {
    public class Category {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Transaction>? Transactions { get; set; }
            = new ObservableCollection<Transaction>();

    }
}
