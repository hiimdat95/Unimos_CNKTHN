using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_DiemTongKetToanKhoa : cBBase
    {
        private cDKQHT_DiemTongKetToanKhoa oDKQHT_DiemTongKetToanKhoa;
        private KQHT_DiemTongKetToanKhoaInfo oKQHT_DiemTongKetToanKhoaInfo;

        public cBKQHT_DiemTongKetToanKhoa()        
        {
            oDKQHT_DiemTongKetToanKhoa = new cDKQHT_DiemTongKetToanKhoa();
        }

        public DataTable Get(KQHT_DiemTongKetToanKhoaInfo pKQHT_DiemTongKetToanKhoaInfo)        
        {
            return oDKQHT_DiemTongKetToanKhoa.Get(pKQHT_DiemTongKetToanKhoaInfo);
        }

        public DataTable GetDanhSach(int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            return oDKQHT_DiemTongKetToanKhoa.GetDanhSach(IDDM_Lop, IDDM_NamHoc, HocKy);
        }

        public DataTable GetTongHop(DM_LopInfo pDM_LopInfo, int IDDM_NamHoc, int LanThi)
        {
            return oDKQHT_DiemTongKetToanKhoa.GetTongHop(pDM_LopInfo,IDDM_NamHoc, LanThi);
        }

        public DataTable GetDiemTotNghieps(DM_LopInfo pDM_LopInfo, int IDDM_NamHoc, int LanThi)
        {
            return oDKQHT_DiemTongKetToanKhoa.GetDiemTotNghieps(pDM_LopInfo, IDDM_NamHoc, LanThi);
        }

        public DataTable GetDanhSachNoMon(DM_LopInfo pDM_LopInfo)
        {
            return oDKQHT_DiemTongKetToanKhoa.GetDanhSachNoMon(pDM_LopInfo);
        }

        public int Add(KQHT_DiemTongKetToanKhoaInfo pKQHT_DiemTongKetToanKhoaInfo)
        {
			int ID = 0;
            ID = oDKQHT_DiemTongKetToanKhoa.Add(pKQHT_DiemTongKetToanKhoaInfo);
            mErrorMessage = oDKQHT_DiemTongKetToanKhoa.ErrorMessages;
            mErrorNumber = oDKQHT_DiemTongKetToanKhoa.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_DiemTongKetToanKhoaInfo pKQHT_DiemTongKetToanKhoaInfo)
        {
            oDKQHT_DiemTongKetToanKhoa.Update(pKQHT_DiemTongKetToanKhoaInfo);
            mErrorMessage = oDKQHT_DiemTongKetToanKhoa.ErrorMessages;
            mErrorNumber = oDKQHT_DiemTongKetToanKhoa.ErrorNumber;
        }
        
        public void Delete(KQHT_DiemTongKetToanKhoaInfo pKQHT_DiemTongKetToanKhoaInfo)
        {
            oDKQHT_DiemTongKetToanKhoa.Delete(pKQHT_DiemTongKetToanKhoaInfo);
            mErrorMessage = oDKQHT_DiemTongKetToanKhoa.ErrorMessages;
            mErrorNumber = oDKQHT_DiemTongKetToanKhoa.ErrorNumber;
        }

        public List<KQHT_DiemTongKetToanKhoaInfo> GetList(KQHT_DiemTongKetToanKhoaInfo pKQHT_DiemTongKetToanKhoaInfo)
        {
            List<KQHT_DiemTongKetToanKhoaInfo> oKQHT_DiemTongKetToanKhoaInfoList = new List<KQHT_DiemTongKetToanKhoaInfo>();
            DataTable dtb = Get(pKQHT_DiemTongKetToanKhoaInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_DiemTongKetToanKhoaInfo = new KQHT_DiemTongKetToanKhoaInfo();

                    oKQHT_DiemTongKetToanKhoaInfo.@KQHT_DiemTongKetToanKhoaID = long.Parse(dtb.Rows[i]["KQHT_DiemTongKetToanKhoaID"].ToString());
                    oKQHT_DiemTongKetToanKhoaInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oKQHT_DiemTongKetToanKhoaInfo.Diem = double.Parse(dtb.Rows[i]["Diem"].ToString());
                    oKQHT_DiemTongKetToanKhoaInfo.IDDM_XepLoai = int.Parse(dtb.Rows[i]["IDDM_XepLoai"].ToString());
                    oKQHT_DiemTongKetToanKhoaInfo.GhiChu = dtb.Rows[i]["GhiChu"].ToString();
                    
                    oKQHT_DiemTongKetToanKhoaInfoList.Add(oKQHT_DiemTongKetToanKhoaInfo);
                }
            }
            return oKQHT_DiemTongKetToanKhoaInfoList;
        }
        
        public void ToDataRow(KQHT_DiemTongKetToanKhoaInfo pKQHT_DiemTongKetToanKhoaInfo, ref DataRow dr)
        {

            dr[pKQHT_DiemTongKetToanKhoaInfo.strKQHT_DiemTongKetToanKhoaID] = pKQHT_DiemTongKetToanKhoaInfo.@KQHT_DiemTongKetToanKhoaID;
			dr[pKQHT_DiemTongKetToanKhoaInfo.strIDSV_SinhVien] = pKQHT_DiemTongKetToanKhoaInfo.IDSV_SinhVien;
			dr[pKQHT_DiemTongKetToanKhoaInfo.strDiem] = pKQHT_DiemTongKetToanKhoaInfo.Diem;
			dr[pKQHT_DiemTongKetToanKhoaInfo.strIDDM_XepLoai] = pKQHT_DiemTongKetToanKhoaInfo.IDDM_XepLoai;
			dr[pKQHT_DiemTongKetToanKhoaInfo.strGhiChu] = pKQHT_DiemTongKetToanKhoaInfo.GhiChu;
        }
        
        public void ToInfo(ref KQHT_DiemTongKetToanKhoaInfo pKQHT_DiemTongKetToanKhoaInfo, DataRow dr)
        {

            pKQHT_DiemTongKetToanKhoaInfo.@KQHT_DiemTongKetToanKhoaID = long.Parse(dr[pKQHT_DiemTongKetToanKhoaInfo.strKQHT_DiemTongKetToanKhoaID].ToString());
			pKQHT_DiemTongKetToanKhoaInfo.IDSV_SinhVien = int.Parse(dr[pKQHT_DiemTongKetToanKhoaInfo.strIDSV_SinhVien].ToString());
			pKQHT_DiemTongKetToanKhoaInfo.Diem = double.Parse(dr[pKQHT_DiemTongKetToanKhoaInfo.strDiem].ToString());
			pKQHT_DiemTongKetToanKhoaInfo.IDDM_XepLoai = int.Parse(dr[pKQHT_DiemTongKetToanKhoaInfo.strIDDM_XepLoai].ToString());
			pKQHT_DiemTongKetToanKhoaInfo.GhiChu = dr[pKQHT_DiemTongKetToanKhoaInfo.strGhiChu].ToString();
        }
    }
}
