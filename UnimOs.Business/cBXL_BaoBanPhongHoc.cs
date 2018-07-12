using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBXL_BaoBanPhongHoc : cBBase
    {
        private cDXL_BaoBanPhongHoc oDXL_BaoBanPhongHoc;
        private XL_BaoBanPhongHocInfo oXL_BaoBanPhongHocInfo;

        public cBXL_BaoBanPhongHoc()        
        {
            oDXL_BaoBanPhongHoc = new cDXL_BaoBanPhongHoc();
        }

        public DataTable Get(XL_BaoBanPhongHocInfo pXL_BaoBanPhongHocInfo)        
        {
            return oDXL_BaoBanPhongHoc.Get(pXL_BaoBanPhongHocInfo);
        }

        public int Add(XL_BaoBanPhongHocInfo pXL_BaoBanPhongHocInfo)
        {
			int ID = 0;
            ID = oDXL_BaoBanPhongHoc.Add(pXL_BaoBanPhongHocInfo);
            mErrorMessage = oDXL_BaoBanPhongHoc.ErrorMessages;
            mErrorNumber = oDXL_BaoBanPhongHoc.ErrorNumber;
            return ID;
        }

        public void Update(XL_BaoBanPhongHocInfo pXL_BaoBanPhongHocInfo)
        {
            oDXL_BaoBanPhongHoc.Update(pXL_BaoBanPhongHocInfo);
            mErrorMessage = oDXL_BaoBanPhongHoc.ErrorMessages;
            mErrorNumber = oDXL_BaoBanPhongHoc.ErrorNumber;
        }
        
        public void Delete(XL_BaoBanPhongHocInfo pXL_BaoBanPhongHocInfo)
        {
            oDXL_BaoBanPhongHoc.Delete(pXL_BaoBanPhongHocInfo);
            mErrorMessage = oDXL_BaoBanPhongHoc.ErrorMessages;
            mErrorNumber = oDXL_BaoBanPhongHoc.ErrorNumber;
        }

        public List<XL_BaoBanPhongHocInfo> GetList(XL_BaoBanPhongHocInfo pXL_BaoBanPhongHocInfo)
        {
            List<XL_BaoBanPhongHocInfo> oXL_BaoBanPhongHocInfoList = new List<XL_BaoBanPhongHocInfo>();
            DataTable dtb = Get(pXL_BaoBanPhongHocInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oXL_BaoBanPhongHocInfo = new XL_BaoBanPhongHocInfo();
                    

                    oXL_BaoBanPhongHocInfo.XL_BaoBanPhongHocID = int.Parse(dtb.Rows[i]["XL_BaoBanPhongHocID"].ToString());
                    oXL_BaoBanPhongHocInfo.IDTuan = long.Parse(dtb.Rows[i]["IDTuan"].ToString());
                    oXL_BaoBanPhongHocInfo.IDXL_PhongHoc = int.Parse(dtb.Rows[i]["IDXL_PhongHoc"].ToString());
                    oXL_BaoBanPhongHocInfo.Thu = int.Parse(dtb.Rows[i]["Thu"].ToString());
                    oXL_BaoBanPhongHocInfo.Tiet = int.Parse(dtb.Rows[i]["Tiet"].ToString());
                    oXL_BaoBanPhongHocInfo.SoTiet = int.Parse(dtb.Rows[i]["SoTiet"].ToString());
                    oXL_BaoBanPhongHocInfo.MoTa = dtb.Rows[i]["MoTa"].ToString();
                    
                    oXL_BaoBanPhongHocInfoList.Add(oXL_BaoBanPhongHocInfo);
                }
            }
            return oXL_BaoBanPhongHocInfoList;
        }
    }
}
