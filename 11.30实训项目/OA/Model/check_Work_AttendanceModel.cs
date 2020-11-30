using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class check_Work_AttendanceModel
    {
        public readonly object Ssick_Leaveex;
        int _id = 0;
        string _UserId = "";
        string _Attendance_time = "";
        string _work_Overtime = "";
        string _sick_Leave = "";
        string _compassionate_Leave = "";
        string _State = "";
        /// <summary>
        /// 标识列
        /// </summary>
        public int Id { get => _id; set => _id = value; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId { get => _UserId; set => _UserId = value; }
        /// <summary>
        /// 打卡时间
        /// </summary>
        public string Attendance_time { get => _Attendance_time; set => _Attendance_time = value; }
        /// <summary>
        /// 是否加班列
        /// </summary>
        public string Work_Overtime { get => _work_Overtime; set => _work_Overtime = value; }
        /// <summary>
        /// 病假
        /// </summary>
        public string Sick_Leave { get => _sick_Leave; set => _sick_Leave = value; }
        /// <summary>
        /// 事假
        /// </summary>
        public string Compassionate_Leave { get => _compassionate_Leave; set => _compassionate_Leave = value; }
        /// <summary>
        /// 状态
        /// </summary>
        public string State { get => _State; set => _State = value; }
    }
}
