using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBTC_BienLaiThuTien_ChiTiet : cBBase
    {
        private cDTC_BienLaiThuTien_ChiTiet oDTC_BienLaiThuTien_ChiTiet;
        private TC_BienLaiThuTien_ChiTietInfo oTC_BienLaiThuTien_ChiTietInfo;

        public cBTC_BienLaiThuTien_ChiTiet()        
        {
            oDTC_BienLaiThuTien_ChiTiet = new cDTC_BienLaiThuTien_ChiTiet();
        }

        public DataTable Get(TC_BienLaiThuTien_ChiTietInfo pTC_BienLaiThuTien_ChiTietInfo)        
        {
            return oDTC_BienLaiThuTien_ChiTiet.Get(pTC_BienLaiThuTien_ChiTietInfo);
        }
        public DataTable GetBySinhVien(int IDSV_SinhVien, int IDTC_LoaiThuChi, int IDDM_NamHOc, int HocKy)
        {
            return oDTC_BienLaiThuTien_ChiTiet.GetBySinhVien(IDSV_SinhVien, IDTC_LoaiThuChi, IDDM_NamHOc, HocKy);
        }
        public int Add(TC_BienLaiThuTien_ChiTietInfo pTC_BienLaiThuTien_ChiTietInfo)
        {
			int ID = 0;
            ID = oDTC_BienLaiThuTien_ChiTiet.Add(pTC_BienLaiThuTien_ChiTietInfo);
            mErrorMessage = oDTC_BienLaiThuTien_ChiTiet.ErrorMessages;
            mErrorNumber = oDTC_BienLaiThuTien_ChiTiet.ErrorNumber;
            return ID;
        }

        public void Update(TC_BienLaiThuTien_ChiTietInfo pTC_BienLaiThuTien_ChiTietInfo)
        {
            oDTC_BienLaiThuTien_ChiTiet.Update(pTC_BienLaiThuTien_ChiTietInfo);
            mErrorMessage = oDTC_BienLaiThuTien_ChiTiet.ErrorMessages;
            mErrorNumber = oDTC_BienLaiThuTien_ChiTiet.ErrorNumber;
        }
        
        public void Delete(TC_BienLaiThuTien_ChiTietInfo pTC_BienLaiThuTien_ChiTietInfo)
        {
            oDTC_BienLaiThuTien_ChiTiet.Delete(pTC_BienLaiThuTien_ChiTietInfo);
            mErrorMessage = oDTC_BienLaiThuTien_ChiTiet.ErrorMessages;
            mErrorNumber = oDTC_BienLaiThuTien_ChiTiet.ErrorNumber;
        }
        public void DeleteBy_BienLaiThuTien(int IDTC_BienLaiThuTien )
        {
            oDTC_BienLaiThuTien_ChiTiet.DeleteBy_BienLaiThuTien(IDTC_BienLaiThuTien);
            mErrorMessage = oDTC_BienLaiThuTien_ChiTiet.ErrorMessages;
            mErrorNumber = oDTC_BienLaiThuTien_ChiTiet.ErrorNumber;
        }

        public List<TC_BienLaiThuTien_ChiTietInfo> GetList(TC_BienLaiThuTien_ChiTietInfo pTC_BienLaiThuTien_ChiTietInfo)
        {
            List<TC_BienLaiThuTien_ChiTietInfo> oTC_BienLaiThuTien_ChiTietInfoList = new List<TC_BienLaiThuTien_ChiTietInfo>();
            DataTable dtb = Get(pTC_BienLaiThuTien_ChiTietInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oTC_BienLaiThuTien_ChiTietInfo = new TC_BienLaiThuTien_ChiTietInfo();

                    oTC_BienLaiThuTien_ChiTietInfo.TC_BienLaiThuTien_ChiTietID = int.Parse(dtb.Rows[i]["TC_BienLaiThuTien_ChiTietID"].ToString());
                    oTC_BienLaiThuTien_ChiTietInfo.IDTC_BienLaiThuTien = int.Parse(dtb.Rows[i]["IDTC_BienLaiThuTien"].ToString());
                    oTC_BienLaiThuTien_ChiTietInfo.IDTC_LoaiThuChi = int.Parse(dtb.Rows[i]["IDTC_LoaiThuChi"].ToString());
                    oTC_BienLaiThuTien_ChiTietInfo.IDTC_DinhMucThuSinhVien = int.Parse(dtb.Rows[i]["IDTC_DinhMucThuSinhVien"].ToString());
                    oTC_BienLaiThuTien_ChiTietInfo.LanThu = int.Parse(dtb.Rows[i]["LanThu"].ToString());
                    oTC_BienLaiThuTien_ChiTietInfo.NoiDung = dtb.Rows[i]["NoiDung"].ToString();
                    oTC_BienLaiThuTien_ChiTietInfo.SoTien = double.Parse(dtb.Rows[i]["SoTien"].ToString());
                    
                    oTC_BienLaiThuTien_ChiTietInfoList.Add(oTC_BienLaiThuTien_ChiTietInfo);
                }
            }
            return oTC_BienLaiThuTien_ChiTietInfoList;
        }
        
        public void ToDataRow(TC_BienLaiThuTien_ChiTietInfo pTC_BienLaiThuTien_ChiTietInfo, ref DataRow dr)
        {

			dr[pTC_BienLaiThuTien_ChiTietInfo.strTC_BienLaiThuTien_ChiTietID] = pTC_BienLaiThuTien_ChiTietInfo.TC_BienLaiThuTien_ChiTietID;
			dr[pTC_BienLaiThuTien_ChiTietInfo.strIDTC_BienLaiThuTien] = pTC_BienLaiThuTien_ChiTietInfo.IDTC_BienLaiThuTien;
			dr[pTC_BienLaiThuTien_ChiTietInfo.strIDTC_LoaiThuChi] = pTC_BienLaiThuTien_ChiTietInfo.IDTC_LoaiThuChi;
			dr[pTC_BienLaiThuTien_ChiTietInfo.strIDTC_DinhMucThuSinhVien] = pTC_BienLaiThuTien_ChiTietInfo.IDTC_DinhMucThuSinhVien;
			dr[pTC_BienLaiThuTien_ChiTietInfo.strLanThu] = pTC_BienLaiThuTien_ChiTietInfo.LanThu;
			dr[pTC_BienLaiThuTien_ChiTietInfo.strNoiDung] = pTC_BienLaiThuTien_ChiTietInfo.NoiDung;
			dr[pTC_BienLaiThuTien_ChiTietInfo.strSoTien] = pTC_BienLaiThuTien_ChiTietInfo.SoTien;
        }
        
        public void ToInfo(ref TC_BienLaiThuTien_ChiTietInfo pTC_BienLaiThuTien_ChiTietInfo, DataRow dr)
        {

			pTC_BienLaiThuTien_ChiTietInfo.TC_BienLaiThuTien_ChiTietID = int.Parse(dr[pTC_BienLaiThuTien_ChiTietInfo.strTC_BienLaiThuTien_ChiTietID].ToString());
			pTC_BienLaiThuTien_ChiTietInfo.IDTC_BienLaiThuTien = int.Parse(dr[pTC_BienLaiThuTien_ChiTietInfo.strIDTC_BienLaiThuTien].ToString());
			pTC_BienLaiThuTien_ChiTietInfo.IDTC_LoaiThuChi = int.Parse(dr[pTC_BienLaiThuTien_ChiTietInfo.strIDTC_LoaiThuChi].ToString());
			pTC_BienLaiThuTien_ChiTietInfo.IDTC_DinhMucThuSinhVien = int.Parse(dr[pTC_BienLaiThuTien_ChiTietInfo.strIDTC_DinhMucThuSinhVien].ToString());
			pTC_BienLaiThuTien_ChiTietInfo.LanThu = int.Parse(dr[pTC_BienLaiThuTien_ChiTietInfo.strLanThu].ToString());
			pTC_BienLaiThuTien_ChiTietInfo.NoiDung = dr[pTC_BienLaiThuTien_ChiTietInfo.strNoiDung].ToString();
			pTC_BienLaiThuTien_ChiTietInfo.SoTien = double.Parse(dr[pTC_BienLaiThuTien_ChiTietInfo.strSoTien].ToString());
        }

        public DataTable CreateTableChiTiet()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("NoiDung", typeof(string));
            dt.Columns.Add("SoTien", typeof(double));
            dt.Columns.Add("LanThu", typeof(string));

            return dt;
        }
    }
}
