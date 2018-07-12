using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_MonHoc_CT_KhoiKienThuc : cBBase
    {
        private cDKQHT_MonHoc_CT_KhoiKienThuc oDKQHT_MonHoc_CT_KhoiKienThuc;
        private KQHT_MonHoc_CT_KhoiKienThucInfo oKQHT_MonHoc_CT_KhoiKienThucInfo;

        public cBKQHT_MonHoc_CT_KhoiKienThuc()        
        {
            oDKQHT_MonHoc_CT_KhoiKienThuc = new cDKQHT_MonHoc_CT_KhoiKienThuc();
        }

        public DataTable Get(KQHT_MonHoc_CT_KhoiKienThucInfo pKQHT_MonHoc_CT_KhoiKienThucInfo)        
        {
            return oDKQHT_MonHoc_CT_KhoiKienThuc.Get(pKQHT_MonHoc_CT_KhoiKienThucInfo);
        }

        public int Add(KQHT_MonHoc_CT_KhoiKienThucInfo pKQHT_MonHoc_CT_KhoiKienThucInfo)
        {
			int ID = 0;
            ID = oDKQHT_MonHoc_CT_KhoiKienThuc.Add(pKQHT_MonHoc_CT_KhoiKienThucInfo);
            mErrorMessage = oDKQHT_MonHoc_CT_KhoiKienThuc.ErrorMessages;
            mErrorNumber = oDKQHT_MonHoc_CT_KhoiKienThuc.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_MonHoc_CT_KhoiKienThucInfo pKQHT_MonHoc_CT_KhoiKienThucInfo)
        {
            oDKQHT_MonHoc_CT_KhoiKienThuc.Update(pKQHT_MonHoc_CT_KhoiKienThucInfo);
            mErrorMessage = oDKQHT_MonHoc_CT_KhoiKienThuc.ErrorMessages;
            mErrorNumber = oDKQHT_MonHoc_CT_KhoiKienThuc.ErrorNumber;
        }
        
        public void Delete(KQHT_MonHoc_CT_KhoiKienThucInfo pKQHT_MonHoc_CT_KhoiKienThucInfo)
        {
            oDKQHT_MonHoc_CT_KhoiKienThuc.Delete(pKQHT_MonHoc_CT_KhoiKienThucInfo);
            mErrorMessage = oDKQHT_MonHoc_CT_KhoiKienThuc.ErrorMessages;
            mErrorNumber = oDKQHT_MonHoc_CT_KhoiKienThuc.ErrorNumber;
        }

        public List<KQHT_MonHoc_CT_KhoiKienThucInfo> GetList(KQHT_MonHoc_CT_KhoiKienThucInfo pKQHT_MonHoc_CT_KhoiKienThucInfo)
        {
            List<KQHT_MonHoc_CT_KhoiKienThucInfo> oKQHT_MonHoc_CT_KhoiKienThucInfoList = new List<KQHT_MonHoc_CT_KhoiKienThucInfo>();
            DataTable dtb = Get(pKQHT_MonHoc_CT_KhoiKienThucInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_MonHoc_CT_KhoiKienThucInfo = new KQHT_MonHoc_CT_KhoiKienThucInfo();

                    oKQHT_MonHoc_CT_KhoiKienThucInfo.KQHT_MonHoc_CT_KhoiKienThucID = int.Parse(dtb.Rows[i]["KQHT_MonHoc_CT_KhoiKienThucID"].ToString());
                    oKQHT_MonHoc_CT_KhoiKienThucInfo.IDKQHT_CT_KhoiKienThuc = int.Parse(dtb.Rows[i]["IDKQHT_CT_KhoiKienThuc"].ToString());
                    oKQHT_MonHoc_CT_KhoiKienThucInfo.IDDM_MonHoc = int.Parse(dtb.Rows[i]["IDDM_MonHoc"].ToString());
                    oKQHT_MonHoc_CT_KhoiKienThucInfo.SoHocTrinh = double.Parse(dtb.Rows[i]["SoHocTrinh"].ToString());
                    oKQHT_MonHoc_CT_KhoiKienThucInfo.SoTiet = int.Parse(dtb.Rows[i]["SoTiet"].ToString());
                    oKQHT_MonHoc_CT_KhoiKienThucInfo.LyThuyet = int.Parse(dtb.Rows[i]["LyThuyet"].ToString());
                    oKQHT_MonHoc_CT_KhoiKienThucInfo.ThucHanh = int.Parse(dtb.Rows[i]["ThucHanh"].ToString());
                    oKQHT_MonHoc_CT_KhoiKienThucInfo.LoaiTietKhac1 = int.Parse(dtb.Rows[i]["LoaiTietKhac1"].ToString());
                    oKQHT_MonHoc_CT_KhoiKienThucInfo.LoaiTietKhac2 = int.Parse(dtb.Rows[i]["LoaiTietKhac2"].ToString());
                    oKQHT_MonHoc_CT_KhoiKienThucInfo.ChoPhepXepLich = bool.Parse(dtb.Rows[i]["ChoPhepXepLich"].ToString());
                    oKQHT_MonHoc_CT_KhoiKienThucInfo.IDDM_HinhThucThi = int.Parse(dtb.Rows[i]["IDDM_HinhThucThi"].ToString());
                    oKQHT_MonHoc_CT_KhoiKienThucInfo.TuChon = bool.Parse(dtb.Rows[i]["TuChon"].ToString());
                    oKQHT_MonHoc_CT_KhoiKienThucInfo.SapXep = int.Parse(dtb.Rows[i]["SapXep"].ToString());
                    
                    oKQHT_MonHoc_CT_KhoiKienThucInfoList.Add(oKQHT_MonHoc_CT_KhoiKienThucInfo);
                }
            }
            return oKQHT_MonHoc_CT_KhoiKienThucInfoList;
        }
        
        public void ToDataRow(KQHT_MonHoc_CT_KhoiKienThucInfo pKQHT_MonHoc_CT_KhoiKienThucInfo, ref DataRow dr)
        {
			dr[pKQHT_MonHoc_CT_KhoiKienThucInfo.strKQHT_MonHoc_CT_KhoiKienThucID] = pKQHT_MonHoc_CT_KhoiKienThucInfo.KQHT_MonHoc_CT_KhoiKienThucID;
			dr[pKQHT_MonHoc_CT_KhoiKienThucInfo.strIDKQHT_CT_KhoiKienThuc] = pKQHT_MonHoc_CT_KhoiKienThucInfo.IDKQHT_CT_KhoiKienThuc;
			dr[pKQHT_MonHoc_CT_KhoiKienThucInfo.strIDDM_MonHoc] = pKQHT_MonHoc_CT_KhoiKienThucInfo.IDDM_MonHoc;
			dr[pKQHT_MonHoc_CT_KhoiKienThucInfo.strSoHocTrinh] = pKQHT_MonHoc_CT_KhoiKienThucInfo.SoHocTrinh;
			dr[pKQHT_MonHoc_CT_KhoiKienThucInfo.strSoTiet] = pKQHT_MonHoc_CT_KhoiKienThucInfo.SoTiet;
			dr[pKQHT_MonHoc_CT_KhoiKienThucInfo.strLyThuyet] = pKQHT_MonHoc_CT_KhoiKienThucInfo.LyThuyet;
			dr[pKQHT_MonHoc_CT_KhoiKienThucInfo.strThucHanh] = pKQHT_MonHoc_CT_KhoiKienThucInfo.ThucHanh;
			dr[pKQHT_MonHoc_CT_KhoiKienThucInfo.strLoaiTietKhac1] = pKQHT_MonHoc_CT_KhoiKienThucInfo.LoaiTietKhac1;
			dr[pKQHT_MonHoc_CT_KhoiKienThucInfo.strLoaiTietKhac2] = pKQHT_MonHoc_CT_KhoiKienThucInfo.LoaiTietKhac2;
			dr[pKQHT_MonHoc_CT_KhoiKienThucInfo.strChoPhepXepLich] = pKQHT_MonHoc_CT_KhoiKienThucInfo.ChoPhepXepLich;
			dr[pKQHT_MonHoc_CT_KhoiKienThucInfo.strIDDM_HinhThucThi] = pKQHT_MonHoc_CT_KhoiKienThucInfo.IDDM_HinhThucThi;
			dr[pKQHT_MonHoc_CT_KhoiKienThucInfo.strTuChon] = pKQHT_MonHoc_CT_KhoiKienThucInfo.TuChon;
			dr[pKQHT_MonHoc_CT_KhoiKienThucInfo.strSapXep] = pKQHT_MonHoc_CT_KhoiKienThucInfo.SapXep;
            dr[pKQHT_MonHoc_CT_KhoiKienThucInfo.strTinhDiemToanKhoa] = pKQHT_MonHoc_CT_KhoiKienThucInfo.TinhDiemToanKhoa;
        }

        public DataTable GetDanhSachMon(int IDKQHT_CT_KhoiKienThuc)
        {
            return oDKQHT_MonHoc_CT_KhoiKienThuc.GetDanhSach(IDKQHT_CT_KhoiKienThuc);
        }
    }
}
