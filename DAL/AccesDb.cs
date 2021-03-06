using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET;


namespace DAL
{
    public class AccesDb
    {
        private SqlConnection connect = new SqlConnection();

        private void Open()
        {
            string cs = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            connect.ConnectionString = cs;
            connect.Open();
        }
        private void Close()
        {
            connect.Close();
            
        }

        public DataTable Read(string procedure , List<SqlParameter> parameters = null)
        {
            Open();

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.SelectCommand = NewSqlCommand(procedure, parameters);
            adapter.Fill(table);

            Close();
            return table;
        }
        //public SqlDataReader Reader(string procedure, List<SqlParameter> parameters = null, SqlDataReader reader = null)
        //{
        //    Open();
        //    SqlCommand command = NewSqlCommand(procedure, parameters);
        //    reader = command.ExecuteReader();
        //    Close();
        //    return reader;
        //}

        public SqlParameter NewSqlParameterString(string nameParam , string value)
        {
            SqlParameter param = new SqlParameter();

            param.ParameterName = nameParam;
            param.Value = value;
            param.DbType = DbType.String;

            return param;
            

        }

        public SqlParameter NewSqlParameterInt(string nameParam, int value)
        {
            SqlParameter param = new SqlParameter();

            param.ParameterName = nameParam;
            param.Value = value;
            param.DbType = DbType.Int32;

            return param;


        }

        private SqlCommand NewSqlCommand(string procedure , List<SqlParameter> Lparam = null)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connect;
            command.CommandText = procedure;
            command.CommandType = CommandType.StoredProcedure;
            //if(reader != null)
            //{
            //    reader = command.ExecuteReader();
            //}

            if (Lparam.Any())
            {
                command.Parameters.AddRange(Lparam.ToArray());
            }
            return command;
        }

        public SqlDataReader LogIn(string procedure, List<SqlParameter> parameters)
        {
            
            SqlCommand command = NewSqlCommand(procedure, parameters);
            Open();
            SqlDataReader reader = command.ExecuteReader();
            
            return reader;


        }

        //public void ExecuteQuery(string procedure , List<SqlParameter> parameters)
        //{
            
        //    //Open();
            

        //    //Close();
            
        //}



        //public UserET Seed()
        //{
        //    var query = NewSqlCommand("Select * From usuario");
        //    Open();

        //    SqlDataReader read = query.ExecuteReader();
        //    var anyRow = read.HasRows;
        //    if ( anyRow == false)
        //    {
        //        return new UserET
        //        {
        //            Nombre = "Admin",
        //            Email = "admin@gmail.com",
        //            Password = "admin",

        //        }
        //    }
        //}
    }
}
