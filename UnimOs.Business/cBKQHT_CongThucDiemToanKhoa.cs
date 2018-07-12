using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_CongThucDiemToanKhoa : cBBase
    {
        private cDKQHT_CongThucDiemToanKhoa oDKQHT_CongThucDiemToanKhoa;
        private KQHT_CongThucDiemToanKhoaInfo oKQHT_CongThucDiemToanKhoaInfo;

        public cBKQHT_CongThucDiemToanKhoa()        
        {
            oDKQHT_CongThucDiemToanKhoa = new cDKQHT_CongThucDiemToanKhoa();
        }

        public DataTable Get(KQHT_CongThucDiemToanKhoaInfo pKQHT_CongThucDiemToanKhoaInfo)        
        {
            return oDKQHT_CongThucDiemToanKhoa.Get(pKQHT_CongThucDiemToanKhoaInfo);
        }

        public int Add(KQHT_CongThucDiemToanKhoaInfo pKQHT_CongThucDiemToanKhoaInfo)
        {
			int ID = 0;
            ID = oDKQHT_CongThucDiemToanKhoa.Add(pKQHT_CongThucDiemToanKhoaInfo);
            mErrorMessage = oDKQHT_CongThucDiemToanKhoa.ErrorMessages;
            mErrorNumber = oDKQHT_CongThucDiemToanKhoa.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_CongThucDiemToanKhoaInfo pKQHT_CongThucDiemToanKhoaInfo)
        {
            oDKQHT_CongThucDiemToanKhoa.Update(pKQHT_CongThucDiemToanKhoaInfo);
            mErrorMessage = oDKQHT_CongThucDiemToanKhoa.ErrorMessages;
            mErrorNumber = oDKQHT_CongThucDiemToanKhoa.ErrorNumber;
        }
        
        public void Delete(KQHT_CongThucDiemToanKhoaInfo pKQHT_CongThucDiemToanKhoaInfo)
        {
            oDKQHT_CongThucDiemToanKhoa.Delete(pKQHT_CongThucDiemToanKhoaInfo);
            mErrorMessage = oDKQHT_CongThucDiemToanKhoa.ErrorMessages;
            mErrorNumber = oDKQHT_CongThucDiemToanKhoa.ErrorNumber;
        }

        public List<KQHT_CongThucDiemToanKhoaInfo> GetList(KQHT_CongThucDiemToanKhoaInfo pKQHT_CongThucDiemToanKhoaInfo)
        {
            List<KQHT_CongThucDiemToanKhoaInfo> oKQHT_CongThucDiemToanKhoaInfoList = new List<KQHT_CongThucDiemToanKhoaInfo>();
            DataTable dtb = Get(pKQHT_CongThucDiemToanKhoaInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_CongThucDiemToanKhoaInfo = new KQHT_CongThucDiemToanKhoaInfo();

                    oKQHT_CongThucDiemToanKhoaInfo.KQHT_CongThucDiemToanKhoaID = int.Parse(dtb.Rows[i]["KQHT_CongThucDiemToanKhoaID"].ToString());
                    oKQHT_CongThucDiemToanKhoaInfo.TenCongThucDiem = dtb.Rows[i]["TenCongThucDiem"].ToString();
                    oKQHT_CongThucDiemToanKhoaInfo.CongThuc = dtb.Rows[i]["CongThuc"].ToString();
                    oKQHT_CongThucDiemToanKhoaInfo.GhChu = dtb.Rows[i]["GhChu"].ToString();
                    
                    oKQHT_CongThucDiemToanKhoaInfoList.Add(oKQHT_CongThucDiemToanKhoaInfo);
                }
            }
            return oKQHT_CongThucDiemToanKhoaInfoList;
        }
        
        public void ToDataRow(KQHT_CongThucDiemToanKhoaInfo pKQHT_CongThucDiemToanKhoaInfo, ref DataRow dr)
        {

			dr[pKQHT_CongThucDiemToanKhoaInfo.strKQHT_CongThucDiemToanKhoaID] = pKQHT_CongThucDiemToanKhoaInfo.KQHT_CongThucDiemToanKhoaID;
			dr[pKQHT_CongThucDiemToanKhoaInfo.strTenCongThucDiem] = pKQHT_CongThucDiemToanKhoaInfo.TenCongThucDiem;
			dr[pKQHT_CongThucDiemToanKhoaInfo.strCongThuc] = pKQHT_CongThucDiemToanKhoaInfo.CongThuc;
			dr[pKQHT_CongThucDiemToanKhoaInfo.strGhChu] = pKQHT_CongThucDiemToanKhoaInfo.GhChu;
        }
        
        public void ToInfo(ref KQHT_CongThucDiemToanKhoaInfo pKQHT_CongThucDiemToanKhoaInfo, DataRow dr)
        {

			pKQHT_CongThucDiemToanKhoaInfo.KQHT_CongThucDiemToanKhoaID = int.Parse(dr[pKQHT_CongThucDiemToanKhoaInfo.strKQHT_CongThucDiemToanKhoaID].ToString());
			pKQHT_CongThucDiemToanKhoaInfo.TenCongThucDiem = dr[pKQHT_CongThucDiemToanKhoaInfo.strTenCongThucDiem].ToString();
			pKQHT_CongThucDiemToanKhoaInfo.CongThuc = dr[pKQHT_CongThucDiemToanKhoaInfo.strCongThuc].ToString();
			pKQHT_CongThucDiemToanKhoaInfo.GhChu = dr[pKQHT_CongThucDiemToanKhoaInfo.strGhChu].ToString();
        }
    }
}
