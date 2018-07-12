using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBNS_QuaTrinhBoiDuong : cBBase
    {
        private cDNS_QuaTrinhBoiDuong oDNS_QuaTrinhBoiDuong;
        private NS_QuaTrinhBoiDuongInfo oNS_QuaTrinhBoiDuongInfo;

        public cBNS_QuaTrinhBoiDuong()        
        {
            oDNS_QuaTrinhBoiDuong = new cDNS_QuaTrinhBoiDuong();
        }

        public DataTable Get(NS_QuaTrinhBoiDuongInfo pNS_QuaTrinhBoiDuongInfo)        
        {
            return oDNS_QuaTrinhBoiDuong.Get(pNS_QuaTrinhBoiDuongInfo);
        }

        public DataTable GetBy_IDNS_GiaoVien(int IDNS_GiaoVien)
        {
            return oDNS_QuaTrinhBoiDuong.GetBy_IDNS_GiaoVien(IDNS_GiaoVien);
        }

        public int Add(NS_QuaTrinhBoiDuongInfo pNS_QuaTrinhBoiDuongInfo)
        {
			int ID = 0;
            ID = oDNS_QuaTrinhBoiDuong.Add(pNS_QuaTrinhBoiDuongInfo);
            mErrorMessage = oDNS_QuaTrinhBoiDuong.ErrorMessages;
            mErrorNumber = oDNS_QuaTrinhBoiDuong.ErrorNumber;
            return ID;
        }

        public void Update(NS_QuaTrinhBoiDuongInfo pNS_QuaTrinhBoiDuongInfo)
        {
            oDNS_QuaTrinhBoiDuong.Update(pNS_QuaTrinhBoiDuongInfo);
            mErrorMessage = oDNS_QuaTrinhBoiDuong.ErrorMessages;
            mErrorNumber = oDNS_QuaTrinhBoiDuong.ErrorNumber;
        }
        
        public void Delete(NS_QuaTrinhBoiDuongInfo pNS_QuaTrinhBoiDuongInfo)
        {
            oDNS_QuaTrinhBoiDuong.Delete(pNS_QuaTrinhBoiDuongInfo);
            mErrorMessage = oDNS_QuaTrinhBoiDuong.ErrorMessages;
            mErrorNumber = oDNS_QuaTrinhBoiDuong.ErrorNumber;
        }

        public List<NS_QuaTrinhBoiDuongInfo> GetList(NS_QuaTrinhBoiDuongInfo pNS_QuaTrinhBoiDuongInfo)
        {
            List<NS_QuaTrinhBoiDuongInfo> oNS_QuaTrinhBoiDuongInfoList = new List<NS_QuaTrinhBoiDuongInfo>();
            DataTable dtb = Get(pNS_QuaTrinhBoiDuongInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oNS_QuaTrinhBoiDuongInfo = new NS_QuaTrinhBoiDuongInfo();

                    oNS_QuaTrinhBoiDuongInfo.NS_QuaTrinhBoiDuongID = int.Parse(dtb.Rows[i]["NS_QuaTrinhBoiDuongID"].ToString());
                    oNS_QuaTrinhBoiDuongInfo.IDNS_GiaoVien = int.Parse(dtb.Rows[i]["IDNS_GiaoVien"].ToString());
                    oNS_QuaTrinhBoiDuongInfo.NoiBoiDuong = dtb.Rows[i]["NoiBoiDuong"].ToString();
                    oNS_QuaTrinhBoiDuongInfo.NoiDungBoiDuong = dtb.Rows[i]["NoiDungBoiDuong"].ToString();
                    oNS_QuaTrinhBoiDuongInfo.TuNgay = DateTime.Parse(dtb.Rows[i]["TuNgay"].ToString());
                    oNS_QuaTrinhBoiDuongInfo.DenNgay = DateTime.Parse(dtb.Rows[i]["DenNgay"].ToString());
                    oNS_QuaTrinhBoiDuongInfo.IDDM_VanBangChungChi = int.Parse(dtb.Rows[i]["IDDM_VanBangChungChi"].ToString());
                    oNS_QuaTrinhBoiDuongInfo.IDDM_XepLoaiChungChi = int.Parse(dtb.Rows[i]["IDDM_XepLoaiChungChi"].ToString());
                    oNS_QuaTrinhBoiDuongInfo.IDDM_HinhThucDaoTao = int.Parse(dtb.Rows[i]["IDDM_HinhThucDaoTao"].ToString());
                    oNS_QuaTrinhBoiDuongInfo.CoThoiHan = bool.Parse(dtb.Rows[i]["CoThoiHan"].ToString());
                    oNS_QuaTrinhBoiDuongInfo.ThoiHanTuNgay = DateTime.Parse(dtb.Rows[i]["ThoiHanTuNgay"].ToString());
                    oNS_QuaTrinhBoiDuongInfo.ThoiHanDenNgay = DateTime.Parse(dtb.Rows[i]["ThoiHanDenNgay"].ToString());
                    
                    oNS_QuaTrinhBoiDuongInfoList.Add(oNS_QuaTrinhBoiDuongInfo);
                }
            }
            return oNS_QuaTrinhBoiDuongInfoList;
        }
        
        public void ToDataRow(NS_QuaTrinhBoiDuongInfo pNS_QuaTrinhBoiDuongInfo, ref DataRow dr)
        {

			dr[pNS_QuaTrinhBoiDuongInfo.strNS_QuaTrinhBoiDuongID] = pNS_QuaTrinhBoiDuongInfo.NS_QuaTrinhBoiDuongID;
			dr[pNS_QuaTrinhBoiDuongInfo.strIDNS_GiaoVien] = pNS_QuaTrinhBoiDuongInfo.IDNS_GiaoVien;
			dr[pNS_QuaTrinhBoiDuongInfo.strNoiBoiDuong] = pNS_QuaTrinhBoiDuongInfo.NoiBoiDuong;
			dr[pNS_QuaTrinhBoiDuongInfo.strNoiDungBoiDuong] = pNS_QuaTrinhBoiDuongInfo.NoiDungBoiDuong;
			dr[pNS_QuaTrinhBoiDuongInfo.strTuNgay] = pNS_QuaTrinhBoiDuongInfo.TuNgay;
			dr[pNS_QuaTrinhBoiDuongInfo.strDenNgay] = pNS_QuaTrinhBoiDuongInfo.DenNgay;
			dr[pNS_QuaTrinhBoiDuongInfo.strIDDM_VanBangChungChi] = pNS_QuaTrinhBoiDuongInfo.IDDM_VanBangChungChi;
			dr[pNS_QuaTrinhBoiDuongInfo.strIDDM_XepLoaiChungChi] = pNS_QuaTrinhBoiDuongInfo.IDDM_XepLoaiChungChi;
			dr[pNS_QuaTrinhBoiDuongInfo.strIDDM_HinhThucDaoTao] = pNS_QuaTrinhBoiDuongInfo.IDDM_HinhThucDaoTao;
			dr[pNS_QuaTrinhBoiDuongInfo.strCoThoiHan] = pNS_QuaTrinhBoiDuongInfo.CoThoiHan;
			dr[pNS_QuaTrinhBoiDuongInfo.strThoiHanTuNgay] = pNS_QuaTrinhBoiDuongInfo.ThoiHanTuNgay;
			dr[pNS_QuaTrinhBoiDuongInfo.strThoiHanDenNgay] = pNS_QuaTrinhBoiDuongInfo.ThoiHanDenNgay;
        }
        
        public void ToInfo(ref NS_QuaTrinhBoiDuongInfo pNS_QuaTrinhBoiDuongInfo, DataRow dr)
        {

			pNS_QuaTrinhBoiDuongInfo.NS_QuaTrinhBoiDuongID = int.Parse(dr[pNS_QuaTrinhBoiDuongInfo.strNS_QuaTrinhBoiDuongID].ToString());
			pNS_QuaTrinhBoiDuongInfo.IDNS_GiaoVien = int.Parse("0" + dr[pNS_QuaTrinhBoiDuongInfo.strIDNS_GiaoVien]);
			pNS_QuaTrinhBoiDuongInfo.NoiBoiDuong = dr[pNS_QuaTrinhBoiDuongInfo.strNoiBoiDuong].ToString();
			pNS_QuaTrinhBoiDuongInfo.NoiDungBoiDuong = dr[pNS_QuaTrinhBoiDuongInfo.strNoiDungBoiDuong].ToString();
            if (dr[pNS_QuaTrinhBoiDuongInfo.strTuNgay].ToString() != "")
			    pNS_QuaTrinhBoiDuongInfo.TuNgay = DateTime.Parse(dr[pNS_QuaTrinhBoiDuongInfo.strTuNgay].ToString());
            if(dr[pNS_QuaTrinhBoiDuongInfo.strDenNgay].ToString() != "")
			    pNS_QuaTrinhBoiDuongInfo.DenNgay = DateTime.Parse(dr[pNS_QuaTrinhBoiDuongInfo.strDenNgay].ToString());
			pNS_QuaTrinhBoiDuongInfo.IDDM_VanBangChungChi = int.Parse("0" + dr[pNS_QuaTrinhBoiDuongInfo.strIDDM_VanBangChungChi]);
			pNS_QuaTrinhBoiDuongInfo.IDDM_XepLoaiChungChi = int.Parse("0" + dr[pNS_QuaTrinhBoiDuongInfo.strIDDM_XepLoaiChungChi]);
			pNS_QuaTrinhBoiDuongInfo.IDDM_HinhThucDaoTao = int.Parse("0" + dr[pNS_QuaTrinhBoiDuongInfo.strIDDM_HinhThucDaoTao]);
			pNS_QuaTrinhBoiDuongInfo.CoThoiHan = bool.Parse(dr[pNS_QuaTrinhBoiDuongInfo.strCoThoiHan].ToString());
            if (dr[pNS_QuaTrinhBoiDuongInfo.strThoiHanTuNgay].ToString() != "")
			    pNS_QuaTrinhBoiDuongInfo.ThoiHanTuNgay = DateTime.Parse(dr[pNS_QuaTrinhBoiDuongInfo.strThoiHanTuNgay].ToString());
            if (dr[pNS_QuaTrinhBoiDuongInfo.strThoiHanTuNgay].ToString() != "")
			    pNS_QuaTrinhBoiDuongInfo.ThoiHanDenNgay = DateTime.Parse(dr[pNS_QuaTrinhBoiDuongInfo.strThoiHanDenNgay].ToString());
        }
    }
}
