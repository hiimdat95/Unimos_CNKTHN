using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_ToChucThi : cBBase
    {
        private cDKQHT_ToChucThi oDKQHT_ToChucThi;
        private KQHT_ToChucThiInfo oKQHT_ToChucThiInfo;

        public cBKQHT_ToChucThi()        
        {
            oDKQHT_ToChucThi = new cDKQHT_ToChucThi();
        }

        public DataTable Get(KQHT_ToChucThiInfo pKQHT_ToChucThiInfo)        
        {
            return oDKQHT_ToChucThi.Get(pKQHT_ToChucThiInfo);
        }

        public DataTable GetByMonHoc(int IDDM_MonHoc, int IDDM_NamHoc, int HocKy)
        {
            return oDKQHT_ToChucThi.GetByMonHoc(IDDM_MonHoc, IDDM_NamHoc, HocKy);
        }

        public DataTable GetDotThiByMonHoc(int IDDM_MonHoc, int IDDM_NamHoc, int HocKy)
        {
            return oDKQHT_ToChucThi.GetDotThiByMonHoc(IDDM_MonHoc, IDDM_NamHoc, HocKy);
        }

        public DataTable GetDanhSachByDotThi(int IDKQHT_ToChucThi)
        {
            return oDKQHT_ToChucThi.GetDanhSachByDotThi(IDKQHT_ToChucThi);
        }

        public DataTable GetPhongThi(int IDKQHT_ToChucThi)
        {
            return oDKQHT_ToChucThi.GetPhongThi(IDKQHT_ToChucThi);
        }

        public DataTable GetDanhSachDuThi_TotNghiep(int IDKQHT_ToChucThi)
        {
            return oDKQHT_ToChucThi.GetDanhSachDuThi_TotNghiep(IDKQHT_ToChucThi);
        }

        public int Add(KQHT_ToChucThiInfo pKQHT_ToChucThiInfo)
        {
			int ID = 0;
            ID = oDKQHT_ToChucThi.Add(pKQHT_ToChucThiInfo);
            mErrorMessage = oDKQHT_ToChucThi.ErrorMessages;
            mErrorNumber = oDKQHT_ToChucThi.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_ToChucThiInfo pKQHT_ToChucThiInfo)
        {
            oDKQHT_ToChucThi.Update(pKQHT_ToChucThiInfo);
            mErrorMessage = oDKQHT_ToChucThi.ErrorMessages;
            mErrorNumber = oDKQHT_ToChucThi.ErrorNumber;
        }

        public void UpdateDongTui(bool DongTui, int KQHT_ToChucThiID)
        {
            oDKQHT_ToChucThi.UpdateDongTui(DongTui, KQHT_ToChucThiID);
            mErrorMessage = oDKQHT_ToChucThi.ErrorMessages;
            mErrorNumber = oDKQHT_ToChucThi.ErrorNumber;
        }
        
        public void Delete(KQHT_ToChucThiInfo pKQHT_ToChucThiInfo)
        {
            oDKQHT_ToChucThi.Delete(pKQHT_ToChucThiInfo);
            mErrorMessage = oDKQHT_ToChucThi.ErrorMessages;
            mErrorNumber = oDKQHT_ToChucThi.ErrorNumber;
        }

        public List<KQHT_ToChucThiInfo> GetList(KQHT_ToChucThiInfo pKQHT_ToChucThiInfo)
        {
            List<KQHT_ToChucThiInfo> oKQHT_ToChucThiInfoList = new List<KQHT_ToChucThiInfo>();
            DataTable dtb = Get(pKQHT_ToChucThiInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_ToChucThiInfo = new KQHT_ToChucThiInfo();

                    oKQHT_ToChucThiInfo.KQHT_ToChucThiID = int.Parse(dtb.Rows[i]["KQHT_ToChucThiID"].ToString());
                    oKQHT_ToChucThiInfo.IDDM_MonHoc = int.Parse(dtb.Rows[i]["IDDM_MonHoc"].ToString());
                    oKQHT_ToChucThiInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
                    oKQHT_ToChucThiInfo.HocKy = int.Parse(dtb.Rows[i]["HocKy"].ToString());
                    oKQHT_ToChucThiInfo.LanThi = int.Parse(dtb.Rows[i]["LanThi"].ToString());
                    oKQHT_ToChucThiInfo.DotThi = int.Parse(dtb.Rows[i]["DotThi"].ToString());
                    oKQHT_ToChucThiInfo.NgayThi = DateTime.Parse(dtb.Rows[i]["NgayThi"].ToString());
                    oKQHT_ToChucThiInfo.CaThi = int.Parse(dtb.Rows[i]["CaThi"].ToString());
                    oKQHT_ToChucThiInfo.NhomTiet = int.Parse(dtb.Rows[i]["NhomTiet"].ToString());
                    oKQHT_ToChucThiInfo.IDHT_User = int.Parse(dtb.Rows[i]["IDHT_User"].ToString());
                    oKQHT_ToChucThiInfo.NgayTao = DateTime.Parse(dtb.Rows[i]["NgayTao"].ToString());
                    
                    oKQHT_ToChucThiInfoList.Add(oKQHT_ToChucThiInfo);
                }
            }
            return oKQHT_ToChucThiInfoList;
        }
        
        public void ToDataRow(KQHT_ToChucThiInfo pKQHT_ToChucThiInfo, ref DataRow dr)
        {

			dr[pKQHT_ToChucThiInfo.strKQHT_ToChucThiID] = pKQHT_ToChucThiInfo.KQHT_ToChucThiID;
			dr[pKQHT_ToChucThiInfo.strIDDM_MonHoc] = pKQHT_ToChucThiInfo.IDDM_MonHoc;
			dr[pKQHT_ToChucThiInfo.strIDDM_NamHoc] = pKQHT_ToChucThiInfo.IDDM_NamHoc;
			dr[pKQHT_ToChucThiInfo.strHocKy] = pKQHT_ToChucThiInfo.HocKy;
			dr[pKQHT_ToChucThiInfo.strLanThi] = pKQHT_ToChucThiInfo.LanThi;
			dr[pKQHT_ToChucThiInfo.strDotThi] = pKQHT_ToChucThiInfo.DotThi;
			dr[pKQHT_ToChucThiInfo.strNgayThi] = pKQHT_ToChucThiInfo.NgayThi;
			dr[pKQHT_ToChucThiInfo.strCaThi] = pKQHT_ToChucThiInfo.CaThi;
			dr[pKQHT_ToChucThiInfo.strNhomTiet] = pKQHT_ToChucThiInfo.NhomTiet;
			dr[pKQHT_ToChucThiInfo.strIDHT_User] = pKQHT_ToChucThiInfo.IDHT_User;
			dr[pKQHT_ToChucThiInfo.strNgayTao] = pKQHT_ToChucThiInfo.NgayTao;
        }
        
        public void ToInfo(ref KQHT_ToChucThiInfo pKQHT_ToChucThiInfo, DataRow dr)
        {

			pKQHT_ToChucThiInfo.KQHT_ToChucThiID = int.Parse(dr[pKQHT_ToChucThiInfo.strKQHT_ToChucThiID].ToString());
			pKQHT_ToChucThiInfo.IDDM_MonHoc = int.Parse(dr[pKQHT_ToChucThiInfo.strIDDM_MonHoc].ToString());
			pKQHT_ToChucThiInfo.IDDM_NamHoc = int.Parse(dr[pKQHT_ToChucThiInfo.strIDDM_NamHoc].ToString());
			pKQHT_ToChucThiInfo.HocKy = int.Parse(dr[pKQHT_ToChucThiInfo.strHocKy].ToString());
			pKQHT_ToChucThiInfo.LanThi = int.Parse(dr[pKQHT_ToChucThiInfo.strLanThi].ToString());
			pKQHT_ToChucThiInfo.DotThi = int.Parse(dr[pKQHT_ToChucThiInfo.strDotThi].ToString());
			pKQHT_ToChucThiInfo.NgayThi = DateTime.Parse(dr[pKQHT_ToChucThiInfo.strNgayThi].ToString());
			pKQHT_ToChucThiInfo.CaThi = int.Parse(dr[pKQHT_ToChucThiInfo.strCaThi].ToString());
			pKQHT_ToChucThiInfo.NhomTiet = int.Parse(dr[pKQHT_ToChucThiInfo.strNhomTiet].ToString());
			pKQHT_ToChucThiInfo.IDHT_User = int.Parse(dr[pKQHT_ToChucThiInfo.strIDHT_User].ToString());
			pKQHT_ToChucThiInfo.NgayTao = DateTime.Parse(dr[pKQHT_ToChucThiInfo.strNgayTao].ToString());
        }
    }
}
