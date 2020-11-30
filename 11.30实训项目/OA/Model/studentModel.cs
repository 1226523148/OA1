using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StudentModel
    {
        int _id = 0;
        string _name = "";
        string _classNumber = "";
        string _age = "";
        string _sex = "";
        string _phoneNumber = "";
        string _id_Card = "";
        string _adress = "";
        string _roleId = "";
        string _userType = "";
        string _passWord = "123456";
        /// <summary>
        /// ID 标识
        /// </summary>
        public int Id { get => _id; set => _id = value; }
        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get => _name; set => _name = value; }
        public string ClassNumber { get => _classNumber; set => _classNumber = value; }
        public string Age { get => _age; set => _age = value; }
        public string Sex { get => _sex; set => _sex = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public string Adress { get => _adress; set => _adress = value; }
        public string RoleId { get => _roleId; set => _roleId = value; }
        public string UserType { get => _userType; set => _userType = value; }
        public string Id_Card { get => _id_Card; set => _id_Card = value; }
        public string PassWord { get => _passWord; set => _passWord = value; }
    }
}
