using System;

using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ApplicationLayer
{


    public class DatabaseController
    {
        

        //------------------------------------------------------ Appendix -----------------------------------------------------//
        private string ConnectionString = "Server=EALSQL1.eal.local; Database=B_DB17_2018; User Id=B_STUDENT17; Password=B_OPENDB17;";



        //------------------------------------------------------ Expenditure -------------------------------------------------//

        public void GetExpenditureByTravel()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("GetExpenditureByTravel", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@travel", travel.Id));

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = int.Parse(reader["id"].ToString());
                        string title = reader["title"].ToString();
                        int expenseType = int.Parse(reader["expensetype"].ToString());
                        bool cash = bool.Parse(reader["cash"].ToString());
                        DateTime date = DateTime.Parse(reader["date"].ToString());
                        double amount = float.Parse(reader["amount"].ToString());
                        driving.Add(new Expenditure(title, date, amount, (Type)expenseType, cash, travel));
                    }
                }
            }
        }

    }

        public override void Save()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("insert_expenditure_appendix", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@title", Title);
                command.Parameters.AddWithValue("@expensetype", expenseType);
                command.Parameters.AddWithValue("@cash", cash);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@amount", amount);
                command.Parameters.AddWithValue("@travel", travel.Id);

                command.ExecuteNonQuery();
            }
        }


        //----------------------------------------------------------- Driving ----------------------------------------------//
        public override void Save()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("insert_driving_compensation", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@title", Title);
                command.Parameters.AddWithValue("@employee", Employee.Id);
                command.Parameters.AddWithValue("@numberplate", NumberPlate);

                Id = Convert.ToInt32(command.ExecuteScalar());
            }
            appendices.ForEach(o => o.Save());
        }


        //--------------------------------------------------------- Travel ---------------------------------------------------//

        internal static List<Travel> GetTravelByEmployee(Employee employee)
        {
            List<Travel> travels = new List<Travel>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("GetTravelById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@employee", employee.Id));

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = int.Parse(reader["id"].ToString());
                        string title = reader["title"].ToString();
                        DateTime departureDate = DateTime.Parse(reader["departuredate"].ToString());
                        DateTime returnDate = DateTime.Parse(reader["returndate"].ToString());
                        bool overNightStay = bool.Parse(reader["overnightstay"].ToString());
                        double credit = float.Parse(reader["credit"].ToString());

                        Travel travel = new Travel(title, employee, departureDate, returnDate, overNightStay, credit);
                        travel.Id = id;
                        travels.Add(travel);
                    }
                }
            }
            return travels;
        }

        public override void Save()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("insert_travel_compensation", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@title", Title);
                command.Parameters.AddWithValue("@employee", Employee.Id);
                command.Parameters.AddWithValue("@departuredate", DepartureDate);
                command.Parameters.AddWithValue("@returndate", ReturnDate);
                command.Parameters.AddWithValue("@overnightstay", OverNightStay);
                command.Parameters.AddWithValue("@credit", Credit);

                Id = Convert.ToInt32(command.ExecuteScalar());
            }
            appendices.ForEach(o => o.Save());
        }


        //----------------------------------------------------------- Employee ---------------------------------------------//

        internal static Employee GetEmployeeById(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("GetEmployeeById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@id", id));

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    string fullname = reader["fullname"].ToString();
                    int department = int.Parse(reader["department"].ToString());
                    return new Employee(id, fullname, department);
                }
                else
                {
                    throw new EntryPointNotFoundException();
                }
            }
        }



        //------------------------------------------------------- Trip -----------------------------------------------------//
        public override void Save()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("insert_trip_appendix", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@title", Title);
                command.Parameters.AddWithValue("@departuredestination", DepartureDestination);
                command.Parameters.AddWithValue("@departuredate", DepartureDate);
                command.Parameters.AddWithValue("@arrivaldestination", ArrivalDestination);
                command.Parameters.AddWithValue("@arrivaldate", ArrivalDate);
                command.Parameters.AddWithValue("@distance", Distance);
                command.Parameters.AddWithValue("@driving", driving.Id);

                command.ExecuteNonQuery();
            }
        }
    }
}
