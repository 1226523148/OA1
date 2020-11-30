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
    public class StudentDAL
    {
        /// <summary>
        /// 新增方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(Model.StudentModel model)
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("insert into student (name,classNumber,age,sex,phoneNumber,id_Card,adress,roleId,userType,password)");
            strSQL.Append("values (@name,@classNumber,@age,@sex,@phoneNumber,@id_Card,@adress,@roleId,@userType,@password)");
            SqlParameter[] parameters = {
                   new SqlParameter("@name",SqlDbType.VarChar,20),
                   new SqlParameter("@classNumber",SqlDbType.VarChar,20),
                   new SqlParameter("@age",SqlDbType.VarChar,5),
                   new SqlParameter("@sex",SqlDbType.VarChar,5),
                   new SqlParameter("@phoneNumber",SqlDbType.VarChar,18),
                   new SqlParameter("@id_Card",SqlDbType.VarChar,18),
                   new SqlParameter("@adress",SqlDbType.VarChar,200),
                   new SqlParameter("@roleId",SqlDbType.VarChar,5),
                   new SqlParameter("@userType",SqlDbType.VarChar,5),
                    new SqlParameter("@password",SqlDbType.VarChar,50)
            };
            parameters[0].Value = model.Name;
            parameters[1].Value = model.ClassNumber;
            parameters[2].Value = model.Adress;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.PhoneNumber;
            parameters[5].Value = model.Id_Card;
            parameters[6].Value = model.Adress;
            parameters[7].Value = model.RoleId;
            parameters[8].Value = model.UserType;
            parameters[9].Value = model.PassWord;

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
            strSQL.Append("select id,name,classNumber,age,sex,ID_card,phoneNumber,adress,roleId,Usertype,password from student");
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
        public Model.StudentModel DataRowToModel(DataRow dr)
        {
            Model.StudentModel model = new Model.StudentModel();
            if (dr != null)
            {
                model.Id = Convert.ToInt32(dr["Id"].ToString());
                model.Adress = dr["Adress"].ToString();
                model.Age = dr["Age"].ToString();
                model.ClassNumber = dr["classNumber"].ToString();
                model.Id_Card = dr["Id_Card"].ToString();
                model.Name = dr["Name"].ToString();
                model.PhoneNumber = dr["PhoneNumber"].ToString();
                model.RoleId = dr["RoleId"].ToString();
                model.UserType = dr["UserType"].ToString();
                model.PassWord = dr["PassWord"].ToString();
            }
            return model;
        }
        /// <summary>
        /// 根据ID获取对象;
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Model.StudentModel GetModel(int Id)
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("select id,name,classNumber,age,sex,ID_card,phoneNumber,adress,roleId,Usertype,PassWord from student");
            strSQL.Append(" where id=@id");
            SqlParameter[] parameter = {
            new SqlParameter("@id",SqlDbType.Int)
            };
            parameter[0].Value = Id;
            DataSet ds = DbHelperSQL.Query(strSQL.ToString(), parameter);
            Model.StudentModel tempModel = new Model.StudentModel();
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
            strSQL.Append("delete from student where id=@id");
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

        public bool Update(Model.StudentModel model)
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("update student set name=@name,classNumber=@classNumber,age=@age,sex=@sex,@phoneNumber=@phoneNumber,id_Card=@id_Card,adress=@adress,roleId=@roleid,userType=@userType,password=@PassWord where id=@id");
            SqlParameter[] parameters = {
                   new SqlParameter("@name",SqlDbType.VarChar,20),
                   new SqlParameter("@classNumber",SqlDbType.VarChar,20),
                   new SqlParameter("@age",SqlDbType.VarChar,5),
                   new SqlParameter("@sex",SqlDbType.VarChar,5),
                   new SqlParameter("@phoneNumber",SqlDbType.VarChar,18),
                   new SqlParameter("@id_Card",SqlDbType.VarChar,18),
                   new SqlParameter("@adress",SqlDbType.VarChar,200),
                   new SqlParameter("@roleId",SqlDbType.VarChar,5),
                   new SqlParameter("@userType",SqlDbType.VarChar,5),
                    new SqlParameter("@password",SqlDbType.VarChar,50),
                   new SqlParameter("@id",SqlDbType.Int)
            };
            parameters[0].Value = model.Name;
            parameters[1].Value = model.ClassNumber;
            parameters[2].Value = model.Adress;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.PhoneNumber;
            parameters[5].Value = model.Id_Card;
            parameters[6].Value = model.Adress;
            parameters[7].Value = model.RoleId;
            parameters[8].Value = model.UserType;
            parameters[9].Value = model.PassWord;
            parameters[10].Value = model.Id;
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
        public Model.StudentModel GetModel(string ClassNumber)
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
