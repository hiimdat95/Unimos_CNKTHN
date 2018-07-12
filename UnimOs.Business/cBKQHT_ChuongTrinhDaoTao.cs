using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_ChuongTrinhDaoTao : cBBase
    {
        private cDKQHT_ChuongTrinhDaoTao oDKQHT_ChuongTrinhDaoTao;
        private KQHT_ChuongTrinhDaoTaoInfo oKQHT_ChuongTrinhDaoTaoInfo;

        public cBKQHT_ChuongTrinhDaoTao()        
        {
            oDKQHT_ChuongTrinhDaoTao = new cDKQHT_ChuongTrinhDaoTao();
        }

        public DataTable Get(KQHT_ChuongTrinhDaoTaoInfo pKQHT_ChuongTrinhDaoTaoInfo)        
        {
            return oDKQHT_ChuongTrinhDaoTao.Get(pKQHT_ChuongTrinhDaoTaoInfo);
        }

        public DataTable GetDanhSach(int IDDM_TrinhDo)
        {
            return oDKQHT_ChuongTrinhDaoTao.GetDanhSach(IDDM_TrinhDo);
        }

        public DataTable GetChiTiet(int KQHT_ChuongTrinhDaoTaoID)
        {
            return oDKQHT_ChuongTrinhDaoTao.GetChiTiet(KQHT_ChuongTrinhDaoTaoID);
        }

        public DataTable GetMonKhung(int KQHT_ChuongTrinhDaoTaoID, int IDDM_Lop, int HocKy)
        {
            return oDKQHT_ChuongTrinhDaoTao.GetMonKhung(KQHT_ChuongTrinhDaoTaoID, IDDM_Lop, HocKy);
        }
        
        public DataTable GetMonChuaToChuc(int KQHT_ChuongTrinhDaoTaoID, int IDDM_Lop,int CTDT_HocKy)
        {
            return oDKQHT_ChuongTrinhDaoTao.GetMonChuaToChuc(KQHT_ChuongTrinhDaoTaoID, IDDM_Lop,CTDT_HocKy);
        }

        public DataTable GetLop(int IDKQHT_ChuongTrinhDaoTao)
        {
            return oDKQHT_ChuongTrinhDaoTao.GetLop(IDKQHT_ChuongTrinhDaoTao);
        }

        public int Add(KQHT_ChuongTrinhDaoTaoInfo pKQHT_ChuongTrinhDaoTaoInfo)
        {
			int ID = 0;
            ID = oDKQHT_ChuongTrinhDaoTao.Add(pKQHT_ChuongTrinhDaoTaoInfo);
            mErrorMessage = oDKQHT_ChuongTrinhDaoTao.ErrorMessages;
            mErrorNumber = oDKQHT_ChuongTrinhDaoTao.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_ChuongTrinhDaoTaoInfo pKQHT_ChuongTrinhDaoTaoInfo)
        {
            oDKQHT_ChuongTrinhDaoTao.Update(pKQHT_ChuongTrinhDaoTaoInfo);
            mErrorMessage = oDKQHT_ChuongTrinhDaoTao.ErrorMessages;
            mErrorNumber = oDKQHT_ChuongTrinhDaoTao.ErrorNumber;
        }
        
        public void Delete(KQHT_ChuongTrinhDaoTaoInfo pKQHT_ChuongTrinhDaoTaoInfo)
        {
            oDKQHT_ChuongTrinhDaoTao.Delete(pKQHT_ChuongTrinhDaoTaoInfo);
            mErrorMessage = oDKQHT_ChuongTrinhDaoTao.ErrorMessages;
            mErrorNumber = oDKQHT_ChuongTrinhDaoTao.ErrorNumber;
        }

        public List<KQHT_ChuongTrinhDaoTaoInfo> GetList(KQHT_ChuongTrinhDaoTaoInfo pKQHT_ChuongTrinhDaoTaoInfo)
        {
            List<KQHT_ChuongTrinhDaoTaoInfo> oKQHT_ChuongTrinhDaoTaoInfoList = new List<KQHT_ChuongTrinhDaoTaoInfo>();
            DataTable dtb = Get(pKQHT_ChuongTrinhDaoTaoInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
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
