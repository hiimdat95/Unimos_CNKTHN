using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace TruongViet.UnimOs.Data
{
    public class cDBase
    {
        public static SqlConnection sqlCn;
        public static SqlTransaction sqlTrans;

        protected string mErrorMessage;
        protected int mErrorNumber;

        public int ErrorNumber
        {
            get
            {
                return mErrorNumber;
            }
        }

        public string ErrorMessages
        {
            get
            {
                return mErrorMessage;
            }
        }

        #region Xu ly Transaction
        public void BeginTransaction()
        {
            sqlTrans = sqlCn.BeginTransaction();
        }

        public void Commit()
        {
            sqlTrans.Commit();
            sqlTrans = null;
        }

        public void RollBack()
        {
            sqlTrans.Rollback();
            sqlTrans = null;
        }
        #endregion

        public string RunQuery(string sqlConnection, string SQL)
        {
            string result = "";
            SqlCommand sqlCmd = new SqlCommand(SQL);
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnection))
                {
                    connection.Open();
                    sqlCmd.Connection = connection;
                    sqlCmd.CommandType = CommandType.Text;

                    sqlCmd.ExecuteNonQuery();
                    result = "TRUE";
                }
            }
            catch (SqlException sqlEx)
            {
                result = "FALSE" + sqlEx.Message;
            }
            finally { }

            sqlCmd.Dispose();
            sqlCmd = null;
            return result;
        }

        protected void RunProcedure(string ProcedureName, ArrayList colParam)
        {
            SqlCommand sqlCmd = new SqlCommand();
            //SqlDataAdapter sqlDA = new SqlDataAdapter();
            try
            {   
                sqlCmd.Connection = sqlCn;
                //sqlDA.SelectCommand = sqlCmd;
                sqlCmd.CommandText = ProcedureName;
                sqlCmd.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < colParam.Count; i++)
                    sqlCmd.Parameters.Add((SqlParameter)colParam[i]);
                sqlCmd.ExecuteNonQuery();
            }
            //catch(SqlException sqlEx) {
            //    strErrorMessage = sqlEx.Message;
            //    intErrorNumber = sqlEx.Number;            
            //}
            finally{ }

            //sqlDA.Dispose();
            //sqlDA = null;
            sqlCmd.Dispose();
            sqlCmd = null;
        }

        protected void RunProcedureTrans(string ProcedureName, ArrayList colParam)
        {
            SqlCommand sqlCmd = new SqlCommand();
            //SqlDataAdapter sqlDA = new SqlDataAdapter();
            try
            {
                sqlCmd.Connection = sqlCn;
                sqlCmd.Transaction = sqlTrans;
                //sqlDA.SelectCommand = sqlCmd;
                sqlCmd.CommandText = ProcedureName;
                sqlCmd.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < colParam.Count; i++)
                    sqlCmd.Parameters.Add((SqlParameter)colParam[i]);
                sqlCmd.ExecuteNonQuery();
            }
            //catch(SqlException sqlEx) {
            //    strErrorMessage = sqlEx.Message;
            //    intErrorNumber = sqlEx.Number;            
            //}
            finally { }

            //sqlDA.Dispose();
            //sqlDA = null;
            sqlCmd.Dispose();
            sqlCmd = null;
        }

        /// <summary>
        /// Thuc thi thu tuc co tra lai gia tri la doi tuong
        /// </summary>
        /// <param name="ProcedureName"></param>
        /// <param name="colParam"></param>
        /// <returns></returns>
        protected object RunProcedureOut(string ProcedureName, ArrayList colParam, string FieldName)
        {
            object Result;
            SqlCommand sqlCmd = new SqlCommand();
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            try
            {
                sqlCmd.Connection = sqlCn;
                sqlDA.SelectCommand = sqlCmd;
                sqlCmd.CommandText = ProcedureName;
                sqlCmd.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < colParam.Count; i++)
                    sqlCmd.Parameters.Add((SqlParameter)colParam[i]);
                sqlCmd.ExecuteNonQuery();
                Result = sqlCmd.Parameters["@" + FieldName].Value;
            }
            //catch(SqlException sqlEx) {
            //    strErrorMessage = sqlEx.Message;
            //    intErrorNumber = sqlEx.Number;
            //}
            finally { }

            sqlDA.Dispose();
            sqlDA = null;
            sqlCmd.Dispose();
            sqlCmd = null;
            return Result;
        }

        /// <summary>
        /// Thuc thi thu tuc co tra lai gia tri la mang doi tuong
        /// </summary>
        /// <param name="ProcedureName"></param>
        /// <param name="colParam"></param>
        /// <returns></returns>
        protected object[] RunProcedureOut(string ProcedureName, ArrayList colParam, string[] FieldName)
        {
            object[] Result = new object[FieldName.Length];
            SqlCommand sqlCmd = new SqlCommand();
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            try
            {
                sqlCmd.Connection = sqlCn;
                sqlDA.SelectCommand = sqlCmd;
                sqlCmd.CommandText = ProcedureName;
                sqlCmd.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < colParam.Count; i++)
                    sqlCmd.Parameters.Add((SqlParameter)colParam[i]);
                sqlCmd.ExecuteNonQuery();
                for (int i = 0; i < FieldName.Length; i++)
                    Result[i] = sqlCmd.Parameters["@" + FieldName[i]].Value;
            }
            //catch(SqlException sqlEx) {
            //    strErrorMessage = sqlEx.Message;
            //    intErrorNumber = sqlEx.Number;
            //}
            finally { }

            sqlDA.Dispose();
            sqlDA = null;
            sqlCmd.Dispose();
            sqlCmd = null;
            return Result;
        }

        /// <summary>
        /// Thuc thi thu tuc co tra lai gia tri la so tu tang cua bang
        /// </summary>
        /// <param name="ProcedureName"></param>
        /// <param name="colParam"></param>
        /// <returns></returns>
        protected object RunProcedureOut(string ProcedureName, ArrayList colParam)
        {
            object ID;
            SqlCommand sqlCmd = new SqlCommand();
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            try
            {
                sqlCmd.Connection = sqlCn;
                sqlDA.SelectCommand = sqlCmd;
                sqlCmd.CommandText = ProcedureName;
                sqlCmd.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < colParam.Count; i++)
                    sqlCmd.Parameters.Add((SqlParameter)colParam[i]);
                sqlCmd.ExecuteNonQuery();
                ID = sqlCmd.Parameters["@ID"].Value;
            }
            //catch(SqlException sqlEx) {
            //    strErrorMessage = sqlEx.Message;
            //    intErrorNumber = sqlEx.Number;            
            //}
            finally { }

            sqlDA.Dispose();
            sqlDA = null;
            sqlCmd.Dispose();
            sqlCmd = null;
            return ID;
        }

        /// <summary>
        /// Ham goi thu tuc truy van
        /// </summary>
        /// 
        /// <param name="ProcedureName"></param>
        /// <param name="colParam"></param>
        /// <returns></returns>
        protected DataTable RunProcedureGet(string ProcedureName, ArrayList colParam)
        {
            DataTable dtb = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            try
            {
                sqlCmd.Connection = sqlCn;
                sqlDA.SelectCommand = sqlCmd;
                sqlCmd.CommandText = ProcedureName;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = 120;

                for (int i = 0; i < colParam.Count; i++)
                    sqlCmd.Parameters.Add((SqlParameter)colParam[i]);

                sqlDA.Fill(dtb);
            }
            //catch(SqlException sqlEx) {
            //    strErrorMessage = sqlEx.Message;
            //    intErrorNumber = sqlEx.Number;
            //}
            finally { }

            sqlDA.Dispose();
            sqlDA = null;
            sqlCmd.Dispose();
            sqlCmd = null;

            return dtb;
        }

        /// <summary>
        /// Ham goi thu tuc truy van
        /// </summary>
        /// 
        /// <param name="ProcedureName"></param>
        /// <param name="colParam"></param>
        /// <returns></returns>
        protected DataSet RunProcedureGetDataSet(string ProcedureName, ArrayList colParam)
        {
            DataSet ds = new DataSet();
            SqlCommand sqlCmd = new SqlCommand();
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            try
            {
                sqlCmd.Connection = sqlCn;
                sqlDA.SelectCommand = sqlCmd;
                sqlCmd.CommandText = ProcedureName;
                sqlCmd.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < colParam.Count; i++)
                    sqlCmd.Parameters.Add((SqlParameter)colParam[i]);

                sqlDA.Fill(ds);
            }
            //catch(SqlException sqlEx) {
            //    strErrorMessage = sqlEx.Message;
            //    intErrorNumber = sqlEx.Number;
            //}
            finally { }

            sqlDA.Dispose();
            sqlDA = null;
            sqlCmd.Dispose();
            sqlCmd = null;

            return ds;
        }

        /// <summary>
        /// Tao tham so cho thu tuc
        /// </summary>
        /// <param name="_TenThamSo"></param>
        /// <param name="_KieuDuLieu"></param>
        /// <param name="_GiaTri"></param>
        /// <returns></returns>
        public SqlParameter CreateParam(string _TenThamSo, SqlDbType _KieuDuLieu, object _GiaTri)
        {
            SqlParameter sqlParam = new SqlParameter();
            sqlParam.ParameterName = _TenThamSo;
            sqlParam.SqlDbType = _KieuDuLieu;
            sqlParam.Value = _GiaTri;
            return sqlParam;
        }
        
        /// <summary>
        /// Tao tham so output cho thu tuc
        /// </summary>
        /// <param name="_TenThamSo"></param>
        /// <param name="_KieuDuLieu"></param>
        /// <returns></returns>
        public SqlParameter CreateParamOut(string _TenThamSo, SqlDbType _KieuDuLieu)
        {
            SqlParameter sqlParam = new SqlParameter();
            sqlParam.ParameterName = _TenThamSo;
            sqlParam.SqlDbType = _KieuDuLieu;
            sqlParam.Direction = ParameterDirection.Output;
            return sqlParam;
        }

        /// <summary>
        /// Tao tham so cho thu tuc
        /// </summary>
        /// <param name="_TenThamSo"></param>
        /// <param name="_KieuDuLieu"></param>
        /// <param name="_KichThuoc"></param>
        /// <param name="_GiaTri"></param>
        /// <returns></returns>
        public SqlParameter CreateParam(string _TenThamSo, SqlDbType _KieuDuLieu, int _KichThuoc, object _GiaTri)
        {
            SqlParameter sqlParam = CreateParam(_TenThamSo, _KieuDuLieu, _GiaTri);
            sqlParam.Size = _KichThuoc;
            return sqlParam;
        }
        
        /// <summary>
        /// Tao tham so output cho thu tuc
        /// </summary>
        /// <param name="_TenThamSo"></param>
        /// <param name="_KieuDuLieu"></param>
        /// <param name="_KichThuoc"></param>
        /// <returns></returns>
        public SqlParameter CreateParamOut(string _TenThamSo, SqlDbType _KieuDuLieu, int _KichThuoc)
        {
            SqlParameter sqlParam = CreateParamOut(_TenThamSo, _KieuDuLieu);
            sqlParam.Size = _KichThuoc;
            return sqlParam;
        }
    }
}
