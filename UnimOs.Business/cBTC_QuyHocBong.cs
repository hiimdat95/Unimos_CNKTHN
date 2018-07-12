using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBTC_QuyHocBong : cBBase
    {
        private cDTC_QuyHocBong oDTC_QuyHocBong;
        private TC_QuyHocBongInfo oTC_QuyHocBongInfo;

        public cBTC_QuyHocBong()        
        {
            oDTC_QuyHocBong = new cDTC_QuyHocBong();
        }

        public DataTable Get(TC_QuyHocBongInfo pTC_QuyHocBongInfo)        
        {
            return oDTC_QuyHocBong.Get(pTC_QuyHocBongInfo);
        }

        public int Add(TC_QuyHocBongInfo pTC_QuyHocBongInfo)
        {
			int ID = 0;
            ID = oDTC_QuyHocBong.Add(pTC_QuyHocBongInfo);
            mErrorMessage = oDTC_QuyHocBong.ErrorMessages;
            mErrorNumber = oDTC_QuyHocBong.ErrorNumber;
            return ID;
        }

        public void Update(TC_QuyHocBongInfo pTC_QuyHocBongInfo)
        {
            oDTC_QuyHocBong.Update(pTC_QuyHocBongInfo);
            mErrorMessage = oDTC_QuyHocBong.ErrorMessages;
            mErrorNumber = oDTC_QuyHocBong.ErrorNumber;
        }
        
        public void Delete(TC_QuyHocBongInfo pTC_QuyHocBongInfo)
        {
            oDTC_QuyHocBong.Delete(pTC_QuyHocBongInfo);
            mErrorMessage = oDTC_QuyHocBong.ErrorMessages;
            mErrorNumber = oDTC_QuyHocBong.ErrorNumber;
        }

        public List<TC_QuyHocBongInfo> GetList(TC_QuyHocBongInfo pTC_QuyHocBongInfo)
        {
            List<TC_QuyHocBongInfo> oTC_QuyHocBongInfoList = new List<TC_QuyHocBongInfo>();
            DataTable dtb = Get(pTC_QuyHocBongInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oTC_QuyHocBongInfo = new TC_QuyHocBongInfo();

                    oTC_QuyHocBongInfo.TC_QuyHocBongID = int.Parse(dtb.Rows[i]["TC_QuyHocBongID"].ToString());
                    oTC_QuyHocBongInfo.IDDM_He = int.Parse(dtb.Rows[i]["IDDM_He"].ToString());
                    oTC_QuyHocBongInfo.IDDM_TrinhDo = int.Parse(dtb.Rows[i]["IDDM_TrinhDo"].ToString());
                    oTC_QuyHocBongInfo.IDDM_LoaiQuy = int.Parse(dtb.Rows[i]["IDDM_LoaiQuy"].ToString());
                    oTC_QuyHocBongInfo.PhanTramHocPhi = double.Parse(dtb.Rows[i]["PhanTramHocPhi"].ToString());
                    oTC_QuyHocBongInfo.SoTien = double.Parse(dtb.Rows[i]["SoTien"].ToString());
                    oTC_QuyHocBongInfo.GhiChu = dtb.Rows[i]["GhiChu"].ToString();
                    oTC_QuyHocBongInfo.HetHan = bool.Parse(dtb.Rows[i]["HetHan"].ToString());
                    
                    oTC_QuyHocBongInfoList.Add(oTC_QuyHocBongInfo);
                }
            }
            return oTC_QuyHocBongInfoList;
        }
        
        public void ToDataRow(TC_QuyHocBongInfo pTC_QuyHocBongInfo, ref DataRow dr)
        {

			dr[pTC_QuyHocBongInfo.strTC_QuyHocBongID] = pTC_QuyHocBongInfo.TC_QuyHocBongID;
			dr[pTC_QuyHocBongInfo.strIDDM_He] = pTC_QuyHocBongInfo.IDDM_He;
			dr[pTC_QuyHocBongInfo.strIDDM_TrinhDo] = pTC_QuyHocBongInfo.IDDM_TrinhDo;
			dr[pTC_QuyHocBongInfo.strIDDM_LoaiQuy] = pTC_QuyHocBongInfo.IDDM_LoaiQuy;
			dr[pTC_QuyHocBongInfo.strPhanTramHocPhi] = pTC_QuyHocBongInfo.PhanTramHocPhi;
			dr[pTC_QuyHocBongInfo.strSoTien] = pTC_QuyHocBongInfo.SoTien;
			dr[pTC_QuyHocBongInfo.strGhiChu] = pTC_QuyHocBongInfo.GhiChu;
			dr[pTC_QuyHocBongInfo.strHetHan] = pTC_QuyHocBongInfo.HetHan;
        }
        
        public void ToInfo(ref TC_QuyHocBongInfo pTC_QuyHocBongInfo, DataRow dr)
        {

			pTC_QuyHocBongInfo.TC_QuyHocBongID = int.Parse(dr[pTC_QuyHocBongInfo.strTC_QuyHocBongID].ToString());
			pTC_QuyHocBongInfo.IDDM_He = int.Parse(dr[pTC_QuyHocBongInfo.strIDDM_He].ToString());
			pTC_QuyHocBongInfo.IDDM_TrinhDo = int.Parse(dr[pTC_QuyHocBongInfo.strIDDM_TrinhDo].ToString());
			pTC_QuyHocBongInfo.IDDM_LoaiQuy = int.Parse(dr[pTC_QuyHocBongInfo.strIDDM_LoaiQuy].ToString());
			pTC_QuyHocBongInfo.PhanTramHocPhi = double.Parse(dr[pTC_QuyHocBongInfo.strPhanTramHocPhi].ToString());
			pTC_QuyHocBongInfo.SoTien = double.Parse(dr[pTC_QuyHocBongInfo.strSoTien].ToString());
			pTC_QuyHocBongInfo.GhiChu = dr[pTC_QuyHocBongInfo.strGhiChu].ToString();
			pTC_QuyHocBongInfo.HetHan = bool.Parse(dr[pTC_QuyHocBongInfo.strHetHan].ToString());
        }
    }
}
