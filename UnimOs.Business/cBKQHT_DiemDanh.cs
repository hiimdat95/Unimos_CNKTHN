using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_DiemDanh : cBBase
    {
        private cDKQHT_DiemDanh oDKQHT_DiemDanh;
        private KQHT_DiemDanhInfo oKQHT_DiemDanhInfo;

        public cBKQHT_DiemDanh()        
        {
            oDKQHT_DiemDanh = new cDKQHT_DiemDanh();
        }

        public DataTable Get(KQHT_DiemDanhInfo pKQHT_DiemDanhInfo)        
        {
            return oDKQHT_DiemDanh.Get(pKQHT_DiemDanhInfo);
        }

        public DataTable GetDanhSach(int IDDM_Lop, int IDXL_MonHocTrongKy, int IDDM_NamHoc, int HocKy)
        {
            return oDKQHT_DiemDanh.GetDanhSach(IDDM_Lop, IDXL_MonHocTrongKy, IDDM_NamHoc, HocKy);
        }

        public DataTable GetByLop(int IDDM_Lop, int IDXL_MonHocTrongKy, int DiemLan)
        {
            return oDKQHT_DiemDanh.GetByLop(IDDM_Lop, IDXL_MonHocTrongKy, DiemLan);
        }

        public DataTable ChoNhapLaiDiem_GetByLop(int IDKQHT_ChoNhapLaiDiem)
        {
            return oDKQHT_DiemDanh.ChoNhapLaiDiem_GetByLop(IDKQHT_ChoNhapLaiDiem);
        }

        public int Add(KQHT_DiemDanhInfo pKQHT_DiemDanhInfo)
        {
			int ID = 0;
            ID = oDKQHT_DiemDanh.Add(pKQHT_DiemDanhInfo);
            mErrorMessage = oDKQHT_DiemDanh.ErrorMessages;
            mErrorNumber = oDKQHT_DiemDanh.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_DiemDanhInfo pKQHT_DiemDanhInfo)
        {
            oDKQHT_DiemDanh.Update(pKQHT_DiemDanhInfo);
            mErrorMessage = oDKQHT_DiemDanh.ErrorMessages;
            mErrorNumber = oDKQHT_DiemDanh.ErrorNumber;
        }
        
        public void Delete(KQHT_DiemDanhInfo pKQHT_DiemDanhInfo)
        {
            oDKQHT_DiemDanh.Delete(pKQHT_DiemDanhInfo);
            mErrorMessage = oDKQHT_DiemDanh.ErrorMessages;
            mErrorNumber = oDKQHT_DiemDanh.ErrorNumber;
        }

        public void DeleteByInfo(int IDSV_SinhVien, int IDXL_MonHocTrongKy, string LyDo, int DiemLan)
        {
            oDKQHT_DiemDanh.DeleteByInfo(IDSV_SinhVien, IDXL_MonHocTrongKy, LyDo, DiemLan);
            mErrorMessage = oDKQHT_DiemDanh.ErrorMessages;
            mErrorNumber = oDKQHT_DiemDanh.ErrorNumber;
        }

        public List<KQHT_DiemDanhInfo> GetList(KQHT_DiemDanhInfo pKQHT_DiemDanhInfo)
        {
            List<KQHT_DiemDanhInfo> oKQHT_DiemDanhInfoList = new List<KQHT_DiemDanhInfo>();
            DataTable dtb = Get(pKQHT_DiemDanhInfo);
            if (dtb != null)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    oKQHT_DiemDanhInfo = new KQHT_DiemDanhInfo();

                    oKQHT_DiemDanhInfo.KQHT_DiemDanhID = int.Parse(dtb.Rows[i]["KQHT_DiemDanhID"].ToString());
                    oKQHT_DiemDanhInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oKQHT_DiemDanhInfo.IDXL_MonHocTrongKy = int.Parse(dtb.Rows[i]["IDXL_MonHocTrongKy"].ToString());
                    oKQHT_DiemDanhInfo.CoLyDo = int.Parse(dtb.Rows[i]["CoLyDo"].ToString());
                    oKQHT_DiemDanhInfo.KhongLyDo = int.Parse(dtb.Rows[i]["KhongLyDo"].ToString());

                    oKQHT_DiemDanhInfoList.Add(oKQHT_DiemDanhInfo);
                }
            }
            return oKQHT_DiemDanhInfoList;
        }

        public void ToDataRow(KQHT_DiemDanhInfo pKQHT_DiemDanhInfo, ref DataRow dr)
        {

            dr[pKQHT_DiemDanhInfo.strKQHT_DiemDanhID] = pKQHT_DiemDanhInfo.KQHT_DiemDanhID;
            dr[pKQHT_DiemDanhInfo.strIDSV_SinhVien] = pKQHT_DiemDanhInfo.IDSV_SinhVien;
            dr[pKQHT_DiemDanhInfo.strIDXL_MonHocTrongKy] = pKQHT_DiemDanhInfo.IDXL_MonHocTrongKy;
            dr[pKQHT_DiemDanhInfo.strCoLyDo] = pKQHT_DiemDanhInfo.CoLyDo;
            dr[pKQHT_DiemDanhInfo.strKhongLyDo] = pKQHT_DiemDanhInfo.KhongLyDo;
        }

        public void ToInfo(ref KQHT_DiemDanhInfo pKQHT_DiemDanhInfo, DataRow dr)
        {

            pKQHT_DiemDanhInfo.KQHT_DiemDanhID = int.Parse(dr[pKQHT_DiemDanhInfo.strKQHT_DiemDanhID].ToString());
            pKQHT_DiemDanhInfo.IDSV_SinhVien = int.Parse(dr[pKQHT_DiemDanhInfo.strIDSV_SinhVien].ToString());
            pKQHT_DiemDanhInfo.IDXL_MonHocTrongKy = int.Parse(dr[pKQHT_DiemDanhInfo.strIDXL_MonHocTrongKy].ToString());
            pKQHT_DiemDanhInfo.CoLyDo = int.Parse(dr[pKQHT_DiemDanhInfo.strCoLyDo].ToString());
            pKQHT_DiemDanhInfo.KhongLyDo = int.Parse(dr[pKQHT_DiemDanhInfo.strKhongLyDo].ToString());
        }
    }
}
