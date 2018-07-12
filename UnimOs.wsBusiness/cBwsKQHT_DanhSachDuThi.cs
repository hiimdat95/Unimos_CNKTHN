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
    public class cBwsKQHT_DanhSachDuThi : cBwsBase
    {
        private cDKQHT_DanhSachDuThi oDKQHT_DanhSachDuThi;
        private KQHT_DanhSachDuThiInfo oKQHT_DanhSachDuThiInfo;

        public cBwsKQHT_DanhSachDuThi()
        {
            oDKQHT_DanhSachDuThi = new cDKQHT_DanhSachDuThi();
        }

        //public DataTable Get(KQHT_DanhSachDuThiInfo pKQHT_DanhSachDuThiInfo)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return ConvertList.ToDataTable<KQHT_DanhSachDuThiInfo>(client.cDKQHT_DanhSachDuThi_Get(GlobalVar.MaXacThuc, pKQHT_DanhSachDuThiInfo));
        //    }
        //}

        public DataTable GetByIDToChucThi(int IDKQHT_ToChucThi)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_DanhSachDuThi_GetByIDToChucThiResult>(client.cDKQHT_DanhSachDuThi_GetByIDToChucThi(GlobalVar.MaXacThuc, IDKQHT_ToChucThi));
            }
        }

        public DataTable GetDanhSach(int IDDM_Lop, long IDXL_MonHocTrongKy, int LanThi)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_DanhSachDuThi_GetDanhSachResult>(client.cDKQHT_DanhSachDuThi_GetDanhSach(GlobalVar.MaXacThuc, IDDM_Lop, IDXL_MonHocTrongKy, LanThi));
            }
        }

        public DataTable GetNhapDiem(long IDXL_MonHocTrongKy, int LanThi)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_DanhSachDuThi_GetNhapDiemResult>(client.cDKQHT_DanhSachDuThi_GetNhapDiem(GlobalVar.MaXacThuc, IDXL_MonHocTrongKy, LanThi));
            }
        }

        public bool GetDaChuyenDiemByMonHocTrongKy(long IDXL_MonHocTrongKy, int LanThi)
        {
            var client = new UnimOsServiceClient();
            DataTable dt = ConvertList.ToDataTable<sp_KQHT_DanhSachDuThi_GetDaChuyenDiemByMonHocTrongKyResult>(client.cDKQHT_DanhSachDuThi_GetDaChuyenDiemByMonHocTrongKy(GlobalVar.MaXacThuc, IDXL_MonHocTrongKy, LanThi));
            client.Close();
            if (dt.Rows.Count <= 0)
                return false;
            return bool.Parse(dt.Rows[0]["IsDaChuyen"].ToString());
        }

        //public int Add(KQHT_DanhSachDuThiInfo pKQHT_DanhSachDuThiInfo)
        //{
        //    int ID = 0;
        //    var client = new UnimOsServiceClient();
        //    ID = client.cDKQHT_DanhSachDuThi_Add(GlobalVar.MaXacThuc, pKQHT_DanhSachDuThiInfo);
        //    client.Close();
        //    mErrorMessage = oDKQHT_DanhSachDuThi.ErrorMessages;
        //    mErrorNumber = oDKQHT_DanhSachDuThi.ErrorNumber;
        //    return ID;
        //}

        //public void Update(KQHT_DanhSachDuThiInfo pKQHT_DanhSachDuThiInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDKQHT_DanhSachDuThi_Update(GlobalVar.MaXacThuc, pKQHT_DanhSachDuThiInfo);
        //    client.Close();
        //    mErrorMessage = oDKQHT_DanhSachDuThi.ErrorMessages;
        //    mErrorNumber = oDKQHT_DanhSachDuThi.ErrorNumber;
        //}

        public void UpdateSoPhach(string SoPhach, int TuiThiSo, double KQHT_DanhSachDuThiID)
        {
            var client = new UnimOsServiceClient();
            client.cDKQHT_DanhSachDuThi_UpdateSoPhach(GlobalVar.MaXacThuc, SoPhach, TuiThiSo, KQHT_DanhSachDuThiID);
            client.Close();
            mErrorMessage = oDKQHT_DanhSachDuThi.ErrorMessages;
            mErrorNumber = oDKQHT_DanhSachDuThi.ErrorNumber;
        }

        public void UpdateDiem(double Diem, double KQHT_DanhSachDuThiID)
        {
            var client = new UnimOsServiceClient();
            client.cDKQHT_DanhSachDuThi_UpdateDiem(GlobalVar.MaXacThuc, Diem, KQHT_DanhSachDuThiID);
            client.Close();
            mErrorMessage = oDKQHT_DanhSachDuThi.ErrorMessages;
            mErrorNumber = oDKQHT_DanhSachDuThi.ErrorNumber;
        }

        public void UpdateDaChuyenDiem(bool IsDaChuyen, double IDXL_MonHocTrongKy, int LanThi)
        {
            var client = new UnimOsServiceClient();
            client.cDKQHT_DanhSachDuThi_UpdateDaChuyenDiem(GlobalVar.MaXacThuc, IsDaChuyen, IDXL_MonHocTrongKy, LanThi);
            client.Close();
            mErrorMessage = oDKQHT_DanhSachDuThi.ErrorMessages;
            mErrorNumber = oDKQHT_DanhSachDuThi.ErrorNumber;
        }

        public void UpdateDaChuyenDiemByToChucThi(bool IsDaChuyen, int IDKQHT_ToChucThi, int LanThi)
        {
            var client = new UnimOsServiceClient();
            client.cDKQHT_DanhSachDuThi_UpdateDaChuyenDiemByToChucThi(GlobalVar.MaXacThuc, IsDaChuyen, IDKQHT_ToChucThi, LanThi);
            client.Close();
            mErrorMessage = oDKQHT_DanhSachDuThi.ErrorMessages;
            mErrorNumber = oDKQHT_DanhSachDuThi.ErrorNumber;
        }

        public void UpdateSoPhachMonLop(DataTable dt, long IDXL_MonHocTrongKy, int LanThi)
        {
            foreach (DataRow dr in dt.Rows)
            {
                var client = new UnimOsServiceClient();
                client.cDKQHT_DanhSachDuThi_UpdateSoPhachMonLop(GlobalVar.MaXacThuc, int.Parse(dr["SV_SinhVienID"].ToString()), "" + dr["SoPhach"], IDXL_MonHocTrongKy, LanThi, int.Parse("0" + dr["MucPhatQuyChe"]), "" + dr["LyDoViPhamQuyChe"]);
                client.Close();

            }
            mErrorMessage = oDKQHT_DanhSachDuThi.ErrorMessages;
            mErrorNumber = oDKQHT_DanhSachDuThi.ErrorNumber;
        }

        public void HuyPhachMonLop(long IDXL_MonHocTrongKy, int LanThi)
        {
            var client = new UnimOsServiceClient();
            client.cDKQHT_DanhSachDuThi_HuyPhachMonLop(GlobalVar.MaXacThuc, IDXL_MonHocTrongKy, LanThi);
            client.Close();

            mErrorMessage = oDKQHT_DanhSachDuThi.ErrorMessages;
            mErrorNumber = oDKQHT_DanhSachDuThi.ErrorNumber;
        }

        //public void Delete(KQHT_DanhSachDuThiInfo pKQHT_DanhSachDuThiInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDKQHT_DanhSachDuThi_Delete(GlobalVar.MaXacThuc, pKQHT_DanhSachDuThiInfo);
        //    client.Close();
        //    mErrorMessage = oDKQHT_DanhSachDuThi.ErrorMessages;
        //    mErrorNumber = oDKQHT_DanhSachDuThi.ErrorNumber;
        //}

        //public List<KQHT_DanhSachDuThiInfo> GetList(KQHT_DanhSachDuThiInfo pKQHT_DanhSachDuThiInfo)
        //{
        //    List<KQHT_DanhSachDuThiInfo> oKQHT_DanhSachDuThiInfoList = new List<KQHT_DanhSachDuThiInfo>();
        //    DataTable dtb = Get(pKQHT_DanhSachDuThiInfo);
        //    if (dtb != null)
        //    {
        //        for (int i = 0; i < dtb.Rows.Count; i++)
        //        {
        //            oKQHT_DanhSachDuThiInfo = new KQHT_DanhSachDuThiInfo();

        //            oKQHT_DanhSachDuThiInfo.KQHT_DanhSachDuThiID = long.Parse(dtb.Rows[i]["KQHT_DanhSachDuThiID"].ToString());
        //            oKQHT_DanhSachDuThiInfo.IDKQHT_ToChucThi = int.Parse(dtb.Rows[i]["IDKQHT_ToChucThi"].ToString());
        //            oKQHT_DanhSachDuThiInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
        //            oKQHT_DanhSachDuThiInfo.IDDM_PhongHoc = int.Parse(dtb.Rows[i]["IDDM_PhongHoc"].ToString());
        //            oKQHT_DanhSachDuThiInfo.SoBaoDanh = int.Parse(dtb.Rows[i]["SoBaoDanh"].ToString());
        //            oKQHT_DanhSachDuThiInfo.SoPhach = dtb.Rows[i]["SoPhach"].ToString();
        //            oKQHT_DanhSachDuThiInfo.TuiThiSo = int.Parse(dtb.Rows[i]["TuiThiSo"].ToString());
        //            oKQHT_DanhSachDuThiInfo.GhiChu = dtb.Rows[i]["GhiChu"].ToString();

        //            oKQHT_DanhSachDuThiInfoList.Add(oKQHT_DanhSachDuThiInfo);
        //        }
        //    }
        //    return oKQHT_DanhSachDuThiInfoList;
        //}

        public void ToDataRow(KQHT_DanhSachDuThiInfo pKQHT_DanhSachDuThiInfo, ref DataRow dr)
        {

            dr[pKQHT_DanhSachDuThiInfo.strKQHT_DanhSachDuThiID] = pKQHT_DanhSachDuThiInfo.KQHT_DanhSachDuThiID;
            dr[pKQHT_DanhSachDuThiInfo.strIDKQHT_ToChucThi] = pKQHT_DanhSachDuThiInfo.IDKQHT_ToChucThi;
            dr[pKQHT_DanhSachDuThiInfo.strIDSV_SinhVien] = pKQHT_DanhSachDuThiInfo.IDSV_SinhVien;
            dr[pKQHT_DanhSachDuThiInfo.strIDDM_PhongHoc] = pKQHT_DanhSachDuThiInfo.IDDM_PhongHoc;
            dr[pKQHT_DanhSachDuThiInfo.strSoBaoDanh] = pKQHT_DanhSachDuThiInfo.SoBaoDanh;
            dr[pKQHT_DanhSachDuThiInfo.strSoPhach] = pKQHT_DanhSachDuThiInfo.SoPhach;
            dr[pKQHT_DanhSachDuThiInfo.strTuiThiSo] = pKQHT_DanhSachDuThiInfo.TuiThiSo;
            dr[pKQHT_DanhSachDuThiInfo.strGhiChu] = pKQHT_DanhSachDuThiInfo.GhiChu;
        }

        public void ToInfo(ref KQHT_DanhSachDuThiInfo pKQHT_DanhSachDuThiInfo, DataRow dr)
        {

            pKQHT_DanhSachDuThiInfo.KQHT_DanhSachDuThiID = long.Parse(dr[pKQHT_DanhSachDuThiInfo.strKQHT_DanhSachDuThiID].ToString());
            pKQHT_DanhSachDuThiInfo.IDKQHT_ToChucThi = int.Parse(dr[pKQHT_DanhSachDuThiInfo.strIDKQHT_ToChucThi].ToString());
            pKQHT_DanhSachDuThiInfo.IDSV_SinhVien = int.Parse(dr[pKQHT_DanhSachDuThiInfo.strIDSV_SinhVien].ToString());
            pKQHT_DanhSachDuThiInfo.IDDM_PhongHoc = int.Parse(dr[pKQHT_DanhSachDuThiInfo.strIDDM_PhongHoc].ToString());
            pKQHT_DanhSachDuThiInfo.SoBaoDanh = int.Parse(dr[pKQHT_DanhSachDuThiInfo.strSoBaoDanh].ToString());
            pKQHT_DanhSachDuThiInfo.SoPhach = dr[pKQHT_DanhSachDuThiInfo.strSoPhach].ToString();
            pKQHT_DanhSachDuThiInfo.TuiThiSo = int.Parse(dr[pKQHT_DanhSachDuThiInfo.strTuiThiSo].ToString());
            pKQHT_DanhSachDuThiInfo.GhiChu = dr[pKQHT_DanhSachDuThiInfo.strGhiChu].ToString();
        }
    }
}
