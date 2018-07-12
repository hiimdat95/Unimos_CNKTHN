using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_XepLoaiTotNghiep : cBBase
    {
        private cDKQHT_XepLoaiTotNghiep oDKQHT_XepLoaiTotNghiep;
        private KQHT_XepLoaiTotNghiepInfo oKQHT_XepLoaiTotNghiepInfo;

        public cBKQHT_XepLoaiTotNghiep()        
        {
            oDKQHT_XepLoaiTotNghiep = new cDKQHT_XepLoaiTotNghiep();
        }

        public DataTable Get(KQHT_XepLoaiTotNghiepInfo pKQHT_XepLoaiTotNghiepInfo)        
        {
            return oDKQHT_XepLoaiTotNghiep.Get(pKQHT_XepLoaiTotNghiepInfo);
        }

        public int Add(KQHT_XepLoaiTotNghiepInfo pKQHT_XepLoaiTotNghiepInfo)
        {
			int ID = 0;
            ID = oDKQHT_XepLoaiTotNghiep.Add(pKQHT_XepLoaiTotNghiepInfo);
            mErrorMessage = oDKQHT_XepLoaiTotNghiep.ErrorMessages;
            mErrorNumber = oDKQHT_XepLoaiTotNghiep.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_XepLoaiTotNghiepInfo pKQHT_XepLoaiTotNghiepInfo)
        {
            oDKQHT_XepLoaiTotNghiep.Update(pKQHT_XepLoaiTotNghiepInfo);
            mErrorMessage = oDKQHT_XepLoaiTotNghiep.ErrorMessages;
            mErrorNumber = oDKQHT_XepLoaiTotNghiep.ErrorNumber;
        }
        
        public void Delete(KQHT_XepLoaiTotNghiepInfo pKQHT_XepLoaiTotNghiepInfo)
        {
            oDKQHT_XepLoaiTotNghiep.Delete(pKQHT_XepLoaiTotNghiepInfo);
            mErrorMessage = oDKQHT_XepLoaiTotNghiep.ErrorMessages;
            mErrorNumber = oDKQHT_XepLoaiTotNghiep.ErrorNumber;
        }

        public List<KQHT_XepLoaiTotNghiepInfo> GetList(KQHT_XepLoaiTotNghiepInfo pKQHT_XepLoaiTotNghiepInfo)
        {
            List<KQHT_XepLoaiTotNghiepInfo> oKQHT_XepLoaiTotNghiepInfoList = new List<KQHT_XepLoaiTotNghiepInfo>();
            DataTable dtb = Get(pKQHT_XepLoaiTotNghiepInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_XepLoaiTotNghiepInfo = new KQHT_XepLoaiTotNghiepInfo();

                    oKQHT_XepLoaiTotNghiepInfo.KQHT_XepLoaiTotNghiepID = int.Parse(dtb.Rows[i]["KQHT_XepLoaiTotNghiepID"].ToString());
                    oKQHT_XepLoaiTotNghiepInfo.TenXepLoai = dtb.Rows[i]["TenXepLoai"].ToString();
                    oKQHT_XepLoaiTotNghiepInfo.TuDiem = double.Parse(dtb.Rows[i]["TuDiem"].ToString());
                    oKQHT_XepLoaiTotNghiepInfo.MaXepLoai = dtb.Rows[i]["MaXepLoai"].ToString();
                    oKQHT_XepLoaiTotNghiepInfo.HaXepLoaiThiLaiQuaMucPhanTram = 
                        "" + dtb.Rows[i]["HaXepLoaiThiLaiQuaMucPhanTram"] == "" ? false : 
                            bool.Parse(dtb.Rows[i]["HaXepLoaiThiLaiQuaMucPhanTram"].ToString());
                    
                    oKQHT_XepLoaiTotNghiepInfoList.Add(oKQHT_XepLoaiTotNghiepInfo);
                }
            }
            return oKQHT_XepLoaiTotNghiepInfoList;
        }
        
        public void ToDataRow(KQHT_XepLoaiTotNghiepInfo pKQHT_XepLoaiTotNghiepInfo, ref DataRow dr)
        {

			dr[pKQHT_XepLoaiTotNghiepInfo.strKQHT_XepLoaiTotNghiepID] = pKQHT_XepLoaiTotNghiepInfo.KQHT_XepLoaiTotNghiepID;
			dr[pKQHT_XepLoaiTotNghiepInfo.strTenXepLoai] = pKQHT_XepLoaiTotNghiepInfo.TenXepLoai;
			dr[pKQHT_XepLoaiTotNghiepInfo.strTuDiem] = pKQHT_XepLoaiTotNghiepInfo.TuDiem;
			dr[pKQHT_XepLoaiTotNghiepInfo.strMaXepLoai] = pKQHT_XepLoaiTotNghiepInfo.MaXepLoai;
            dr[pKQHT_XepLoaiTotNghiepInfo.strHaXepLoaiThiLaiQuaMucPhanTram] = pKQHT_XepLoaiTotNghiepInfo.HaXepLoaiThiLaiQuaMucPhanTram;
        }
        
        public void ToInfo(ref KQHT_XepLoaiTotNghiepInfo pKQHT_XepLoaiTotNghiepInfo, DataRow dr)
        {

			pKQHT_XepLoaiTotNghiepInfo.KQHT_XepLoaiTotNghiepID = int.Parse(dr[pKQHT_XepLoaiTotNghiepInfo.strKQHT_XepLoaiTotNghiepID].ToString());
			pKQHT_XepLoaiTotNghiepInfo.TenXepLoai = dr[pKQHT_XepLoaiTotNghiepInfo.strTenXepLoai].ToString();
			pKQHT_XepLoaiTotNghiepInfo.TuDiem = double.Parse(dr[pKQHT_XepLoaiTotNghiepInfo.strTuDiem].ToString());
			pKQHT_XepLoaiTotNghiepInfo.MaXepLoai = dr[pKQHT_XepLoaiTotNghiepInfo.strMaXepLoai].ToString();
            pKQHT_XepLoaiTotNghiepInfo.HaXepLoaiThiLaiQuaMucPhanTram = "" + dr[pKQHT_XepLoaiTotNghiepInfo.strHaXepLoaiThiLaiQuaMucPhanTram] == "" ? 
                false : bool.Parse(dr[pKQHT_XepLoaiTotNghiepInfo.strHaXepLoaiThiLaiQuaMucPhanTram].ToString());
        }
    }
}
