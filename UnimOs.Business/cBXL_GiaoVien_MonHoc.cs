using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBXL_GiaoVien_MonHoc : cBBase
    {
        private cDXL_GiaoVien_MonHoc oDXL_GiaoVien_MonHoc;
        private XL_GiaoVien_MonHocInfo oXL_GiaoVien_MonHocInfo;

        public cBXL_GiaoVien_MonHoc()        
        {
            oDXL_GiaoVien_MonHoc = new cDXL_GiaoVien_MonHoc();
        }

        public DataTable Get(XL_GiaoVien_MonHocInfo pXL_GiaoVien_MonHocInfo)        
        {
            return oDXL_GiaoVien_MonHoc.Get(pXL_GiaoVien_MonHocInfo);
        }

        public DataTable GetDanhSach(XL_GiaoVien_MonHocInfo pXL_GiaoVien_MonHocInfo)
        {
            return oDXL_GiaoVien_MonHoc.GetDanhSach(pXL_GiaoVien_MonHocInfo);
        }

        public DataTable GetByIDDM_MonHoc(int IDDM_MonHoc, string IDNS_GiaoVien)
        {
            return oDXL_GiaoVien_MonHoc.GetByIDDM_MonHoc(IDDM_MonHoc, IDNS_GiaoVien);
        }

        public DataTable GetByIDDM_MonHocs(string IDDM_MonHocs)
        {
            return oDXL_GiaoVien_MonHoc.GetByIDDM_MonHocs(IDDM_MonHocs);
        }

        public DataTable GetByMonLop(int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            return oDXL_GiaoVien_MonHoc.GetByMonLop(IDDM_Lop, IDDM_NamHoc, HocKy);
        }

        public int Add(XL_GiaoVien_MonHocInfo pXL_GiaoVien_MonHocInfo)
        {
			int ID = 0;
            ID = oDXL_GiaoVien_MonHoc.Add(pXL_GiaoVien_MonHocInfo);
            mErrorMessage = oDXL_GiaoVien_MonHoc.ErrorMessages;
            mErrorNumber = oDXL_GiaoVien_MonHoc.ErrorNumber;
            return ID;
        }

        public void Update(XL_GiaoVien_MonHocInfo pXL_GiaoVien_MonHocInfo)
        {
            oDXL_GiaoVien_MonHoc.Update(pXL_GiaoVien_MonHocInfo);
            mErrorMessage = oDXL_GiaoVien_MonHoc.ErrorMessages;
            mErrorNumber = oDXL_GiaoVien_MonHoc.ErrorNumber;
        }
        
        public void Delete(XL_GiaoVien_MonHocInfo pXL_GiaoVien_MonHocInfo)
        {
            oDXL_GiaoVien_MonHoc.Delete(pXL_GiaoVien_MonHocInfo);
            mErrorMessage = oDXL_GiaoVien_MonHoc.ErrorMessages;
            mErrorNumber = oDXL_GiaoVien_MonHoc.ErrorNumber;
        }

        public List<XL_GiaoVien_MonHocInfo> GetList(XL_GiaoVien_MonHocInfo pXL_GiaoVien_MonHocInfo)
        {
            List<XL_GiaoVien_MonHocInfo> oXL_GiaoVien_MonHocInfoList = new List<XL_GiaoVien_MonHocInfo>();
            DataTable dtb = Get(pXL_GiaoVien_MonHocInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oXL_GiaoVien_MonHocInfo = new XL_GiaoVien_MonHocInfo();

                    oXL_GiaoVien_MonHocInfo.XL_GiaoVien_MonHocID = int.Parse(dtb.Rows[i]["XL_GiaoVien_MonHocID"].ToString());
                    oXL_GiaoVien_MonHocInfo.IDNS_GiaoVien = int.Parse(dtb.Rows[i]["IDNS_GiaoVien"].ToString());
                    oXL_GiaoVien_MonHocInfo.IDDM_MonHoc = int.Parse(dtb.Rows[i]["IDDM_MonHoc"].ToString());
                    
                    oXL_GiaoVien_MonHocInfoList.Add(oXL_GiaoVien_MonHocInfo);
                }
            }
            return oXL_GiaoVien_MonHocInfoList;
        }
        
        public void ToDataRow(XL_GiaoVien_MonHocInfo pXL_GiaoVien_MonHocInfo, ref DataRow dr)
        {

			dr[pXL_GiaoVien_MonHocInfo.strXL_GiaoVien_MonHocID] = pXL_GiaoVien_MonHocInfo.XL_GiaoVien_MonHocID;
			dr[pXL_GiaoVien_MonHocInfo.strIDNS_GiaoVien] = pXL_GiaoVien_MonHocInfo.IDNS_GiaoVien;
			dr[pXL_GiaoVien_MonHocInfo.strIDDM_MonHoc] = pXL_GiaoVien_MonHocInfo.IDDM_MonHoc;
        }
        
        public void ToInfo(ref XL_GiaoVien_MonHocInfo pXL_GiaoVien_MonHocInfo, DataRow dr)
        {

			pXL_GiaoVien_MonHocInfo.XL_GiaoVien_MonHocID = int.Parse(dr[pXL_GiaoVien_MonHocInfo.strXL_GiaoVien_MonHocID].ToString());
            pXL_GiaoVien_MonHocInfo.IDNS_GiaoVien = int.Parse(dr[pXL_GiaoVien_MonHocInfo.strIDNS_GiaoVien].ToString());
            pXL_GiaoVien_MonHocInfo.IDDM_MonHoc = int.Parse(dr[pXL_GiaoVien_MonHocInfo.strIDDM_MonHoc].ToString());
        }
    }
}
