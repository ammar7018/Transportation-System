using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using MiniUber;

namespace Mini_Uber
{
    public abstract class DataBase
    {
        protected string connstring = "Data Source=MOHAMED-SAMY10\\SS01;Initial Catalog=mini_uber;Integrated Security=True";

        public abstract User GetUser(string UserName);
        public abstract List<Driver> GetDrivers();
        public abstract void InsertUser(User user);
        public abstract void InsertRide(string ride);

        public abstract Dictionary<string, int> GetCities();

        public abstract void InsertTicket(Ticket t);
        public abstract int[,]  GetDestinations( int [,] Distances);

        public abstract void InsertCredit(User user);

        public abstract int GetTicketID();

        public abstract Vehicle GetCarsDetails(Driver driver);
        










    }
}
