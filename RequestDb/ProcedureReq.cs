using DAL;
using ET;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RequestDb
{
    public class ProcedureReq
    {
        private AccesDb acces = new AccesDb();

        public List<UserET> List()
        {
            DataTable table = acces.Read("Select * from usuario", null);
            List<UserET> userL = new List<UserET>();
            foreach (DataRow row in table.Rows)
            {
                UserET user = new UserET()
                {
                    id = Convert.ToInt32(row["id"]),
                    nombre = row["nombre"].ToString(),
                    email = row["email"].ToString(),
                    password = row["password"].ToString(),
                    idRol = Convert.ToInt32(row["idRol"])
                };
                userL.Add(user);
            }
            return userL;
        }
        public bool Login(string nombre , string password)
        {

            List<SqlParameter> parameter = new List<SqlParameter>();
            parameter.Add(acces.NewSqlParameterString("@name", nombre));
            parameter.Add(acces.NewSqlParameterString("@pass", password));

            SqlDataReader read = acces.LogIn("sp_Login", parameter);
            if (read.HasRows)
            {
                while (read.Read())
                {
                    UserET user = new UserET();

                    //user.id = read.GetInt32(0);
                    user.nombre = read.GetString(0);
                    //user.email = read.GetString(2);
                    user.password = read.GetString(1);
                    //user.idRol = read.GetInt32(4);

                }
                return true;
            }
            else
            {
                return false;
            }
            //DataTable table = acces.Read("sp_Login", parameter);
            ////if(table.Rows.Count > 0)
            ////{
            ////    if(table.Rows[0][1].ToString() == "Admin")
            ////    {
            ////        HttpContext.Current.Response.Redirect("AdminForm.aspx");

            ////    }else if (table.Rows[0][1].ToString() == "Student")
            ////    {
            ////        HttpContext.Current.Response.Redirect("StudentForm.aspx");
            ////    }
            ////}


        }
        //private ET.UserET Model(string nombre, string password)
        //{
        //    ET.UserET user = new ET.UserET();

        //    user.nombre = nombre;
        //    user.password = password;

        //    return user;

        //}
       
    }
}
