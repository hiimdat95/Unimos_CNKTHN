using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBTC_LoaiHocBong : cBBase
    {
        private cDTC_LoaiHocBong oDTC_LoaiHocBong;
        private TC_LoaiHocBongInfo oTC_LoaiHocBongInfo;

        public cBTC_LoaiHocBong()        
        {
            oDTC_LoaiHocBong = new cDTC_LoaiHocBong();
        }

        public DataTable Get(TC_LoaiHocBongInfo pTC_LoaiHocBongInfo)        
        {
            return oDTC_LoaiHocBong.Get(pTC_LoaiHocBongInfo);
        }

        public int Add(TC_LoaiHocBongInfo pTC_LoaiHocBongInfo)
        {
			int ID = 0;
            ID = oDTC_LoaiHocBong.Add(pTC_LoaiHocBongInfo);
            mErrorMessage = oDTC_LoaiHocBong.ErrorMessages;
            mErrorNumber = oDTC_LoaiHocBong.ErrorNumber;
            return ID;
        }

        public void Update(TC_LoaiHocBongInfo pTC_LoaiHocBongInfo)
        {
            oDTC_LoaiHocBong.Update(pTC_LoaiHocBongInfo);
            mErrorMessage = oDTC_LoaiHocBong.ErrorMessages;
            mErrorNumber = oDTC_LoaiHocBong.ErrorNumber;
        }
        
        public void Delete(TC_LoaiHocBongInfo pTC_LoaiHocBongInfo)
        {
            oDTC_LoaiHocBong.Delete(pTC_LoaiHocBongInfo);
            mErrorMessage = oDTC_LoaiHocBong.ErrorMessages;
            mErrorNumber = oDTC_LoaiHocBong.ErrorNumber;
        }

        public List<TC_LoaiHocBongInfo> GetList(TC_LoaiHocBongInfo pTC_LoaiHocBongInfo)
        {
            List<TC_LoaiHocBongInfo> oTC_LoaiHocBongInfoList = new List<TC_LoaiHocBongInfo>();
            DataTable dtb = Get(pTC_LoaiHocBongInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oTC_LoaiHocBongInfo = new TC_LoaiHocBongInfo();

                    oTC_LoaiHocBongInfo.TC_LoaiHocBongID = int.Parse(dtb.Rows[i]["TC_LoaiHocBongID"].ToString());
                    oTC_LoaiHocBongInfo.TenLoaiHocBong = dtb.Rows[i]["TenLoaiHocBong"].ToString();
                    oTC_LoaiHocBongInfo.KyHieu = dtb.Rows[i]["KyHieu"].ToString();
                    oTC_LoaiHocBongInfo.SoTien = double.Parse(dtb.Rows[i]["SoTien"].ToString());
                    oTC_LoaiHocBongInfo.IDDM_TrinhDo = int.Parse(dtb.Rows[i]["IDDM_TrinhDo"].ToString());
                    
                    oTC_LoaiHocBongInfoList.Add(oTC_LoaiHocBongInfo);
                }
            }
            return oTC_LoaiHocBongInfoList;
        }
        
        public void ToDataRow(TC_LoaiHocBongInfo pTC_LoaiHocBongInfo, ref DataRow dr)
        {

			dr[pTC_LoaiHocBongInfo.strTC_LoaiHocBongID] = pTC_LoaiHocBongInfo.TC_LoaiHocBongID;
			dr[pTC_LoaiHocBongInfo.strTenLoaiHocBong] = pTC_LoaiHocBongInfo.TenLoaiHocBong;
			dr[pTC_LoaiHocBongInfo.strKyHieu] = pTC_LoaiHocBongInfo.KyHieu;
			dr[pTC_LoaiHocBongInfo.strSoTien] = pTC_LoaiHocBongInfo.SoTien;
			dr[pTC_LoaiHocBongInfo.strIDDM_TrinhDo] = pTC_LoaiHocBongInfo.IDDM_TrinhDo;
        }
        
        public void ToInfo(ref TC_LoaiHocBongInfo pTC_LoaiHocBongInfo, DataRow dr)
        {

			pTC_LoaiHocBongInfo.TC_LoaiHocBongID = int.Parse(dr[pTC_LoaiHocBongInfo.strTC_LoaiHocBongID].ToString());
			pTC_LoaiHocBongInfo.TenLoaiHocBong = dr[pTC_LoaiHocBongInfo.strTenLoaiHocBong].ToString();
			pTC_LoaiHocBongInfo.KyHieu = dr[pTC_LoaiHocBongInfo.strKyHieu].ToString();
			pTC_LoaiHocBongInfo.SoTien = double.Parse(dr[pTC_LoaiHocBongInfo.strSoTien].ToString());
			pTC_LoaiHocBongInfo.IDDM_TrinhDo = int.Parse(dr[pTC_LoaiHocBongInfo.strIDDM_TrinhDo].ToString());
        }
    }
}
