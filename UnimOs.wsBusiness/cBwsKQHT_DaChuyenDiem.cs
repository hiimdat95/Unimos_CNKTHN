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
    public class cBwsKQHT_DaChuyenDiem : cBwsBase
    {
        private cDKQHT_DaChuyenDiem oDKQHT_DaChuyenDiem;
        private KQHT_DaChuyenDiemInfo oKQHT_DaChuyenDiemInfo;

        public cBwsKQHT_DaChuyenDiem()
        {
            oDKQHT_DaChuyenDiem = new cDKQHT_DaChuyenDiem();
        }

        public DataTable Get(KQHT_DaChuyenDiemInfo pKQHT_DaChuyenDiemInfo)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_DaChuyenDiem_GetResult>(client.cDKQHT_DaChuyenDiem_Get(GlobalVar.MaXacThuc, pKQHT_DaChuyenDiemInfo));
            }
        }

        public DataTable GetByIDMonHocTrongKy(int IDXL_MonHocTrongKy)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_DaChuyenDiem_GetByIDMonHocTrongKyResult>(client.cDKQHT_DaChuyenDiem_GetByIDMonHocTrongKy(GlobalVar.MaXacThuc, IDXL_MonHocTrongKy));
            }
        }

        public DataTable GetLichSuSuaDiem(int IDXL_MonHocTrongKy)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_DaChuyenDiem_GetLichSuSuaDiemResult>(client.cDKQHT_DaChuyenDiem_GetLichSuSuaDiem(GlobalVar.MaXacThuc, IDXL_MonHocTrongKy));
            }
        }

        public int Add(KQHT_DaChuyenDiemInfo pKQHT_DaChuyenDiemInfo)
        {
            int ID = 0;
            var client = new UnimOsServiceClient();
            ID = client.cDKQHT_DaChuyenDiem_Add(GlobalVar.MaXacThuc, pKQHT_DaChuyenDiemInfo);
            client.Close();
            mErrorMessage = oDKQHT_DaChuyenDiem.ErrorMessages;
            mErrorNumber = oDKQHT_DaChuyenDiem.ErrorNumber;
            return ID;
        }

        public int AddChuyen(KQHT_DaChuyenDiemInfo pKQHT_DaChuyenDiemInfo)
        {
            int ID = 0;
            var client = new UnimOsServiceClient();
            ID = client.cDKQHT_DaChuyenDiem_AddChuyen(GlobalVar.MaXacThuc, pKQHT_DaChuyenDiemInfo);
            client.Close();
            mErrorMessage = oDKQHT_DaChuyenDiem.ErrorMessages;
            mErrorNumber = oDKQHT_DaChuyenDiem.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_DaChuyenDiemInfo pKQHT_DaChuyenDiemInfo)
        {
            var client = new UnimOsServiceClient();
            client.cDKQHT_DaChuyenDiem_Update(GlobalVar.MaXacThuc, pKQHT_DaChuyenDiemInfo);
            client.Close();
            mErrorMessage = oDKQHT_DaChuyenDiem.ErrorMessages;
            mErrorNumber = oDKQHT_DaChuyenDiem.ErrorNumber;
        }

        public void UpdateTrangThaiChuyen(KQHT_DaChuyenDiemInfo pKQHT_DaChuyenDiemInfo)
        {
            var client = new UnimOsServiceClient();
            client.cDKQHT_DaChuyenDiem_UpdateTrangThaiChuyen(GlobalVar.MaXacThuc, pKQHT_DaChuyenDiemInfo);
            client.Close();
            mErrorMessage = oDKQHT_DaChuyenDiem.ErrorMessages;
            mErrorNumber = oDKQHT_DaChuyenDiem.ErrorNumber;
        }

        public void Delete(KQHT_DaChuyenDiemInfo pKQHT_DaChuyenDiemInfo)
        {
            var client = new UnimOsServiceClient();
            client.cDKQHT_DaChuyenDiem_Delete(GlobalVar.MaXacThuc, pKQHT_DaChuyenDiemInfo);
            client.Close();
            mErrorMessage = oDKQHT_DaChuyenDiem.ErrorMessages;
            mErrorNumber = oDKQHT_DaChuyenDiem.ErrorNumber;
        }

        public List<KQHT_DaChuyenDiemInfo> GetList(KQHT_DaChuyenDiemInfo pKQHT_DaChuyenDiemInfo)
        {
            List<KQHT_DaChuyenDiemInfo> oKQHT_DaChuyenDiemInfoList = new List<KQHT_DaChuyenDiemInfo>();
            DataTable dtb = Get(pKQHT_DaChuyenDiemInfo);
            if (dtb != null)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    oKQHT_DaChuyenDiemInfo = new KQHT_DaChuyenDiemInfo();

                    oKQHT_DaChuyenDiemInfo.KQHT_DaChuyenDiemID = long.Parse(dtb.Rows[i]["KQHT_DaChuyenDiemID"].ToString());
                    oKQHT_DaChuyenDiemInfo.IDXL_MonHocTrongKy = int.Parse(dtb.Rows[i]["IDXL_MonHocTrongKy"].ToString());
                    oKQHT_DaChuyenDiemInfo.DaNhapDiemThanhPhan = bool.Parse(dtb.Rows[i]["DaNhapDiemThanhPhan"].ToString());
                    oKQHT_DaChuyenDiemInfo.NgayChuyenDiemThanhPhan = DateTime.Parse(dtb.Rows[i]["NgayChuyenDiemThanhPhan"].ToString());
                    oKQHT_DaChuyenDiemInfo.IDNS_GiaoVienChuyenDiemTP = int.Parse(dtb.Rows[i]["IDNS_GiaoVienChuyenDiemTP"].ToString());
                    oKQHT_DaChuyenDiemInfo.DaNhapDiemThiL1 = bool.Parse(dtb.Rows[i]["DaNhapDiemThiL1"].ToString());
                    oKQHT_DaChuyenDiemInfo.NgayChuyenDiemThiL1 = DateTime.Parse(dtb.Rows[i]["NgayChuyenDiemThiL1"].ToString());
                    oKQHT_DaChuyenDiemInfo.IDNS_GiaoVienChuyenDiemThiL1 = int.Parse(dtb.Rows[i]["IDNS_GiaoVienChuyenDiemThiL1"].ToString());
                    oKQHT_DaChuyenDiemInfo.DaNhapDiemThiL2 = bool.Parse(dtb.Rows[i]["DaNhapDiemThiL2"].ToString());
                    oKQHT_DaChuyenDiemInfo.NgayChuyenDiemThiL2 = DateTime.Parse(dtb.Rows[i]["NgayChuyenDiemThiL2"].ToString());
                    oKQHT_DaChuyenDiemInfo.IDNS_GiaoVienChuyenDiemThiL2 = int.Parse(dtb.Rows[i]["IDNS_GiaoVienChuyenDiemThiL2"].ToString());
                    oKQHT_DaChuyenDiemInfo.DaNhapDiemThanhPhanL2 = bool.Parse(dtb.Rows[i]["DaNhapDiemThanhPhanL2"].ToString());
                    oKQHT_DaChuyenDiemInfo.NgayChuyenDiemThanhPhanL2 = DateTime.Parse(dtb.Rows[i]["NgayChuyenDiemThanhPhanL2"].ToString());
                    oKQHT_DaChuyenDiemInfo.IDNS_GiaoVienChuyenDiemTPL2 = int.Parse(dtb.Rows[i]["IDNS_GiaoVienChuyenDiemTPL2"].ToString());

                    oKQHT_DaChuyenDiemInfoList.Add(oKQHT_DaChuyenDiemInfo);
                }
            }
            return oKQHT_DaChuyenDiemInfoList;
        }

        public void ToDataRow(KQHT_DaChuyenDiemInfo pKQHT_DaChuyenDiemInfo, ref DataRow dr)
        {

            dr[pKQHT_DaChuyenDiemInfo.strKQHT_DaChuyenDiemID] = pKQHT_DaChuyenDiemInfo.KQHT_DaChuyenDiemID;
            dr[pKQHT_DaChuyenDiemInfo.strIDXL_MonHocTrongKy] = pKQHT_DaChuyenDiemInfo.IDXL_MonHocTrongKy;
            dr[pKQHT_DaChuyenDiemInfo.strDaNhapDiemThanhPhan] = pKQHT_DaChuyenDiemInfo.DaNhapDiemThanhPhan;
            dr[pKQHT_DaChuyenDiemInfo.strNgayChuyenDiemThanhPhan] = pKQHT_DaChuyenDiemInfo.NgayChuyenDiemThanhPhan;
            dr[pKQHT_DaChuyenDiemInfo.strIDNS_GiaoVienChuyenDiemTP] = pKQHT_DaChuyenDiemInfo.IDNS_GiaoVienChuyenDiemTP;
            dr[pKQHT_DaChuyenDiemInfo.strDaNhapDiemThiL1] = pKQHT_DaChuyenDiemInfo.DaNhapDiemThiL1;
            dr[pKQHT_DaChuyenDiemInfo.strNgayChuyenDiemThiL1] = pKQHT_DaChuyenDiemInfo.NgayChuyenDiemThiL1;
            dr[pKQHT_DaChuyenDiemInfo.strIDNS_GiaoVienChuyenDiemThiL1] = pKQHT_DaChuyenDiemInfo.IDNS_GiaoVienChuyenDiemThiL1;
            dr[pKQHT_DaChuyenDiemInfo.strDaNhapDiemThiL2] = pKQHT_DaChuyenDiemInfo.DaNhapDiemThiL2;
            dr[pKQHT_DaChuyenDiemInfo.strNgayChuyenDiemThiL2] = pKQHT_DaChuyenDiemInfo.NgayChuyenDiemThiL2;
            dr[pKQHT_DaChuyenDiemInfo.strIDNS_GiaoVienChuyenDiemThiL2] = pKQHT_DaChuyenDiemInfo.IDNS_GiaoVienChuyenDiemThiL2;
            dr[pKQHT_DaChuyenDiemInfo.strDaNhapDiemThanhPhanL2] = pKQHT_DaChuyenDiemInfo.DaNhapDiemThanhPhanL2;
            dr[pKQHT_DaChuyenDiemInfo.strNgayChuyenDiemThanhPhanL2] = pKQHT_DaChuyenDiemInfo.NgayChuyenDiemThanhPhanL2;
            dr[pKQHT_DaChuyenDiemInfo.strIDNS_GiaoVienChuyenDiemTPL2] = pKQHT_DaChuyenDiemInfo.IDNS_GiaoVienChuyenDiemTPL2;
        }

        public void ToInfo(ref KQHT_DaChuyenDiemInfo pKQHT_DaChuyenDiemInfo, DataRow dr)
        {

            pKQHT_DaChuyenDiemInfo.KQHT_DaChuyenDiemID = long.Parse(dr[pKQHT_DaChuyenDiemInfo.strKQHT_DaChuyenDiemID].ToString());
            pKQHT_DaChuyenDiemInfo.IDXL_MonHocTrongKy = int.Parse(dr[pKQHT_DaChuyenDiemInfo.strIDXL_MonHocTrongKy].ToString());
            pKQHT_DaChuyenDiemInfo.DaNhapDiemThanhPhan = bool.Parse(dr[pKQHT_DaChuyenDiemInfo.strDaNhapDiemThanhPhan].ToString());
            pKQHT_DaChuyenDiemInfo.NgayChuyenDiemThanhPhan = DateTime.Parse(dr[pKQHT_DaChuyenDiemInfo.strNgayChuyenDiemThanhPhan].ToString());
            pKQHT_DaChuyenDiemInfo.IDNS_GiaoVienChuyenDiemTP = int.Parse(dr[pKQHT_DaChuyenDiemInfo.strIDNS_GiaoVienChuyenDiemTP].ToString());
            pKQHT_DaChuyenDiemInfo.DaNhapDiemThiL1 = bool.Parse(dr[pKQHT_DaChuyenDiemInfo.strDaNhapDiemThiL1].ToString());
            pKQHT_DaChuyenDiemInfo.NgayChuyenDiemThiL1 = DateTime.Parse(dr[pKQHT_DaChuyenDiemInfo.strNgayChuyenDiemThiL1].ToString());
            pKQHT_DaChuyenDiemInfo.IDNS_GiaoVienChuyenDiemThiL1 = int.Parse(dr[pKQHT_DaChuyenDiemInfo.strIDNS_GiaoVienChuyenDiemThiL1].ToString());
            pKQHT_DaChuyenDiemInfo.DaNhapDiemThiL2 = bool.Parse(dr[pKQHT_DaChuyenDiemInfo.strDaNhapDiemThiL2].ToString());
            pKQHT_DaChuyenDiemInfo.NgayChuyenDiemThiL2 = DateTime.Parse(dr[pKQHT_DaChuyenDiemInfo.strNgayChuyenDiemThiL2].ToString());
            pKQHT_DaChuyenDiemInfo.IDNS_GiaoVienChuyenDiemThiL2 = int.Parse(dr[pKQHT_DaChuyenDiemInfo.strIDNS_GiaoVienChuyenDiemThiL2].ToString());
            pKQHT_DaChuyenDiemInfo.DaNhapDiemThanhPhanL2 = bool.Parse(dr[pKQHT_DaChuyenDiemInfo.strDaNhapDiemThanhPhanL2].ToString());
            pKQHT_DaChuyenDiemInfo.NgayChuyenDiemThanhPhanL2 = DateTime.Parse(dr[pKQHT_DaChuyenDiemInfo.strNgayChuyenDiemThanhPhanL2].ToString());
            pKQHT_DaChuyenDiemInfo.IDNS_GiaoVienChuyenDiemTPL2 = int.Parse(dr[pKQHT_DaChuyenDiemInfo.strIDNS_GiaoVienChuyenDiemTPL2].ToString());
        }
    }
}
