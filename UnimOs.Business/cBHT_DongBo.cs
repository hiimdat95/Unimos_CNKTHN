using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;
using System.Data.SqlClient;

namespace TruongViet.UnimOs.Business
{
    public class cBHT_DongBo : cBBase
    {
        private cDHT_DongBo oDHT_DongBo;
        private HT_DongBoInfo oHT_DongBoInfo;

        public cBHT_DongBo()
        {
            oDHT_DongBo = new cDHT_DongBo();
        }

        #region Thao tac co ban
        public DataTable Get(HT_DongBoInfo pHT_DongBoInfo)
        {
            return oDHT_DongBo.Get(pHT_DongBoInfo);
        }

        public DataTable GetSoThayDoi()
        {
            return oDHT_DongBo.GetSoThayDoi();
        }

        public DataTable GetThayDoi()
        {
            return oDHT_DongBo.GetThayDoi();
        }

        public DataTable GetDanhSachThayDoi(string TenBang, string IDThayDoi)
        {
            return oDHT_DongBo.GetDanhSachThayDoi(TenBang, IDThayDoi);
        }

        public void UpdateDanhSachThayDoi()
        {
            oDHT_DongBo.UpdateDanhSachThayDoi();
        }

        public DataTable GetDataChanged(string TenBang, long IDThayDoi)
        {
            return oDHT_DongBo.GetDataChanged(TenBang, IDThayDoi);
        }

        public int Add(HT_DongBoInfo pHT_DongBoInfo)
        {
            int ID = 0;
            ID = oDHT_DongBo.Add(pHT_DongBoInfo);
            mErrorMessage = oDHT_DongBo.ErrorMessages;
            mErrorNumber = oDHT_DongBo.ErrorNumber;
            return ID;
        }

        public void Update(HT_DongBoInfo pHT_DongBoInfo)
        {
            oDHT_DongBo.Update(pHT_DongBoInfo);
            mErrorMessage = oDHT_DongBo.ErrorMessages;
            mErrorNumber = oDHT_DongBo.ErrorNumber;
        }

        public void UpdateTrangThai(bool DaDongBo, long HT_DongBoID)
        {
            oDHT_DongBo.UpdateTrangThai(DaDongBo, HT_DongBoID);
            mErrorMessage = oDHT_DongBo.ErrorMessages;
            mErrorNumber = oDHT_DongBo.ErrorNumber;
        }

        public void Delete(HT_DongBoInfo pHT_DongBoInfo)
        {
            oDHT_DongBo.Delete(pHT_DongBoInfo);
            mErrorMessage = oDHT_DongBo.ErrorMessages;
            mErrorNumber = oDHT_DongBo.ErrorNumber;
        }

        public List<HT_DongBoInfo> GetList(HT_DongBoInfo pHT_DongBoInfo)
        {
            List<HT_DongBoInfo> oHT_DongBoInfoList = new List<HT_DongBoInfo>();
            DataTable dtb = Get(pHT_DongBoInfo);
            if (dtb != null)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    oHT_DongBoInfo = new HT_DongBoInfo();

                    oHT_DongBoInfo.HT_DongBoID = long.Parse(dtb.Rows[i]["HT_DongBoID"].ToString());
                    oHT_DongBoInfo.TenBang = dtb.Rows[i]["TenBang"].ToString();
                    oHT_DongBoInfo.IDThayDoi = long.Parse(dtb.Rows[i]["IDThayDoi"].ToString());
                    oHT_DongBoInfo.ThaoTac = dtb.Rows[i]["ThaoTac"].ToString();
                    oHT_DongBoInfo.DaDongBo = bool.Parse(dtb.Rows[i]["DaDongBo"].ToString());
                    oHT_DongBoInfo.CreatedTime = DateTime.Parse(dtb.Rows[i]["CreatedTime"].ToString());

                    oHT_DongBoInfoList.Add(oHT_DongBoInfo);
                }
            }
            return oHT_DongBoInfoList;
        }

        public void ToDataRow(HT_DongBoInfo pHT_DongBoInfo, ref DataRow dr)
        {

            dr[pHT_DongBoInfo.strHT_DongBoID] = pHT_DongBoInfo.HT_DongBoID;
            dr[pHT_DongBoInfo.strTenBang] = pHT_DongBoInfo.TenBang;
            dr[pHT_DongBoInfo.strIDThayDoi] = pHT_DongBoInfo.IDThayDoi;
            dr[pHT_DongBoInfo.strThaoTac] = pHT_DongBoInfo.ThaoTac;
            dr[pHT_DongBoInfo.strDaDongBo] = pHT_DongBoInfo.DaDongBo;
            dr[pHT_DongBoInfo.strCreatedTime] = pHT_DongBoInfo.CreatedTime;
        }

        public void ToInfo(ref HT_DongBoInfo pHT_DongBoInfo, DataRow dr)
        {

            pHT_DongBoInfo.HT_DongBoID = long.Parse(dr[pHT_DongBoInfo.strHT_DongBoID].ToString());
            pHT_DongBoInfo.TenBang = dr[pHT_DongBoInfo.strTenBang].ToString();
            pHT_DongBoInfo.IDThayDoi = long.Parse(dr[pHT_DongBoInfo.strIDThayDoi].ToString());
            pHT_DongBoInfo.ThaoTac = dr[pHT_DongBoInfo.strThaoTac].ToString();
            pHT_DongBoInfo.DaDongBo = bool.Parse(dr[pHT_DongBoInfo.strDaDongBo].ToString());
            pHT_DongBoInfo.CreatedTime = DateTime.Parse(dr[pHT_DongBoInfo.strCreatedTime].ToString());
        }
        #endregion

        #region Dong bo du lieu
        // CongNC
        public string ThucHienDongBo(string sqlConnection)
        {
            try
            {
                // Lấy bảng thay đổi
                DataTable dtThayDoi = GetThayDoi();
                string SQL = "", TenBang = "", IDThayDoi = "";
                DataTable dtbThayDoi;
                if (dtThayDoi != null && dtThayDoi.Rows.Count > 0)
                {
                    cDBase oDBase = new cDBase();
                    
                    // Đẩy bảng HT_DongBo lên hosting để thực hiện xóa dữ liệu cũ
                    DataTable dtDongBo = Get(new HT_DongBoInfo());
                    using (SqlBulkCopy s = new SqlBulkCopy(sqlConnection))
                    {
                        s.DestinationTableName = "HT_DongBo";
                        s.NotifyAfter = 10000;
                        s.WriteToServer(dtDongBo);
                        s.Close();
                    }

                    // Xóa hết những dữ liệu đã có theo thay đổi trên DB Web
                    for (int i = 0; i < dtThayDoi.Rows.Count; i++)
                    {
                        TenBang = dtThayDoi.Rows[i]["TenBang"] + "";
                        SQL = "DELETE A FROM " + TenBang +
                                " A INNER JOIN HT_DongBo B ON B.TenBang = '" + TenBang +
                                "' AND DaDongBo = 0 AND A." + TenBang + "ID = B.IDThayDoi";
                        oDBase.RunQuery(sqlConnection, SQL);
                        // Lấy các dữ liệu thay đổi của bảng dtThayDoi.Rows[i]["TenBang"] có ID là IDThayDoi và ThaoTac là Update hoặc Insert
                        // Insert dữ liệu thay đổi mới lên DB Web
                        dtbThayDoi = GetDanhSachThayDoi(TenBang, IDThayDoi);
                        if (dtbThayDoi != null && dtbThayDoi.Rows.Count > 0)
                        {
                            using (SqlBulkCopy s = new SqlBulkCopy(sqlConnection))
                            {
                                s.DestinationTableName = TenBang;
                                s.NotifyAfter = 10000;
                                s.WriteToServer(dtbThayDoi);
                                s.Close();
                            }
                        }
                    }

                    // Xóa dữ liệu bảng HT_DongBo trên hosting
                    SQL = "DELETE HT_DongBo";
                    oDBase.RunQuery(sqlConnection, SQL);

                    // Xong duoi thi quay lại cập nhật lại trạng thái cho bảng đồng bộ DB ở trường
                    UpdateDanhSachThayDoi();
                }
                return "TRUE";
            }
            catch (Exception es)
            {
                return es.Message;
            }
        }
        
        private string GenSQLDongBo(DataTable dtData, string TenBang, string ThaoTac)
        {
            string SQL = "";
            switch (ThaoTac.Trim().ToUpper())
            {
                case "INSERT":
                    string Values = " VALUES (";
                    SQL = "INSERT INTO " + TenBang + "(";
                    foreach (DataColumn dc in dtData.Columns)
                    {
                        if (!((dc.DataType.ToString() == "System.DateTime" && "" + dtData.Rows[0][dc.ColumnName] == "") ||
                            (dc.DataType.ToString() == "System.Byte[]")))
                        {
                            SQL += dc.ColumnName + ",";
                            Values += SQLValue(dtData.Rows[0][dc.ColumnName].ToString(), dc.DataType.ToString()) + ",";
                        }
                    }
                    SQL = SQL.Substring(0, SQL.Length - 1) + ")" + Values.Substring(0, Values.Length - 1) + ")";
                    break;
                case "UPDATE":
                    SQL = "UPDATE " + TenBang + " SET ";
                    foreach (DataColumn dc in dtData.Columns)
                    {
                        if (!(dc.ColumnName == TenBang + "ID" ||
                            (dc.DataType.ToString() == "System.DateTime" && "" + dtData.Rows[0][dc.ColumnName] == "") ||
                            (dc.DataType.ToString() == "System.Byte[]" && "" + dtData.Rows[0][dc.ColumnName] == "")))
                        {
                            SQL += dc.ColumnName + " = " + SQLValue(dtData.Rows[0][dc.ColumnName].ToString(), dc.DataType.ToString()) + ",";
                        }
                    }
                    SQL = SQL.Substring(0, SQL.Length - 1) + " WHERE " + TenBang + "ID = " + dtData.Rows[0][TenBang + "ID"];
                    break;
                case "DELETE":
                    SQL = "DELETE FROM " + TenBang + " WHERE " + TenBang + "ID = " + dtData.Rows[0][TenBang + "ID"];
                    break;
            }
            return SQL;
        }

        private string SQLValue(string value, string DataType)
        {
            string result = "";
            switch (DataType)
            {
                case "System.Int32":
                case "System.Int16":
                case "System.Int64":
                case "System.Double":
                case "System.Decimal":
                case "System.Single":
                case "System.Real":
                case "System.Byte[]":
                    if (value == string.Empty)
                        result = "null";
                    else
                        result = value;
                    break;
                case "System.Boolean":
                    result = "" + (value == "True" ? 1 : 0);
                    break;
                case "System.String":
                    result = "N'" + value + "'";
                    break;
                case "System.DateTime":
                    result = "Convert(Datetime, '" + value + "', 103)";
                    break;
            }
            return result;
        }
        #endregion
    }
}
