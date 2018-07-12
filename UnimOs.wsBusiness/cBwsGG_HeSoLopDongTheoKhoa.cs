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
    public class cBwsGG_HeSoLopDongTheoKhoa : cBwsBase
    {
        private cDGG_HeSoLopDongTheoKhoa oDGG_HeSoLopDongTheoKhoa;

        public cBwsGG_HeSoLopDongTheoKhoa()
        {
            oDGG_HeSoLopDongTheoKhoa = new cDGG_HeSoLopDongTheoKhoa();
        }

        public DataTable Get(GG_HeSoLopDongTheoKhoaInfo pGG_HeSoLopDongTheoKhoaInfo)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_GG_HeSoLopDongTheoKhoa_GetResult>(client.cDGG_HeSoLopDongTheoKhoa_Get(GlobalVar.MaXacThuc, pGG_HeSoLopDongTheoKhoaInfo));
            }
        }

        public DataTable GetAll(int GG_HeSoLopDongTheoKhoaID)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_GG_HeSoLopDongTheoKhoa_GetAllResult>(client.cDGG_HeSoLopDongTheoKhoa_GetAll(GlobalVar.MaXacThuc, GG_HeSoLopDongTheoKhoaID));
            }
        }

        public int Add(GG_HeSoLopDongTheoKhoaInfo pGG_HeSoLopDongTheoKhoaInfo)
        {
            int ID = 0;
            var client = new UnimOsServiceClient();
            ID = client.cDGG_HeSoLopDongTheoKhoa_Add(GlobalVar.MaXacThuc, pGG_HeSoLopDongTheoKhoaInfo);
            client.Close();
            mErrorMessage = oDGG_HeSoLopDongTheoKhoa.ErrorMessages;
            mErrorNumber = oDGG_HeSoLopDongTheoKhoa.ErrorNumber;
            return ID;
        }

        public void Update(GG_HeSoLopDongTheoKhoaInfo pGG_HeSoLopDongTheoKhoaInfo)
        {
            var client = new UnimOsServiceClient();
            client.cDGG_HeSoLopDongTheoKhoa_Update(GlobalVar.MaXacThuc, pGG_HeSoLopDongTheoKhoaInfo);
            client.Close();
            mErrorMessage = oDGG_HeSoLopDongTheoKhoa.ErrorMessages;
            mErrorNumber = oDGG_HeSoLopDongTheoKhoa.ErrorNumber;
        }

        public void Delete(GG_HeSoLopDongTheoKhoaInfo pGG_HeSoLopDongTheoKhoaInfo)
        {
            var client = new UnimOsServiceClient();
            client.cDGG_HeSoLopDongTheoKhoa_Delete(GlobalVar.MaXacThuc, pGG_HeSoLopDongTheoKhoaInfo);
            client.Close();
            mErrorMessage = oDGG_HeSoLopDongTheoKhoa.ErrorMessages;
            mErrorNumber = oDGG_HeSoLopDongTheoKhoa.ErrorNumber;
        }

        public List<GG_HeSoLopDongTheoKhoaInfo> GetList(GG_HeSoLopDongTheoKhoaInfo pGG_HeSoLopDongTheoKhoaInfo)
        {
            List<GG_HeSoLopDongTheoKhoaInfo> oGG_HeSoLopDongTheoKhoaInfoList = new List<GG_HeSoLopDongTheoKhoaInfo>();
            DataTable dtb = Get(pGG_HeSoLopDongTheoKhoaInfo);
            if (dtb != null)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    pGG_HeSoLopDongTheoKhoaInfo = new GG_HeSoLopDongTheoKhoaInfo();

                    pGG_HeSoLopDongTheoKhoaInfo.GG_HeSoLopDongTheoKhoaID = int.Parse(dtb.Rows[i][pGG_HeSoLopDongTheoKhoaInfo.strGG_HeSoLopDongTheoKhoaID].ToString());
                    pGG_HeSoLopDongTheoKhoaInfo.LoaiGiangDay = dtb.Rows[i][pGG_HeSoLopDongTheoKhoaInfo.strLoaiGiangDay].ToString();
                    pGG_HeSoLopDongTheoKhoaInfo.IDDM_TrinhDo = int.Parse(dtb.Rows[i][pGG_HeSoLopDongTheoKhoaInfo.strIDDM_TrinhDo].ToString());
                    pGG_HeSoLopDongTheoKhoaInfo.IDDM_Khoa = int.Parse(dtb.Rows[i][pGG_HeSoLopDongTheoKhoaInfo.strIDDM_Khoa].ToString());
                    pGG_HeSoLopDongTheoKhoaInfo.SoSVToiDa = int.Parse(dtb.Rows[i][pGG_HeSoLopDongTheoKhoaInfo.strSoSVToiDa].ToString());
                    pGG_HeSoLopDongTheoKhoaInfo.HeSoQuyChuan = double.Parse(dtb.Rows[i][pGG_HeSoLopDongTheoKhoaInfo.strHeSoQuyChuan].ToString());
                    pGG_HeSoLopDongTheoKhoaInfo.SoCongThem1Tiet = int.Parse(dtb.Rows[i][pGG_HeSoLopDongTheoKhoaInfo.strSoCongThem1Tiet].ToString());
                    pGG_HeSoLopDongTheoKhoaInfo.SoTietDinhMuc1Tuan = double.Parse(dtb.Rows[i][pGG_HeSoLopDongTheoKhoaInfo.strSoTietDinhMuc1Tuan].ToString());

                    oGG_HeSoLopDongTheoKhoaInfoList.Add(pGG_HeSoLopDongTheoKhoaInfo);
                }
            }
            return oGG_HeSoLopDongTheoKhoaInfoList;
        }

        public void ToDataRow(GG_HeSoLopDongTheoKhoaInfo pGG_HeSoLopDongTheoKhoaInfo, ref DataRow dr)
        {

            dr[pGG_HeSoLopDongTheoKhoaInfo.strGG_HeSoLopDongTheoKhoaID] = pGG_HeSoLopDongTheoKhoaInfo.GG_HeSoLopDongTheoKhoaID;
            dr[pGG_HeSoLopDongTheoKhoaInfo.strLoaiGiangDay] = pGG_HeSoLopDongTheoKhoaInfo.LoaiGiangDay;
            dr[pGG_HeSoLopDongTheoKhoaInfo.strIDDM_TrinhDo] = pGG_HeSoLopDongTheoKhoaInfo.IDDM_TrinhDo;
            dr[pGG_HeSoLopDongTheoKhoaInfo.strIDDM_Khoa] = pGG_HeSoLopDongTheoKhoaInfo.IDDM_Khoa;
            dr[pGG_HeSoLopDongTheoKhoaInfo.strSoSVToiDa] = pGG_HeSoLopDongTheoKhoaInfo.SoSVToiDa;
            dr[pGG_HeSoLopDongTheoKhoaInfo.strHeSoQuyChuan] = pGG_HeSoLopDongTheoKhoaInfo.HeSoQuyChuan;
            dr[pGG_HeSoLopDongTheoKhoaInfo.strSoCongThem1Tiet] = pGG_HeSoLopDongTheoKhoaInfo.SoCongThem1Tiet;
            dr[pGG_HeSoLopDongTheoKhoaInfo.strSoTietDinhMuc1Tuan] = pGG_HeSoLopDongTheoKhoaInfo.SoTietDinhMuc1Tuan;
        }

        public void ToInfo(ref GG_HeSoLopDongTheoKhoaInfo pGG_HeSoLopDongTheoKhoaInfo, DataRow dr)
        {

            pGG_HeSoLopDongTheoKhoaInfo.GG_HeSoLopDongTheoKhoaID = int.Parse(dr[pGG_HeSoLopDongTheoKhoaInfo.strGG_HeSoLopDongTheoKhoaID].ToString());
            pGG_HeSoLopDongTheoKhoaInfo.LoaiGiangDay = dr[pGG_HeSoLopDongTheoKhoaInfo.strLoaiGiangDay].ToString();
            pGG_HeSoLopDongTheoKhoaInfo.IDDM_TrinhDo = int.Parse(dr[pGG_HeSoLopDongTheoKhoaInfo.strIDDM_TrinhDo].ToString());
            pGG_HeSoLopDongTheoKhoaInfo.IDDM_Khoa = int.Parse(dr[pGG_HeSoLopDongTheoKhoaInfo.strIDDM_Khoa].ToString());
            pGG_HeSoLopDongTheoKhoaInfo.SoSVToiDa = int.Parse(dr[pGG_HeSoLopDongTheoKhoaInfo.strSoSVToiDa].ToString());
            pGG_HeSoLopDongTheoKhoaInfo.HeSoQuyChuan = double.Parse(dr[pGG_HeSoLopDongTheoKhoaInfo.strHeSoQuyChuan].ToString());
            pGG_HeSoLopDongTheoKhoaInfo.SoCongThem1Tiet = int.Parse(dr[pGG_HeSoLopDongTheoKhoaInfo.strSoCongThem1Tiet].ToString());
            pGG_HeSoLopDongTheoKhoaInfo.SoTietDinhMuc1Tuan = double.Parse(dr[pGG_HeSoLopDongTheoKhoaInfo.strSoTietDinhMuc1Tuan].ToString());
        }
    }
}
