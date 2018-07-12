using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_DanhSachKhongThi : cBBase
    {
        private cDKQHT_DanhSachKhongThi oDKQHT_DanhSachKhongThi;
        private KQHT_DanhSachKhongThiInfo oKQHT_DanhSachKhongThiInfo;

        public cBKQHT_DanhSachKhongThi()        
        {
            oDKQHT_DanhSachKhongThi = new cDKQHT_DanhSachKhongThi();
        }

        public DataTable Get(KQHT_DanhSachKhongThiInfo pKQHT_DanhSachKhongThiInfo)        
        {
            return oDKQHT_DanhSachKhongThi.Get(pKQHT_DanhSachKhongThiInfo);
        }

        public DataTable GetIn_SinhVien(int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi)
        {
            return oDKQHT_DanhSachKhongThi.GetIn_SinhVien(IDDM_Lop, IDDM_MonHoc, IDDM_NamHoc, HocKy, LanThi);
        }

        public DataTable GetNotIn_SinhVien(int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi)
        {
            return oDKQHT_DanhSachKhongThi.GetNotIn_SinhVien(IDDM_Lop, IDDM_MonHoc, IDDM_NamHoc, HocKy, LanThi);
        }

        public int Add(KQHT_DanhSachKhongThiInfo pKQHT_DanhSachKhongThiInfo)
        {
			int ID = 0;
            ID = oDKQHT_DanhSachKhongThi.Add(pKQHT_DanhSachKhongThiInfo);
            mErrorMessage = oDKQHT_DanhSachKhongThi.ErrorMessages;
            mErrorNumber = oDKQHT_DanhSachKhongThi.ErrorNumber;
            return ID;
        }

        public int AddTuDong(KQHT_DanhSachKhongThiInfo pKQHT_DanhSachKhongThiInfo)
        {
            int ID = 0;
            ID = oDKQHT_DanhSachKhongThi.AddTuDong(pKQHT_DanhSachKhongThiInfo);
            mErrorMessage = oDKQHT_DanhSachKhongThi.ErrorMessages;
            mErrorNumber = oDKQHT_DanhSachKhongThi.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_DanhSachKhongThiInfo pKQHT_DanhSachKhongThiInfo)
        {
            oDKQHT_DanhSachKhongThi.Update(pKQHT_DanhSachKhongThiInfo);
            mErrorMessage = oDKQHT_DanhSachKhongThi.ErrorMessages;
            mErrorNumber = oDKQHT_DanhSachKhongThi.ErrorNumber;
        }
        
        public void Delete(KQHT_DanhSachKhongThiInfo pKQHT_DanhSachKhongThiInfo)
        {
            oDKQHT_DanhSachKhongThi.Delete(pKQHT_DanhSachKhongThiInfo);
            mErrorMessage = oDKQHT_DanhSachKhongThi.ErrorMessages;
            mErrorNumber = oDKQHT_DanhSachKhongThi.ErrorNumber;
        }

        public void DeleteDanhSachDuThi(KQHT_DanhSachKhongThiInfo pKQHT_DanhSachKhongThiInfo, int IDXL_MonHocTrongKy)
        {
            oDKQHT_DanhSachKhongThi.DeleteDanhSachDuThi(pKQHT_DanhSachKhongThiInfo, IDXL_MonHocTrongKy);
            mErrorMessage = oDKQHT_DanhSachKhongThi.ErrorMessages;
            mErrorNumber = oDKQHT_DanhSachKhongThi.ErrorNumber;
        }

        public List<KQHT_DanhSachKhongThiInfo> GetList(KQHT_DanhSachKhongThiInfo pKQHT_DanhSachKhongThiInfo)
        {
            List<KQHT_DanhSachKhongThiInfo> oKQHT_DanhSachKhongThiInfoList = new List<KQHT_DanhSachKhongThiInfo>();
            DataTable dtb = Get(pKQHT_DanhSachKhongThiInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_DanhSachKhongThiInfo = new KQHT_DanhSachKhongThiInfo();

                    oKQHT_DanhSachKhongThiInfo.KQHT_DanhSachKhongThiID = int.Parse(dtb.Rows[i]["KQHT_DanhSachKhongThiID"].ToString());
                    oKQHT_DanhSachKhongThiInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oKQHT_DanhSachKhongThiInfo.IDDM_MonHoc = int.Parse(dtb.Rows[i]["IDDM_MonHoc"].ToString());
                    oKQHT_DanhSachKhongThiInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
                    oKQHT_DanhSachKhongThiInfo.HocKy = int.Parse(dtb.Rows[i]["HocKy"].ToString());
                    oKQHT_DanhSachKhongThiInfo.LyDo = dtb.Rows[i]["LyDo"].ToString();
                    
                    oKQHT_DanhSachKhongThiInfoList.Add(oKQHT_DanhSachKhongThiInfo);
                }
            }
            return oKQHT_DanhSachKhongThiInfoList;
        }
        
        public void ToDataRow(KQHT_DanhSachKhongThiInfo pKQHT_DanhSachKhongThiInfo, ref DataRow dr)
        {

			dr[pKQHT_DanhSachKhongThiInfo.strKQHT_DanhSachKhongThiID] = pKQHT_DanhSachKhongThiInfo.KQHT_DanhSachKhongThiID;
			dr[pKQHT_DanhSachKhongThiInfo.strIDSV_SinhVien] = pKQHT_DanhSachKhongThiInfo.IDSV_SinhVien;
			dr[pKQHT_DanhSachKhongThiInfo.strIDDM_MonHoc] = pKQHT_DanhSachKhongThiInfo.IDDM_MonHoc;
			dr[pKQHT_DanhSachKhongThiInfo.strIDDM_NamHoc] = pKQHT_DanhSachKhongThiInfo.IDDM_NamHoc;
			dr[pKQHT_DanhSachKhongThiInfo.strHocKy] = pKQHT_DanhSachKhongThiInfo.HocKy;
			dr[pKQHT_DanhSachKhongThiInfo.strLyDo] = pKQHT_DanhSachKhongThiInfo.LyDo;
        }
        
        public void ToInfo(ref KQHT_DanhSachKhongThiInfo pKQHT_DanhSachKhongThiInfo, DataRow dr)
        {

			pKQHT_DanhSachKhongThiInfo.KQHT_DanhSachKhongThiID = int.Parse(dr[pKQHT_DanhSachKhongThiInfo.strKQHT_DanhSachKhongThiID].ToString());
			pKQHT_DanhSachKhongThiInfo.IDSV_SinhVien = int.Parse(dr[pKQHT_DanhSachKhongThiInfo.strIDSV_SinhVien].ToString());
			pKQHT_DanhSachKhongThiInfo.IDDM_MonHoc = int.Parse(dr[pKQHT_DanhSachKhongThiInfo.strIDDM_MonHoc].ToString());
			pKQHT_DanhSachKhongThiInfo.IDDM_NamHoc = int.Parse(dr[pKQHT_DanhSachKhongThiInfo.strIDDM_NamHoc].ToString());
			pKQHT_DanhSachKhongThiInfo.HocKy = int.Parse(dr[pKQHT_DanhSachKhongThiInfo.strHocKy].ToString());
			pKQHT_DanhSachKhongThiInfo.LyDo = dr[pKQHT_DanhSachKhongThiInfo.strLyDo].ToString();
        }
    }
}
