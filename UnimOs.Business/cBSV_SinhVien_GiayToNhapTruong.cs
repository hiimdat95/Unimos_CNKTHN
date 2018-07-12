using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBSV_SinhVien_GiayToNhapTruong : cBBase
    {
        private cDSV_SinhVien_GiayToNhapTruong oDSV_SinhVien_GiayToNhapTruong;
        private SV_SinhVien_GiayToNhapTruongInfo oSV_SinhVien_GiayToNhapTruongInfo;

        public cBSV_SinhVien_GiayToNhapTruong()        
        {
            oDSV_SinhVien_GiayToNhapTruong = new cDSV_SinhVien_GiayToNhapTruong();
        }

        public DataTable Get(SV_SinhVien_GiayToNhapTruongInfo pSV_SinhVien_GiayToNhapTruongInfo)        
        {
            return oDSV_SinhVien_GiayToNhapTruong.Get(pSV_SinhVien_GiayToNhapTruongInfo);
        }

        public DataTable GetBySinhVien(int IDSV_SinhVienNhapTruong)
        {
            return oDSV_SinhVien_GiayToNhapTruong.GetBySinhVien(IDSV_SinhVienNhapTruong);
        }

        public int Add(SV_SinhVien_GiayToNhapTruongInfo pSV_SinhVien_GiayToNhapTruongInfo)
        {
			int ID = 0;
            ID = oDSV_SinhVien_GiayToNhapTruong.Add(pSV_SinhVien_GiayToNhapTruongInfo);
            mErrorMessage = oDSV_SinhVien_GiayToNhapTruong.ErrorMessages;
            mErrorNumber = oDSV_SinhVien_GiayToNhapTruong.ErrorNumber;
            return ID;
        }

        public int AddGiayTo(SV_SinhVien_GiayToNhapTruongInfo pSV_SinhVien_GiayToNhapTruongInfo, bool DaNop)
        {
            int ID = 0;
            ID = oDSV_SinhVien_GiayToNhapTruong.AddGiayTo(pSV_SinhVien_GiayToNhapTruongInfo, DaNop);
            mErrorMessage = oDSV_SinhVien_GiayToNhapTruong.ErrorMessages;
            mErrorNumber = oDSV_SinhVien_GiayToNhapTruong.ErrorNumber;
            return ID;
        }

        public void Update(SV_SinhVien_GiayToNhapTruongInfo pSV_SinhVien_GiayToNhapTruongInfo)
        {
            oDSV_SinhVien_GiayToNhapTruong.Update(pSV_SinhVien_GiayToNhapTruongInfo);
            mErrorMessage = oDSV_SinhVien_GiayToNhapTruong.ErrorMessages;
            mErrorNumber = oDSV_SinhVien_GiayToNhapTruong.ErrorNumber;
        }
        
        public void Delete(SV_SinhVien_GiayToNhapTruongInfo pSV_SinhVien_GiayToNhapTruongInfo)
        {
            oDSV_SinhVien_GiayToNhapTruong.Delete(pSV_SinhVien_GiayToNhapTruongInfo);
            mErrorMessage = oDSV_SinhVien_GiayToNhapTruong.ErrorMessages;
            mErrorNumber = oDSV_SinhVien_GiayToNhapTruong.ErrorNumber;
        }

        public List<SV_SinhVien_GiayToNhapTruongInfo> GetList(SV_SinhVien_GiayToNhapTruongInfo pSV_SinhVien_GiayToNhapTruongInfo)
        {
            List<SV_SinhVien_GiayToNhapTruongInfo> oSV_SinhVien_GiayToNhapTruongInfoList = new List<SV_SinhVien_GiayToNhapTruongInfo>();
            DataTable dtb = Get(pSV_SinhVien_GiayToNhapTruongInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oSV_SinhVien_GiayToNhapTruongInfo = new SV_SinhVien_GiayToNhapTruongInfo();

                    oSV_SinhVien_GiayToNhapTruongInfo.SV_SinhVien_GiayToNhapTruongID = int.Parse(dtb.Rows[i]["SV_SinhVien_GiayToNhapTruongID"].ToString());
                    oSV_SinhVien_GiayToNhapTruongInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oSV_SinhVien_GiayToNhapTruongInfo.IDSV_SinhVienNhapTruong = int.Parse(dtb.Rows[i]["IDSV_SinhVienNhapTruong"].ToString());
                    oSV_SinhVien_GiayToNhapTruongInfo.IDDM_GiayToNhapTruong = int.Parse(dtb.Rows[i]["IDDM_GiayToNhapTruong"].ToString());
                    oSV_SinhVien_GiayToNhapTruongInfo.GhiChu = dtb.Rows[i]["GhiChu"].ToString();
                    oSV_SinhVien_GiayToNhapTruongInfo.DaTra = bool.Parse(dtb.Rows[i]["DaTra"].ToString());
                    
                    oSV_SinhVien_GiayToNhapTruongInfoList.Add(oSV_SinhVien_GiayToNhapTruongInfo);
                }
            }
            return oSV_SinhVien_GiayToNhapTruongInfoList;
        }
        
        public void ToDataRow(SV_SinhVien_GiayToNhapTruongInfo pSV_SinhVien_GiayToNhapTruongInfo, ref DataRow dr)
        {

			dr[pSV_SinhVien_GiayToNhapTruongInfo.strSV_SinhVien_GiayToNhapTruongID] = pSV_SinhVien_GiayToNhapTruongInfo.SV_SinhVien_GiayToNhapTruongID;
			dr[pSV_SinhVien_GiayToNhapTruongInfo.strIDSV_SinhVien] = pSV_SinhVien_GiayToNhapTruongInfo.IDSV_SinhVien;
			dr[pSV_SinhVien_GiayToNhapTruongInfo.strIDSV_SinhVienNhapTruong] = pSV_SinhVien_GiayToNhapTruongInfo.IDSV_SinhVienNhapTruong;
			dr[pSV_SinhVien_GiayToNhapTruongInfo.strIDDM_GiayToNhapTruong] = pSV_SinhVien_GiayToNhapTruongInfo.IDDM_GiayToNhapTruong;
			dr[pSV_SinhVien_GiayToNhapTruongInfo.strGhiChu] = pSV_SinhVien_GiayToNhapTruongInfo.GhiChu;
			dr[pSV_SinhVien_GiayToNhapTruongInfo.strDaTra] = pSV_SinhVien_GiayToNhapTruongInfo.DaTra;
        }
        
        public void ToInfo(ref SV_SinhVien_GiayToNhapTruongInfo pSV_SinhVien_GiayToNhapTruongInfo, DataRow dr)
        {

			pSV_SinhVien_GiayToNhapTruongInfo.SV_SinhVien_GiayToNhapTruongID = int.Parse(dr[pSV_SinhVien_GiayToNhapTruongInfo.strSV_SinhVien_GiayToNhapTruongID].ToString());
			pSV_SinhVien_GiayToNhapTruongInfo.IDSV_SinhVien = int.Parse(dr[pSV_SinhVien_GiayToNhapTruongInfo.strIDSV_SinhVien].ToString());
			pSV_SinhVien_GiayToNhapTruongInfo.IDSV_SinhVienNhapTruong = int.Parse(dr[pSV_SinhVien_GiayToNhapTruongInfo.strIDSV_SinhVienNhapTruong].ToString());
			pSV_SinhVien_GiayToNhapTruongInfo.IDDM_GiayToNhapTruong = int.Parse(dr[pSV_SinhVien_GiayToNhapTruongInfo.strIDDM_GiayToNhapTruong].ToString());
			pSV_SinhVien_GiayToNhapTruongInfo.GhiChu = dr[pSV_SinhVien_GiayToNhapTruongInfo.strGhiChu].ToString();
			pSV_SinhVien_GiayToNhapTruongInfo.DaTra = bool.Parse(dr[pSV_SinhVien_GiayToNhapTruongInfo.strDaTra].ToString());
        }
    }
}
