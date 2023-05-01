using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;

namespace ADONET
{
	public class HelperSQL
	{
        public SqlConnection connection { get; set; }
        public HelperSQL()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost";   // update me
            builder.UserID = "sa";              // update me
            builder.Password = "reallyStrongPwd123";      // update me
            builder.InitialCatalog = "Adonet";

            connection = new SqlConnection(builder.ConnectionString);
        }

        public void AddArtists(string name,string surname,DateOnly birthday, string gender)
        {
            string com = $"INSERT INTO Artists VALUES('{name}','{surname}','{birthday}','{gender}')";
            GetCheckConnect(GetConnect(com));
        }

        public void AddMusics(string name, TimeOnly duration, int catId)
        {
            string com = $"INSERT INTO Musics VALUES('{name}','{duration}','{catId}')";
            GetCheckConnect(GetConnect(com));
        }

        public DataTable ExecuteQuery(string query)
        {
            connection.Open();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            connection.Close();

            return table;

        }

        public int GetConnect(string com)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(com, connection);
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;
        }
        public void GetCheckConnect(int result)
        {  
            if (result > 0)
            {
                Console.WriteLine("ugurlu netice");
            }
            else
            {
                Console.WriteLine("problem yarandi");
            }
        }


    }
}

