using Domain_Layer.Compensations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Appendices
{
    public class Expenditure : Appendix
    {
        public readonly Type expenseType;
        public readonly bool cash;
        public readonly DateTime date;
        public readonly double amount;
        private readonly Travel travel;

        public enum Type
        {
            Messeomkostninger = 54080,
            Transport = 87020,
            Ophold = 87030,
            Fortæring = 87040,
            Diverse = 87050,
            Repræsentaion = 81020,
            Bankkortgebyr = 96440
        }

        public Expenditure(string expenditure_title, DateTime expenditure_date, double expenditure_amount, Type expenditure_type, bool expenditure_cash, Travel expenditure_travel) : base(expenditure_title)
        {
            date = expenditure_date;
            amount = expenditure_amount;
            expenseType = expenditure_type;
            cash = expenditure_cash;
            this.travel = expenditure_travel;
        }

        internal static List<Expenditure> GetExpenditureByTravel(Travel travel)
        {
            List<Expenditure> driving = new List<Expenditure>();
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
            return driving;
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
    }
}
