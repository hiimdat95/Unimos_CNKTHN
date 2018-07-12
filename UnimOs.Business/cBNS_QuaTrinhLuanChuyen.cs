using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBNS_QuaTrinhLuanChuyen : cBBase
    {
        private cDNS_QuaTrinhLuanChuyen oDNS_QuaTrinhLuanChuyen;
        private NS_QuaTrinhLuanChuyenInfo oNS_QuaTrinhLuanChuyenInfo;

        public cBNS_QuaTrinhLuanChuyen()        
        {
            oDNS_QuaTrinhLuanChuyen = new cDNS_QuaTrinhLuanChuyen();
        }

        public DataTable Get(NS_QuaTrinhLuanChuyenInfo pNS_QuaTrinhLuanChuyenInfo)        
        {
            return oDNS_QuaTrinhLuanChuyen.Get(pNS_QuaTrinhLuanChuyenInfo);
        }

        public void Get_UpdateBy_IDNS_GiaoVien(int IDNS_GiaoVien)
        {
            oDNS_QuaTrinhLuanChuyen.Get_UpdateBy_IDNS_GiaoVien(IDNS_GiaoVien);
        }

        public DataTable GetBy_IDNS_GiaoVien(int IDNS_GiaoVien)
        {
            return oDNS_QuaTrinhLuanChuyen.GetBy_IDNS_GiaoVien(IDNS_GiaoVien);
        }

        public int Add(NS_QuaTrinhLuanChuyenInfo pNS_QuaTrinhLuanChuyenInfo)
        {
			int ID = 0;
            ID = oDNS_QuaTrinhLuanChuyen.Add(pNS_QuaTrinhLuanChuyenInfo);
            mErrorMessage = oDNS_QuaTrinhLuanChuyen.ErrorMessages;
            mErrorNumber = oDNS_QuaTrinhLuanChuyen.ErrorNumber;
            return ID;
        }

        public void Update(NS_QuaTrinhLuanChuyenInfo pNS_QuaTrinhLuanChuyenInfo)
        {
            oDNS_QuaTrinhLuanChuyen.Update(pNS_QuaTrinhLuanChuyenInfo);
            mErrorMessage = oDNS_QuaTrinhLuanChuyen.ErrorMessages;
            mErrorNumber = oDNS_QuaTrinhLuanChuyen.ErrorNumber;
        }
        
        public void Delete(NS_QuaTrinhLuanChuyenInfo pNS_QuaTrinhLuanChuyenInfo)
        {
            oDNS_QuaTrinhLuanChuyen.Delete(pNS_QuaTrinhLuanChuyenInfo);
            mErrorMessage = oDNS_QuaTrinhLuanChuyen.ErrorMessages;
            mErrorNumber = oDNS_QuaTrinhLuanChuyen.ErrorNumber;
        }

        public List<NS_QuaTrinhLuanChuyenInfo> GetList(NS_QuaTrinhLuanChuyenInfo pNS_QuaTrinhLuanChuyenInfo)
        {
            List<NS_QuaTrinhLuanChuyenInfo> oNS_QuaTrinhLuanChuyenInfoList = new List<NS_QuaTrinhLuanChuyenInfo>();
            DataTable dtb = Get(pNS_QuaTrinhLuanChuyenInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oNS_QuaTrinhLuanChuyenInfo = new NS_QuaTrinhLuanChuyenInfo();

                    oNS_QuaTrinhLuanChuyenInfo.NS_QuaTrinhLuanChuyenID = int.Parse(dtb.Rows[i]["NS_QuaTrinhLuanChuyenID"].ToString());
                    oNS_QuaTrinhLuanChuyenInfo.IDNS_GiaoVien = int.Parse(dtb.Rows[i]["IDNS_GiaoVien"].ToString());
                    oNS_QuaTrinhLuanChuyenInfo.SoQuyetDinh = dtb.Rows[i]["SoQuyetDinh"].ToString();
                    oNS_QuaTrinhLuanChuyenInfo.NgayQuyetDinh = DateTime.Parse(dtb.Rows[i]["NgayQuyetDinh"].ToString());
                    oNS_QuaTrinhLuanChuyenInfo.NgayCoHieuLuc = DateTime.Parse(dtb.Rows[i]["NgayCoHieuLuc"].ToString());
                    oNS_QuaTrinhLuanChuyenInfo.IDNS_LoaiLuanChuyen = int.Parse(dtb.Rows[i]["IDNS_LoaiLuanChuyen"].ToString());
                    oNS_QuaTrinhLuanChuyenInfo.IDNS_DonViCu = int.Parse(dtb.Rows[i]["IDNS_DonViCu"].ToString());
                    oNS_QuaTrinhLuanChuyenInfo.IDNS_DonViMoi = int.Parse(dtb.Rows[i]["IDNS_DonViMoi"].ToString());
                    oNS_QuaTrinhLuanChuyenInfo.NoiDung = dtb.Rows[i]["NoiDung"].ToString();
                    
                    oNS_QuaTrinhLuanChuyenInfoList.Add(oNS_QuaTrinhLuanChuyenInfo);
                }
            }
            return oNS_QuaTrinhLuanChuyenInfoList;
        }
        
        public void ToDataRow(NS_QuaTrinhLuanChuyenInfo pNS_QuaTrinhLuanChuyenInfo, ref DataRow dr)
        {

			dr[pNS_QuaTrinhLuanChuyenInfo.strNS_QuaTrinhLuanChuyenID] = pNS_QuaTrinhLuanChuyenInfo.NS_QuaTrinhLuanChuyenID;
			dr[pNS_QuaTrinhLuanChuyenInfo.strIDNS_GiaoVien] = pNS_QuaTrinhLuanChuyenInfo.IDNS_GiaoVien;
			dr[pNS_QuaTrinhLuanChuyenInfo.strSoQuyetDinh] = pNS_QuaTrinhLuanChuyenInfo.SoQuyetDinh;
			dr[pNS_QuaTrinhLuanChuyenInfo.strNgayQuyetDinh] = pNS_QuaTrinhLuanChuyenInfo.NgayQuyetDinh;
			dr[pNS_QuaTrinhLuanChuyenInfo.strNgayCoHieuLuc] = pNS_QuaTrinhLuanChuyenInfo.NgayCoHieuLuc;
			dr[pNS_QuaTrinhLuanChuyenInfo.strIDNS_LoaiLuanChuyen] = pNS_QuaTrinhLuanChuyenInfo.IDNS_LoaiLuanChuyen;
			dr[pNS_QuaTrinhLuanChuyenInfo.strIDNS_DonViCu] = pNS_QuaTrinhLuanChuyenInfo.IDNS_DonViCu;
			dr[pNS_QuaTrinhLuanChuyenInfo.strIDNS_DonViMoi] = pNS_QuaTrinhLuanChuyenInfo.IDNS_DonViMoi;
			dr[pNS_QuaTrinhLuanChuyenInfo.strNoiDung] = pNS_QuaTrinhLuanChuyenInfo.NoiDung;
        }
        
        public void ToInfo(ref NS_QuaTrinhLuanChuyenInfo pNS_QuaTrinhLuanChuyenInfo, DataRow dr)
        {

			pNS_QuaTrinhLuanChuyenInfo.NS_QuaTrinhLuanChuyenID = int.Parse(dr[pNS_QuaTrinhLuanChuyenInfo.strNS_QuaTrinhLuanChuyenID].ToString());
			pNS_QuaTrinhLuanChuyenInfo.IDNS_GiaoVien = int.Parse("0" + dr[pNS_QuaTrinhLuanChuyenInfo.strIDNS_GiaoVien]);
			pNS_QuaTrinhLuanChuyenInfo.SoQuyetDinh = dr[pNS_QuaTrinhLuanChuyenInfo.strSoQuyetDinh].ToString();
            if (dr[pNS_QuaTrinhLuanChuyenInfo.strNgayQuyetDinh].ToString() != "")
			    pNS_QuaTrinhLuanChuyenInfo.NgayQuyetDinh = DateTime.Parse(dr[pNS_QuaTrinhLuanChuyenInfo.strNgayQuyetDinh].ToString());
            if (dr[pNS_QuaTrinhLuanChuyenInfo.strNgayCoHieuLuc].ToString() != "")
			    pNS_QuaTrinhLuanChuyenInfo.NgayCoHieuLuc = DateTime.Parse(dr[pNS_QuaTrinhLuanChuyenInfo.strNgayCoHieuLuc].ToString());
			pNS_QuaTrinhLuanChuyenInfo.IDNS_LoaiLuanChuyen = int.Parse("0" + dr[pNS_QuaTrinhLuanChuyenInfo.strIDNS_LoaiLuanChuyen]);
			pNS_QuaTrinhLuanChuyenInfo.IDNS_DonViCu = int.Parse("0" + dr[pNS_QuaTrinhLuanChuyenInfo.strIDNS_DonViCu]);
			pNS_QuaTrinhLuanChuyenInfo.IDNS_DonViMoi = int.Parse("0" + dr[pNS_QuaTrinhLuanChuyenInfo.strIDNS_DonViMoi]);
			pNS_QuaTrinhLuanChuyenInfo.NoiDung = dr[pNS_QuaTrinhLuanChuyenInfo.strNoiDung].ToString();
        }
    }
}
