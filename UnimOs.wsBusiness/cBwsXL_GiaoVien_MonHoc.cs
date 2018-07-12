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
    public class cBwsXL_GiaoVien_MonHoc : cBwsBase
    {
        private cDXL_GiaoVien_MonHoc oDXL_GiaoVien_MonHoc;
        private XL_GiaoVien_MonHocInfo oXL_GiaoVien_MonHocInfo;

        public cBwsXL_GiaoVien_MonHoc()
        {
            oDXL_GiaoVien_MonHoc = new cDXL_GiaoVien_MonHoc();
        }

        public DataTable Get(XL_GiaoVien_MonHocInfo pXL_GiaoVien_MonHocInfo)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_XL_GiaoVien_MonHoc_GetResult>(client.cDXL_GiaoVien_MonHoc_Get(GlobalVar.MaXacThuc, pXL_GiaoVien_MonHocInfo));
            }
        }

        public DataTable GetDanhSach(XL_GiaoVien_MonHocInfo pXL_GiaoVien_MonHocInfo)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_XL_GiaoVien_MonHoc_GetDanhSachResult>(client.cDXL_GiaoVien_MonHoc_GetDanhSach(GlobalVar.MaXacThuc, pXL_GiaoVien_MonHocInfo));
            }
        }

        public DataTable GetByIDDM_MonHoc(int IDDM_MonHoc, string IDNS_GiaoVien)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_XL_GiaoVien_MonHoc_GetByIDDM_MonHocResult>(client.cDXL_GiaoVien_MonHoc_GetByIDDM_MonHoc(GlobalVar.MaXacThuc, IDDM_MonHoc, IDNS_GiaoVien));
            }
        }

        public DataTable GetByIDDM_MonHocs(string IDDM_MonHocs)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<XL_GiaoVien_MonHocInfo>(client.cDXL_GiaoVien_MonHoc_GetByIDDM_MonHocs(GlobalVar.MaXacThuc, IDDM_MonHocs));
            }
        }

        public DataTable GetByMonLop(int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_XL_GiaoVien_MonHoc_GetByMonLopResult>(client.cDXL_GiaoVien_MonHoc_GetByMonLop(GlobalVar.MaXacThuc, IDDM_Lop, IDDM_NamHoc, HocKy));
            }
        }

        //public int Add(XL_GiaoVien_MonHocInfo pXL_GiaoVien_MonHocInfo)
        //{
        //    int ID = 0;
        //    var client = new UnimOsServiceClient();
        //    ID = client.cDXL_GiaoVien_MonHoc_Add(GlobalVar.MaXacThuc, pXL_GiaoVien_MonHocInfo);
        //    client.Close();
        //    mErrorMessage = oDXL_GiaoVien_MonHoc.ErrorMessages;
        //    mErrorNumber = oDXL_GiaoVien_MonHoc.ErrorNumber;
        //    return ID;
        //}

        //public void Update(XL_GiaoVien_MonHocInfo pXL_GiaoVien_MonHocInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDXL_GiaoVien_MonHoc_Update(GlobalVar.MaXacThuc, pXL_GiaoVien_MonHocInfo);
        //    client.Close();
        //    mErrorMessage = oDXL_GiaoVien_MonHoc.ErrorMessages;
        //    mErrorNumber = oDXL_GiaoVien_MonHoc.ErrorNumber;
        //}

        //public void Delete(XL_GiaoVien_MonHocInfo pXL_GiaoVien_MonHocInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDXL_GiaoVien_MonHoc_Delete(GlobalVar.MaXacThuc, pXL_GiaoVien_MonHocInfo);
        //    client.Close();
        //    mErrorMessage = oDXL_GiaoVien_MonHoc.ErrorMessages;
        //    mErrorNumber = oDXL_GiaoVien_MonHoc.ErrorNumber;
        //}

        //public List<XL_GiaoVien_MonHocInfo> GetList(XL_GiaoVien_MonHocInfo pXL_GiaoVien_MonHocInfo)
        //{
        //    List<XL_GiaoVien_MonHocInfo> oXL_GiaoVien_MonHocInfoList = new List<XL_GiaoVien_MonHocInfo>();
        //    DataTable dtb = Get(pXL_GiaoVien_MonHocInfo);
        //    if (dtb != null)
        //    {
        //        for (int i = 0; i < dtb.Rows.Count; i++)
        //        {
        //            oXL_GiaoVien_MonHocInfo = new XL_GiaoVien_MonHocInfo();

        //            oXL_GiaoVien_MonHocInfo.XL_GiaoVien_MonHocID = int.Parse(dtb.Rows[i]["XL_GiaoVien_MonHocID"].ToString());
        //            oXL_GiaoVien_MonHocInfo.IDNS_GiaoVien = int.Parse(dtb.Rows[i]["IDNS_GiaoVien"].ToString());
        //            oXL_GiaoVien_MonHocInfo.IDDM_MonHoc = int.Parse(dtb.Rows[i]["IDDM_MonHoc"].ToString());

        //            oXL_GiaoVien_MonHocInfoList.Add(oXL_GiaoVien_MonHocInfo);
        //        }
        //    }
        //    return oXL_GiaoVien_MonHocInfoList;
        //}

        //public void ToDataRow(XL_GiaoVien_MonHocInfo pXL_GiaoVien_MonHocInfo, ref DataRow dr)
        //{

        //    dr[pXL_GiaoVien_MonHocInfo.strXL_GiaoVien_MonHocID] = pXL_GiaoVien_MonHocInfo.XL_GiaoVien_MonHocID;
        //    dr[pXL_GiaoVien_MonHocInfo.strIDNS_GiaoVien] = pXL_GiaoVien_MonHocInfo.IDNS_GiaoVien;
        //    dr[pXL_GiaoVien_MonHocInfo.strIDDM_MonHoc] = pXL_GiaoVien_MonHocInfo.IDDM_MonHoc;
        //}

        public void ToInfo(ref XL_GiaoVien_MonHocInfo pXL_GiaoVien_MonHocInfo, DataRow dr)
        {

            pXL_GiaoVien_MonHocInfo.XL_GiaoVien_MonHocID = int.Parse(dr[pXL_GiaoVien_MonHocInfo.strXL_GiaoVien_MonHocID].ToString());
            pXL_GiaoVien_MonHocInfo.IDNS_GiaoVien = int.Parse(dr[pXL_GiaoVien_MonHocInfo.strIDNS_GiaoVien].ToString());
            pXL_GiaoVien_MonHocInfo.IDDM_MonHoc = int.Parse(dr[pXL_GiaoVien_MonHocInfo.strIDDM_MonHoc].ToString());
        }
    }
}
