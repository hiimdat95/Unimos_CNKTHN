using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBXL_SuKienTKB : cBBase
    {
        private cDXL_SuKienTKB oDXL_SuKienTKB;
        private XL_SuKienTKBInfo oXL_SuKienTKBInfo;

        public cBXL_SuKienTKB()        
        {
            oDXL_SuKienTKB = new cDXL_SuKienTKB();
        }

        public bool CheckExist(long IDTuan)
        {
            return oDXL_SuKienTKB.CheckExist(IDTuan);
        }

        public DataTable Get(XL_SuKienTKBInfo pXL_SuKienTKBInfo)        
        {
            return oDXL_SuKienTKB.Get(pXL_SuKienTKBInfo);
        }

        public DataTable Get_TKB(long IDXL_Tuan)
        {
            return oDXL_SuKienTKB.Get_TKB(IDXL_Tuan);
        }

        public DataSet Get_TKBByIDDM_Lop(int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            return oDXL_SuKienTKB.Get_TKBByIDDM_Lop(IDDM_Lop, IDDM_NamHoc, HocKy);
        }

        public int Add(XL_SuKienTKBInfo pXL_SuKienTKBInfo)
        {
			int ID = 0;
            ID = oDXL_SuKienTKB.Add(pXL_SuKienTKBInfo);
            mErrorMessage = oDXL_SuKienTKB.ErrorMessages;
            mErrorNumber = oDXL_SuKienTKB.ErrorNumber;
            return ID;
        }

        public void Update(XL_SuKienTKBInfo pXL_SuKienTKBInfo)
        {
            oDXL_SuKienTKB.Update(pXL_SuKienTKBInfo);
            mErrorMessage = oDXL_SuKienTKB.ErrorMessages;
            mErrorNumber = oDXL_SuKienTKB.ErrorNumber;
        }
        
        public void Delete(XL_SuKienTKBInfo pXL_SuKienTKBInfo)
        {
            oDXL_SuKienTKB.Delete(pXL_SuKienTKBInfo);
            mErrorMessage = oDXL_SuKienTKB.ErrorMessages;
            mErrorNumber = oDXL_SuKienTKB.ErrorNumber;
        }

        public List<XL_SuKienTKBInfo> GetList(XL_SuKienTKBInfo pXL_SuKienTKBInfo)
        {
            List<XL_SuKienTKBInfo> oXL_SuKienTKBInfoList = new List<XL_SuKienTKBInfo>();
            DataTable dtb = Get(pXL_SuKienTKBInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oXL_SuKienTKBInfo = new XL_SuKienTKBInfo();
                    

                    oXL_SuKienTKBInfo.XL_SuKienTKBID = long.Parse(dtb.Rows[i]["XL_SuKienTKBID"].ToString());
                    oXL_SuKienTKBInfo.IDXL_Tuan = long.Parse(dtb.Rows[i]["IDXL_Tuan"].ToString());
                    oXL_SuKienTKBInfo.IDDM_Lop = int.Parse(dtb.Rows[i]["IDDM_Lop"].ToString());
                    oXL_SuKienTKBInfo.IDXL_MonHocTrongKy = long.Parse(dtb.Rows[i]["IDXL_MonHocTrongKy"].ToString());
                    oXL_SuKienTKBInfo.IDDM_MonHoc = int.Parse(dtb.Rows[i]["IDDM_MonHoc"].ToString());
                    oXL_SuKienTKBInfo.IDDM_PhongHoc = int.Parse(dtb.Rows[i]["IDDM_PhongHoc"].ToString());
                    oXL_SuKienTKBInfo.IDNS_GiaoVien = int.Parse(dtb.Rows[i]["IDNS_GiaoVien"].ToString());
                    oXL_SuKienTKBInfo.CaHoc = (CA_HOC)dtb.Rows[i]["CaHoc"];
                    oXL_SuKienTKBInfo.Thu = int.Parse(dtb.Rows[i]["Thu"].ToString());
                    oXL_SuKienTKBInfo.TietDau = int.Parse(dtb.Rows[i]["TietDau"].ToString());
                    oXL_SuKienTKBInfo.SoTiet = int.Parse(dtb.Rows[i]["SoTiet"].ToString());
                    oXL_SuKienTKBInfo.LoaiTiet = (LOAI_TIET)dtb.Rows[i]["LoaiTiet"];
                    oXL_SuKienTKBInfo.DaXepLich = bool.Parse(dtb.Rows[i]["DaXepLich"].ToString());
                    oXL_SuKienTKBInfo.Locked = bool.Parse(dtb.Rows[i]["Locked"].ToString());
                    
                    oXL_SuKienTKBInfoList.Add(oXL_SuKienTKBInfo);
                }
            }
            return oXL_SuKienTKBInfoList;
        }
    }
}
