using Design_Pattern;
using MiniUber;
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
using System.Windows.Shapes;

namespace Mini_Uber
{
    /// <summary>
    /// Interaction logic for CreditCardPage.xaml
    /// </summary>
    public partial class CreditCardPage : Window
    {
        DbProxy database;
        User user;
        RidePrice ride;
        public CreditCardPage(User u, RidePrice r)
        {
            user = u;
            ride = r;
            database = DbProxy.GetDB();
            InitializeComponent();
            confirm_btn.Click += Confirm_btn_Click;
        }

        private void Confirm_btn_Click(object sender, RoutedEventArgs e)
        {
            user.Card.CardNumber = number_txt.Text;
            user.Card.CVV= cvv_txt.Text;
            database.InsertCredit(user);
            var page = new Searching(user,ride);
            page.Show();
            this.Close();
            
        }
    }
}
