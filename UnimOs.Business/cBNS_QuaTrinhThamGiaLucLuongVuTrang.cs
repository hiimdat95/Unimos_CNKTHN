using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBNS_QuaTrinhThamGiaLucLuongVuTrang : cBBase
    {
        private cDNS_QuaTrinhThamGiaLucLuongVuTrang oDNS_QuaTrinhThamGiaLucLuongVuTrang;
        private NS_QuaTrinhThamGiaLucLuongVuTrangInfo oNS_QuaTrinhThamGiaLucLuongVuTrangInfo;

        public cBNS_QuaTrinhThamGiaLucLuongVuTrang()        
        {
            oDNS_QuaTrinhThamGiaLucLuongVuTrang = new cDNS_QuaTrinhThamGiaLucLuongVuTrang();
        }

        public DataTable Get(NS_QuaTrinhThamGiaLucLuongVuTrangInfo pNS_QuaTrinhThamGiaLucLuongVuTrangInfo)        
        {
            return oDNS_QuaTrinhThamGiaLucLuongVuTrang.Get(pNS_QuaTrinhThamGiaLucLuongVuTrangInfo);
        }

        public DataTable GetBy_IDNS_GiaoVien(int IDNS_GiaoVien)
        {
            return oDNS_QuaTrinhThamGiaLucLuongVuTrang.GetBy_IDNS_GiaoVien(IDNS_GiaoVien);
        }

        public int Add(NS_QuaTrinhThamGiaLucLuongVuTrangInfo pNS_QuaTrinhThamGiaLucLuongVuTrangInfo)
        {
			int ID = 0;
            ID = oDNS_QuaTrinhThamGiaLucLuongVuTrang.Add(pNS_QuaTrinhThamGiaLucLuongVuTrangInfo);
            mErrorMessage = oDNS_QuaTrinhThamGiaLucLuongVuTrang.ErrorMessages;
            mErrorNumber = oDNS_QuaTrinhThamGiaLucLuongVuTrang.ErrorNumber;
            return ID;
        }

        public void Update(NS_QuaTrinhThamGiaLucLuongVuTrangInfo pNS_QuaTrinhThamGiaLucLuongVuTrangInfo)
        {
            oDNS_QuaTrinhThamGiaLucLuongVuTrang.Update(pNS_QuaTrinhThamGiaLucLuongVuTrangInfo);
            mErrorMessage = oDNS_QuaTrinhThamGiaLucLuongVuTrang.ErrorMessages;
            mErrorNumber = oDNS_QuaTrinhThamGiaLucLuongVuTrang.ErrorNumber;
        }
        
        public void Delete(NS_QuaTrinhThamGiaLucLuongVuTrangInfo pNS_QuaTrinhThamGiaLucLuongVuTrangInfo)
        {
            oDNS_QuaTrinhThamGiaLucLuongVuTrang.Delete(pNS_QuaTrinhThamGiaLucLuongVuTrangInfo);
            mErrorMessage = oDNS_QuaTrinhThamGiaLucLuongVuTrang.ErrorMessages;
            mErrorNumber = oDNS_QuaTrinhThamGiaLucLuongVuTrang.ErrorNumber;
        }

        public List<NS_QuaTrinhThamGiaLucLuongVuTrangInfo> GetList(NS_QuaTrinhThamGiaLucLuongVuTrangInfo pNS_QuaTrinhThamGiaLucLuongVuTrangInfo)
        {
            List<NS_QuaTrinhThamGiaLucLuongVuTrangInfo> oNS_QuaTrinhThamGiaLucLuongVuTrangInfoList = new List<NS_QuaTrinhThamGiaLucLuongVuTrangInfo>();
            DataTable dtb = Get(pNS_QuaTrinhThamGiaLucLuongVuTrangInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oNS_QuaTrinhThamGiaLucLuongVuTrangInfo = new NS_QuaTrinhThamGiaLucLuongVuTrangInfo();

                    oNS_QuaTrinhThamGiaLucLuongVuTrangInfo.NS_QuaTrinhThamGiaLucLuongVuTrangID = int.Parse(dtb.Rows[i]["NS_QuaTrinhThamGiaLucLuongVuTrangID"].ToString());
                    oNS_QuaTrinhThamGiaLucLuongVuTrangInfo.IDNS_GiaoVien = int.Parse(dtb.Rows[i]["IDNS_GiaoVien"].ToString());
                    oNS_QuaTrinhThamGiaLucLuongVuTrangInfo.NgayNhapNgu = DateTime.Parse(dtb.Rows[i]["NgayNhapNgu"].ToString());
                    oNS_QuaTrinhThamGiaLucLuongVuTrangInfo.NgayXuatNgu = DateTime.Parse(dtb.Rows[i]["NgayXuatNgu"].ToString());
                    oNS_QuaTrinhThamGiaLucLuongVuTrangInfo.IDDM_QuanHam = int.Parse(dtb.Rows[i]["IDDM_QuanHam"].ToString());
                    oNS_QuaTrinhThamGiaLucLuongVuTrangInfo.DonVi = dtb.Rows[i]["DonVi"].ToString();
                    oNS_QuaTrinhThamGiaLucLuongVuTrangInfo.ChucVu = dtb.Rows[i]["ChucVu"].ToString();
                    
                    oNS_QuaTrinhThamGiaLucLuongVuTrangInfoList.Add(oNS_QuaTrinhThamGiaLucLuongVuTrangInfo);
                }
            }
            return oNS_QuaTrinhThamGiaLucLuongVuTrangInfoList;
        }
        
        public void ToDataRow(NS_QuaTrinhThamGiaLucLuongVuTrangInfo pNS_QuaTrinhThamGiaLucLuongVuTrangInfo, ref DataRow dr)
        {

			dr[pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.strNS_QuaTrinhThamGiaLucLuongVuTrangID] = pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.NS_QuaTrinhThamGiaLucLuongVuTrangID;
			dr[pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.strIDNS_GiaoVien] = pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.IDNS_GiaoVien;
			dr[pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.strNgayNhapNgu] = pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.NgayNhapNgu;
			dr[pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.strNgayXuatNgu] = pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.NgayXuatNgu;
			dr[pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.strIDDM_QuanHam] = pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.IDDM_QuanHam;
			dr[pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.strDonVi] = pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.DonVi;
			dr[pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.strChucVu] = pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.ChucVu;
        }
        
        public void ToInfo(ref NS_QuaTrinhThamGiaLucLuongVuTrangInfo pNS_QuaTrinhThamGiaLucLuongVuTrangInfo, DataRow dr)
        {

			pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.NS_QuaTrinhThamGiaLucLuongVuTrangID = int.Parse(dr[pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.strNS_QuaTrinhThamGiaLucLuongVuTrangID].ToString());
			pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.IDNS_GiaoVien = int.Parse("0" + dr[pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.strIDNS_GiaoVien]);
            if (dr[pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.strNgayNhapNgu].ToString() != "")
			    pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.NgayNhapNgu = DateTime.Parse(dr[pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.strNgayNhapNgu].ToString());
            if (dr[pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.strNgayXuatNgu].ToString()!= "")
			    pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.NgayXuatNgu = DateTime.Parse(dr[pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.strNgayXuatNgu].ToString());
			pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.IDDM_QuanHam = int.Parse("0" + dr[pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.strIDDM_QuanHam]);
			pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.DonVi = dr[pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.strDonVi].ToString();
			pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.ChucVu = dr[pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.strChucVu].ToString();
        }
    }
}
