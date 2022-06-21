using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wallet_project_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window
    {
        Transation[] transations = new Transation[]
        {
            new Transation("test1", 100, "kredyt"),
            new Transation("test2", 200, "produkty spozywcze")
        };

        public HistoryWindow()
        {
            InitializeComponent();

            transactionList.ItemsSource = transations;
            //categoryComboBox.ItemsSource = new string[] { "Title", "Price", "Category" };
            //categoryComboBox.ItemsSource = typeof(Transation).GetProperties().Select((k) => k.Name);
            List<String> list = new List<String>();
            list.Add("");
            foreach (Transation transation in transations)
            {

                list.Add(transation.category);
                
            }
            categoryComboBox.ItemsSource = list;

            

        }

       
        

        private bool MyFilter(object obj)
        {
            //MessageBox.Show("robie filtr");
            var filterObj = obj as Transation;
            var text = categoryComboBox.SelectedItem.ToString();


            var selectedCategory = categoryComboBox.SelectedItem.ToString();
            var selectedPriceFrom = priceFrom.Text;
            var selectedPriceTo = priceTo.Text;

            //return filterObj.category.Contains(categoryComboBox.Text);

            if (selectedCategory == "" && selectedPriceFrom == "" && selectedPriceTo == "")
            {
                return true;
            }

            if(selectedPriceFrom == "")
            {
                selectedPriceFrom = "0";
            }

            if (selectedPriceTo == "")
            {
                selectedPriceTo = "2147483647";
            }


            if (filterObj.category.Contains(selectedCategory) && (filterObj.price > Convert.ToInt32(selectedPriceFrom)) && (filterObj.price < Convert.ToInt32(selectedPriceTo)))
            {
                return true;
            }
            


            return false;
        }

        private bool TransactionFilter(object item)
        {

            return true;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CategoriesChanged(object sender, SelectionChangedEventArgs e)
        {
            
            transactionList.Items.Filter = MyFilter;
            //categoryComboBox.ItemsSource



        }

        private void priceFrom_TextChanged(object sender, TextChangedEventArgs e)
        {
            transactionList.Items.Filter = MyFilter;
        }

        private void priceTo_TextChanged(object sender, TextChangedEventArgs e)
        {
            transactionList.Items.Filter = MyFilter;
        }
    }
}
