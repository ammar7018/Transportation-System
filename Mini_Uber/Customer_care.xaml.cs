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
    /// Interaction logic for Customer_care.xaml
    /// </summary>
    public partial class Customer_care : Window
    {
        Ticket ticket;
        DbProxy database;
        User user;
        Driver driver;
        public Customer_care(User u, Driver d)
        {
            database = DbProxy.GetDB();
            InitializeComponent();
            confirm_btn.Click += Confirm_btn_Click;
            ticket = new Ticket();
            ticket.Ticket_ID = database.GetTicketID();
            user = u;
            driver = d;
        }

        private void Confirm_btn_Click(object sender, RoutedEventArgs e)
        {

            Fare fare = new Fare();
            vehicle_unsafe vehicle_Unsafe = new vehicle_unsafe();
            Wallet wallet = new Wallet();
            Sleepy sleepy = new Sleepy();

            ticket.Driver_ssn = driver.SSN;
            ticket.Problem_def = problem_def_txt.Text;
            ticket.Status = "Pending";
            ticket.Type = comb.Text.ToString();
            ticket.User_name = user.Username;
            

            fare.set_next(vehicle_Unsafe);
            vehicle_Unsafe.set_next(sleepy);
            sleepy.set_next(wallet);
            fare.handle_request(ticket);
            MessageBox.Show("We Recived your problem");
            this.Close();
            
            
        }
    }
}
