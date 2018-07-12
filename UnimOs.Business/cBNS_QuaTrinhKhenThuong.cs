using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBNS_QuaTrinhKhenThuong : cBBase
    {
        private cDNS_QuaTrinhKhenThuong oDNS_QuaTrinhKhenThuong;
        private NS_QuaTrinhKhenThuongInfo oNS_QuaTrinhKhenThuongInfo;

        public cBNS_QuaTrinhKhenThuong()        
        {
            oDNS_QuaTrinhKhenThuong = new cDNS_QuaTrinhKhenThuong();
        }

        public DataTable Get(NS_QuaTrinhKhenThuongInfo pNS_QuaTrinhKhenThuongInfo)        
        {
            return oDNS_QuaTrinhKhenThuong.Get(pNS_QuaTrinhKhenThuongInfo);
        }

        public DataTable GetBy_IDNS_GiaoVien(int IDNS_GiaoVien)
        {
            return oDNS_QuaTrinhKhenThuong.GetBy_IDNS_GiaoVien(IDNS_GiaoVien);
        }

        public int Add(NS_QuaTrinhKhenThuongInfo pNS_QuaTrinhKhenThuongInfo)
        {
			int ID = 0;
            ID = oDNS_QuaTrinhKhenThuong.Add(pNS_QuaTrinhKhenThuongInfo);
            mErrorMessage = oDNS_QuaTrinhKhenThuong.ErrorMessages;
            mErrorNumber = oDNS_QuaTrinhKhenThuong.ErrorNumber;
            return ID;
        }

        public void Update(NS_QuaTrinhKhenThuongInfo pNS_QuaTrinhKhenThuongInfo)
        {
            oDNS_QuaTrinhKhenThuong.Update(pNS_QuaTrinhKhenThuongInfo);
            mErrorMessage = oDNS_QuaTrinhKhenThuong.ErrorMessages;
            mErrorNumber = oDNS_QuaTrinhKhenThuong.ErrorNumber;
        }
        
        public void Delete(NS_QuaTrinhKhenThuongInfo pNS_QuaTrinhKhenThuongInfo)
        {
            oDNS_QuaTrinhKhenThuong.Delete(pNS_QuaTrinhKhenThuongInfo);
            mErrorMessage = oDNS_QuaTrinhKhenThuong.ErrorMessages;
            mErrorNumber = oDNS_QuaTrinhKhenThuong.ErrorNumber;
        }

        public List<NS_QuaTrinhKhenThuongInfo> GetList(NS_QuaTrinhKhenThuongInfo pNS_QuaTrinhKhenThuongInfo)
        {
            List<NS_QuaTrinhKhenThuongInfo> oNS_QuaTrinhKhenThuongInfoList = new List<NS_QuaTrinhKhenThuongInfo>();
            DataTable dtb = Get(pNS_QuaTrinhKhenThuongInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oNS_QuaTrinhKhenThuongInfo = new NS_QuaTrinhKhenThuongInfo();

                    oNS_QuaTrinhKhenThuongInfo.NS_QuaTrinhKhenThuongID = int.Parse(dtb.Rows[i]["NS_QuaTrinhKhenThuongID"].ToString());
                    oNS_QuaTrinhKhenThuongInfo.IDNS_GiaoVien = int.Parse(dtb.Rows[i]["IDNS_GiaoVien"].ToString());
                    oNS_QuaTrinhKhenThuongInfo.SoQuyetDinh = dtb.Rows[i]["SoQuyetDinh"].ToString();
                    oNS_QuaTrinhKhenThuongInfo.NgayQuyetDinh = DateTime.Parse(dtb.Rows[i]["NgayQuyetDinh"].ToString());
                    oNS_QuaTrinhKhenThuongInfo.NgayCoHieuLuc = DateTime.Parse(dtb.Rows[i]["NgayCoHieuLuc"].ToString());
                    oNS_QuaTrinhKhenThuongInfo.IDDM_CapKhenThuong = int.Parse(dtb.Rows[i]["IDDM_CapKhenThuong"].ToString());
                    oNS_QuaTrinhKhenThuongInfo.NoiDung = dtb.Rows[i]["NoiDung"].ToString();
                    oNS_QuaTrinhKhenThuongInfo.GiamSoThangTangLuong = int.Parse(dtb.Rows[i]["GiamSoThangTangLuong"].ToString());
                    oNS_QuaTrinhKhenThuongInfo.SoTien = double.Parse(dtb.Rows[i]["SoTien"].ToString());
                    
                    oNS_QuaTrinhKhenThuongInfoList.Add(oNS_QuaTrinhKhenThuongInfo);
                }
            }
            return oNS_QuaTrinhKhenThuongInfoList;
        }
        
        public void ToDataRow(NS_QuaTrinhKhenThuongInfo pNS_QuaTrinhKhenThuongInfo, ref DataRow dr)
        {

			dr[pNS_QuaTrinhKhenThuongInfo.strNS_QuaTrinhKhenThuongID] = pNS_QuaTrinhKhenThuongInfo.NS_QuaTrinhKhenThuongID;
			dr[pNS_QuaTrinhKhenThuongInfo.strIDNS_GiaoVien] = pNS_QuaTrinhKhenThuongInfo.IDNS_GiaoVien;
			dr[pNS_QuaTrinhKhenThuongInfo.strSoQuyetDinh] = pNS_QuaTrinhKhenThuongInfo.SoQuyetDinh;
			dr[pNS_QuaTrinhKhenThuongInfo.strNgayQuyetDinh] = pNS_QuaTrinhKhenThuongInfo.NgayQuyetDinh;
			dr[pNS_QuaTrinhKhenThuongInfo.strNgayCoHieuLuc] = pNS_QuaTrinhKhenThuongInfo.NgayCoHieuLuc;
			dr[pNS_QuaTrinhKhenThuongInfo.strIDDM_CapKhenThuong] = pNS_QuaTrinhKhenThuongInfo.IDDM_CapKhenThuong;
			dr[pNS_QuaTrinhKhenThuongInfo.strNoiDung] = pNS_QuaTrinhKhenThuongInfo.NoiDung;
			dr[pNS_QuaTrinhKhenThuongInfo.strGiamSoThangTangLuong] = pNS_QuaTrinhKhenThuongInfo.GiamSoThangTangLuong;
			dr[pNS_QuaTrinhKhenThuongInfo.strSoTien] = pNS_QuaTrinhKhenThuongInfo.SoTien;
        }
        
        public void ToInfo(ref NS_QuaTrinhKhenThuongInfo pNS_QuaTrinhKhenThuongInfo, DataRow dr)
        {

			pNS_QuaTrinhKhenThuongInfo.NS_QuaTrinhKhenThuongID = int.Parse(dr[pNS_QuaTrinhKhenThuongInfo.strNS_QuaTrinhKhenThuongID].ToString());
			pNS_QuaTrinhKhenThuongInfo.IDNS_GiaoVien = int.Parse("0" + dr[pNS_QuaTrinhKhenThuongInfo.strIDNS_GiaoVien]);
			pNS_QuaTrinhKhenThuongInfo.SoQuyetDinh = dr[pNS_QuaTrinhKhenThuongInfo.strSoQuyetDinh].ToString();
            if (dr[pNS_QuaTrinhKhenThuongInfo.strNgayQuyetDinh].ToString() != "")
			    pNS_QuaTrinhKhenThuongInfo.NgayQuyetDinh = DateTime.Parse(dr[pNS_QuaTrinhKhenThuongInfo.strNgayQuyetDinh].ToString());
            if (dr[pNS_QuaTrinhKhenThuongInfo.strNgayCoHieuLuc].ToString() != "")
			    pNS_QuaTrinhKhenThuongInfo.NgayCoHieuLuc = DateTime.Parse(dr[pNS_QuaTrinhKhenThuongInfo.strNgayCoHieuLuc].ToString());
			pNS_QuaTrinhKhenThuongInfo.IDDM_CapKhenThuong = int.Parse("0" + dr[pNS_QuaTrinhKhenThuongInfo.strIDDM_CapKhenThuong]);
			pNS_QuaTrinhKhenThuongInfo.NoiDung = dr[pNS_QuaTrinhKhenThuongInfo.strNoiDung].ToString();
			pNS_QuaTrinhKhenThuongInfo.GiamSoThangTangLuong = int.Parse("0" + dr[pNS_QuaTrinhKhenThuongInfo.strGiamSoThangTangLuong]);
			pNS_QuaTrinhKhenThuongInfo.SoTien = double.Parse("0" + dr[pNS_QuaTrinhKhenThuongInfo.strSoTien]);
        }
    }
}
