using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_QuyetDinhTotNghiep_SinhVien : cBBase
    {
        private cDKQHT_QuyetDinhTotNghiep_SinhVien oDKQHT_QuyetDinhTotNghiep_SinhVien;

        public cBKQHT_QuyetDinhTotNghiep_SinhVien()        
        {
            oDKQHT_QuyetDinhTotNghiep_SinhVien = new cDKQHT_QuyetDinhTotNghiep_SinhVien();
        }

        public DataTable Get(KQHT_QuyetDinhTotNghiep_SinhVienInfo pKQHT_QuyetDinhTotNghiep_SinhVienInfo)        
        {
            return oDKQHT_QuyetDinhTotNghiep_SinhVien.Get(pKQHT_QuyetDinhTotNghiep_SinhVienInfo);
        }

        public DataTable GetByQuyetDinh(int IDKQHT_QuyetDinhTotNghiep)
        {
            return oDKQHT_QuyetDinhTotNghiep_SinhVien.GetByQuyetDinh(IDKQHT_QuyetDinhTotNghiep);
        }

        public DataTable GetByIDDM_NamHoc(int IDDM_NamHoc)
        {
            return oDKQHT_QuyetDinhTotNghiep_SinhVien.GetByIDDM_NamHoc(IDDM_NamHoc);
        }

        public DataTable GetNotIn(DM_LopInfo pDM_LopInfo, int IDDM_NamHoc)
        {
            return oDKQHT_QuyetDinhTotNghiep_SinhVien.GetNotIn(pDM_LopInfo, IDDM_NamHoc);
        }

        public DataTable GetBangDiem(string IDSV_SinhViens, int IDDM_NamHoc, string TenNamHoc)
        {
            return oDKQHT_QuyetDinhTotNghiep_SinhVien.GetBangDiem(IDSV_SinhViens, IDDM_NamHoc, TenNamHoc);
        }

        public DataTable GetBangDiemLanCuoi(string IDSV_SinhViens, int IDDM_NamHoc, string TenNamHoc)
        {
            return oDKQHT_QuyetDinhTotNghiep_SinhVien.GetBangDiemLanCuoi(IDSV_SinhViens, IDDM_NamHoc, TenNamHoc);
        }

        public long Add(KQHT_QuyetDinhTotNghiep_SinhVienInfo pKQHT_QuyetDinhTotNghiep_SinhVienInfo)
        {
			long ID = 0;
            ID = oDKQHT_QuyetDinhTotNghiep_SinhVien.Add(pKQHT_QuyetDinhTotNghiep_SinhVienInfo);
            mErrorMessage = oDKQHT_QuyetDinhTotNghiep_SinhVien.ErrorMessages;
            mErrorNumber = oDKQHT_QuyetDinhTotNghiep_SinhVien.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_QuyetDinhTotNghiep_SinhVienInfo pKQHT_QuyetDinhTotNghiep_SinhVienInfo)
        {
            oDKQHT_QuyetDinhTotNghiep_SinhVien.Update(pKQHT_QuyetDinhTotNghiep_SinhVienInfo);
            mErrorMessage = oDKQHT_QuyetDinhTotNghiep_SinhVien.ErrorMessages;
            mErrorNumber = oDKQHT_QuyetDinhTotNghiep_SinhVien.ErrorNumber;
        }

        public void UpdateSoBang(int KQHT_QuyetDinhTotNghiep_SinhVienID, string SoBang)
        {
            oDKQHT_QuyetDinhTotNghiep_SinhVien.UpdateSoBang(KQHT_QuyetDinhTotNghiep_SinhVienID, SoBang);
            mErrorMessage = oDKQHT_QuyetDinhTotNghiep_SinhVien.ErrorMessages;
            mErrorNumber = oDKQHT_QuyetDinhTotNghiep_SinhVien.ErrorNumber;
        }
        
        public void Delete(KQHT_QuyetDinhTotNghiep_SinhVienInfo pKQHT_QuyetDinhTotNghiep_SinhVienInfo)
        {
            oDKQHT_QuyetDinhTotNghiep_SinhVien.Delete(pKQHT_QuyetDinhTotNghiep_SinhVienInfo);
            mErrorMessage = oDKQHT_QuyetDinhTotNghiep_SinhVien.ErrorMessages;
            mErrorNumber = oDKQHT_QuyetDinhTotNghiep_SinhVien.ErrorNumber;
        }

        public List<KQHT_QuyetDinhTotNghiep_SinhVienInfo> GetList(KQHT_QuyetDinhTotNghiep_SinhVienInfo pKQHT_QuyetDinhTotNghiep_SinhVienInfo)
        {
            List<KQHT_QuyetDinhTotNghiep_SinhVienInfo> oKQHT_QuyetDinhTotNghiep_SinhVienInfoList = new List<KQHT_QuyetDinhTotNghiep_SinhVienInfo>();
            DataTable dtb = Get(pKQHT_QuyetDinhTotNghiep_SinhVienInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    pKQHT_QuyetDinhTotNghiep_SinhVienInfo = new KQHT_QuyetDinhTotNghiep_SinhVienInfo();

                    pKQHT_QuyetDinhTotNghiep_SinhVienInfo.KQHT_QuyetDinhTotNghiep_SinhVienID = long.Parse(dtb.Rows[i][pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strKQHT_QuyetDinhTotNghiep_SinhVienID].ToString());
                    pKQHT_QuyetDinhTotNghiep_SinhVienInfo.IDKQHT_QuyetDinhTotNghiep = int.Parse(dtb.Rows[i][pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strIDKQHT_QuyetDinhTotNghiep].ToString());
                    pKQHT_QuyetDinhTotNghiep_SinhVienInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i][pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strIDSV_SinhVien].ToString());
                    if("" + dtb.Rows[i][pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strDiemMonTotNghiep1] != "")
                    	pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemMonTotNghiep1 = double.Parse(dtb.Rows[i][pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strDiemMonTotNghiep1].ToString());
                    if("" + dtb.Rows[i][pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strDiemMonTotNghiep2] != "")
                    	pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemMonTotNghiep2 = double.Parse(dtb.Rows[i][pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strDiemMonTotNghiep2].ToString());
                    if("" + dtb.Rows[i][pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strDiemMonTotNghiep3] != "")
                    	pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemMonTotNghiep3 = double.Parse(dtb.Rows[i][pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strDiemMonTotNghiep3].ToString());
                    if("" + dtb.Rows[i][pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strDiemMonTotNghiep4] != "")
                    	pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemMonTotNghiep4 = double.Parse(dtb.Rows[i][pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strDiemMonTotNghiep4].ToString());
                    if("" + dtb.Rows[i][pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strDiemTrungBinhChungToanKhoa] != "")
                    	pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemTrungBinhChungToanKhoa = double.Parse(dtb.Rows[i][pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strDiemTrungBinhChungToanKhoa].ToString());
                    if("" + dtb.Rows[i][pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strDiemTrungBinhChungTotNghiep] != "")
                    	pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemTrungBinhChungTotNghiep = double.Parse(dtb.Rows[i][pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strDiemTrungBinhChungTotNghiep].ToString());
                    if("" + dtb.Rows[i][pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strIDKQHT_XepLoaiTotNghiep] != "")
                    	pKQHT_QuyetDinhTotNghiep_SinhVienInfo.IDKQHT_XepLoaiTotNghiep = int.Parse(dtb.Rows[i][pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strIDKQHT_XepLoaiTotNghiep].ToString());
                    
                    oKQHT_QuyetDinhTotNghiep_SinhVienInfoList.Add(pKQHT_QuyetDinhTotNghiep_SinhVienInfo);
                }
            }
            return oKQHT_QuyetDinhTotNghiep_SinhVienInfoList;
        }
        
        public void ToDataRow(KQHT_QuyetDinhTotNghiep_SinhVienInfo pKQHT_QuyetDinhTotNghiep_SinhVienInfo, ref DataRow dr)
        {

			dr[pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strKQHT_QuyetDinhTotNghiep_SinhVienID] = pKQHT_QuyetDinhTotNghiep_SinhVienInfo.KQHT_QuyetDinhTotNghiep_SinhVienID;
			dr[pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strIDKQHT_QuyetDinhTotNghiep] = pKQHT_QuyetDinhTotNghiep_SinhVienInfo.IDKQHT_QuyetDinhTotNghiep;
			dr[pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strIDSV_SinhVien] = pKQHT_QuyetDinhTotNghiep_SinhVienInfo.IDSV_SinhVien;
			dr[pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strDiemMonTotNghiep1] = pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemMonTotNghiep1;
			dr[pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strDiemMonTotNghiep2] = pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemMonTotNghiep2;
			dr[pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strDiemMonTotNghiep3] = pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemMonTotNghiep3;
			dr[pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strDiemMonTotNghiep4] = pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemMonTotNghiep4;
			dr[pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strDiemTrungBinhChungToanKhoa] = pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemTrungBinhChungToanKhoa;
			dr[pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strDiemTrungBinhChungTotNghiep] = pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemTrungBinhChungTotNghiep;
			dr[pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strIDKQHT_XepLoaiTotNghiep] = pKQHT_QuyetDinhTotNghiep_SinhVienInfo.IDKQHT_XepLoaiTotNghiep;
        }
        
        public void ToInfo(ref KQHT_QuyetDinhTotNghiep_SinhVienInfo pKQHT_QuyetDinhTotNghiep_SinhVienInfo, DataRow dr)
        {

			pKQHT_QuyetDinhTotNghiep_SinhVienInfo.KQHT_QuyetDinhTotNghiep_SinhVienID = long.Parse(dr[pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strKQHT_QuyetDinhTotNghiep_SinhVienID].ToString());
			pKQHT_QuyetDinhTotNghiep_SinhVienInfo.IDKQHT_QuyetDinhTotNghiep = int.Parse(dr[pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strIDKQHT_QuyetDinhTotNghiep].ToString());
			pKQHT_QuyetDinhTotNghiep_SinhVienInfo.IDSV_SinhVien = int.Parse(dr[pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strIDSV_SinhVien].ToString());
			if("" + dr[pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strDiemMonTotNghiep1] != "")
				pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemMonTotNghiep1 = double.Parse(dr[pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strDiemMonTotNghiep1].ToString());
			if("" + dr[pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strDiemMonTotNghiep2] != "")
				pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemMonTotNghiep2 = double.Parse(dr[pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strDiemMonTotNghiep2].ToString());
			if("" + dr[pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strDiemMonTotNghiep3] != "")
				pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemMonTotNghiep3 = double.Parse(dr[pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strDiemMonTotNghiep3].ToString());
			if("" + dr[pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strDiemMonTotNghiep4] != "")
				pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemMonTotNghiep4 = double.Parse(dr[pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strDiemMonTotNghiep4].ToString());
			if("" + dr[pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strDiemTrungBinhChungToanKhoa] != "")
				pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemTrungBinhChungToanKhoa = double.Parse(dr[pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strDiemTrungBinhChungToanKhoa].ToString());
			if("" + dr[pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strDiemTrungBinhChungTotNghiep] != "")
				pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemTrungBinhChungTotNghiep = double.Parse(dr[pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strDiemTrungBinhChungTotNghiep].ToString());
			if("" + dr[pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strIDKQHT_XepLoaiTotNghiep] != "")
				pKQHT_QuyetDinhTotNghiep_SinhVienInfo.IDKQHT_XepLoaiTotNghiep = int.Parse(dr[pKQHT_QuyetDinhTotNghiep_SinhVienInfo.strIDKQHT_XepLoaiTotNghiep].ToString());
        }
    }
}
