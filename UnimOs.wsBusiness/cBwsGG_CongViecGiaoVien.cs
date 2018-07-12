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
    public class cBwsGG_CongViecGiaoVien : cBwsBase
    {
        private cDGG_CongViecGiaoVien oDGG_CongViecGiaoVien;

        public cBwsGG_CongViecGiaoVien()
        {
            oDGG_CongViecGiaoVien = new cDGG_CongViecGiaoVien();
        }

        public DataTable Get(GG_CongViecGiaoVienInfo pGG_CongViecGiaoVienInfo)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_GG_CongViecGiaoVien_GetResult>(client.cDGG_CongViecGiaoVien_Get_2(GlobalVar.MaXacThuc, pGG_CongViecGiaoVienInfo));
            }
        }

        public DataTable Get(int IDGiaoVien, int IDNamHoc)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_GG_CongViecGiaoVien_GetResult>(client.cDGG_CongViecGiaoVien_Get(GlobalVar.MaXacThuc, IDGiaoVien, IDNamHoc));
            }
        }

        public DataTable GetByHocKy(int IDDM_NamHoc, int HocKy, int IDNS_DonVi)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_GG_CongViecGiaoVien_GetAllByHocKyResult>(client.cDGG_CongViecGiaoVien_GetByHocKy(GlobalVar.MaXacThuc, IDDM_NamHoc, HocKy, IDNS_DonVi));
            }
        }

        public DataTable GetByIDDM_LoaiCongViec(int IDDM_LoaiCongViec, int IDNS_DonVi, int IDDM_NamHoc, int HocKy)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_GG_CongViecGiaoVien_GetByIDDM_LoaiCongViecResult>(client.cDGG_CongViecGiaoVien_GetByIDDM_LoaiCongViec(GlobalVar.MaXacThuc, IDDM_LoaiCongViec, IDNS_DonVi, IDDM_NamHoc, HocKy));
            }
        }

        //public long Add(GG_CongViecGiaoVienInfo pGG_CongViecGiaoVienInfo)
        //{
        //    long ID = 0;
        //    var client = new UnimOsServiceClient();
        //    ID = client.cDGG_CongViecGiaoVien_Add(GlobalVar.MaXacThuc, pGG_CongViecGiaoVienInfo);
        //    client.Close();
        //    mErrorMessage = oDGG_CongViecGiaoVien.ErrorMessages;
        //    mErrorNumber = oDGG_CongViecGiaoVien.ErrorNumber;
        //    return ID;
        //}

        //public void Update(GG_CongViecGiaoVienInfo pGG_CongViecGiaoVienInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDGG_CongViecGiaoVien_Update(GlobalVar.MaXacThuc, pGG_CongViecGiaoVienInfo);
        //    client.Close();
        //    mErrorMessage = oDGG_CongViecGiaoVien.ErrorMessages;
        //    mErrorNumber = oDGG_CongViecGiaoVien.ErrorNumber;
        //}

        public long UpdateAdd(GG_CongViecGiaoVienInfo pGG_CongViecGiaoVienInfo)
        {
            long ID = 0;
            var client = new UnimOsServiceClient();
            ID = client.cDGG_CongViecGiaoVien_UpdateAdd(GlobalVar.MaXacThuc, pGG_CongViecGiaoVienInfo);
            client.Close();
            mErrorMessage = oDGG_CongViecGiaoVien.ErrorMessages;
            mErrorNumber = oDGG_CongViecGiaoVien.ErrorNumber;
            return ID;
        }

        //public void Delete(GG_CongViecGiaoVienInfo pGG_CongViecGiaoVienInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDGG_CongViecGiaoVien_Delete(GlobalVar.MaXacThuc, pGG_CongViecGiaoVienInfo);
        //    client.Close();
        //    mErrorMessage = oDGG_CongViecGiaoVien.ErrorMessages;
        //    mErrorNumber = oDGG_CongViecGiaoVien.ErrorNumber;
        //}

        public void DeleteNotIn(int IDNS_GiaoVien, int IDDM_NamHoc, int HocKy, string IDCVNotIn)
        {
            var client = new UnimOsServiceClient();
            client.cDGG_CongViecGiaoVien_DeleteNotIn(GlobalVar.MaXacThuc, IDNS_GiaoVien, IDDM_NamHoc, HocKy, IDCVNotIn);
            client.Close();
            mErrorMessage = oDGG_CongViecGiaoVien.ErrorMessages;
            mErrorNumber = oDGG_CongViecGiaoVien.ErrorNumber;
        }

        public List<GG_CongViecGiaoVienInfo> GetList(GG_CongViecGiaoVienInfo pGG_CongViecGiaoVienInfo)
        {
            List<GG_CongViecGiaoVienInfo> oGG_CongViecGiaoVienInfoList = new List<GG_CongViecGiaoVienInfo>();
            DataTable dtb = Get(pGG_CongViecGiaoVienInfo);
            if (dtb != null)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    pGG_CongViecGiaoVienInfo = new GG_CongViecGiaoVienInfo();

                    pGG_CongViecGiaoVienInfo.GG_CongViecGiaoVienID = int.Parse(dtb.Rows[i][pGG_CongViecGiaoVienInfo.strGG_CongViecGiaoVienID].ToString());
                    pGG_CongViecGiaoVienInfo.IDDM_LoaiCongViec = int.Parse(dtb.Rows[i][pGG_CongViecGiaoVienInfo.strIDDM_LoaiCongViec].ToString());
                    pGG_CongViecGiaoVienInfo.IDNS_GiaoVien = int.Parse(dtb.Rows[i][pGG_CongViecGiaoVienInfo.strIDNS_GiaoVien].ToString());
                    pGG_CongViecGiaoVienInfo.SoGio = int.Parse(dtb.Rows[i][pGG_CongViecGiaoVienInfo.strSoGio].ToString());
                    pGG_CongViecGiaoVienInfo.HeSo = double.Parse(dtb.Rows[i][pGG_CongViecGiaoVienInfo.strHeSo].ToString());
                    pGG_CongViecGiaoVienInfo.GioQuyChuan = double.Parse(dtb.Rows[i][pGG_CongViecGiaoVienInfo.strGioQuyChuan].ToString());
                    pGG_CongViecGiaoVienInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i][pGG_CongViecGiaoVienInfo.strIDDM_NamHoc].ToString());
                    pGG_CongViecGiaoVienInfo.HocKy = int.Parse(dtb.Rows[i][pGG_CongViecGiaoVienInfo.strHocKy].ToString());
                    if ("" + dtb.Rows[i][pGG_CongViecGiaoVienInfo.strGhiChu] != "")
                        pGG_CongViecGiaoVienInfo.GhiChu = dtb.Rows[i][pGG_CongViecGiaoVienInfo.strGhiChu].ToString();

                    oGG_CongViecGiaoVienInfoList.Add(pGG_CongViecGiaoVienInfo);
                }
            }
            return oGG_CongViecGiaoVienInfoList;
        }

        public void ToDataRow(GG_CongViecGiaoVienInfo pGG_CongViecGiaoVienInfo, ref DataRow dr)
        {

            dr[pGG_CongViecGiaoVienInfo.strGG_CongViecGiaoVienID] = pGG_CongViecGiaoVienInfo.GG_CongViecGiaoVienID;
            dr[pGG_CongViecGiaoVienInfo.strIDDM_LoaiCongViec] = pGG_CongViecGiaoVienInfo.IDDM_LoaiCongViec;
            dr[pGG_CongViecGiaoVienInfo.strIDNS_GiaoVien] = pGG_CongViecGiaoVienInfo.IDNS_GiaoVien;
            dr[pGG_CongViecGiaoVienInfo.strSoGio] = pGG_CongViecGiaoVienInfo.SoGio;
            dr[pGG_CongViecGiaoVienInfo.strHeSo] = pGG_CongViecGiaoVienInfo.HeSo;
            dr[pGG_CongViecGiaoVienInfo.strGioQuyChuan] = pGG_CongViecGiaoVienInfo.GioQuyChuan;
            dr[pGG_CongViecGiaoVienInfo.strIDDM_NamHoc] = pGG_CongViecGiaoVienInfo.IDDM_NamHoc;
            dr[pGG_CongViecGiaoVienInfo.strHocKy] = pGG_CongViecGiaoVienInfo.HocKy;
            dr[pGG_CongViecGiaoVienInfo.strGhiChu] = pGG_CongViecGiaoVienInfo.GhiChu;
        }

        public void ToInfo(ref GG_CongViecGiaoVienInfo pGG_CongViecGiaoVienInfo, DataRow dr)
        {

            pGG_CongViecGiaoVienInfo.GG_CongViecGiaoVienID = int.Parse(dr[pGG_CongViecGiaoVienInfo.strGG_CongViecGiaoVienID].ToString());
            pGG_CongViecGiaoVienInfo.IDDM_LoaiCongViec = int.Parse(dr[pGG_CongViecGiaoVienInfo.strIDDM_LoaiCongViec].ToString());
            pGG_CongViecGiaoVienInfo.IDNS_GiaoVien = int.Parse(dr[pGG_CongViecGiaoVienInfo.strIDNS_GiaoVien].ToString());
            pGG_CongViecGiaoVienInfo.SoGio = int.Parse(dr[pGG_CongViecGiaoVienInfo.strSoGio].ToString());
            pGG_CongViecGiaoVienInfo.HeSo = double.Parse(dr[pGG_CongViecGiaoVienInfo.strHeSo].ToString());
            pGG_CongViecGiaoVienInfo.GioQuyChuan = double.Parse(dr[pGG_CongViecGiaoVienInfo.strGioQuyChuan].ToString());
            pGG_CongViecGiaoVienInfo.IDDM_NamHoc = int.Parse(dr[pGG_CongViecGiaoVienInfo.strIDDM_NamHoc].ToString());
            pGG_CongViecGiaoVienInfo.HocKy = int.Parse(dr[pGG_CongViecGiaoVienInfo.strHocKy].ToString());
            if ("" + dr[pGG_CongViecGiaoVienInfo.strGhiChu] != "")
                pGG_CongViecGiaoVienInfo.GhiChu = dr[pGG_CongViecGiaoVienInfo.strGhiChu].ToString();
        }
    }
}
