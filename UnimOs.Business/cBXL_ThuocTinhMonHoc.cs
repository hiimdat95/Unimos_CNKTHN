using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBXL_ThuocTinhMonHoc : cBBase
    {
        private cDXL_ThuocTinhMonHoc oDXL_ThuocTinhMonHoc;
        private XL_ThuocTinhMonHocInfo oXL_ThuocTinhMonHocInfo;

        public cBXL_ThuocTinhMonHoc()        
        {
            oDXL_ThuocTinhMonHoc = new cDXL_ThuocTinhMonHoc();
        }

        public DataTable Get(XL_ThuocTinhMonHocInfo pXL_ThuocTinhMonHocInfo)        
        {
            return oDXL_ThuocTinhMonHoc.Get(pXL_ThuocTinhMonHocInfo);
        }

        public int Add(XL_ThuocTinhMonHocInfo pXL_ThuocTinhMonHocInfo)
        {
			int ID = 0;
            ID = oDXL_ThuocTinhMonHoc.Add(pXL_ThuocTinhMonHocInfo);
            mErrorMessage = oDXL_ThuocTinhMonHoc.ErrorMessages;
            mErrorNumber = oDXL_ThuocTinhMonHoc.ErrorNumber;
            return ID;
        }

        public void Update(XL_ThuocTinhMonHocInfo pXL_ThuocTinhMonHocInfo)
        {
            oDXL_ThuocTinhMonHoc.Update(pXL_ThuocTinhMonHocInfo);
            mErrorMessage = oDXL_ThuocTinhMonHoc.ErrorMessages;
            mErrorNumber = oDXL_ThuocTinhMonHoc.ErrorNumber;
        }
        
        public void Delete(XL_ThuocTinhMonHocInfo pXL_ThuocTinhMonHocInfo)
        {
            oDXL_ThuocTinhMonHoc.Delete(pXL_ThuocTinhMonHocInfo);
            mErrorMessage = oDXL_ThuocTinhMonHoc.ErrorMessages;
            mErrorNumber = oDXL_ThuocTinhMonHoc.ErrorNumber;
        }

        public List<XL_ThuocTinhMonHocInfo> GetList(XL_ThuocTinhMonHocInfo pXL_ThuocTinhMonHocInfo)
        {
            List<XL_ThuocTinhMonHocInfo> oXL_ThuocTinhMonHocInfoList = new List<XL_ThuocTinhMonHocInfo>();
            DataTable dtb = Get(pXL_ThuocTinhMonHocInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oXL_ThuocTinhMonHocInfo = new XL_ThuocTinhMonHocInfo();
                    

                    oXL_ThuocTinhMonHocInfo.XL_ThuocTinhMonHocID = int.Parse(dtb.Rows[i]["XL_ThuocTinhMonHocID"].ToString());
                    oXL_ThuocTinhMonHocInfo.IDDM_MonHoc = int.Parse(dtb.Rows[i]["IDDM_MonHoc"].ToString());
                    oXL_ThuocTinhMonHocInfo.XepCachNgay = bool.Parse(dtb.Rows[i]["XepCachNgay"].ToString());
                    oXL_ThuocTinhMonHocInfo.TietXepLichSang = dtb.Rows[i]["TietXepLichSang"].ToString();
                    oXL_ThuocTinhMonHocInfo.TietXepLichChieu = dtb.Rows[i]["TietXepLichChieu"].ToString();
                    oXL_ThuocTinhMonHocInfo.TietXepLichToi = dtb.Rows[i]["TietXepLichToi"].ToString();
                    oXL_ThuocTinhMonHocInfo.HocPhongChuyenMon = bool.Parse(dtb.Rows[i]["HocPhongChuyenMon"].ToString());
                    oXL_ThuocTinhMonHocInfo.HocCachTietTrongBuoi = bool.Parse(dtb.Rows[i]["HocCachTietTrongBuoi"].ToString());
                    oXL_ThuocTinhMonHocInfo.SoTietToiDaTrongNhomTiet = int.Parse(dtb.Rows[i]["SoTietToiDaTrongNhomTiet"].ToString());
                    
                    oXL_ThuocTinhMonHocInfoList.Add(oXL_ThuocTinhMonHocInfo);
                }
            }
            return oXL_ThuocTinhMonHocInfoList;
        }
    }
}
