using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBNS_GiaoVien_NghiViec : cBBase
    {
        private cDNS_GiaoVien_NghiViec oDNS_GiaoVien_NghiViec;

        public cBNS_GiaoVien_NghiViec()        
        {
            oDNS_GiaoVien_NghiViec = new cDNS_GiaoVien_NghiViec();
        }

        public DataTable Get(NS_GiaoVien_NghiViecInfo pNS_GiaoVien_NghiViecInfo)        
        {
            return oDNS_GiaoVien_NghiViec.Get(pNS_GiaoVien_NghiViecInfo);
        }

        public DataTable GetBy_NS_GiaoienID(int NS_GiaoVienID)
        {
            return oDNS_GiaoVien_NghiViec.GetBy_NS_GiaoienID(NS_GiaoVienID);
        }

        public int Add(NS_GiaoVien_NghiViecInfo pNS_GiaoVien_NghiViecInfo)
        {
			int ID = 0;
            ID = oDNS_GiaoVien_NghiViec.Add(pNS_GiaoVien_NghiViecInfo);
            mErrorMessage = oDNS_GiaoVien_NghiViec.ErrorMessages;
            mErrorNumber = oDNS_GiaoVien_NghiViec.ErrorNumber;
            return ID;
        }

        public void Update(NS_GiaoVien_NghiViecInfo pNS_GiaoVien_NghiViecInfo)
        {
            oDNS_GiaoVien_NghiViec.Update(pNS_GiaoVien_NghiViecInfo);
            mErrorMessage = oDNS_GiaoVien_NghiViec.ErrorMessages;
            mErrorNumber = oDNS_GiaoVien_NghiViec.ErrorNumber;
        }
        
        public void Delete(NS_GiaoVien_NghiViecInfo pNS_GiaoVien_NghiViecInfo)
        {
            oDNS_GiaoVien_NghiViec.Delete(pNS_GiaoVien_NghiViecInfo);
            mErrorMessage = oDNS_GiaoVien_NghiViec.ErrorMessages;
            mErrorNumber = oDNS_GiaoVien_NghiViec.ErrorNumber;
        }

        public List<NS_GiaoVien_NghiViecInfo> GetList(NS_GiaoVien_NghiViecInfo pNS_GiaoVien_NghiViecInfo)
        {
            List<NS_GiaoVien_NghiViecInfo> oNS_GiaoVien_NghiViecInfoList = new List<NS_GiaoVien_NghiViecInfo>();
            DataTable dtb = Get(pNS_GiaoVien_NghiViecInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    pNS_GiaoVien_NghiViecInfo = new NS_GiaoVien_NghiViecInfo();

                    pNS_GiaoVien_NghiViecInfo.NS_GiaoVien_NghiViecID = int.Parse(dtb.Rows[i][pNS_GiaoVien_NghiViecInfo.strNS_GiaoVien_NghiViecID].ToString());
                    pNS_GiaoVien_NghiViecInfo.IDNS_GiaoVien = int.Parse(dtb.Rows[i][pNS_GiaoVien_NghiViecInfo.strIDNS_GiaoVien].ToString());
                    if("" + dtb.Rows[i][pNS_GiaoVien_NghiViecInfo.strSoQuyetDinh] != "")
                    	pNS_GiaoVien_NghiViecInfo.SoQuyetDinh = dtb.Rows[i][pNS_GiaoVien_NghiViecInfo.strSoQuyetDinh].ToString();
                    pNS_GiaoVien_NghiViecInfo.IDNS_HinhThucNghiViec = dtb.Rows[i][pNS_GiaoVien_NghiViecInfo.strIDNS_HinhThucNghiViec].ToString();
                    pNS_GiaoVien_NghiViecInfo.NgayCoHieuLuc = DateTime.Parse(dtb.Rows[i][pNS_GiaoVien_NghiViecInfo.strNgayCoHieuLuc].ToString());
                    
                    oNS_GiaoVien_NghiViecInfoList.Add(pNS_GiaoVien_NghiViecInfo);
                }
            }
            return oNS_GiaoVien_NghiViecInfoList;
        }
        
        public void ToDataRow(NS_GiaoVien_NghiViecInfo pNS_GiaoVien_NghiViecInfo, ref DataRow dr)
        {

			dr[pNS_GiaoVien_NghiViecInfo.strNS_GiaoVien_NghiViecID] = pNS_GiaoVien_NghiViecInfo.NS_GiaoVien_NghiViecID;
			dr[pNS_GiaoVien_NghiViecInfo.strIDNS_GiaoVien] = pNS_GiaoVien_NghiViecInfo.IDNS_GiaoVien;
			dr[pNS_GiaoVien_NghiViecInfo.strSoQuyetDinh] = pNS_GiaoVien_NghiViecInfo.SoQuyetDinh;
			dr[pNS_GiaoVien_NghiViecInfo.strIDNS_HinhThucNghiViec] = pNS_GiaoVien_NghiViecInfo.IDNS_HinhThucNghiViec;
			dr[pNS_GiaoVien_NghiViecInfo.strNgayCoHieuLuc] = pNS_GiaoVien_NghiViecInfo.NgayCoHieuLuc;
        }
        
        public void ToInfo(ref NS_GiaoVien_NghiViecInfo pNS_GiaoVien_NghiViecInfo, DataRow dr)
        {

			pNS_GiaoVien_NghiViecInfo.NS_GiaoVien_NghiViecID = int.Parse(dr[pNS_GiaoVien_NghiViecInfo.strNS_GiaoVien_NghiViecID].ToString());
			pNS_GiaoVien_NghiViecInfo.IDNS_GiaoVien = int.Parse(dr[pNS_GiaoVien_NghiViecInfo.strIDNS_GiaoVien].ToString());
			if("" + dr[pNS_GiaoVien_NghiViecInfo.strSoQuyetDinh] != "")
				pNS_GiaoVien_NghiViecInfo.SoQuyetDinh = dr[pNS_GiaoVien_NghiViecInfo.strSoQuyetDinh].ToString();
			pNS_GiaoVien_NghiViecInfo.IDNS_HinhThucNghiViec = dr[pNS_GiaoVien_NghiViecInfo.strIDNS_HinhThucNghiViec].ToString();
			pNS_GiaoVien_NghiViecInfo.NgayCoHieuLuc = DateTime.Parse(dr[pNS_GiaoVien_NghiViecInfo.strNgayCoHieuLuc].ToString());
        }
    }
}
