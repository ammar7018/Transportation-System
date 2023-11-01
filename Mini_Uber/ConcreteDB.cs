using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MiniUber;

namespace Mini_Uber
{
   public class ConcreteDB : DataBase
    {
       private SqlConnection conn;
       private SqlCommand cmd;
        private List<Driver> drivers;
        private Dictionary<string,int> cities;


       public ConcreteDB()
        {
            conn = new SqlConnection(connstring);
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }

        public override Vehicle GetCarsDetails(Driver driver)
        {
            conn.Open();
            cmd.CommandText = "select vehicle.plate_number,model,v_type from vehicle join driver on vehicle.plate_number=@driver.plate_number";
           
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@driver.plate_number", driver.Vehicle.PlateNumber);
            Vehicle vehicle = new Vehicle();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                vehicle.PlateNumber = dr[0].ToString();
                vehicle.Model = dr[1].ToString();
                vehicle.VehicleType = dr[2].ToString();
               
            }

            cmd.Parameters.Clear();
            conn.Close();
            return vehicle;


        }

        public override Dictionary<string,int> GetCities()
        {
            if (cities == null)
            {
                cities = new Dictionary<string, int>();
                conn.Open();

                cmd.CommandText = "select * from cities";
                cmd.CommandType = System.Data.CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cities.Add(dr[1].ToString().ToLower(),Convert.ToInt32(dr[0]));
                }
            }
            cmd.Parameters.Clear();
            conn.Close();
            return cities;

        }

        public override int [,] GetDestinations(int[,] Distances)
        {
            conn.Open();
            cmd.CommandText = "select * from destination";
            cmd.CommandType = System.Data.CommandType.Text;

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Distances[Convert.ToInt32(dr[0]),Convert.ToInt32(dr[1])] = Convert.ToInt32(dr[2]);
            }
            
            cmd.Parameters.Clear();
            conn.Close();
            dr.Close();
            return Distances;
          
        }

        public override List<Driver> GetDrivers()
        {
            
            if (drivers == null)
            {
                drivers = new List<Driver>();

                conn.Open();

                cmd.CommandText = "select * from driver";
                cmd.CommandType = System.Data.CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Driver d = new Driver(dr[1].ToString(),dr[2].ToString(),dr[3].ToString());
                    d.SSN = dr[0].ToString();
                    d.PlateNumber = dr[4].ToString();
                    

                    drivers.Add(d);
                    
                }
            }
            conn.Close();
            return drivers;
            

        }

        public override int GetTicketID()
        {
            conn.Open();
            cmd.CommandText = "select max(ticket_id) from customer_care";
            cmd.CommandType = System.Data.CommandType.Text;

            int mx=Convert.ToInt32 (cmd.ExecuteScalar());

            conn.Close();
                return mx+1;
            

        }

        public override User GetUser(string UserName)
        {
            User u;
            conn.Open();
            cmd.CommandText = "select * from client where user_name = @user";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@user", UserName);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                u= new User(dr[5].ToString(), dr[6].ToString(), dr[2].ToString(), dr[0].ToString(), dr[1].ToString());

                if (dr[3].ToString() != null) {

                    u.Card.CardNumber = dr[3].ToString();
                    u.Card.CVV = dr[4].ToString();
                }
              

                                   
            }
            else
            {
                u= null;
            }
            cmd.Parameters.Clear();
            conn.Close();
            dr.Close();
            return u;
         

        }

        public override void InsertCredit(User user)
        {

            conn.Open();
            cmd.CommandText = "update client set credit_card_number=@number,cvv=@cvv where user_name=@user";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@number", user.Card.CardNumber);
            cmd.Parameters.AddWithValue("@cvv", user.Card.CVV);
            cmd.Parameters.AddWithValue("@user", user.Username);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            conn.Close();

        }

        public override void InsertRide(string ride)
        {
            conn.Open();
            cmd.CommandText = "insert into rides values()";
            cmd.CommandType = System.Data.CommandType.Text;

        }

        public override void InsertTicket(Ticket t)
        {
            conn.Open();
            cmd.CommandText = "insert into customer_care values(@id,@type,@status,@problem_def,@user_name,@driver_ssn)";
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.Parameters.AddWithValue("@id", t.Ticket_ID);
            cmd.Parameters.AddWithValue("@type", t.Type);
            cmd.Parameters.AddWithValue("@status", t.Status);
            cmd.Parameters.AddWithValue("@problem_def", t.Problem_def);
            cmd.Parameters.AddWithValue("@user_name", t.User_name);
            cmd.Parameters.AddWithValue("@driver_ssn", t.Driver_ssn);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            conn.Close();
        }

        public override void InsertUser(User user)
        {
            conn.Open();
            cmd.CommandText = "insert into client values(@user_name,@password,@phone_number,@credit,@cvv,@fname,@lname)";
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.Parameters.AddWithValue("@user_name", user.Username);
            cmd.Parameters.AddWithValue("@password", user.Password);
            cmd.Parameters.AddWithValue("@phone_number", user.PhoneNumber);
            cmd.Parameters.AddWithValue("@credit", "-1");
            cmd.Parameters.AddWithValue("@cvv", "-1");
            cmd.Parameters.AddWithValue("@fname", user.Fname);
            cmd.Parameters.AddWithValue("@lname", user.Lname);
            cmd.ExecuteNonQuery();


            cmd.Parameters.Clear();
            conn.Close();

        }


    }
}
