using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.wsBusiness;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Entity.Model;
using TruongViet.UnimOs.Data;
using UnimOs.wsBusiness.wsUnimOs;

namespace TruongViet.UnimOs.wsBusiness
{
    public class cBwsKQHT_DiemDanh : cBwsBase
    {
        private cDKQHT_DiemDanh oDKQHT_DiemDanh;
        private KQHT_DiemDanhInfo oKQHT_DiemDanhInfo;

        public cBwsKQHT_DiemDanh()
        {
            oDKQHT_DiemDanh = new cDKQHT_DiemDanh();
        }

        public DataTable Get(KQHT_DiemDanhInfo pKQHT_DiemDanhInfo)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_DiemDanh_GetResult>(client.cDKQHT_DiemDanh_Get(GlobalVar.MaXacThuc, pKQHT_DiemDanhInfo));
            }
        }

        public DataTable GetDanhSach(int IDDM_Lop, int IDXL_MonHocTrongKy, int IDDM_NamHoc, int HocKy)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_DiemDanh_GetDanhSachResult>(client.cDKQHT_DiemDanh_GetDanhSach(GlobalVar.MaXacThuc, IDDM_Lop, IDXL_MonHocTrongKy, IDDM_NamHoc, HocKy));
            }
        }

        public DataTable GetByLop(int IDDM_Lop, int IDXL_MonHocTrongKy, int DiemLan)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_DiemDanh_GetByLopResult>(client.cDKQHT_DiemDanh_GetByLop(GlobalVar.MaXacThuc, IDDM_Lop, IDXL_MonHocTrongKy, DiemLan));
            }
        }

        public DataTable ChoNhapLaiDiem_GetByLop(int IDKQHT_ChoNhapLaiDiem)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_DiemDanh_ChoNhapLaiDiem_GetByLopResult>(client.cDKQHT_DiemDanh_ChoNhapLaiDiem_GetByLop(GlobalVar.MaXacThuc, IDKQHT_ChoNhapLaiDiem));
            }
        }

        public int Add(KQHT_DiemDanhInfo pKQHT_DiemDanhInfo)
        {
            int ID = 0;
            var client = new UnimOsServiceClient();
            ID = client.cDKQHT_DiemDanh_Add(GlobalVar.MaXacThuc, pKQHT_DiemDanhInfo);
            client.Close();
            mErrorMessage = oDKQHT_DiemDanh.ErrorMessages;
            mErrorNumber = oDKQHT_DiemDanh.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_DiemDanhInfo pKQHT_DiemDanhInfo)
        {
            var client = new UnimOsServiceClient();
            client.cDKQHT_DiemDanh_Update(GlobalVar.MaXacThuc, pKQHT_DiemDanhInfo);
            client.Close();
            mErrorMessage = oDKQHT_DiemDanh.ErrorMessages;
            mErrorNumber = oDKQHT_DiemDanh.ErrorNumber;
        }

        public void Delete(KQHT_DiemDanhInfo pKQHT_DiemDanhInfo)
        {
            var client = new UnimOsServiceClient();
            client.cDKQHT_DiemDanh_Delete(GlobalVar.MaXacThuc, pKQHT_DiemDanhInfo);
            client.Close();
            mErrorMessage = oDKQHT_DiemDanh.ErrorMessages;
            mErrorNumber = oDKQHT_DiemDanh.ErrorNumber;
        }

        public void DeleteByInfo(int IDSV_SinhVien, int IDXL_MonHocTrongKy, string LyDo, int DiemLan)
        {
            var client = new UnimOsServiceClient();
            client.cDKQHT_DiemDanh_DeleteByInfo(GlobalVar.MaXacThuc, IDSV_SinhVien, IDXL_MonHocTrongKy, LyDo, DiemLan);
            client.Close();
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
