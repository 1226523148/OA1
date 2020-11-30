using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RoleModel
    {
        int _id = 0;
        string _roleName = "";
        string _url = "";

        public int Id { get => _id; set => _id = value; }
        public string RoleName { get => _roleName; set => _roleName = value; }
        public string Url { get => _url; set => _url = value; }
    }
}
