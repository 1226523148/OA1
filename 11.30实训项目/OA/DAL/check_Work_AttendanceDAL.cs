using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Maticsoft.DBUtility;

namespace DAL
{
   public class check_Work_AttendanceDAL
    {
        /// <summary>
        /// 新增方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(Model.check_Work_AttendanceModel model)
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("insert into check_Work_Attendance (UserId,Attendance_time,work_Overtime,sick_Leave,compassionate_Leave,State)");
            strSQL.Append("values (@UserId,@Attendance_time,@work_Overtime,@sick_Leave,@compassionate_Leave,@State)");
            SqlParameter[] parameters = {
                   new SqlParameter("@UserId",SqlDbType.VarChar,20),
                   new SqlParameter("@Attendance_time",SqlDbType.DateTime),
                   new SqlParameter("@work_Overtime",SqlDbType.VarChar,2),
                   new SqlParameter("@sick_Leave",SqlDbType.Text),
                   new SqlParameter("@compassionate_Leave",SqlDbType.Text),
                   new SqlParameter("@State",SqlDbType.VarChar,20),
            };
            parameters[0].Value = model.UserId;
            parameters[1].Value = model.Attendance_time;
            parameters[2].Value = model.Work_Overtime;
            parameters[3].Value = model.Ssick_Leaveex;
            parameters[4].Value = model.Compassionate_Leave;
            parameters[5].Value = model.State;

            int row = Maticsoft.DBUtility.DbHelperSQL.ExecuteSql(strSQL.ToString(), parameters);
            if (row > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataSet GetList(string where)
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("select id,UserId,Attendance_time,Work_Overtime,Ssick_Leaveex,Compassionate_Leave,State from check_Work_Attendance");
            if (where != "")
            {
                strSQL.Append(" where ");
                strSQL.Append(where);
            }
            return DbHelperSQL.Query(strSQL.ToString());
        }
        /// <summary>
        /// 将行数据转换成对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public Model.check_Work_AttendanceModel DataRowToModel(DataRow dr)
        {
            Model.check_Work_AttendanceModel model = new Model.check_Work_AttendanceModel();
            if (dr != null)
            {
                model.Id = Convert.ToInt32(dr["Id"].ToString());
                model.UserId = dr["UserId"].ToString();
                model.Attendance_time = dr["Attendance_time"].ToString();
                model.Work_Overtime = dr["Work_Overtime"].ToString();
                model.Sick_Leave = dr["Ssick_Leaveex"].ToString();
                model.Compassionate_Leave = dr["Compassionate_Leave"].ToString();
                model.State = dr["State"].ToString();
            }
            return model;
        }
        /// <summary>
        /// 根据ID获取对象;
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Model.check_Work_AttendanceModel GetModel(int Id)
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("select id,UserId,Attendance_time,Work_Overtime,Sick_Leave,Compassionate_Leave,State from check_Work_Attendance");
            strSQL.Append(" where id=@id");
            SqlParameter[] parameter = {
            new SqlParameter("@id",SqlDbType.Int)
            };
            parameter[0].Value = Id;
            DataSet ds = DbHelperSQL.Query(strSQL.ToString(), parameter);
            Model.check_Work_AttendanceModel tempModel = new Model.check_Work_AttendanceModel();
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    tempModel = DataRowToModel(item);
                }
            }
            return tempModel;
        }
        /// <summary>
        /// 根据ID删除某数据
        /// </summary>
        /// <param name="Id">ID</param>
        /// <returns></returns>
        public bool Delete(int Id)
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("delete from check_Work_Attendance where id=@id");
            SqlParameter[] parameters = {
            new SqlParameter("@id",SqlDbType.Int)
            };
            parameters[0].Value = Id;
            int rows = DbHelperSQL.ExecuteSql(strSQL.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(Model.check_Work_AttendanceModel model)
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("update check_Work_Attendance set UserId=@UserId,Attendance_time=@Attendance_time," +
                "Work_Overtime=@Work_Overtime,Sick_Leave=@Sick_Leave,Compassionate_Leave=@Compassionate_Leave," +
                "State=@State where id=@id");
            SqlParameter[] parameters = {
                   new SqlParameter("@UserId",SqlDbType.VarChar,20),
                   new SqlParameter("@Attendance_time",SqlDbType.DateTime),
                   new SqlParameter("@work_Overtime",SqlDbType.VarChar,2),
                   new SqlParameter("@sick_Leave",SqlDbType.Text),
                   new SqlParameter("@compassionate_Leave",SqlDbType.Text),
                   new SqlParameter("@State",SqlDbType.VarChar,20),
            };
            parameters[0].Value = model.UserId;
            parameters[1].Value = model.Attendance_time;
            parameters[2].Value = model.Work_Overtime;
            parameters[3].Value = model.Ssick_Leaveex;
            parameters[4].Value = model.Compassionate_Leave;
            parameters[5].Value = model.State;
            int rows = DbHelperSQL.ExecuteSql(strSQL.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 根据学号获取用户对象
        /// </summary>
        /// <param name="ClassNumber"></param>
        /// <returns></returns>
        public Model.check_Work_AttendanceModel GetModel(string ClassNumber)
        {
            DataSet ds = GetList("classNumber='" + ClassNumber + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            return null;
        }
    }
}
}
