using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBNS_Luong : cBBase
    {
        private cDNS_Luong oDNS_Luong;
        private NS_LuongInfo oNS_LuongInfo;

        public cBNS_Luong()        
        {
            oDNS_Luong = new cDNS_Luong();
        }

        public DataTable Get(NS_LuongInfo pNS_LuongInfo)        
        {
            return oDNS_Luong.Get(pNS_LuongInfo);
        }

        public DataTable GetBy_IDNS_GiaoVien(int IDNS_GiaoVien)
        {
            return oDNS_Luong.GetBy_IDNS_GiaoVien(IDNS_GiaoVien);
        }

        public DataTable Get_CanhBaoHanNangLuong(int HanCanhBao, DateTime TinhDenNgay)
        {
            return oDNS_Luong.Get_CanhBaoHanNangLuong(HanCanhBao, TinhDenNgay);
        }

        public DataTable Get_BangLuong(DateTime TinhDenNgay)
        {
            return oDNS_Luong.Get_BangLuong(TinhDenNgay);
        }

        public DataTable GetBy_NS_SoQuyetDinhID(int NS_SoQuyetDinhID)
        {
            return oDNS_Luong.GetBy_NS_SoQuyetDinhID(NS_SoQuyetDinhID);
        }

        public DataTable GetSoLuongCongChuc(DateTime DenNgay)
        {
            return oDNS_Luong.GetSoLuongCongChuc(DenNgay);
        }

        public int Add(NS_LuongInfo pNS_LuongInfo)
        {
			int ID = 0;
            ID = oDNS_Luong.Add(pNS_LuongInfo);
            mErrorMessage = oDNS_Luong.ErrorMessages;
            mErrorNumber = oDNS_Luong.ErrorNumber;
            return ID;
        }

        public int Add_InfoFull(NS_LuongInfo pNS_LuongInfo)
        {
            int ID = 0;
            ID = oDNS_Luong.Add_InfoFull(pNS_LuongInfo);
            mErrorMessage = oDNS_Luong.ErrorMessages;
            mErrorNumber = oDNS_Luong.ErrorNumber;
            return ID;
        }

        public void Update(NS_LuongInfo pNS_LuongInfo)
        {
            oDNS_Luong.Update(pNS_LuongInfo);
            mErrorMessage = oDNS_Luong.ErrorMessages;
            mErrorNumber = oDNS_Luong.ErrorNumber;
        }
        
        public void Delete(NS_LuongInfo pNS_LuongInfo)
        {
            oDNS_Luong.Delete(pNS_LuongInfo);
            mErrorMessage = oDNS_Luong.ErrorMessages;
            mErrorNumber = oDNS_Luong.ErrorNumber;
        }

        public void Delete_NS_SoQuyetDinhID(int NS_SoQuyetDinhID)
        {
            oDNS_Luong.Delete_NS_SoQuyetDinhID(NS_SoQuyetDinhID);
            mErrorMessage = oDNS_Luong.ErrorMessages;
            mErrorNumber = oDNS_Luong.ErrorNumber;
        }

        public List<NS_LuongInfo> GetList(NS_LuongInfo pNS_LuongInfo)
        {
            List<NS_LuongInfo> oNS_LuongInfoList = new List<NS_LuongInfo>();
            DataTable dtb = Get(pNS_LuongInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oNS_LuongInfo = new NS_LuongInfo();

                    oNS_LuongInfo.NS_LuongID = int.Parse(dtb.Rows[i]["NS_LuongID"].ToString());
                    oNS_LuongInfo.IDNS_SoQuyetDinh = int.Parse(dtb.Rows[i]["IDNS_SoQuyetDinh"].ToString());
                    oNS_LuongInfo.IDNS_GiaoVien = int.Parse(dtb.Rows[i]["IDNS_GiaoVien"].ToString());
                    oNS_LuongInfo.CongViecDamNhiem = dtb.Rows[i]["CongViecDamNhiem"].ToString();
                    oNS_LuongInfo.IDNS_NgachCongChuc = int.Parse(dtb.Rows[i]["IDNS_NgachCongChuc"].ToString());
                    oNS_LuongInfo.BacLuong = int.Parse(dtb.Rows[i]["BacLuong"].ToString());
                    oNS_LuongInfo.HeSoLuong = double.Parse(dtb.Rows[i]["HeSoLuong"].ToString());
                    oNS_LuongInfo.PhanTramHuong = double.Parse(dtb.Rows[i]["PhanTramHuong"].ToString());
                    oNS_LuongInfo.TuNgay = DateTime.Parse(dtb.Rows[i]["TuNgay"].ToString());
                    oNS_LuongInfo.DenNgay = DateTime.Parse(dtb.Rows[i]["DenNgay"].ToString());
                    
                    oNS_LuongInfoList.Add(oNS_LuongInfo);
                }
            }
            return oNS_LuongInfoList;
        }
        
        public void ToDataRow(NS_LuongInfo pNS_LuongInfo, ref DataRow dr)
        {

			dr[pNS_LuongInfo.strNS_LuongID] = pNS_LuongInfo.NS_LuongID;
            dr[pNS_LuongInfo.strIDNS_SoQuyetDinh] = pNS_LuongInfo.IDNS_SoQuyetDinh;
			dr[pNS_LuongInfo.strIDNS_GiaoVien] = pNS_LuongInfo.IDNS_GiaoVien;
			dr[pNS_LuongInfo.strCongViecDamNhiem] = pNS_LuongInfo.CongViecDamNhiem;
			dr[pNS_LuongInfo.strIDNS_NgachCongChuc] = pNS_LuongInfo.IDNS_NgachCongChuc;
			dr[pNS_LuongInfo.strBacLuong] = pNS_LuongInfo.BacLuong;
			dr[pNS_LuongInfo.strHeSoLuong] = pNS_LuongInfo.HeSoLuong;
			dr[pNS_LuongInfo.strPhanTramHuong] = pNS_LuongInfo.PhanTramHuong;
			dr[pNS_LuongInfo.strTuNgay] = pNS_LuongInfo.TuNgay;
			dr[pNS_LuongInfo.strDenNgay] = pNS_LuongInfo.DenNgay;
        }
        
        public void ToInfo(ref NS_LuongInfo pNS_LuongInfo, DataRow dr)
        {

			pNS_LuongInfo.NS_LuongID = int.Parse(dr[pNS_LuongInfo.strNS_LuongID].ToString());
			pNS_LuongInfo.IDNS_GiaoVien = int.Parse("0" + dr[pNS_LuongInfo.strIDNS_GiaoVien]);
            pNS_LuongInfo.IDNS_SoQuyetDinh = int.Parse("0" + dr[pNS_LuongInfo.strIDNS_SoQuyetDinh]);
			pNS_LuongInfo.CongViecDamNhiem = dr[pNS_LuongInfo.strCongViecDamNhiem].ToString();
			pNS_LuongInfo.IDNS_NgachCongChuc = int.Parse("0" + dr[pNS_LuongInfo.strIDNS_NgachCongChuc]);
			pNS_LuongInfo.BacLuong = int.Parse("0" + dr[pNS_LuongInfo.strBacLuong]);
            pNS_LuongInfo.HeSoLuong = double.Parse("0" + dr[pNS_LuongInfo.strHeSoLuong]);
            pNS_LuongInfo.PhanTramHuong = double.Parse("0" + dr[pNS_LuongInfo.strPhanTramHuong]);
            if (dr[pNS_LuongInfo.strTuNgay].ToString() != "")
                pNS_LuongInfo.TuNgay = DateTime.Parse(dr[pNS_LuongInfo.strTuNgay].ToString());
            if (dr[pNS_LuongInfo.strDenNgay].ToString() != "")
			    pNS_LuongInfo.DenNgay = DateTime.Parse(dr[pNS_LuongInfo.strDenNgay].ToString());
        }
    }
}
