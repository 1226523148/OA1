using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 角色
    /// </summary>
    public class JurisdictionModel
    {
        int _id = 0;
        string _jueisName = "";
        string _roleIds = "";
        public int Id { get => _id; set => _id = value; }
        public string JueisName { get => _jueisName; set => _jueisName = value; }
        public string RoleIds { get => _roleIds; set => _roleIds = value; }
    }
}
