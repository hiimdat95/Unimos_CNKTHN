using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBNS_QuaTrinhThamGiaToChucCTXH : cBBase
    {
        private cDNS_QuaTrinhThamGiaToChucCTXH oDNS_QuaTrinhThamGiaToChucCTXH;
        private NS_QuaTrinhThamGiaToChucCTXHInfo oNS_QuaTrinhThamGiaToChucCTXHInfo;

        public cBNS_QuaTrinhThamGiaToChucCTXH()        
        {
            oDNS_QuaTrinhThamGiaToChucCTXH = new cDNS_QuaTrinhThamGiaToChucCTXH();
        }

        public DataTable Get(NS_QuaTrinhThamGiaToChucCTXHInfo pNS_QuaTrinhThamGiaToChucCTXHInfo)        
        {
            return oDNS_QuaTrinhThamGiaToChucCTXH.Get(pNS_QuaTrinhThamGiaToChucCTXHInfo);
        }

        public DataTable GetBy_IDNS_GiaoVien(int IDNS_GiaoVien)
        {
            return oDNS_QuaTrinhThamGiaToChucCTXH.GetBy_IDNS_GiaoVien(IDNS_GiaoVien);
        }

        public int Add(NS_QuaTrinhThamGiaToChucCTXHInfo pNS_QuaTrinhThamGiaToChucCTXHInfo)
        {
			int ID = 0;
            ID = oDNS_QuaTrinhThamGiaToChucCTXH.Add(pNS_QuaTrinhThamGiaToChucCTXHInfo);
            mErrorMessage = oDNS_QuaTrinhThamGiaToChucCTXH.ErrorMessages;
            mErrorNumber = oDNS_QuaTrinhThamGiaToChucCTXH.ErrorNumber;
            return ID;
        }

        public void Update(NS_QuaTrinhThamGiaToChucCTXHInfo pNS_QuaTrinhThamGiaToChucCTXHInfo)
        {
            oDNS_QuaTrinhThamGiaToChucCTXH.Update(pNS_QuaTrinhThamGiaToChucCTXHInfo);
            mErrorMessage = oDNS_QuaTrinhThamGiaToChucCTXH.ErrorMessages;
            mErrorNumber = oDNS_QuaTrinhThamGiaToChucCTXH.ErrorNumber;
        }
        
        public void Delete(NS_QuaTrinhThamGiaToChucCTXHInfo pNS_QuaTrinhThamGiaToChucCTXHInfo)
        {
            oDNS_QuaTrinhThamGiaToChucCTXH.Delete(pNS_QuaTrinhThamGiaToChucCTXHInfo);
            mErrorMessage = oDNS_QuaTrinhThamGiaToChucCTXH.ErrorMessages;
            mErrorNumber = oDNS_QuaTrinhThamGiaToChucCTXH.ErrorNumber;
        }

        public List<NS_QuaTrinhThamGiaToChucCTXHInfo> GetList(NS_QuaTrinhThamGiaToChucCTXHInfo pNS_QuaTrinhThamGiaToChucCTXHInfo)
        {
            List<NS_QuaTrinhThamGiaToChucCTXHInfo> oNS_QuaTrinhThamGiaToChucCTXHInfoList = new List<NS_QuaTrinhThamGiaToChucCTXHInfo>();
            DataTable dtb = Get(pNS_QuaTrinhThamGiaToChucCTXHInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oNS_QuaTrinhThamGiaToChucCTXHInfo = new NS_QuaTrinhThamGiaToChucCTXHInfo();

                    oNS_QuaTrinhThamGiaToChucCTXHInfo.NS_QuaTrinhThamGiaToChucCTXHID = int.Parse(dtb.Rows[i]["NS_QuaTrinhThamGiaToChucCTXHID"].ToString());
                    oNS_QuaTrinhThamGiaToChucCTXHInfo.IDNS_GiaoVien = int.Parse(dtb.Rows[i]["IDNS_GiaoVien"].ToString());
                    oNS_QuaTrinhThamGiaToChucCTXHInfo.NgayThamGia = DateTime.Parse(dtb.Rows[i]["NgayThamGia"].ToString());
                    oNS_QuaTrinhThamGiaToChucCTXHInfo.TenToChuc = dtb.Rows[i]["TenToChuc"].ToString();
                    oNS_QuaTrinhThamGiaToChucCTXHInfo.CongViec = dtb.Rows[i]["CongViec"].ToString();
                    
                    oNS_QuaTrinhThamGiaToChucCTXHInfoList.Add(oNS_QuaTrinhThamGiaToChucCTXHInfo);
                }
            }
            return oNS_QuaTrinhThamGiaToChucCTXHInfoList;
        }
        
        public void ToDataRow(NS_QuaTrinhThamGiaToChucCTXHInfo pNS_QuaTrinhThamGiaToChucCTXHInfo, ref DataRow dr)
        {

			dr[pNS_QuaTrinhThamGiaToChucCTXHInfo.strNS_QuaTrinhThamGiaToChucCTXHID] = pNS_QuaTrinhThamGiaToChucCTXHInfo.NS_QuaTrinhThamGiaToChucCTXHID;
			dr[pNS_QuaTrinhThamGiaToChucCTXHInfo.strIDNS_GiaoVien] = pNS_QuaTrinhThamGiaToChucCTXHInfo.IDNS_GiaoVien;
			dr[pNS_QuaTrinhThamGiaToChucCTXHInfo.strNgayThamGia] = pNS_QuaTrinhThamGiaToChucCTXHInfo.NgayThamGia;
			dr[pNS_QuaTrinhThamGiaToChucCTXHInfo.strTenToChuc] = pNS_QuaTrinhThamGiaToChucCTXHInfo.TenToChuc;
			dr[pNS_QuaTrinhThamGiaToChucCTXHInfo.strCongViec] = pNS_QuaTrinhThamGiaToChucCTXHInfo.CongViec;
        }
        
        public void ToInfo(ref NS_QuaTrinhThamGiaToChucCTXHInfo pNS_QuaTrinhThamGiaToChucCTXHInfo, DataRow dr)
        {

			pNS_QuaTrinhThamGiaToChucCTXHInfo.NS_QuaTrinhThamGiaToChucCTXHID = int.Parse(dr[pNS_QuaTrinhThamGiaToChucCTXHInfo.strNS_QuaTrinhThamGiaToChucCTXHID].ToString());
			pNS_QuaTrinhThamGiaToChucCTXHInfo.IDNS_GiaoVien = int.Parse("0" + dr[pNS_QuaTrinhThamGiaToChucCTXHInfo.strIDNS_GiaoVien]);
            if (dr[pNS_QuaTrinhThamGiaToChucCTXHInfo.strNgayThamGia].ToString() != "")
                pNS_QuaTrinhThamGiaToChucCTXHInfo.NgayThamGia = DateTime.Parse(dr[pNS_QuaTrinhThamGiaToChucCTXHInfo.strNgayThamGia].ToString());
			pNS_QuaTrinhThamGiaToChucCTXHInfo.TenToChuc = dr[pNS_QuaTrinhThamGiaToChucCTXHInfo.strTenToChuc].ToString();
			pNS_QuaTrinhThamGiaToChucCTXHInfo.CongViec = dr[pNS_QuaTrinhThamGiaToChucCTXHInfo.strCongViec].ToString();
        }
    }
}
