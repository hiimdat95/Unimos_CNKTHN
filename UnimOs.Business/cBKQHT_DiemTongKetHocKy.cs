using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_DiemTongKetHocKy : cBBase
    {
        private cDKQHT_DiemTongKetHocKy oDKQHT_DiemTongKetHocKy;
        private KQHT_DiemTongKetHocKyInfo oKQHT_DiemTongKetHocKyInfo;

        public cBKQHT_DiemTongKetHocKy()        
        {
            oDKQHT_DiemTongKetHocKy = new cDKQHT_DiemTongKetHocKy();
        }

        public DataTable Get(KQHT_DiemTongKetHocKyInfo pKQHT_DiemTongKetHocKyInfo)        
        {
            return oDKQHT_DiemTongKetHocKy.Get(pKQHT_DiemTongKetHocKyInfo);
        }
        public DataTable GetDanhSach(int IDDM_Lop, int IDDM_NamHoc, int HocKy, int LanThi)
        {
            return oDKQHT_DiemTongKetHocKy.GetDanhSach(IDDM_Lop, IDDM_NamHoc, HocKy, LanThi);
        }
        public DataTable GetBangDiemThiTN(int SV_IDSinhVien)
        {
            return oDKQHT_DiemTongKetHocKy.GetDiemThiTN(SV_IDSinhVien);
        }
        public DataTable GetDiemTongKet(int SV_IDSinhVien, int IDDM_NamHoc, int HocKy)
        {
            return oDKQHT_DiemTongKetHocKy.GetDiemTongKet(SV_IDSinhVien, IDDM_NamHoc, HocKy);
        }
        public DataTable GetDiemTongKet_KQHT(int SV_IDSinhVien)
        {
            return oDKQHT_DiemTongKetHocKy.GetDiemTongKet_KQHT(SV_IDSinhVien);
        }
        public int Add(KQHT_DiemTongKetHocKyInfo pKQHT_DiemTongKetHocKyInfo)
        {
			int ID = 0;
            ID = oDKQHT_DiemTongKetHocKy.Add(pKQHT_DiemTongKetHocKyInfo);
            mErrorMessage = oDKQHT_DiemTongKetHocKy.ErrorMessages;
            mErrorNumber = oDKQHT_DiemTongKetHocKy.ErrorNumber;
            return ID;
        }

        public void UpdateTrangThai(int IDSV_SinhVien, int IDDM_NamHoc, int HocKy, int TrangThai, string GhiChu)
        {
            oDKQHT_DiemTongKetHocKy.UpdateTrangThai(IDSV_SinhVien, IDDM_NamHoc, HocKy, TrangThai, GhiChu);
            mErrorMessage = oDKQHT_DiemTongKetHocKy.ErrorMessages;
            mErrorNumber = oDKQHT_DiemTongKetHocKy.ErrorNumber;
        }

        public void Update(KQHT_DiemTongKetHocKyInfo pKQHT_DiemTongKetHocKyInfo)
        {
            oDKQHT_DiemTongKetHocKy.Update(pKQHT_DiemTongKetHocKyInfo);
            mErrorMessage = oDKQHT_DiemTongKetHocKy.ErrorMessages;
            mErrorNumber = oDKQHT_DiemTongKetHocKy.ErrorNumber;
        }
        
        public void Delete(KQHT_DiemTongKetHocKyInfo pKQHT_DiemTongKetHocKyInfo)
        {
            oDKQHT_DiemTongKetHocKy.Delete(pKQHT_DiemTongKetHocKyInfo);
            mErrorMessage = oDKQHT_DiemTongKetHocKy.ErrorMessages;
            mErrorNumber = oDKQHT_DiemTongKetHocKy.ErrorNumber;
        }

        public List<KQHT_DiemTongKetHocKyInfo> GetList(KQHT_DiemTongKetHocKyInfo pKQHT_DiemTongKetHocKyInfo)
        {
            List<KQHT_DiemTongKetHocKyInfo> oKQHT_DiemTongKetHocKyInfoList = new List<KQHT_DiemTongKetHocKyInfo>();
            DataTable dtb = Get(pKQHT_DiemTongKetHocKyInfo);
            if (dtb != null)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    oKQHT_DiemTongKetHocKyInfo = new KQHT_DiemTongKetHocKyInfo();

                    oKQHT_DiemTongKetHocKyInfo.KQHT_DiemTongKetHocKyID = int.Parse(dtb.Rows[i]["KQHT_DiemTongKetHocKyID"].ToString());
                    oKQHT_DiemTongKetHocKyInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oKQHT_DiemTongKetHocKyInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
                    oKQHT_DiemTongKetHocKyInfo.HocKy = int.Parse(dtb.Rows[i]["HocKy"].ToString());
                    oKQHT_DiemTongKetHocKyInfo.DiemL1 = double.Parse(dtb.Rows[i]["DiemL1"].ToString());
                    oKQHT_DiemTongKetHocKyInfo.IDDM_XepLoaiL1 = int.Parse(dtb.Rows[i]["IDDM_XepLoaiL1"].ToString());
                    oKQHT_DiemTongKetHocKyInfo.GhiChuL1 = dtb.Rows[i]["GhiChuL1"].ToString();
                    oKQHT_DiemTongKetHocKyInfo.DiemL2 = double.Parse(dtb.Rows[i]["DiemL2"].ToString());
                    oKQHT_DiemTongKetHocKyInfo.IDDM_XepLoaiL2 = int.Parse(dtb.Rows[i]["IDDM_XepLoaiL2"].ToString());
                    oKQHT_DiemTongKetHocKyInfo.GhiChuL2 = dtb.Rows[i]["GhiChuL2"].ToString();
                    oKQHT_DiemTongKetHocKyInfo.TrangThai = int.Parse(dtb.Rows[i]["TrangThai"].ToString());

                    oKQHT_DiemTongKetHocKyInfoList.Add(oKQHT_DiemTongKetHocKyInfo);
                }
            }
            return oKQHT_DiemTongKetHocKyInfoList;
        }

        public void ToDataRow(KQHT_DiemTongKetHocKyInfo pKQHT_DiemTongKetHocKyInfo, ref DataRow dr)
        {

            dr[pKQHT_DiemTongKetHocKyInfo.strKQHT_DiemTongKetHocKyID] = pKQHT_DiemTongKetHocKyInfo.KQHT_DiemTongKetHocKyID;
            dr[pKQHT_DiemTongKetHocKyInfo.strIDSV_SinhVien] = pKQHT_DiemTongKetHocKyInfo.IDSV_SinhVien;
            dr[pKQHT_DiemTongKetHocKyInfo.strIDDM_NamHoc] = pKQHT_DiemTongKetHocKyInfo.IDDM_NamHoc;
            dr[pKQHT_DiemTongKetHocKyInfo.strHocKy] = pKQHT_DiemTongKetHocKyInfo.HocKy;
            dr[pKQHT_DiemTongKetHocKyInfo.strDiemL1] = pKQHT_DiemTongKetHocKyInfo.DiemL1;
            dr[pKQHT_DiemTongKetHocKyInfo.strIDDM_XepLoaiL1] = pKQHT_DiemTongKetHocKyInfo.IDDM_XepLoaiL1;
            dr[pKQHT_DiemTongKetHocKyInfo.strGhiChuL1] = pKQHT_DiemTongKetHocKyInfo.GhiChuL1;
            dr[pKQHT_DiemTongKetHocKyInfo.strDiemL2] = pKQHT_DiemTongKetHocKyInfo.DiemL2;
            dr[pKQHT_DiemTongKetHocKyInfo.strIDDM_XepLoaiL2] = pKQHT_DiemTongKetHocKyInfo.IDDM_XepLoaiL2;
            dr[pKQHT_DiemTongKetHocKyInfo.strGhiChuL2] = pKQHT_DiemTongKetHocKyInfo.GhiChuL2;
            dr[pKQHT_DiemTongKetHocKyInfo.strTrangThai] = pKQHT_DiemTongKetHocKyInfo.TrangThai;
        }

        public void ToInfo(ref KQHT_DiemTongKetHocKyInfo pKQHT_DiemTongKetHocKyInfo, DataRow dr)
        {

            pKQHT_DiemTongKetHocKyInfo.KQHT_DiemTongKetHocKyID = int.Parse(dr[pKQHT_DiemTongKetHocKyInfo.strKQHT_DiemTongKetHocKyID].ToString());
            pKQHT_DiemTongKetHocKyInfo.IDSV_SinhVien = int.Parse(dr[pKQHT_DiemTongKetHocKyInfo.strIDSV_SinhVien].ToString());
            pKQHT_DiemTongKetHocKyInfo.IDDM_NamHoc = int.Parse(dr[pKQHT_DiemTongKetHocKyInfo.strIDDM_NamHoc].ToString());
            pKQHT_DiemTongKetHocKyInfo.HocKy = int.Parse(dr[pKQHT_DiemTongKetHocKyInfo.strHocKy].ToString());
            pKQHT_DiemTongKetHocKyInfo.DiemL1 = double.Parse(dr[pKQHT_DiemTongKetHocKyInfo.strDiemL1].ToString());
            pKQHT_DiemTongKetHocKyInfo.IDDM_XepLoaiL1 = int.Parse(dr[pKQHT_DiemTongKetHocKyInfo.strIDDM_XepLoaiL1].ToString());
            pKQHT_DiemTongKetHocKyInfo.GhiChuL1 = dr[pKQHT_DiemTongKetHocKyInfo.strGhiChuL1].ToString();
            pKQHT_DiemTongKetHocKyInfo.DiemL2 = double.Parse(dr[pKQHT_DiemTongKetHocKyInfo.strDiemL2].ToString());
            pKQHT_DiemTongKetHocKyInfo.IDDM_XepLoaiL2 = int.Parse(dr[pKQHT_DiemTongKetHocKyInfo.strIDDM_XepLoaiL2].ToString());
            pKQHT_DiemTongKetHocKyInfo.GhiChuL2 = dr[pKQHT_DiemTongKetHocKyInfo.strGhiChuL2].ToString();
            pKQHT_DiemTongKetHocKyInfo.TrangThai = int.Parse(dr[pKQHT_DiemTongKetHocKyInfo.strTrangThai].ToString());
        }
    }
}
