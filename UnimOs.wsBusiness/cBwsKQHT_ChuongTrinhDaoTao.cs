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
    public class cBwsKQHT_ChuongTrinhDaoTao : cBwsBase
    {
        private cDKQHT_ChuongTrinhDaoTao oDKQHT_ChuongTrinhDaoTao;
        private KQHT_ChuongTrinhDaoTaoInfo oKQHT_ChuongTrinhDaoTaoInfo;

        public cBwsKQHT_ChuongTrinhDaoTao()
        {
            oDKQHT_ChuongTrinhDaoTao = new cDKQHT_ChuongTrinhDaoTao();
        }

        public DataTable Get(KQHT_ChuongTrinhDaoTaoInfo pKQHT_ChuongTrinhDaoTaoInfo)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_ChuongTrinhDaoTao_GetResult>(client.cDKQHT_ChuongTrinhDaoTao_Get(GlobalVar.MaXacThuc, pKQHT_ChuongTrinhDaoTaoInfo));
            }
        }

        public DataTable GetDanhSach(int IDDM_TrinhDo)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_ChuongTrinhDaoTao_GetDanhSachResult>(client.cDKQHT_ChuongTrinhDaoTao_GetDanhSach(GlobalVar.MaXacThuc, IDDM_TrinhDo));
            }
        }

        public DataTable GetChiTiet(int KQHT_ChuongTrinhDaoTaoID)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_ChuongTrinhDaoTao_GetChiTietResult>(client.cDKQHT_ChuongTrinhDaoTao_GetChiTiet(GlobalVar.MaXacThuc, KQHT_ChuongTrinhDaoTaoID));
            }
        }

        public DataTable GetMonKhung(int KQHT_ChuongTrinhDaoTaoID, int IDDM_Lop, int HocKy)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_ChuongTrinhDaoTao_GetMonKhungResult>(client.cDKQHT_ChuongTrinhDaoTao_GetMonKhung(GlobalVar.MaXacThuc, KQHT_ChuongTrinhDaoTaoID, IDDM_Lop, HocKy));
            }
        }

        public DataTable GetMonChuaToChuc(int KQHT_ChuongTrinhDaoTaoID, int IDDM_Lop, int CTDT_HocKy)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_ChuongTrinhDaoTao_GetMonChuaToChucResult>(client.cDKQHT_ChuongTrinhDaoTao_GetMonChuaToChuc(GlobalVar.MaXacThuc, KQHT_ChuongTrinhDaoTaoID, IDDM_Lop, CTDT_HocKy));
            }
        }

        public DataTable GetLop(int IDKQHT_ChuongTrinhDaoTao)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_ChuongTrinhDaoTao_GetLopResult>(client.cDKQHT_ChuongTrinhDaoTao_GetLop(GlobalVar.MaXacThuc, IDKQHT_ChuongTrinhDaoTao));
            }
        }

        public int Add(KQHT_ChuongTrinhDaoTaoInfo pKQHT_ChuongTrinhDaoTaoInfo)
        {
            int ID = 0;
            var client = new UnimOsServiceClient();
            ID = client.cDKQHT_ChuongTrinhDaoTao_Add(GlobalVar.MaXacThuc, pKQHT_ChuongTrinhDaoTaoInfo);
            client.Close();
            mErrorMessage = oDKQHT_ChuongTrinhDaoTao.ErrorMessages;
            mErrorNumber = oDKQHT_ChuongTrinhDaoTao.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_ChuongTrinhDaoTaoInfo pKQHT_ChuongTrinhDaoTaoInfo)
        {
            var client = new UnimOsServiceClient();
            client.cDKQHT_ChuongTrinhDaoTao_Update(GlobalVar.MaXacThuc, pKQHT_ChuongTrinhDaoTaoInfo);
            client.Close();
            mErrorMessage = oDKQHT_ChuongTrinhDaoTao.ErrorMessages;
            mErrorNumber = oDKQHT_ChuongTrinhDaoTao.ErrorNumber;
        }

        public void Delete(KQHT_ChuongTrinhDaoTaoInfo pKQHT_ChuongTrinhDaoTaoInfo)
        {
            var client = new UnimOsServiceClient();
            client.cDKQHT_ChuongTrinhDaoTao_Delete(GlobalVar.MaXacThuc, pKQHT_ChuongTrinhDaoTaoInfo);
            client.Close();
            mErrorMessage = oDKQHT_ChuongTrinhDaoTao.ErrorMessages;
            mErrorNumber = oDKQHT_ChuongTrinhDaoTao.ErrorNumber;
        }

        public List<KQHT_ChuongTrinhDaoTaoInfo> GetList(KQHT_ChuongTrinhDaoTaoInfo pKQHT_ChuongTrinhDaoTaoInfo)
        {
            List<KQHT_ChuongTrinhDaoTaoInfo> oKQHT_ChuongTrinhDaoTaoInfoList = new List<KQHT_ChuongTrinhDaoTaoInfo>();
            DataTable dtb = Get(pKQHT_ChuongTrinhDaoTaoInfo);
            if (dtb != null)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    oKQHT_ChuongTrinhDaoTaoInfo = new KQHT_ChuongTrinhDaoTaoInfo();

                    oKQHT_ChuongTrinhDaoTaoInfo.KQHT_ChuongTrinhDaoTaoID = int.Parse(dtb.Rows[i]["KQHT_ChuongTrinhDaoTaoID"].ToString());
                    oKQHT_ChuongTrinhDaoTaoInfo.MaChuongTrinhDaoTao = dtb.Rows[i]["MaChuongTrinhDaoTao"].ToString();
                    oKQHT_ChuongTrinhDaoTaoInfo.TenChuongTrinhDaoTao = dtb.Rows[i]["TenChuongTrinhDaoTao"].ToString();
                    oKQHT_ChuongTrinhDaoTaoInfo.IDDM_TrinhDo = int.Parse(dtb.Rows[i]["IDDM_TrinhDo"].ToString());
                    oKQHT_ChuongTrinhDaoTaoInfo.IDDM_Nganh = int.Parse(dtb.Rows[i]["IDDM_Nganh"].ToString());
                    oKQHT_ChuongTrinhDaoTaoInfo.IDDM_ChuyenNganh = int.Parse(dtb.Rows[i]["IDDM_ChuyenNganh"].ToString());
                    oKQHT_ChuongTrinhDaoTaoInfo.IDDM_KhoaHoc = int.Parse(dtb.Rows[i]["IDDM_KhoaHoc"].ToString());
                    oKQHT_ChuongTrinhDaoTaoInfo.ChuongTrinhDaoTaoSo = int.Parse(dtb.Rows[i]["ChuongTrinhDaoTaoSo"].ToString());
                    oKQHT_ChuongTrinhDaoTaoInfo.MoTa = dtb.Rows[i]["MoTa"].ToString();

                    oKQHT_ChuongTrinhDaoTaoInfoList.Add(oKQHT_ChuongTrinhDaoTaoInfo);
                }
            }
            return oKQHT_ChuongTrinhDaoTaoInfoList;
        }

        public void ToDataRow(KQHT_ChuongTrinhDaoTaoInfo pKQHT_ChuongTrinhDaoTaoInfo, ref DataRow dr)
        {

            dr[pKQHT_ChuongTrinhDaoTaoInfo.strKQHT_ChuongTrinhDaoTaoID] = pKQHT_ChuongTrinhDaoTaoInfo.KQHT_ChuongTrinhDaoTaoID;
            dr[pKQHT_ChuongTrinhDaoTaoInfo.strMaChuongTrinhDaoTao] = pKQHT_ChuongTrinhDaoTaoInfo.MaChuongTrinhDaoTao;
            dr[pKQHT_ChuongTrinhDaoTaoInfo.strTenChuongTrinhDaoTao] = pKQHT_ChuongTrinhDaoTaoInfo.TenChuongTrinhDaoTao;
            dr[pKQHT_ChuongTrinhDaoTaoInfo.strIDDM_TrinhDo] = pKQHT_ChuongTrinhDaoTaoInfo.IDDM_TrinhDo;
            dr[pKQHT_ChuongTrinhDaoTaoInfo.strIDDM_Nganh] = pKQHT_ChuongTrinhDaoTaoInfo.IDDM_Nganh;
            dr[pKQHT_ChuongTrinhDaoTaoInfo.strIDDM_ChuyenNganh] = pKQHT_ChuongTrinhDaoTaoInfo.IDDM_ChuyenNganh;
            dr[pKQHT_ChuongTrinhDaoTaoInfo.strIDDM_KhoaHoc] = pKQHT_ChuongTrinhDaoTaoInfo.IDDM_KhoaHoc;
            dr[pKQHT_ChuongTrinhDaoTaoInfo.strChuongTrinhDaoTaoSo] = pKQHT_ChuongTrinhDaoTaoInfo.ChuongTrinhDaoTaoSo;
            dr[pKQHT_ChuongTrinhDaoTaoInfo.strMoTa] = pKQHT_ChuongTrinhDaoTaoInfo.MoTa;
        }
    }
}
