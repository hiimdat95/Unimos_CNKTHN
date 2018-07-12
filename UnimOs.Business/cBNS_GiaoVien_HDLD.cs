using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBNS_GiaoVien_HDLD : cBBase
    {
        private cDNS_GiaoVien_HDLD oDNS_GiaoVien_HDLD;

        public cBNS_GiaoVien_HDLD()        
        {
            oDNS_GiaoVien_HDLD = new cDNS_GiaoVien_HDLD();
        }

        public DataTable Get(NS_GiaoVien_HDLDInfo pNS_GiaoVien_HDLDInfo)        
        {
            return oDNS_GiaoVien_HDLD.Get(pNS_GiaoVien_HDLDInfo);
        }

        public DataTable GetBy_NS_GiaoienID(int NS_GiaoVienID)
        {
            return oDNS_GiaoVien_HDLD.GetBy_NS_GiaoienID(NS_GiaoVienID);
        }

        public int Add(NS_GiaoVien_HDLDInfo pNS_GiaoVien_HDLDInfo)
        {
			int ID = 0;
            ID = oDNS_GiaoVien_HDLD.Add(pNS_GiaoVien_HDLDInfo);
            mErrorMessage = oDNS_GiaoVien_HDLD.ErrorMessages;
            mErrorNumber = oDNS_GiaoVien_HDLD.ErrorNumber;
            return ID;
        }

        public void Update(NS_GiaoVien_HDLDInfo pNS_GiaoVien_HDLDInfo)
        {
            oDNS_GiaoVien_HDLD.Update(pNS_GiaoVien_HDLDInfo);
            mErrorMessage = oDNS_GiaoVien_HDLD.ErrorMessages;
            mErrorNumber = oDNS_GiaoVien_HDLD.ErrorNumber;
        }
        
        public void Delete(NS_GiaoVien_HDLDInfo pNS_GiaoVien_HDLDInfo)
        {
            oDNS_GiaoVien_HDLD.Delete(pNS_GiaoVien_HDLDInfo);
            mErrorMessage = oDNS_GiaoVien_HDLD.ErrorMessages;
            mErrorNumber = oDNS_GiaoVien_HDLD.ErrorNumber;
        }

        public List<NS_GiaoVien_HDLDInfo> GetList(NS_GiaoVien_HDLDInfo pNS_GiaoVien_HDLDInfo)
        {
            List<NS_GiaoVien_HDLDInfo> oNS_GiaoVien_HDLDInfoList = new List<NS_GiaoVien_HDLDInfo>();
            DataTable dtb = Get(pNS_GiaoVien_HDLDInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    pNS_GiaoVien_HDLDInfo = new NS_GiaoVien_HDLDInfo();

                    pNS_GiaoVien_HDLDInfo.NS_GiaoVien_HDLDID = int.Parse(dtb.Rows[i][pNS_GiaoVien_HDLDInfo.strNS_GiaoVien_HDLDID].ToString());
                    pNS_GiaoVien_HDLDInfo.IDNS_GiaoVien = int.Parse(dtb.Rows[i][pNS_GiaoVien_HDLDInfo.strIDNS_GiaoVien].ToString());
                    pNS_GiaoVien_HDLDInfo.IDHinhThucHDLD = dtb.Rows[i][pNS_GiaoVien_HDLDInfo.strIDHinhThucHDLD].ToString();
                    if("" + dtb.Rows[i][pNS_GiaoVien_HDLDInfo.strSoHopDong] != "")
                    	pNS_GiaoVien_HDLDInfo.SoHopDong = dtb.Rows[i][pNS_GiaoVien_HDLDInfo.strSoHopDong].ToString();
                    if("" + dtb.Rows[i][pNS_GiaoVien_HDLDInfo.strSoThangHopDong] != "")
                    	pNS_GiaoVien_HDLDInfo.SoThangHopDong = int.Parse(dtb.Rows[i][pNS_GiaoVien_HDLDInfo.strSoThangHopDong].ToString());
                    if("" + dtb.Rows[i][pNS_GiaoVien_HDLDInfo.strGhiChu] != "")
                    	pNS_GiaoVien_HDLDInfo.GhiChu = dtb.Rows[i][pNS_GiaoVien_HDLDInfo.strGhiChu].ToString();
                    pNS_GiaoVien_HDLDInfo.ThoiGianBatDau = DateTime.Parse(dtb.Rows[i][pNS_GiaoVien_HDLDInfo.strThoiGianBatDau].ToString());
                    if("" + dtb.Rows[i][pNS_GiaoVien_HDLDInfo.strThoiGianKetThuc] != "")
                    	pNS_GiaoVien_HDLDInfo.ThoiGianKetThuc = DateTime.Parse(dtb.Rows[i][pNS_GiaoVien_HDLDInfo.strThoiGianKetThuc].ToString());
                    
                    oNS_GiaoVien_HDLDInfoList.Add(pNS_GiaoVien_HDLDInfo);
                }
            }
            return oNS_GiaoVien_HDLDInfoList;
        }
        
        public void ToDataRow(NS_GiaoVien_HDLDInfo pNS_GiaoVien_HDLDInfo, ref DataRow dr)
        {

			dr[pNS_GiaoVien_HDLDInfo.strNS_GiaoVien_HDLDID] = pNS_GiaoVien_HDLDInfo.NS_GiaoVien_HDLDID;
			dr[pNS_GiaoVien_HDLDInfo.strIDNS_GiaoVien] = pNS_GiaoVien_HDLDInfo.IDNS_GiaoVien;
			dr[pNS_GiaoVien_HDLDInfo.strIDHinhThucHDLD] = pNS_GiaoVien_HDLDInfo.IDHinhThucHDLD;
			dr[pNS_GiaoVien_HDLDInfo.strSoHopDong] = pNS_GiaoVien_HDLDInfo.SoHopDong;
			dr[pNS_GiaoVien_HDLDInfo.strSoThangHopDong] = pNS_GiaoVien_HDLDInfo.SoThangHopDong;
			dr[pNS_GiaoVien_HDLDInfo.strGhiChu] = pNS_GiaoVien_HDLDInfo.GhiChu;
			dr[pNS_GiaoVien_HDLDInfo.strThoiGianBatDau] = pNS_GiaoVien_HDLDInfo.ThoiGianBatDau;
			dr[pNS_GiaoVien_HDLDInfo.strThoiGianKetThuc] = pNS_GiaoVien_HDLDInfo.ThoiGianKetThuc;
        }
        
        public void ToInfo(ref NS_GiaoVien_HDLDInfo pNS_GiaoVien_HDLDInfo, DataRow dr)
        {

			pNS_GiaoVien_HDLDInfo.NS_GiaoVien_HDLDID = int.Parse(dr[pNS_GiaoVien_HDLDInfo.strNS_GiaoVien_HDLDID].ToString());
			pNS_GiaoVien_HDLDInfo.IDNS_GiaoVien = int.Parse(dr[pNS_GiaoVien_HDLDInfo.strIDNS_GiaoVien].ToString());
			pNS_GiaoVien_HDLDInfo.IDHinhThucHDLD = dr[pNS_GiaoVien_HDLDInfo.strIDHinhThucHDLD].ToString();
			if("" + dr[pNS_GiaoVien_HDLDInfo.strSoHopDong] != "")
				pNS_GiaoVien_HDLDInfo.SoHopDong = dr[pNS_GiaoVien_HDLDInfo.strSoHopDong].ToString();
			if("" + dr[pNS_GiaoVien_HDLDInfo.strSoThangHopDong] != "")
				pNS_GiaoVien_HDLDInfo.SoThangHopDong = int.Parse(dr[pNS_GiaoVien_HDLDInfo.strSoThangHopDong].ToString());
			if("" + dr[pNS_GiaoVien_HDLDInfo.strGhiChu] != "")
				pNS_GiaoVien_HDLDInfo.GhiChu = dr[pNS_GiaoVien_HDLDInfo.strGhiChu].ToString();
			pNS_GiaoVien_HDLDInfo.ThoiGianBatDau = DateTime.Parse(dr[pNS_GiaoVien_HDLDInfo.strThoiGianBatDau].ToString());
			if("" + dr[pNS_GiaoVien_HDLDInfo.strThoiGianKetThuc] != "")
				pNS_GiaoVien_HDLDInfo.ThoiGianKetThuc = DateTime.Parse(dr[pNS_GiaoVien_HDLDInfo.strThoiGianKetThuc].ToString());
        }
    }
}
