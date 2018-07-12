using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_XepLoaiMonHoc : cBBase
    {
        private cDKQHT_XepLoaiMonHoc oDKQHT_XepLoaiMonHoc;
        private KQHT_XepLoaiMonHocInfo oKQHT_XepLoaiMonHocInfo;

        public cBKQHT_XepLoaiMonHoc()        
        {
            oDKQHT_XepLoaiMonHoc = new cDKQHT_XepLoaiMonHoc();
        }

        public DataTable Get(KQHT_XepLoaiMonHocInfo pKQHT_XepLoaiMonHocInfo)        
        {
            return oDKQHT_XepLoaiMonHoc.Get(pKQHT_XepLoaiMonHocInfo);
        }

        public int Add(KQHT_XepLoaiMonHocInfo pKQHT_XepLoaiMonHocInfo)
        {
			int ID = 0;
            ID = oDKQHT_XepLoaiMonHoc.Add(pKQHT_XepLoaiMonHocInfo);
            mErrorMessage = oDKQHT_XepLoaiMonHoc.ErrorMessages;
            mErrorNumber = oDKQHT_XepLoaiMonHoc.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_XepLoaiMonHocInfo pKQHT_XepLoaiMonHocInfo)
        {
            oDKQHT_XepLoaiMonHoc.Update(pKQHT_XepLoaiMonHocInfo);
            mErrorMessage = oDKQHT_XepLoaiMonHoc.ErrorMessages;
            mErrorNumber = oDKQHT_XepLoaiMonHoc.ErrorNumber;
        }
        
        public void Delete(KQHT_XepLoaiMonHocInfo pKQHT_XepLoaiMonHocInfo)
        {
            oDKQHT_XepLoaiMonHoc.Delete(pKQHT_XepLoaiMonHocInfo);
            mErrorMessage = oDKQHT_XepLoaiMonHoc.ErrorMessages;
            mErrorNumber = oDKQHT_XepLoaiMonHoc.ErrorNumber;
        }

        public List<KQHT_XepLoaiMonHocInfo> GetList(KQHT_XepLoaiMonHocInfo pKQHT_XepLoaiMonHocInfo)
        {
            List<KQHT_XepLoaiMonHocInfo> oKQHT_XepLoaiMonHocInfoList = new List<KQHT_XepLoaiMonHocInfo>();
            DataTable dtb = Get(pKQHT_XepLoaiMonHocInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_XepLoaiMonHocInfo = new KQHT_XepLoaiMonHocInfo();

                    oKQHT_XepLoaiMonHocInfo.KQHT_XepLoaiMonHocID = int.Parse(dtb.Rows[i]["KQHT_XepLoaiMonHocID"].ToString());
                    oKQHT_XepLoaiMonHocInfo.TenXepLoai = dtb.Rows[i]["TenXepLoai"].ToString();
                    oKQHT_XepLoaiMonHocInfo.TuDiem = double.Parse(dtb.Rows[i]["TuDiem"].ToString());
                    oKQHT_XepLoaiMonHocInfo.MaXepLoai = dtb.Rows[i]["MaXepLoai"].ToString();
                    
                    oKQHT_XepLoaiMonHocInfoList.Add(oKQHT_XepLoaiMonHocInfo);
                }
            }
            return oKQHT_XepLoaiMonHocInfoList;
        }
        
        public void ToDataRow(KQHT_XepLoaiMonHocInfo pKQHT_XepLoaiMonHocInfo, ref DataRow dr)
        {

			dr[pKQHT_XepLoaiMonHocInfo.strKQHT_XepLoaiMonHocID] = pKQHT_XepLoaiMonHocInfo.KQHT_XepLoaiMonHocID;
			dr[pKQHT_XepLoaiMonHocInfo.strTenXepLoai] = pKQHT_XepLoaiMonHocInfo.TenXepLoai;
			dr[pKQHT_XepLoaiMonHocInfo.strTuDiem] = pKQHT_XepLoaiMonHocInfo.TuDiem;
			dr[pKQHT_XepLoaiMonHocInfo.strMaXepLoai] = pKQHT_XepLoaiMonHocInfo.MaXepLoai;
        }
        
        public void ToInfo(ref KQHT_XepLoaiMonHocInfo pKQHT_XepLoaiMonHocInfo, DataRow dr)
        {

			pKQHT_XepLoaiMonHocInfo.KQHT_XepLoaiMonHocID = int.Parse(dr[pKQHT_XepLoaiMonHocInfo.strKQHT_XepLoaiMonHocID].ToString());
			pKQHT_XepLoaiMonHocInfo.TenXepLoai = dr[pKQHT_XepLoaiMonHocInfo.strTenXepLoai].ToString();
			pKQHT_XepLoaiMonHocInfo.TuDiem = double.Parse(dr[pKQHT_XepLoaiMonHocInfo.strTuDiem].ToString());
			pKQHT_XepLoaiMonHocInfo.MaXepLoai = dr[pKQHT_XepLoaiMonHocInfo.strMaXepLoai].ToString();
        }
    }
}
