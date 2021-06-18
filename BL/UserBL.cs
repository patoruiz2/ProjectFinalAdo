using ET;
using RequestDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UserBL
    {
        private ProcedureReq request = new ProcedureReq();

        public List<UserET> List()
        {
            return request.List();
        }

        public bool Login(string nombre, string password)
        {
            return request.Login( nombre, password);
        }
    }
}
