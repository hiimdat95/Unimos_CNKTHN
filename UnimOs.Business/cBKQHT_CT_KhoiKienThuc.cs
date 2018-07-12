using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_CT_KhoiKienThuc : cBBase
    {
        private cDKQHT_CT_KhoiKienThuc oDKQHT_CT_KhoiKienThuc;
        private KQHT_CT_KhoiKienThucInfo oKQHT_CT_KhoiKienThucInfo;

        public cBKQHT_CT_KhoiKienThuc()        
        {
            oDKQHT_CT_KhoiKienThuc = new cDKQHT_CT_KhoiKienThuc();
        }

        public DataTable Get(KQHT_CT_KhoiKienThucInfo pKQHT_CT_KhoiKienThucInfo)        
        {
            return oDKQHT_CT_KhoiKienThuc.Get(pKQHT_CT_KhoiKienThucInfo);
        }

        public DataTable GetDanhSach(int IDDM_KhoiKienThuc)
        {
            return oDKQHT_CT_KhoiKienThuc.GetDanhSach(IDDM_KhoiKienThuc);
        }

        public DataTable GetChon(int IDKQHT_ChuongTrinhDaoTao)
        {
            return oDKQHT_CT_KhoiKienThuc.GetChon(IDKQHT_ChuongTrinhDaoTao);
        }

        public int Add(KQHT_CT_KhoiKienThucInfo pKQHT_CT_KhoiKienThucInfo)
        {
			int ID = 0;
            ID = oDKQHT_CT_KhoiKienThuc.Add(pKQHT_CT_KhoiKienThucInfo);
            mErrorMessage = oDKQHT_CT_KhoiKienThuc.ErrorMessages;
            mErrorNumber = oDKQHT_CT_KhoiKienThuc.ErrorNumber;
            return ID;
        }

        public int AddKeThua(KQHT_CT_KhoiKienThucInfo pKQHT_CT_KhoiKienThucInfo, int IDKQHT_CT_KhoiKienThucGoc)
        {
            int ID = 0;
            ID = oDKQHT_CT_KhoiKienThuc.AddKeThua(pKQHT_CT_KhoiKienThucInfo, IDKQHT_CT_KhoiKienThucGoc);
            mErrorMessage = oDKQHT_CT_KhoiKienThuc.ErrorMessages;
            mErrorNumber = oDKQHT_CT_KhoiKienThuc.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_CT_KhoiKienThucInfo pKQHT_CT_KhoiKienThucInfo)
        {
            oDKQHT_CT_KhoiKienThuc.Update(pKQHT_CT_KhoiKienThucInfo);
            mErrorMessage = oDKQHT_CT_KhoiKienThuc.ErrorMessages;
            mErrorNumber = oDKQHT_CT_KhoiKienThuc.ErrorNumber;
        }
        
        public void Delete(KQHT_CT_KhoiKienThucInfo pKQHT_CT_KhoiKienThucInfo)
        {
            oDKQHT_CT_KhoiKienThuc.Delete(pKQHT_CT_KhoiKienThucInfo);
            mErrorMessage = oDKQHT_CT_KhoiKienThuc.ErrorMessages;
            mErrorNumber = oDKQHT_CT_KhoiKienThuc.ErrorNumber;
        }

        public List<KQHT_CT_KhoiKienThucInfo> GetList(KQHT_CT_KhoiKienThucInfo pKQHT_CT_KhoiKienThucInfo)
        {
            List<KQHT_CT_KhoiKienThucInfo> oKQHT_CT_KhoiKienThucInfoList = new List<KQHT_CT_KhoiKienThucInfo>();
            DataTable dtb = Get(pKQHT_CT_KhoiKienThucInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_CT_KhoiKienThucInfo = new KQHT_CT_KhoiKienThucInfo();

                    oKQHT_CT_KhoiKienThucInfo.KQHT_CT_KhoiKienThucID = int.Parse(dtb.Rows[i]["KQHT_CT_KhoiKienThucID"].ToString());
                    oKQHT_CT_KhoiKienThucInfo.TenCT_KhoiKienThuc = dtb.Rows[i]["TenCT_KhoiKienThuc"].ToString();
                    oKQHT_CT_KhoiKienThucInfo.IDDM_TrinhDo = int.Parse(dtb.Rows[i]["IDDM_TrinhDo"].ToString());
                    oKQHT_CT_KhoiKienThucInfo.IDDM_Nganh = int.Parse(dtb.Rows[i]["IDDM_Nganh"].ToString());
                    oKQHT_CT_KhoiKienThucInfo.IDDM_ChuyenNganh = int.Parse(dtb.Rows[i]["IDDM_ChuyenNganh"].ToString());
                    oKQHT_CT_KhoiKienThucInfo.IDDM_KhoaHoc = int.Parse(dtb.Rows[i]["IDDM_KhoaHoc"].ToString());
                    oKQHT_CT_KhoiKienThucInfo.IDDM_KhoiKienThuc = int.Parse(dtb.Rows[i]["IDDM_KhoiKienThuc"].ToString());
                    oKQHT_CT_KhoiKienThucInfo.CT_KhoiKienThucSo = int.Parse(dtb.Rows[i]["CT_KhoiKienThucSo"].ToString());
                    oKQHT_CT_KhoiKienThucInfo.TongSoHocTrinh = int.Parse(dtb.Rows[i]["TongSoHocTrinh"].ToString());
                    oKQHT_CT_KhoiKienThucInfo.TongSoMon = int.Parse(dtb.Rows[i]["TongSoMon"].ToString());
                    oKQHT_CT_KhoiKienThucInfo.MoTa = dtb.Rows[i]["MoTa"].ToString();
                    
                    oKQHT_CT_KhoiKienThucInfoList.Add(oKQHT_CT_KhoiKienThucInfo);
                }
            }
            return oKQHT_CT_KhoiKienThucInfoList;
        }
        
        public void ToDataRow(KQHT_CT_KhoiKienThucInfo pKQHT_CT_KhoiKienThucInfo, ref DataRow dr)
        {

			dr[pKQHT_CT_KhoiKienThucInfo.strKQHT_CT_KhoiKienThucID] = pKQHT_CT_KhoiKienThucInfo.KQHT_CT_KhoiKienThucID;
			dr[pKQHT_CT_KhoiKienThucInfo.strTenCT_KhoiKienThuc] = pKQHT_CT_KhoiKienThucInfo.TenCT_KhoiKienThuc;
			dr[pKQHT_CT_KhoiKienThucInfo.strIDDM_TrinhDo] = pKQHT_CT_KhoiKienThucInfo.IDDM_TrinhDo;
			dr[pKQHT_CT_KhoiKienThucInfo.strIDDM_Nganh] = pKQHT_CT_KhoiKienThucInfo.IDDM_Nganh;
			dr[pKQHT_CT_KhoiKienThucInfo.strIDDM_ChuyenNganh] = pKQHT_CT_KhoiKienThucInfo.IDDM_ChuyenNganh;
			dr[pKQHT_CT_KhoiKienThucInfo.strIDDM_KhoaHoc] = pKQHT_CT_KhoiKienThucInfo.IDDM_KhoaHoc;
			dr[pKQHT_CT_KhoiKienThucInfo.strIDDM_KhoiKienThuc] = pKQHT_CT_KhoiKienThucInfo.IDDM_KhoiKienThuc;
			dr[pKQHT_CT_KhoiKienThucInfo.strCT_KhoiKienThucSo] = pKQHT_CT_KhoiKienThucInfo.CT_KhoiKienThucSo;
			dr[pKQHT_CT_KhoiKienThucInfo.strTongSoHocTrinh] = pKQHT_CT_KhoiKienThucInfo.TongSoHocTrinh;
			dr[pKQHT_CT_KhoiKienThucInfo.strTongSoMon] = pKQHT_CT_KhoiKienThucInfo.TongSoMon;
			dr[pKQHT_CT_KhoiKienThucInfo.strMoTa] = pKQHT_CT_KhoiKienThucInfo.MoTa;
        }
    }
}
