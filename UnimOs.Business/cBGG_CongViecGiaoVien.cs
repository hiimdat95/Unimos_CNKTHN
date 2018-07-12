using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBGG_CongViecGiaoVien : cBBase
    {
        private cDGG_CongViecGiaoVien oDGG_CongViecGiaoVien;

        public cBGG_CongViecGiaoVien()        
        {
            oDGG_CongViecGiaoVien = new cDGG_CongViecGiaoVien();
        }

        public DataTable Get(GG_CongViecGiaoVienInfo pGG_CongViecGiaoVienInfo)        
        {
            return oDGG_CongViecGiaoVien.Get(pGG_CongViecGiaoVienInfo);
        }

        public DataTable Get(int IDGiaoVien,int IDNamHoc)
        {
            return oDGG_CongViecGiaoVien.Get(IDGiaoVien, IDNamHoc);
        }

        public DataTable GetByHocKy(int IDDM_NamHoc, int HocKy, int IDNS_DonVi)
        {
            return oDGG_CongViecGiaoVien.GetByHocKy(IDDM_NamHoc, HocKy, IDNS_DonVi);
        }

        public DataTable GetByIDDM_LoaiCongViec(int IDDM_LoaiCongViec, int IDNS_DonVi, int IDDM_NamHoc, int HocKy)
        {
            return oDGG_CongViecGiaoVien.GetByIDDM_LoaiCongViec(IDDM_LoaiCongViec, IDNS_DonVi, IDDM_NamHoc, HocKy);
        }

        public long Add(GG_CongViecGiaoVienInfo pGG_CongViecGiaoVienInfo)
        {
			long ID = 0;
            ID = oDGG_CongViecGiaoVien.Add(pGG_CongViecGiaoVienInfo);
            mErrorMessage = oDGG_CongViecGiaoVien.ErrorMessages;
            mErrorNumber = oDGG_CongViecGiaoVien.ErrorNumber;
            return ID;
        }

        public void Update(GG_CongViecGiaoVienInfo pGG_CongViecGiaoVienInfo)
        {
            oDGG_CongViecGiaoVien.Update(pGG_CongViecGiaoVienInfo);
            mErrorMessage = oDGG_CongViecGiaoVien.ErrorMessages;
            mErrorNumber = oDGG_CongViecGiaoVien.ErrorNumber;
        }

        public long UpdateAdd(GG_CongViecGiaoVienInfo pGG_CongViecGiaoVienInfo)
        {
            long ID = 0;
            ID = oDGG_CongViecGiaoVien.UpdateAdd(pGG_CongViecGiaoVienInfo);
            mErrorMessage = oDGG_CongViecGiaoVien.ErrorMessages;
            mErrorNumber = oDGG_CongViecGiaoVien.ErrorNumber;
            return ID;
        }
        
        public void Delete(GG_CongViecGiaoVienInfo pGG_CongViecGiaoVienInfo)
        {
            oDGG_CongViecGiaoVien.Delete(pGG_CongViecGiaoVienInfo);
            mErrorMessage = oDGG_CongViecGiaoVien.ErrorMessages;
            mErrorNumber = oDGG_CongViecGiaoVien.ErrorNumber;
        }

        public void DeleteNotIn(int IDNS_GiaoVien, int IDDM_NamHoc, int HocKy, string IDCVNotIn)
        {
            oDGG_CongViecGiaoVien.DeleteNotIn(IDNS_GiaoVien, IDDM_NamHoc, HocKy, IDCVNotIn);
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
