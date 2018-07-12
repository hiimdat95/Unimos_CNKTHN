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
    public class cBwsGG_GiangDayGiaoVien : cBwsBase
    {
        private cDGG_GiangDayGiaoVien oDGG_GiangDayGiaoVien;

        public cBwsGG_GiangDayGiaoVien()
        {
            oDGG_GiangDayGiaoVien = new cDGG_GiangDayGiaoVien();
        }

        //public DataTable Get(GG_GiangDayGiaoVienInfo pGG_GiangDayGiaoVienInfo)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return ConvertList.ToDataTable<GG_GiangDayGiaoVienInfo>(client.cDGG_GiangDayGiaoVien_Get(GlobalVar.MaXacThuc, pGG_GiangDayGiaoVienInfo));
        //    }
        //}

        public DataTable GetBangTongHop(int IDNS_DonVi, string TenDonVi, int IDDM_NamHoc, string TenNamHoc, int HocKy)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_GG_GiangDayGiaoVien_GetBangTongHopResult>(client.cDGG_GiangDayGiaoVien_GetBangTongHop(GlobalVar.MaXacThuc, IDNS_DonVi, TenDonVi, IDDM_NamHoc, TenNamHoc, HocKy));
            }
        }

        //public long Add(GG_GiangDayGiaoVienInfo pGG_GiangDayGiaoVienInfo)
        //{
        //    long ID = 0;
        //    var client = new UnimOsServiceClient();
        //    ID = client.cDGG_GiangDayGiaoVien_Add(GlobalVar.MaXacThuc, pGG_GiangDayGiaoVienInfo);
        //    client.Close();
        //    mErrorMessage = oDGG_GiangDayGiaoVien.ErrorMessages;
        //    mErrorNumber = oDGG_GiangDayGiaoVien.ErrorNumber;
        //    return ID;
        //}

        //public void Update(GG_GiangDayGiaoVienInfo pGG_GiangDayGiaoVienInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDGG_GiangDayGiaoVien_Update(GlobalVar.MaXacThuc, pGG_GiangDayGiaoVienInfo);
        //    client.Close();
        //    mErrorMessage = oDGG_GiangDayGiaoVien.ErrorMessages;
        //    mErrorNumber = oDGG_GiangDayGiaoVien.ErrorNumber;
        //}

        public long UpdateAdd(GG_GiangDayGiaoVienInfo pGG_GiangDayGiaoVienInfo)
        {
            long ID = 0;
            var client = new UnimOsServiceClient();
            ID = client.cDGG_GiangDayGiaoVien_UpdateAdd(GlobalVar.MaXacThuc, pGG_GiangDayGiaoVienInfo);
            client.Close();
            mErrorMessage = oDGG_GiangDayGiaoVien.ErrorMessages;
            mErrorNumber = oDGG_GiangDayGiaoVien.ErrorNumber;
            return ID;
        }

        //public void Delete(GG_GiangDayGiaoVienInfo pGG_GiangDayGiaoVienInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDGG_GiangDayGiaoVien_Delete(GlobalVar.MaXacThuc, pGG_GiangDayGiaoVienInfo);
        //    client.Close();
        //    mErrorMessage = oDGG_GiangDayGiaoVien.ErrorMessages;
        //    mErrorNumber = oDGG_GiangDayGiaoVien.ErrorNumber;
        //}

        public void DeleteNotIn(int IDNS_GiaoVien, int IDDM_NamHoc, int HocKy, string IDGGNotIn)
        {
            var client = new UnimOsServiceClient();
            client.cDGG_GiangDayGiaoVien_DeleteNotIn(GlobalVar.MaXacThuc, IDNS_GiaoVien, IDDM_NamHoc, HocKy, IDGGNotIn);
            client.Close();
            mErrorMessage = oDGG_GiangDayGiaoVien.ErrorMessages;
            mErrorNumber = oDGG_GiangDayGiaoVien.ErrorNumber;
        }

        //public List<GG_GiangDayGiaoVienInfo> GetList(GG_GiangDayGiaoVienInfo pGG_GiangDayGiaoVienInfo)
        //{
        //    List<GG_GiangDayGiaoVienInfo> oGG_GiangDayGiaoVienInfoList = new List<GG_GiangDayGiaoVienInfo>();
        //    DataTable dtb = Get(pGG_GiangDayGiaoVienInfo);
        //    if (dtb != null)
        //    {
        //        for (int i = 0; i < dtb.Rows.Count; i++)
        //        {
        //            pGG_GiangDayGiaoVienInfo = new GG_GiangDayGiaoVienInfo();

        //            pGG_GiangDayGiaoVienInfo.GG_GiangDayGiaoVienID = long.Parse(dtb.Rows[i][pGG_GiangDayGiaoVienInfo.strGG_GiangDayGiaoVienID].ToString());
        //            pGG_GiangDayGiaoVienInfo.IDNS_GiaoVien = int.Parse(dtb.Rows[i][pGG_GiangDayGiaoVienInfo.strIDNS_GiaoVien].ToString());
        //            pGG_GiangDayGiaoVienInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i][pGG_GiangDayGiaoVienInfo.strIDDM_NamHoc].ToString());
        //            pGG_GiangDayGiaoVienInfo.HocKy = int.Parse(dtb.Rows[i][pGG_GiangDayGiaoVienInfo.strHocKy].ToString());
        //            pGG_GiangDayGiaoVienInfo.IDXL_MonHocTrongKy = long.Parse(dtb.Rows[i][pGG_GiangDayGiaoVienInfo.strIDXL_MonHocTrongKy].ToString());
        //            pGG_GiangDayGiaoVienInfo.SoSinhVien = int.Parse(dtb.Rows[i][pGG_GiangDayGiaoVienInfo.strSoSinhVien].ToString());
        //            if ("" + dtb.Rows[i][pGG_GiangDayGiaoVienInfo.strLyThuyet] != "")
        //                pGG_GiangDayGiaoVienInfo.LyThuyet = int.Parse(dtb.Rows[i][pGG_GiangDayGiaoVienInfo.strLyThuyet].ToString());
        //            if ("" + dtb.Rows[i][pGG_GiangDayGiaoVienInfo.strLyThuyetQuyChuan] != "")
        //                pGG_GiangDayGiaoVienInfo.LyThuyetQuyChuan = double.Parse(dtb.Rows[i][pGG_GiangDayGiaoVienInfo.strLyThuyetQuyChuan].ToString());
        //            if ("" + dtb.Rows[i][pGG_GiangDayGiaoVienInfo.strThucHanh] != "")
        //                pGG_GiangDayGiaoVienInfo.ThucHanh = int.Parse(dtb.Rows[i][pGG_GiangDayGiaoVienInfo.strThucHanh].ToString());
        //            if ("" + dtb.Rows[i][pGG_GiangDayGiaoVienInfo.strThucHanhQuyChuan] != "")
        //                pGG_GiangDayGiaoVienInfo.ThucHanhQuyChuan = double.Parse(dtb.Rows[i][pGG_GiangDayGiaoVienInfo.strThucHanhQuyChuan].ToString());
        //            pGG_GiangDayGiaoVienInfo.SoGioChuan = double.Parse(dtb.Rows[i][pGG_GiangDayGiaoVienInfo.strSoGioChuan].ToString());
        //            if ("" + dtb.Rows[i][pGG_GiangDayGiaoVienInfo.strGhiChu] != "")
        //                pGG_GiangDayGiaoVienInfo.GhiChu = dtb.Rows[i][pGG_GiangDayGiaoVienInfo.strGhiChu].ToString();

        //            oGG_GiangDayGiaoVienInfoList.Add(pGG_GiangDayGiaoVienInfo);
        //        }
        //    }
        //    return oGG_GiangDayGiaoVienInfoList;
        //}

        public void ToDataRow(GG_GiangDayGiaoVienInfo pGG_GiangDayGiaoVienInfo, ref DataRow dr)
        {

            dr[pGG_GiangDayGiaoVienInfo.strGG_GiangDayGiaoVienID] = pGG_GiangDayGiaoVienInfo.GG_GiangDayGiaoVienID;
            dr[pGG_GiangDayGiaoVienInfo.strIDNS_GiaoVien] = pGG_GiangDayGiaoVienInfo.IDNS_GiaoVien;
            dr[pGG_GiangDayGiaoVienInfo.strIDDM_NamHoc] = pGG_GiangDayGiaoVienInfo.IDDM_NamHoc;
            dr[pGG_GiangDayGiaoVienInfo.strHocKy] = pGG_GiangDayGiaoVienInfo.HocKy;
            dr[pGG_GiangDayGiaoVienInfo.strIDXL_MonHocTrongKy] = pGG_GiangDayGiaoVienInfo.IDXL_MonHocTrongKy;
            dr[pGG_GiangDayGiaoVienInfo.strSoNhom] = pGG_GiangDayGiaoVienInfo.SoNhom;
            dr[pGG_GiangDayGiaoVienInfo.strSoSinhVien] = pGG_GiangDayGiaoVienInfo.SoSinhVien;
            dr[pGG_GiangDayGiaoVienInfo.strLyThuyet] = pGG_GiangDayGiaoVienInfo.LyThuyet;
            dr[pGG_GiangDayGiaoVienInfo.strLyThuyetQuyChuan] = pGG_GiangDayGiaoVienInfo.LyThuyetQuyChuan;
            dr[pGG_GiangDayGiaoVienInfo.strThucHanh] = pGG_GiangDayGiaoVienInfo.ThucHanh;
            dr[pGG_GiangDayGiaoVienInfo.strThucHanhQuyChuan] = pGG_GiangDayGiaoVienInfo.ThucHanhQuyChuan;
            dr[pGG_GiangDayGiaoVienInfo.strSoGioChuan] = pGG_GiangDayGiaoVienInfo.SoGioChuan;
            dr[pGG_GiangDayGiaoVienInfo.strGhiChu] = pGG_GiangDayGiaoVienInfo.GhiChu;
        }

        public void ToInfo(ref GG_GiangDayGiaoVienInfo pGG_GiangDayGiaoVienInfo, DataRow dr)
        {

            pGG_GiangDayGiaoVienInfo.GG_GiangDayGiaoVienID = long.Parse(dr[pGG_GiangDayGiaoVienInfo.strGG_GiangDayGiaoVienID].ToString());
            pGG_GiangDayGiaoVienInfo.IDNS_GiaoVien = int.Parse(dr[pGG_GiangDayGiaoVienInfo.strIDNS_GiaoVien].ToString());
            pGG_GiangDayGiaoVienInfo.IDDM_NamHoc = int.Parse(dr[pGG_GiangDayGiaoVienInfo.strIDDM_NamHoc].ToString());
            pGG_GiangDayGiaoVienInfo.HocKy = int.Parse(dr[pGG_GiangDayGiaoVienInfo.strHocKy].ToString());
            pGG_GiangDayGiaoVienInfo.IDXL_MonHocTrongKy = long.Parse(dr[pGG_GiangDayGiaoVienInfo.strIDXL_MonHocTrongKy].ToString());
            pGG_GiangDayGiaoVienInfo.SoNhom = int.Parse(dr[pGG_GiangDayGiaoVienInfo.strSoNhom].ToString());
            pGG_GiangDayGiaoVienInfo.SoSinhVien = int.Parse(dr[pGG_GiangDayGiaoVienInfo.strSoSinhVien].ToString());
            if ("" + dr[pGG_GiangDayGiaoVienInfo.strLyThuyet] != "")
                pGG_GiangDayGiaoVienInfo.LyThuyet = int.Parse(dr[pGG_GiangDayGiaoVienInfo.strLyThuyet].ToString());
            if ("" + dr[pGG_GiangDayGiaoVienInfo.strLyThuyetQuyChuan] != "")
                pGG_GiangDayGiaoVienInfo.LyThuyetQuyChuan = double.Parse(dr[pGG_GiangDayGiaoVienInfo.strLyThuyetQuyChuan].ToString());
            if ("" + dr[pGG_GiangDayGiaoVienInfo.strThucHanh] != "")
                pGG_GiangDayGiaoVienInfo.ThucHanh = int.Parse(dr[pGG_GiangDayGiaoVienInfo.strThucHanh].ToString());
            if ("" + dr[pGG_GiangDayGiaoVienInfo.strThucHanhQuyChuan] != "")
                pGG_GiangDayGiaoVienInfo.ThucHanhQuyChuan = double.Parse(dr[pGG_GiangDayGiaoVienInfo.strThucHanhQuyChuan].ToString());
            pGG_GiangDayGiaoVienInfo.SoGioChuan = double.Parse(dr[pGG_GiangDayGiaoVienInfo.strSoGioChuan].ToString());
            if ("" + dr[pGG_GiangDayGiaoVienInfo.strGhiChu] != "")
                pGG_GiangDayGiaoVienInfo.GhiChu = dr[pGG_GiangDayGiaoVienInfo.strGhiChu].ToString();
        }
    }
}
