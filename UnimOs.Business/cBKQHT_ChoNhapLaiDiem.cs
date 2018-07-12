using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_ChoNhapLaiDiem : cBBase
    {
        private cDKQHT_ChoNhapLaiDiem oDKQHT_ChoNhapLaiDiem;

        public cBKQHT_ChoNhapLaiDiem()        
        {
            oDKQHT_ChoNhapLaiDiem = new cDKQHT_ChoNhapLaiDiem();
        }

        public DataTable Get(KQHT_ChoNhapLaiDiemInfo pKQHT_ChoNhapLaiDiemInfo)        
        {
            return oDKQHT_ChoNhapLaiDiem.Get(pKQHT_ChoNhapLaiDiemInfo);
        }

        public DataTable GetDanhSach(int IDXL_MonHocTrongKy, int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi)
        {
            return oDKQHT_ChoNhapLaiDiem.GetDanhSach(IDXL_MonHocTrongKy, IDDM_Lop, IDDM_MonHoc, IDDM_NamHoc, HocKy, LanThi);
        }

        public int Add(KQHT_ChoNhapLaiDiemInfo pKQHT_ChoNhapLaiDiemInfo)
        {
			int ID = 0;
            ID = oDKQHT_ChoNhapLaiDiem.Add(pKQHT_ChoNhapLaiDiemInfo);
            mErrorMessage = oDKQHT_ChoNhapLaiDiem.ErrorMessages;
            mErrorNumber = oDKQHT_ChoNhapLaiDiem.ErrorNumber;
            return ID;
        }

        public int AddChuyenDiem(int IDXL_MonHocTrongKy, int IDHT_User, bool DiemThanhPhan_L1, bool DiemThi_L1, bool DiemThanhPhan_L2, bool DiemThi_L2)
        {
            int ID = 0;
            ID = oDKQHT_ChoNhapLaiDiem.AddChuyenDiem(IDXL_MonHocTrongKy, IDHT_User, DiemThanhPhan_L1, DiemThi_L1, DiemThanhPhan_L2, DiemThi_L2);
            mErrorMessage = oDKQHT_ChoNhapLaiDiem.ErrorMessages;
            mErrorNumber = oDKQHT_ChoNhapLaiDiem.ErrorNumber;
            return ID;
        }

        public void LuuDiemHienTai(int IDKQHT_ChoNhapLaiDiem, int IDXL_MonHocTrongKy)
        {
            oDKQHT_ChoNhapLaiDiem.LuuDiemHienTai(IDKQHT_ChoNhapLaiDiem, IDXL_MonHocTrongKy);
            mErrorMessage = oDKQHT_ChoNhapLaiDiem.ErrorMessages;
            mErrorNumber = oDKQHT_ChoNhapLaiDiem.ErrorNumber;
        }

        public void Update(KQHT_ChoNhapLaiDiemInfo pKQHT_ChoNhapLaiDiemInfo)
        {
            oDKQHT_ChoNhapLaiDiem.Update(pKQHT_ChoNhapLaiDiemInfo);
            mErrorMessage = oDKQHT_ChoNhapLaiDiem.ErrorMessages;
            mErrorNumber = oDKQHT_ChoNhapLaiDiem.ErrorNumber;
        }
        
        public void Delete(KQHT_ChoNhapLaiDiemInfo pKQHT_ChoNhapLaiDiemInfo)
        {
            oDKQHT_ChoNhapLaiDiem.Delete(pKQHT_ChoNhapLaiDiemInfo);
            mErrorMessage = oDKQHT_ChoNhapLaiDiem.ErrorMessages;
            mErrorNumber = oDKQHT_ChoNhapLaiDiem.ErrorNumber;
        }

        public List<KQHT_ChoNhapLaiDiemInfo> GetList(KQHT_ChoNhapLaiDiemInfo pKQHT_ChoNhapLaiDiemInfo)
        {
            List<KQHT_ChoNhapLaiDiemInfo> oKQHT_ChoNhapLaiDiemInfoList = new List<KQHT_ChoNhapLaiDiemInfo>();
            DataTable dtb = Get(pKQHT_ChoNhapLaiDiemInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    pKQHT_ChoNhapLaiDiemInfo = new KQHT_ChoNhapLaiDiemInfo();

                    pKQHT_ChoNhapLaiDiemInfo.KQHT_ChoNhapLaiDiemID = int.Parse(dtb.Rows[i][pKQHT_ChoNhapLaiDiemInfo.strKQHT_ChoNhapLaiDiemID].ToString());
                    pKQHT_ChoNhapLaiDiemInfo.IDKQHT_DaChuyenDiem = int.Parse(dtb.Rows[i][pKQHT_ChoNhapLaiDiemInfo.strIDKQHT_DaChuyenDiem].ToString());
                    pKQHT_ChoNhapLaiDiemInfo.IDHT_User = int.Parse(dtb.Rows[i][pKQHT_ChoNhapLaiDiemInfo.strIDHT_User].ToString());
                    pKQHT_ChoNhapLaiDiemInfo.LanChoNhapLai = int.Parse(dtb.Rows[i][pKQHT_ChoNhapLaiDiemInfo.strLanChoNhapLai].ToString());
                    pKQHT_ChoNhapLaiDiemInfo.NgayChoNhapLai = DateTime.Parse(dtb.Rows[i][pKQHT_ChoNhapLaiDiemInfo.strNgayChoNhapLai].ToString());
                    pKQHT_ChoNhapLaiDiemInfo.DiemThanhPhan_L1 = bool.Parse(dtb.Rows[i][pKQHT_ChoNhapLaiDiemInfo.strDiemThanhPhan_L1].ToString());
                    pKQHT_ChoNhapLaiDiemInfo.DiemThi_L1 = bool.Parse(dtb.Rows[i][pKQHT_ChoNhapLaiDiemInfo.strDiemThi_L1].ToString());
                    pKQHT_ChoNhapLaiDiemInfo.DiemThanhPhan_L2 = bool.Parse(dtb.Rows[i][pKQHT_ChoNhapLaiDiemInfo.strDiemThanhPhan_L2].ToString());
                    pKQHT_ChoNhapLaiDiemInfo.DiemThi_L2 = bool.Parse(dtb.Rows[i][pKQHT_ChoNhapLaiDiemInfo.strDiemThi_L2].ToString());
                    
                    oKQHT_ChoNhapLaiDiemInfoList.Add(pKQHT_ChoNhapLaiDiemInfo);
                }
            }
            return oKQHT_ChoNhapLaiDiemInfoList;
        }
        
        public void ToDataRow(KQHT_ChoNhapLaiDiemInfo pKQHT_ChoNhapLaiDiemInfo, ref DataRow dr)
        {

			dr[pKQHT_ChoNhapLaiDiemInfo.strKQHT_ChoNhapLaiDiemID] = pKQHT_ChoNhapLaiDiemInfo.KQHT_ChoNhapLaiDiemID;
			dr[pKQHT_ChoNhapLaiDiemInfo.strIDKQHT_DaChuyenDiem] = pKQHT_ChoNhapLaiDiemInfo.IDKQHT_DaChuyenDiem;
			dr[pKQHT_ChoNhapLaiDiemInfo.strIDHT_User] = pKQHT_ChoNhapLaiDiemInfo.IDHT_User;
			dr[pKQHT_ChoNhapLaiDiemInfo.strLanChoNhapLai] = pKQHT_ChoNhapLaiDiemInfo.LanChoNhapLai;
			dr[pKQHT_ChoNhapLaiDiemInfo.strNgayChoNhapLai] = pKQHT_ChoNhapLaiDiemInfo.NgayChoNhapLai;
			dr[pKQHT_ChoNhapLaiDiemInfo.strDiemThanhPhan_L1] = pKQHT_ChoNhapLaiDiemInfo.DiemThanhPhan_L1;
			dr[pKQHT_ChoNhapLaiDiemInfo.strDiemThi_L1] = pKQHT_ChoNhapLaiDiemInfo.DiemThi_L1;
			dr[pKQHT_ChoNhapLaiDiemInfo.strDiemThanhPhan_L2] = pKQHT_ChoNhapLaiDiemInfo.DiemThanhPhan_L2;
			dr[pKQHT_ChoNhapLaiDiemInfo.strDiemThi_L2] = pKQHT_ChoNhapLaiDiemInfo.DiemThi_L2;
        }
        
        public void ToInfo(ref KQHT_ChoNhapLaiDiemInfo pKQHT_ChoNhapLaiDiemInfo, DataRow dr)
        {

			pKQHT_ChoNhapLaiDiemInfo.KQHT_ChoNhapLaiDiemID = int.Parse(dr[pKQHT_ChoNhapLaiDiemInfo.strKQHT_ChoNhapLaiDiemID].ToString());
			pKQHT_ChoNhapLaiDiemInfo.IDKQHT_DaChuyenDiem = int.Parse(dr[pKQHT_ChoNhapLaiDiemInfo.strIDKQHT_DaChuyenDiem].ToString());
			pKQHT_ChoNhapLaiDiemInfo.IDHT_User = int.Parse(dr[pKQHT_ChoNhapLaiDiemInfo.strIDHT_User].ToString());
			pKQHT_ChoNhapLaiDiemInfo.LanChoNhapLai = int.Parse(dr[pKQHT_ChoNhapLaiDiemInfo.strLanChoNhapLai].ToString());
			pKQHT_ChoNhapLaiDiemInfo.NgayChoNhapLai = DateTime.Parse(dr[pKQHT_ChoNhapLaiDiemInfo.strNgayChoNhapLai].ToString());
			pKQHT_ChoNhapLaiDiemInfo.DiemThanhPhan_L1 = bool.Parse(dr[pKQHT_ChoNhapLaiDiemInfo.strDiemThanhPhan_L1].ToString());
			pKQHT_ChoNhapLaiDiemInfo.DiemThi_L1 = bool.Parse(dr[pKQHT_ChoNhapLaiDiemInfo.strDiemThi_L1].ToString());
			pKQHT_ChoNhapLaiDiemInfo.DiemThanhPhan_L2 = bool.Parse(dr[pKQHT_ChoNhapLaiDiemInfo.strDiemThanhPhan_L2].ToString());
			pKQHT_ChoNhapLaiDiemInfo.DiemThi_L2 = bool.Parse(dr[pKQHT_ChoNhapLaiDiemInfo.strDiemThi_L2].ToString());
        }
    }
}
