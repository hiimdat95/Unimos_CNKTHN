using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_MonThiTotNghiep : cBBase
    {
        private cDKQHT_MonThiTotNghiep oDKQHT_MonThiTotNghiep;
        private KQHT_MonThiTotNghiepInfo oKQHT_MonThiTotNghiepInfo;

        public cBKQHT_MonThiTotNghiep()        
        {
            oDKQHT_MonThiTotNghiep = new cDKQHT_MonThiTotNghiep();
        }

        public DataTable Get(KQHT_MonThiTotNghiepInfo pKQHT_MonThiTotNghiepInfo)        
        {
            return oDKQHT_MonThiTotNghiep.Get(pKQHT_MonThiTotNghiepInfo);
        }

        public int Add(KQHT_MonThiTotNghiepInfo pKQHT_MonThiTotNghiepInfo)
        {
			int ID = 0;
            ID = oDKQHT_MonThiTotNghiep.Add(pKQHT_MonThiTotNghiepInfo);
            mErrorMessage = oDKQHT_MonThiTotNghiep.ErrorMessages;
            mErrorNumber = oDKQHT_MonThiTotNghiep.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_MonThiTotNghiepInfo pKQHT_MonThiTotNghiepInfo)
        {
            oDKQHT_MonThiTotNghiep.Update(pKQHT_MonThiTotNghiepInfo);
            mErrorMessage = oDKQHT_MonThiTotNghiep.ErrorMessages;
            mErrorNumber = oDKQHT_MonThiTotNghiep.ErrorNumber;
        }
        
        public void Delete(KQHT_MonThiTotNghiepInfo pKQHT_MonThiTotNghiepInfo)
        {
            oDKQHT_MonThiTotNghiep.Delete(pKQHT_MonThiTotNghiepInfo);
            mErrorMessage = oDKQHT_MonThiTotNghiep.ErrorMessages;
            mErrorNumber = oDKQHT_MonThiTotNghiep.ErrorNumber;
        }

        public List<KQHT_MonThiTotNghiepInfo> GetList(KQHT_MonThiTotNghiepInfo pKQHT_MonThiTotNghiepInfo)
        {
            List<KQHT_MonThiTotNghiepInfo> oKQHT_MonThiTotNghiepInfoList = new List<KQHT_MonThiTotNghiepInfo>();
            DataTable dtb = Get(pKQHT_MonThiTotNghiepInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_MonThiTotNghiepInfo = new KQHT_MonThiTotNghiepInfo();

                    oKQHT_MonThiTotNghiepInfo.KQHT_MonThiTotNghiepID = int.Parse(dtb.Rows[i]["KQHT_MonThiTotNghiepID"].ToString());
                    oKQHT_MonThiTotNghiepInfo.MaMon = dtb.Rows[i]["MaMon"].ToString();
                    oKQHT_MonThiTotNghiepInfo.TenMon = dtb.Rows[i]["TenMon"].ToString();
                    oKQHT_MonThiTotNghiepInfo.TinhDiem = bool.Parse(dtb.Rows[i]["TinhDiem"].ToString());
                    oKQHT_MonThiTotNghiepInfo.DiemDieuKien = double.Parse(dtb.Rows[i]["DiemDieuKien"].ToString());
                    oKQHT_MonThiTotNghiepInfo.SoHocTrinh = double.Parse(dtb.Rows[i]["SoHocTrinh"].ToString());
                    
                    oKQHT_MonThiTotNghiepInfoList.Add(oKQHT_MonThiTotNghiepInfo);
                }
            }
            return oKQHT_MonThiTotNghiepInfoList;
        }
        
        public void ToDataRow(KQHT_MonThiTotNghiepInfo pKQHT_MonThiTotNghiepInfo, ref DataRow dr)
        {

			dr[pKQHT_MonThiTotNghiepInfo.strKQHT_MonThiTotNghiepID] = pKQHT_MonThiTotNghiepInfo.KQHT_MonThiTotNghiepID;
			dr[pKQHT_MonThiTotNghiepInfo.strMaMon] = pKQHT_MonThiTotNghiepInfo.MaMon;
			dr[pKQHT_MonThiTotNghiepInfo.strTenMon] = pKQHT_MonThiTotNghiepInfo.TenMon;
			dr[pKQHT_MonThiTotNghiepInfo.strTinhDiem] = pKQHT_MonThiTotNghiepInfo.TinhDiem;
			dr[pKQHT_MonThiTotNghiepInfo.strDiemDieuKien] = pKQHT_MonThiTotNghiepInfo.DiemDieuKien;
			dr[pKQHT_MonThiTotNghiepInfo.strSoHocTrinh] = pKQHT_MonThiTotNghiepInfo.SoHocTrinh;
        }
        
        public void ToInfo(ref KQHT_MonThiTotNghiepInfo pKQHT_MonThiTotNghiepInfo, DataRow dr)
        {

			pKQHT_MonThiTotNghiepInfo.KQHT_MonThiTotNghiepID = int.Parse(dr[pKQHT_MonThiTotNghiepInfo.strKQHT_MonThiTotNghiepID].ToString());
			pKQHT_MonThiTotNghiepInfo.MaMon = dr[pKQHT_MonThiTotNghiepInfo.strMaMon].ToString();
			pKQHT_MonThiTotNghiepInfo.TenMon = dr[pKQHT_MonThiTotNghiepInfo.strTenMon].ToString();
			pKQHT_MonThiTotNghiepInfo.TinhDiem = bool.Parse(dr[pKQHT_MonThiTotNghiepInfo.strTinhDiem].ToString());
			pKQHT_MonThiTotNghiepInfo.DiemDieuKien = double.Parse("0" + dr[pKQHT_MonThiTotNghiepInfo.strDiemDieuKien].ToString());
            pKQHT_MonThiTotNghiepInfo.SoHocTrinh = double.Parse("0" +  dr[pKQHT_MonThiTotNghiepInfo.strSoHocTrinh].ToString());
        }
    }
}
