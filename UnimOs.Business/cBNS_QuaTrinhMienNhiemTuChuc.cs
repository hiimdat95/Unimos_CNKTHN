using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBNS_QuaTrinhMienNhiemTuChuc : cBBase
    {
        private cDNS_QuaTrinhMienNhiemTuChuc oDNS_QuaTrinhMienNhiemTuChuc;
        private NS_QuaTrinhMienNhiemTuChucInfo oNS_QuaTrinhMienNhiemTuChucInfo;

        public cBNS_QuaTrinhMienNhiemTuChuc()        
        {
            oDNS_QuaTrinhMienNhiemTuChuc = new cDNS_QuaTrinhMienNhiemTuChuc();
        }

        public DataTable Get(NS_QuaTrinhMienNhiemTuChucInfo pNS_QuaTrinhMienNhiemTuChucInfo)        
        {
            return oDNS_QuaTrinhMienNhiemTuChuc.Get(pNS_QuaTrinhMienNhiemTuChucInfo);
        }

        public DataTable GetBy_IDNS_GiaoVien(int IDNS_GiaoVien)
        {
            return oDNS_QuaTrinhMienNhiemTuChuc.GetBy_IDNS_GiaoVien(IDNS_GiaoVien);
        }

        public int Add_QuaTrinhBoNhiemChucVu(NS_QuaTrinhMienNhiemTuChucInfo pNS_QuaTrinhMienNhiemTuChucInfo, int NS_QuaTrinhBoNhiemChucVuID1)
        {
            int ID = 0;
            ID = oDNS_QuaTrinhMienNhiemTuChuc.Add_QuaTrinhBoNhiemChucVu(pNS_QuaTrinhMienNhiemTuChucInfo, NS_QuaTrinhBoNhiemChucVuID1);
            mErrorMessage = oDNS_QuaTrinhMienNhiemTuChuc.ErrorMessages;
            mErrorNumber = oDNS_QuaTrinhMienNhiemTuChuc.ErrorNumber;
            return ID;
        }

        public void Update_QuaTrinhBoNhiem(NS_QuaTrinhMienNhiemTuChucInfo pNS_QuaTrinhMienNhiemTuChucInfo, int NS_QuaTrinhBoNhiemChucVuID, int NS_QuaTrinhBoNhiemChucVuID1)
        {
            oDNS_QuaTrinhMienNhiemTuChuc.Update_QuaTrinhBoNhiem(pNS_QuaTrinhMienNhiemTuChucInfo, NS_QuaTrinhBoNhiemChucVuID, NS_QuaTrinhBoNhiemChucVuID1);
            mErrorMessage = oDNS_QuaTrinhMienNhiemTuChuc.ErrorMessages;
            mErrorNumber = oDNS_QuaTrinhMienNhiemTuChuc.ErrorNumber;
        }

        public void Delete_QuaTrinhBoNhiemChucVu(NS_QuaTrinhMienNhiemTuChucInfo pNS_QuaTrinhMienNhiemTuChucInfo, int NS_QuaTrinhBoNhiemChucVuID)
        {
            oDNS_QuaTrinhMienNhiemTuChuc.Delete_QuaTrinhBoNhiemChucVu(pNS_QuaTrinhMienNhiemTuChucInfo, NS_QuaTrinhBoNhiemChucVuID);
            mErrorMessage = oDNS_QuaTrinhMienNhiemTuChuc.ErrorMessages;
            mErrorNumber = oDNS_QuaTrinhMienNhiemTuChuc.ErrorNumber;
        }

        public int Add(NS_QuaTrinhMienNhiemTuChucInfo pNS_QuaTrinhMienNhiemTuChucInfo)
        {
			int ID = 0;
            ID = oDNS_QuaTrinhMienNhiemTuChuc.Add(pNS_QuaTrinhMienNhiemTuChucInfo);
            mErrorMessage = oDNS_QuaTrinhMienNhiemTuChuc.ErrorMessages;
            mErrorNumber = oDNS_QuaTrinhMienNhiemTuChuc.ErrorNumber;
            return ID;
        }

        public void Update(NS_QuaTrinhMienNhiemTuChucInfo pNS_QuaTrinhMienNhiemTuChucInfo)
        {
            oDNS_QuaTrinhMienNhiemTuChuc.Update(pNS_QuaTrinhMienNhiemTuChucInfo);
            mErrorMessage = oDNS_QuaTrinhMienNhiemTuChuc.ErrorMessages;
            mErrorNumber = oDNS_QuaTrinhMienNhiemTuChuc.ErrorNumber;
        }
        
        public void Delete(NS_QuaTrinhMienNhiemTuChucInfo pNS_QuaTrinhMienNhiemTuChucInfo)
        {
            oDNS_QuaTrinhMienNhiemTuChuc.Delete(pNS_QuaTrinhMienNhiemTuChucInfo);
            mErrorMessage = oDNS_QuaTrinhMienNhiemTuChuc.ErrorMessages;
            mErrorNumber = oDNS_QuaTrinhMienNhiemTuChuc.ErrorNumber;
        }

        public List<NS_QuaTrinhMienNhiemTuChucInfo> GetList(NS_QuaTrinhMienNhiemTuChucInfo pNS_QuaTrinhMienNhiemTuChucInfo)
        {
            List<NS_QuaTrinhMienNhiemTuChucInfo> oNS_QuaTrinhMienNhiemTuChucInfoList = new List<NS_QuaTrinhMienNhiemTuChucInfo>();
            DataTable dtb = Get(pNS_QuaTrinhMienNhiemTuChucInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oNS_QuaTrinhMienNhiemTuChucInfo = new NS_QuaTrinhMienNhiemTuChucInfo();

                    oNS_QuaTrinhMienNhiemTuChucInfo.NS_QuaTrinhMienNhiemTuChucID = int.Parse(dtb.Rows[i]["NS_QuaTrinhMienNhiemTuChucID"].ToString());
                    oNS_QuaTrinhMienNhiemTuChucInfo.IDNS_GiaoVien = int.Parse(dtb.Rows[i]["IDNS_GiaoVien"].ToString());
                    oNS_QuaTrinhMienNhiemTuChucInfo.SoQuyetDinh = dtb.Rows[i]["SoQuyetDinh"].ToString();
                    oNS_QuaTrinhMienNhiemTuChucInfo.NgayRaQuyetDinh = DateTime.Parse(dtb.Rows[i]["NgayRaQuyetDinh"].ToString());
                    oNS_QuaTrinhMienNhiemTuChucInfo.NgayCoHieuLuc = DateTime.Parse(dtb.Rows[i]["NgayCoHieuLuc"].ToString());
                    oNS_QuaTrinhMienNhiemTuChucInfo.IDDM_CapQuyetDinh = int.Parse(dtb.Rows[i]["IDDM_CapQuyetDinh"].ToString());
                    
                    oNS_QuaTrinhMienNhiemTuChucInfoList.Add(oNS_QuaTrinhMienNhiemTuChucInfo);
                }
            }
            return oNS_QuaTrinhMienNhiemTuChucInfoList;
        }
        
        public void ToDataRow(NS_QuaTrinhMienNhiemTuChucInfo pNS_QuaTrinhMienNhiemTuChucInfo, ref DataRow dr)
        {

			dr[pNS_QuaTrinhMienNhiemTuChucInfo.strNS_QuaTrinhMienNhiemTuChucID] = pNS_QuaTrinhMienNhiemTuChucInfo.NS_QuaTrinhMienNhiemTuChucID;
            dr[pNS_QuaTrinhMienNhiemTuChucInfo.strIDNS_GiaoVien] = pNS_QuaTrinhMienNhiemTuChucInfo.IDNS_GiaoVien;
            dr[pNS_QuaTrinhMienNhiemTuChucInfo.strSoQuyetDinh] = pNS_QuaTrinhMienNhiemTuChucInfo.SoQuyetDinh;
			dr[pNS_QuaTrinhMienNhiemTuChucInfo.strNgayRaQuyetDinh] = pNS_QuaTrinhMienNhiemTuChucInfo.NgayRaQuyetDinh;
			dr[pNS_QuaTrinhMienNhiemTuChucInfo.strNgayCoHieuLuc] = pNS_QuaTrinhMienNhiemTuChucInfo.NgayCoHieuLuc;
			dr[pNS_QuaTrinhMienNhiemTuChucInfo.strIDDM_CapQuyetDinh] = pNS_QuaTrinhMienNhiemTuChucInfo.IDDM_CapQuyetDinh;
        }
        
        public void ToInfo(ref NS_QuaTrinhMienNhiemTuChucInfo pNS_QuaTrinhMienNhiemTuChucInfo, DataRow dr)
        {

			pNS_QuaTrinhMienNhiemTuChucInfo.NS_QuaTrinhMienNhiemTuChucID = int.Parse(dr[pNS_QuaTrinhMienNhiemTuChucInfo.strNS_QuaTrinhMienNhiemTuChucID].ToString());
            pNS_QuaTrinhMienNhiemTuChucInfo.IDNS_GiaoVien = int.Parse(dr[pNS_QuaTrinhMienNhiemTuChucInfo.strIDNS_GiaoVien].ToString());
            pNS_QuaTrinhMienNhiemTuChucInfo.SoQuyetDinh = dr[pNS_QuaTrinhMienNhiemTuChucInfo.strSoQuyetDinh].ToString();
			pNS_QuaTrinhMienNhiemTuChucInfo.NgayRaQuyetDinh = DateTime.Parse(dr[pNS_QuaTrinhMienNhiemTuChucInfo.strNgayRaQuyetDinh].ToString());
			pNS_QuaTrinhMienNhiemTuChucInfo.NgayCoHieuLuc = DateTime.Parse(dr[pNS_QuaTrinhMienNhiemTuChucInfo.strNgayCoHieuLuc].ToString());
			pNS_QuaTrinhMienNhiemTuChucInfo.IDDM_CapQuyetDinh = int.Parse(dr[pNS_QuaTrinhMienNhiemTuChucInfo.strIDDM_CapQuyetDinh].ToString());
        }
    }
}
