using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wallet_project_WPF
{
    public class Transation
    {
        public string title { get; set; }
        public int price { get; set; }

        public string category { get; set; }

        public Transation(string title, int price, string category)
        {
            this.title = title;
            this.price = price;
            this.category = category;
        }

       
    }
}
