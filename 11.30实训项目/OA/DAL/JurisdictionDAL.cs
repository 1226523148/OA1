using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class JurisdictionDAL
    {
        /// <summary>
        /// 新增方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(Model.JurisdictionModel model)
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("insert into Jurisdiction (JueisName,RoleIds)");
            strSQL.Append("values (@JueisName,@RoleIds)");
            SqlParameter[] parameters = {
                   new SqlParameter("@JueisName",SqlDbType.VarChar,50),
                   new SqlParameter("@RoleIds",SqlDbType.VarChar,200)

            };
            parameters[0].Value = model.JueisName;
            parameters[1].Value = model.RoleIds;
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
            strSQL.Append("select id,JueisName,RoleIds from Jurisdiction");
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
        public Model.JurisdictionModel DataRowToModel(DataRow dr)
        {
            Model.JurisdictionModel model = new Model.JurisdictionModel();
            if (dr != null)
            {
                model.Id = Convert.ToInt32(dr["Id"].ToString());
                model.JueisName = dr["JueisName"].ToString();
                model.RoleIds = dr["RoleIds"].ToString();
            }
            return model;
        }
        /// <summary>
        /// 根据ID获取对象;
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Model.JurisdictionModel GetModel(int Id)
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("select id,JueisName,RoleIds from Jurisdiction");
            strSQL.Append(" where id=@id");
            SqlParameter[] parameter = {
            new SqlParameter("@id",SqlDbType.Int)
            };
            parameter[0].Value = Id;
            DataSet ds = DbHelperSQL.Query(strSQL.ToString(), parameter);
            Model.JurisdictionModel tempModel = new Model.JurisdictionModel();
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
            strSQL.Append("delete from Jurisdiction where id=@id");
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

        public bool Update(Model.JurisdictionModel model)
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Append("update Jurisdiction set JueisName=@JueisName,RoleIds=@RoleIds where id=@id");
            SqlParameter[] parameters = {
                   new SqlParameter("@JueisName",SqlDbType.VarChar,20),
                   new SqlParameter("@RoleIds",SqlDbType.VarChar,20),
                   new SqlParameter("@id",SqlDbType.Int)

            };
            parameters[0].Value = model.JueisName;
            parameters[1].Value = model.RoleIds;
            parameters[2].Value = model.Id;
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

    }
}
