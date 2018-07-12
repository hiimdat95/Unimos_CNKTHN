using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBNS_QuaTrinhKyLuat : cBBase
    {
        private cDNS_QuaTrinhKyLuat oDNS_QuaTrinhKyLuat;
        private NS_QuaTrinhKyLuatInfo oNS_QuaTrinhKyLuatInfo;

        public cBNS_QuaTrinhKyLuat()        
        {
            oDNS_QuaTrinhKyLuat = new cDNS_QuaTrinhKyLuat();
        }

        public DataTable Get(NS_QuaTrinhKyLuatInfo pNS_QuaTrinhKyLuatInfo)        
        {
            return oDNS_QuaTrinhKyLuat.Get(pNS_QuaTrinhKyLuatInfo);
        }

        public DataTable GetBy_IDNS_GiaoVien(int IDNS_GiaoVien)
        {
            return oDNS_QuaTrinhKyLuat.GetBy_IDNS_GiaoVien(IDNS_GiaoVien);
        }

        public int Add(NS_QuaTrinhKyLuatInfo pNS_QuaTrinhKyLuatInfo)
        {
			int ID = 0;
            ID = oDNS_QuaTrinhKyLuat.Add(pNS_QuaTrinhKyLuatInfo);
            mErrorMessage = oDNS_QuaTrinhKyLuat.ErrorMessages;
            mErrorNumber = oDNS_QuaTrinhKyLuat.ErrorNumber;
            return ID;
        }

        public void Update(NS_QuaTrinhKyLuatInfo pNS_QuaTrinhKyLuatInfo)
        {
            oDNS_QuaTrinhKyLuat.Update(pNS_QuaTrinhKyLuatInfo);
            mErrorMessage = oDNS_QuaTrinhKyLuat.ErrorMessages;
            mErrorNumber = oDNS_QuaTrinhKyLuat.ErrorNumber;
        }

        public void UpdateBy_NSQuaTrinhKyLuatID(bool XoaKyLuat, DateTime NgayXoa, string LyDoXoa, bool XoaTangSoThangTangLuong, int NS_QuaTrinhKyLuatID)
        {
            oDNS_QuaTrinhKyLuat.UpdateBy_NSQuaTrinhKyLuatID(XoaKyLuat, NgayXoa, LyDoXoa, XoaTangSoThangTangLuong, NS_QuaTrinhKyLuatID);
        }
        
        public void Delete(NS_QuaTrinhKyLuatInfo pNS_QuaTrinhKyLuatInfo)
        {
            oDNS_QuaTrinhKyLuat.Delete(pNS_QuaTrinhKyLuatInfo);
            mErrorMessage = oDNS_QuaTrinhKyLuat.ErrorMessages;
            mErrorNumber = oDNS_QuaTrinhKyLuat.ErrorNumber;
        }

        public List<NS_QuaTrinhKyLuatInfo> GetList(NS_QuaTrinhKyLuatInfo pNS_QuaTrinhKyLuatInfo)
        {
            List<NS_QuaTrinhKyLuatInfo> oNS_QuaTrinhKyLuatInfoList = new List<NS_QuaTrinhKyLuatInfo>();
            DataTable dtb = Get(pNS_QuaTrinhKyLuatInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oNS_QuaTrinhKyLuatInfo = new NS_QuaTrinhKyLuatInfo();

                    oNS_QuaTrinhKyLuatInfo.NS_QuaTrinhKyLuatID = int.Parse(dtb.Rows[i]["NS_QuaTrinhKyLuatID"].ToString());
                    oNS_QuaTrinhKyLuatInfo.IDNS_GiaoVien = int.Parse(dtb.Rows[i]["IDNS_GiaoVien"].ToString());
                    oNS_QuaTrinhKyLuatInfo.SoQuyetDinh = dtb.Rows[i]["SoQuyetDinh"].ToString();
                    oNS_QuaTrinhKyLuatInfo.NgayQuyetDinh = DateTime.Parse(dtb.Rows[i]["NgayQuyetDinh"].ToString());
                    oNS_QuaTrinhKyLuatInfo.IDDM_CapKhenThuong = int.Parse(dtb.Rows[i]["IDDM_CapKhenThuong"].ToString());
                    oNS_QuaTrinhKyLuatInfo.NoiDung = dtb.Rows[i]["NoiDung"].ToString();
                    oNS_QuaTrinhKyLuatInfo.TangSoThangTangLuong = int.Parse(dtb.Rows[i]["TangSoThangTangLuong"].ToString());
                    oNS_QuaTrinhKyLuatInfo.NgayCoHieuLuc = DateTime.Parse(dtb.Rows[i]["NgayCoHieuLuc"].ToString());
                    oNS_QuaTrinhKyLuatInfo.NgayHetHieuLuc = DateTime.Parse(dtb.Rows[i]["NgayHetHieuLuc"].ToString());
                    oNS_QuaTrinhKyLuatInfo.XoaKyLuat = bool.Parse(dtb.Rows[i]["XoaKyLuat"].ToString());
                    oNS_QuaTrinhKyLuatInfo.NgayXoa = DateTime.Parse(dtb.Rows[i]["NgayXoa"].ToString());
                    oNS_QuaTrinhKyLuatInfo.LyDoXoa = dtb.Rows[i]["LyDoXoa"].ToString();
                    oNS_QuaTrinhKyLuatInfo.XoaTangSoThangTangLuong = bool.Parse(dtb.Rows[i]["XoaTangSoThangTangLuong"].ToString());
                    
                    oNS_QuaTrinhKyLuatInfoList.Add(oNS_QuaTrinhKyLuatInfo);
                }
            }
            return oNS_QuaTrinhKyLuatInfoList;
        }
        
        public void ToDataRow(NS_QuaTrinhKyLuatInfo pNS_QuaTrinhKyLuatInfo, ref DataRow dr)
        {

			dr[pNS_QuaTrinhKyLuatInfo.strNS_QuaTrinhKyLuatID] = pNS_QuaTrinhKyLuatInfo.NS_QuaTrinhKyLuatID;
			dr[pNS_QuaTrinhKyLuatInfo.strIDNS_GiaoVien] = pNS_QuaTrinhKyLuatInfo.IDNS_GiaoVien;
			dr[pNS_QuaTrinhKyLuatInfo.strSoQuyetDinh] = pNS_QuaTrinhKyLuatInfo.SoQuyetDinh;
			dr[pNS_QuaTrinhKyLuatInfo.strNgayQuyetDinh] = pNS_QuaTrinhKyLuatInfo.NgayQuyetDinh;
			dr[pNS_QuaTrinhKyLuatInfo.strIDDM_CapKhenThuong] = pNS_QuaTrinhKyLuatInfo.IDDM_CapKhenThuong;
			dr[pNS_QuaTrinhKyLuatInfo.strNoiDung] = pNS_QuaTrinhKyLuatInfo.NoiDung;
			dr[pNS_QuaTrinhKyLuatInfo.strTangSoThangTangLuong] = pNS_QuaTrinhKyLuatInfo.TangSoThangTangLuong;
			dr[pNS_QuaTrinhKyLuatInfo.strNgayCoHieuLuc] = pNS_QuaTrinhKyLuatInfo.NgayCoHieuLuc;
			dr[pNS_QuaTrinhKyLuatInfo.strNgayHetHieuLuc] = pNS_QuaTrinhKyLuatInfo.NgayHetHieuLuc;
            dr[pNS_QuaTrinhKyLuatInfo.strXoaKyLuat] = pNS_QuaTrinhKyLuatInfo.XoaKyLuat;
            dr[pNS_QuaTrinhKyLuatInfo.strNgayXoa] = pNS_QuaTrinhKyLuatInfo.NgayXoa;
            dr[pNS_QuaTrinhKyLuatInfo.strLyDoXoa] = pNS_QuaTrinhKyLuatInfo.LyDoXoa;
            dr[pNS_QuaTrinhKyLuatInfo.strXoaTangSoThangTangLuong] = pNS_QuaTrinhKyLuatInfo.XoaTangSoThangTangLuong;
        }
        
        public void ToInfo(ref NS_QuaTrinhKyLuatInfo pNS_QuaTrinhKyLuatInfo, DataRow dr)
        {

			pNS_QuaTrinhKyLuatInfo.NS_QuaTrinhKyLuatID = int.Parse(dr[pNS_QuaTrinhKyLuatInfo.strNS_QuaTrinhKyLuatID].ToString());
			pNS_QuaTrinhKyLuatInfo.IDNS_GiaoVien = int.Parse("0" + dr[pNS_QuaTrinhKyLuatInfo.strIDNS_GiaoVien]);
			pNS_QuaTrinhKyLuatInfo.SoQuyetDinh = dr[pNS_QuaTrinhKyLuatInfo.strSoQuyetDinh].ToString();
            if (dr[pNS_QuaTrinhKyLuatInfo.strNgayQuyetDinh].ToString() != "")
			    pNS_QuaTrinhKyLuatInfo.NgayQuyetDinh = DateTime.Parse(dr[pNS_QuaTrinhKyLuatInfo.strNgayQuyetDinh].ToString());
			pNS_QuaTrinhKyLuatInfo.IDDM_CapKhenThuong = int.Parse("0" + dr[pNS_QuaTrinhKyLuatInfo.strIDDM_CapKhenThuong]);
			pNS_QuaTrinhKyLuatInfo.NoiDung = dr[pNS_QuaTrinhKyLuatInfo.strNoiDung].ToString();
			pNS_QuaTrinhKyLuatInfo.TangSoThangTangLuong = int.Parse("0" + dr[pNS_QuaTrinhKyLuatInfo.strTangSoThangTangLuong]);
            if (dr[pNS_QuaTrinhKyLuatInfo.strNgayCoHieuLuc].ToString()!= "")
			    pNS_QuaTrinhKyLuatInfo.NgayCoHieuLuc = DateTime.Parse(dr[pNS_QuaTrinhKyLuatInfo.strNgayCoHieuLuc].ToString());
            if (dr[pNS_QuaTrinhKyLuatInfo.strNgayHetHieuLuc].ToString()!= "")
			    pNS_QuaTrinhKyLuatInfo.NgayHetHieuLuc = DateTime.Parse(dr[pNS_QuaTrinhKyLuatInfo.strNgayHetHieuLuc].ToString());
            pNS_QuaTrinhKyLuatInfo.XoaKyLuat = bool.Parse(dr[pNS_QuaTrinhKyLuatInfo.strXoaKyLuat].ToString());
            if (dr[pNS_QuaTrinhKyLuatInfo.strNgayXoa].ToString() != "")
                pNS_QuaTrinhKyLuatInfo.NgayXoa = DateTime.Parse(dr[pNS_QuaTrinhKyLuatInfo.strNgayXoa].ToString());
            pNS_QuaTrinhKyLuatInfo.LyDoXoa = dr[pNS_QuaTrinhKyLuatInfo.strLyDoXoa].ToString();
            pNS_QuaTrinhKyLuatInfo.XoaTangSoThangTangLuong = bool.Parse(dr[pNS_QuaTrinhKyLuatInfo.strXoaTangSoThangTangLuong].ToString());
        }
    }
}
