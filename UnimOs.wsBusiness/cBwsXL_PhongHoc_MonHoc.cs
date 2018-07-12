using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.wsBusiness;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Entity.Model;
using TruongViet.UnimOs.Data;
using UnimOs.wsBusiness.wsUnimOs;

namespace TruongViet.UnimOs.wsBusiness
{
    public class cBwsXL_PhongHoc_MonHoc : cBwsBase
    {
        private cDXL_PhongHoc_MonHoc oDXL_PhongHoc_MonHoc;
        private XL_PhongHoc_MonHocInfo oXL_PhongHoc_MonHocInfo;

        public cBwsXL_PhongHoc_MonHoc()
        {
            oDXL_PhongHoc_MonHoc = new cDXL_PhongHoc_MonHoc();
        }

        public DataTable Get(XL_PhongHoc_MonHocInfo pXL_PhongHoc_MonHocInfo)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_XL_PhongHoc_MonHoc_GetResult>(client.cDXL_PhongHoc_MonHoc_Get(GlobalVar.MaXacThuc, pXL_PhongHoc_MonHocInfo));
            }
        }

        public DataTable GetByIDDM_MonHoc(int IDDM_MonHoc)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_XL_PhongHoc_MonHoc_GetByIDMonHocResult>(client.cDXL_PhongHoc_MonHoc_GetByIDDM_MonHoc(GlobalVar.MaXacThuc, IDDM_MonHoc));
            }
        }

        public int Add(XL_PhongHoc_MonHocInfo pXL_PhongHoc_MonHocInfo)
        {
            int ID = 0;
            var client = new UnimOsServiceClient();
            ID = client.cDXL_PhongHoc_MonHoc_Add(GlobalVar.MaXacThuc, pXL_PhongHoc_MonHocInfo);
            client.Close();
            mErrorMessage = oDXL_PhongHoc_MonHoc.ErrorMessages;
            mErrorNumber = oDXL_PhongHoc_MonHoc.ErrorNumber;
            return ID;
        }

        public void Update(XL_PhongHoc_MonHocInfo pXL_PhongHoc_MonHocInfo)
        {
            var client = new UnimOsServiceClient();
            client.cDXL_PhongHoc_MonHoc_Update(GlobalVar.MaXacThuc, pXL_PhongHoc_MonHocInfo);
            client.Close();
            mErrorMessage = oDXL_PhongHoc_MonHoc.ErrorMessages;
            mErrorNumber = oDXL_PhongHoc_MonHoc.ErrorNumber;
        }

        public void Delete(XL_PhongHoc_MonHocInfo pXL_PhongHoc_MonHocInfo)
        {
            var client = new UnimOsServiceClient();
            client.cDXL_PhongHoc_MonHoc_Delete(GlobalVar.MaXacThuc, pXL_PhongHoc_MonHocInfo);
            client.Close();
            mErrorMessage = oDXL_PhongHoc_MonHoc.ErrorMessages;
            mErrorNumber = oDXL_PhongHoc_MonHoc.ErrorNumber;
        }

        public void DeleteByMonPhong(int IDDM_PhongHoc, int IDDM_MonHoc)
        {
            var client = new UnimOsServiceClient();
            client.cDXL_PhongHoc_MonHoc_DeleteByMonPhong(GlobalVar.MaXacThuc, IDDM_PhongHoc, IDDM_MonHoc);
            client.Close();
            mErrorMessage = oDXL_PhongHoc_MonHoc.ErrorMessages;
            mErrorNumber = oDXL_PhongHoc_MonHoc.ErrorNumber;
        }

        public List<XL_PhongHoc_MonHocInfo> GetList(XL_PhongHoc_MonHocInfo pXL_PhongHoc_MonHocInfo)
        {
            List<XL_PhongHoc_MonHocInfo> oXL_PhongHoc_MonHocInfoList = new List<XL_PhongHoc_MonHocInfo>();
            DataTable dtb = Get(pXL_PhongHoc_MonHocInfo);
            if (dtb != null)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    oXL_PhongHoc_MonHocInfo = new XL_PhongHoc_MonHocInfo();

                    oXL_PhongHoc_MonHocInfo.XL_PhongHoc_MonHocID = int.Parse(dtb.Rows[i]["XL_PhongHoc_MonHocID"].ToString());
                    oXL_PhongHoc_MonHocInfo.IDDM_MonHoc = int.Parse(dtb.Rows[i]["IDDM_MonHoc"].ToString());
                    oXL_PhongHoc_MonHocInfo.IDDM_PhongHoc = int.Parse(dtb.Rows[i]["IDDM_PhongHoc"].ToString());

                    oXL_PhongHoc_MonHocInfoList.Add(oXL_PhongHoc_MonHocInfo);
                }
            }
            return oXL_PhongHoc_MonHocInfoList;
        }

        public void ToDataRow(XL_PhongHoc_MonHocInfo pXL_PhongHoc_MonHocInfo, ref DataRow dr)
        {

            dr[pXL_PhongHoc_MonHocInfo.strXL_PhongHoc_MonHocID] = pXL_PhongHoc_MonHocInfo.XL_PhongHoc_MonHocID;
            dr[pXL_PhongHoc_MonHocInfo.strIDDM_MonHoc] = pXL_PhongHoc_MonHocInfo.IDDM_MonHoc;
            dr[pXL_PhongHoc_MonHocInfo.strIDDM_PhongHoc] = pXL_PhongHoc_MonHocInfo.IDDM_PhongHoc;
        }
    }
}
