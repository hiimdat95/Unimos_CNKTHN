using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBNS_QuaTrinhBoNhiemChucVu : cBBase
    {
        private cDNS_QuaTrinhBoNhiemChucVu oDNS_QuaTrinhBoNhiemChucVu;
        private NS_QuaTrinhBoNhiemChucVuInfo oNS_QuaTrinhBoNhiemChucVuInfo;

        public cBNS_QuaTrinhBoNhiemChucVu()        
        {
            oDNS_QuaTrinhBoNhiemChucVu = new cDNS_QuaTrinhBoNhiemChucVu();
        }

        public DataTable Get(NS_QuaTrinhBoNhiemChucVuInfo pNS_QuaTrinhBoNhiemChucVuInfo)        
        {
            return oDNS_QuaTrinhBoNhiemChucVu.Get(pNS_QuaTrinhBoNhiemChucVuInfo);
        }

        public DataTable GetBy_IDNS_GiaoVien(int IDNS_GiaoVien)
        {
            return oDNS_QuaTrinhBoNhiemChucVu.GetBy_IDNS_GiaoVien(IDNS_GiaoVien);
        }

        public DataTable GetSoLuongBoNhiem(DateTime DenNgay)
        {
            return oDNS_QuaTrinhBoNhiemChucVu.GetSoLuongBoNhiem(DenNgay);
        }

        public DataTable GetSoLuongBienCheSuNghiep(DateTime DenNgay)
        {
            return oDNS_QuaTrinhBoNhiemChucVu.GetSoLuongBienCheSuNghiep(DenNgay);
        }

        public int Add(NS_QuaTrinhBoNhiemChucVuInfo pNS_QuaTrinhBoNhiemChucVuInfo)
        {
			int ID = 0;
            ID = oDNS_QuaTrinhBoNhiemChucVu.Add(pNS_QuaTrinhBoNhiemChucVuInfo);
            mErrorMessage = oDNS_QuaTrinhBoNhiemChucVu.ErrorMessages;
            mErrorNumber = oDNS_QuaTrinhBoNhiemChucVu.ErrorNumber;
            return ID;
        }

        public void Update(NS_QuaTrinhBoNhiemChucVuInfo pNS_QuaTrinhBoNhiemChucVuInfo)
        {
            oDNS_QuaTrinhBoNhiemChucVu.Update(pNS_QuaTrinhBoNhiemChucVuInfo);
            mErrorMessage = oDNS_QuaTrinhBoNhiemChucVu.ErrorMessages;
            mErrorNumber = oDNS_QuaTrinhBoNhiemChucVu.ErrorNumber;
        }
        
        public void Delete(NS_QuaTrinhBoNhiemChucVuInfo pNS_QuaTrinhBoNhiemChucVuInfo)
        {
            oDNS_QuaTrinhBoNhiemChucVu.Delete(pNS_QuaTrinhBoNhiemChucVuInfo);
            mErrorMessage = oDNS_QuaTrinhBoNhiemChucVu.ErrorMessages;
            mErrorNumber = oDNS_QuaTrinhBoNhiemChucVu.ErrorNumber;
        }

        public List<NS_QuaTrinhBoNhiemChucVuInfo> GetList(NS_QuaTrinhBoNhiemChucVuInfo pNS_QuaTrinhBoNhiemChucVuInfo)
        {
            List<NS_QuaTrinhBoNhiemChucVuInfo> oNS_QuaTrinhBoNhiemChucVuInfoList = new List<NS_QuaTrinhBoNhiemChucVuInfo>();
            DataTable dtb = Get(pNS_QuaTrinhBoNhiemChucVuInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oNS_QuaTrinhBoNhiemChucVuInfo = new NS_QuaTrinhBoNhiemChucVuInfo();

                    oNS_QuaTrinhBoNhiemChucVuInfo.NS_QuaTrinhBoNhiemChucVuID = int.Parse(dtb.Rows[i]["NS_QuaTrinhBoNhiemChucVuID"].ToString());
                    oNS_QuaTrinhBoNhiemChucVuInfo.IDNS_GiaoVien = int.Parse(dtb.Rows[i]["IDNS_GiaoVien"].ToString());
                    oNS_QuaTrinhBoNhiemChucVuInfo.SoQuyetDinh = dtb.Rows[i]["SoQuyetDinh"].ToString();
                    oNS_QuaTrinhBoNhiemChucVuInfo.NgayRaQuyetDinh = DateTime.Parse(dtb.Rows[i]["NgayRaQuyetDinh"].ToString());
                    oNS_QuaTrinhBoNhiemChucVuInfo.IDDM_CapQuyetDinh = int.Parse(dtb.Rows[i]["IDDM_CapQuyetDinh"].ToString());
                    oNS_QuaTrinhBoNhiemChucVuInfo.IDDM_ChucVuBoNhiem = int.Parse(dtb.Rows[i]["IDDM_ChucVuBoNhiem"].ToString());
                    oNS_QuaTrinhBoNhiemChucVuInfo.NgayCoHieuLuc = DateTime.Parse(dtb.Rows[i]["NgayCoHieuLuc"].ToString());
                    oNS_QuaTrinhBoNhiemChucVuInfo.NgayHetHieuLuc = DateTime.Parse(dtb.Rows[i]["NgayHetHieuLuc"].ToString());
                    oNS_QuaTrinhBoNhiemChucVuInfo.LaChucVuKiemNhiem = bool.Parse(dtb.Rows[i]["LaChucVuKiemNhiem"].ToString());
                    oNS_QuaTrinhBoNhiemChucVuInfo.IDNS_MienNhiemTuChuc = int.Parse(dtb.Rows[i]["IDNS_MienNhiemTuChuc"].ToString());
                    
                    oNS_QuaTrinhBoNhiemChucVuInfoList.Add(oNS_QuaTrinhBoNhiemChucVuInfo);
                }
            }
            return oNS_QuaTrinhBoNhiemChucVuInfoList;
        }
        
        public void ToDataRow(NS_QuaTrinhBoNhiemChucVuInfo pNS_QuaTrinhBoNhiemChucVuInfo, ref DataRow dr)
        {

			dr[pNS_QuaTrinhBoNhiemChucVuInfo.strNS_QuaTrinhBoNhiemChucVuID] = pNS_QuaTrinhBoNhiemChucVuInfo.NS_QuaTrinhBoNhiemChucVuID;
			dr[pNS_QuaTrinhBoNhiemChucVuInfo.strIDNS_GiaoVien] = pNS_QuaTrinhBoNhiemChucVuInfo.IDNS_GiaoVien;
			dr[pNS_QuaTrinhBoNhiemChucVuInfo.strSoQuyetDinh] = pNS_QuaTrinhBoNhiemChucVuInfo.SoQuyetDinh;
			dr[pNS_QuaTrinhBoNhiemChucVuInfo.strNgayRaQuyetDinh] = pNS_QuaTrinhBoNhiemChucVuInfo.NgayRaQuyetDinh;
			dr[pNS_QuaTrinhBoNhiemChucVuInfo.strIDDM_CapQuyetDinh] = pNS_QuaTrinhBoNhiemChucVuInfo.IDDM_CapQuyetDinh;
			dr[pNS_QuaTrinhBoNhiemChucVuInfo.strIDDM_ChucVuBoNhiem] = pNS_QuaTrinhBoNhiemChucVuInfo.IDDM_ChucVuBoNhiem;
			dr[pNS_QuaTrinhBoNhiemChucVuInfo.strNgayCoHieuLuc] = pNS_QuaTrinhBoNhiemChucVuInfo.NgayCoHieuLuc;
			dr[pNS_QuaTrinhBoNhiemChucVuInfo.strNgayHetHieuLuc] = pNS_QuaTrinhBoNhiemChucVuInfo.NgayHetHieuLuc;
			dr[pNS_QuaTrinhBoNhiemChucVuInfo.strLaChucVuKiemNhiem] = pNS_QuaTrinhBoNhiemChucVuInfo.LaChucVuKiemNhiem;
			dr[pNS_QuaTrinhBoNhiemChucVuInfo.strIDNS_MienNhiemTuChuc] = pNS_QuaTrinhBoNhiemChucVuInfo.IDNS_MienNhiemTuChuc;
        }
        
        public void ToInfo(ref NS_QuaTrinhBoNhiemChucVuInfo pNS_QuaTrinhBoNhiemChucVuInfo, DataRow dr)
        {

			pNS_QuaTrinhBoNhiemChucVuInfo.NS_QuaTrinhBoNhiemChucVuID = int.Parse(dr[pNS_QuaTrinhBoNhiemChucVuInfo.strNS_QuaTrinhBoNhiemChucVuID].ToString());
			pNS_QuaTrinhBoNhiemChucVuInfo.IDNS_GiaoVien = int.Parse("0" + dr[pNS_QuaTrinhBoNhiemChucVuInfo.strIDNS_GiaoVien]);
			pNS_QuaTrinhBoNhiemChucVuInfo.SoQuyetDinh = dr[pNS_QuaTrinhBoNhiemChucVuInfo.strSoQuyetDinh].ToString();
            if (dr[pNS_QuaTrinhBoNhiemChucVuInfo.strNgayRaQuyetDinh].ToString() != "")
			    pNS_QuaTrinhBoNhiemChucVuInfo.NgayRaQuyetDinh = DateTime.Parse(dr[pNS_QuaTrinhBoNhiemChucVuInfo.strNgayRaQuyetDinh].ToString());
			pNS_QuaTrinhBoNhiemChucVuInfo.IDDM_CapQuyetDinh = int.Parse("0" + dr[pNS_QuaTrinhBoNhiemChucVuInfo.strIDDM_CapQuyetDinh]);
			pNS_QuaTrinhBoNhiemChucVuInfo.IDDM_ChucVuBoNhiem = int.Parse("0" + dr[pNS_QuaTrinhBoNhiemChucVuInfo.strIDDM_ChucVuBoNhiem]);
            if (dr[pNS_QuaTrinhBoNhiemChucVuInfo.strNgayCoHieuLuc].ToString() != "")
			    pNS_QuaTrinhBoNhiemChucVuInfo.NgayCoHieuLuc = DateTime.Parse(dr[pNS_QuaTrinhBoNhiemChucVuInfo.strNgayCoHieuLuc].ToString());
            if (dr[pNS_QuaTrinhBoNhiemChucVuInfo.strNgayHetHieuLuc].ToString() != "")
			    pNS_QuaTrinhBoNhiemChucVuInfo.NgayHetHieuLuc = DateTime.Parse(dr[pNS_QuaTrinhBoNhiemChucVuInfo.strNgayHetHieuLuc].ToString());
			pNS_QuaTrinhBoNhiemChucVuInfo.LaChucVuKiemNhiem = bool.Parse(dr[pNS_QuaTrinhBoNhiemChucVuInfo.strLaChucVuKiemNhiem].ToString());
			pNS_QuaTrinhBoNhiemChucVuInfo.IDNS_MienNhiemTuChuc = int.Parse("0" + dr[pNS_QuaTrinhBoNhiemChucVuInfo.strIDNS_MienNhiemTuChuc]);
        }
    }
}
