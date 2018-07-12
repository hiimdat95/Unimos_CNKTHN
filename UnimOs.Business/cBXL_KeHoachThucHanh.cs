using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBXL_KeHoachThucHanh : cBBase
    {
        private cDXL_KeHoachThucHanh oDXL_KeHoachThucHanh;
        private XL_KeHoachThucHanhInfo oXL_KeHoachThucHanhInfo;

        public cBXL_KeHoachThucHanh()        
        {
            oDXL_KeHoachThucHanh = new cDXL_KeHoachThucHanh();
        }

        public DataTable Get(XL_KeHoachThucHanhInfo pXL_KeHoachThucHanhInfo)        
        {
            return oDXL_KeHoachThucHanh.Get(pXL_KeHoachThucHanhInfo);
        }

        public DataTable GetByNamHoc(int IDDM_NamHoc, int HocKy)
        {
            return oDXL_KeHoachThucHanh.GetByNamHoc(IDDM_NamHoc, HocKy);
        }

        public DataTable GetMonThucHanh(int IDXL_KeHoachThucHanh, int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            return oDXL_KeHoachThucHanh.GetMonThucHanh(IDXL_KeHoachThucHanh, IDDM_Lop, IDDM_NamHoc, HocKy);
        }

        public int Add(XL_KeHoachThucHanhInfo pXL_KeHoachThucHanhInfo)
        {
			int ID = 0;
            ID = oDXL_KeHoachThucHanh.Add(pXL_KeHoachThucHanhInfo);
            mErrorMessage = oDXL_KeHoachThucHanh.ErrorMessages;
            mErrorNumber = oDXL_KeHoachThucHanh.ErrorNumber;
            return ID;
        }

        public void Update(XL_KeHoachThucHanhInfo pXL_KeHoachThucHanhInfo)
        {
            oDXL_KeHoachThucHanh.Update(pXL_KeHoachThucHanhInfo);
            mErrorMessage = oDXL_KeHoachThucHanh.ErrorMessages;
            mErrorNumber = oDXL_KeHoachThucHanh.ErrorNumber;
        }
        
        public void Delete(XL_KeHoachThucHanhInfo pXL_KeHoachThucHanhInfo)
        {
            oDXL_KeHoachThucHanh.Delete(pXL_KeHoachThucHanhInfo);
            mErrorMessage = oDXL_KeHoachThucHanh.ErrorMessages;
            mErrorNumber = oDXL_KeHoachThucHanh.ErrorNumber;
        }

        public List<XL_KeHoachThucHanhInfo> GetList(XL_KeHoachThucHanhInfo pXL_KeHoachThucHanhInfo)
        {
            List<XL_KeHoachThucHanhInfo> oXL_KeHoachThucHanhInfoList = new List<XL_KeHoachThucHanhInfo>();
            DataTable dtb = Get(pXL_KeHoachThucHanhInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oXL_KeHoachThucHanhInfo = new XL_KeHoachThucHanhInfo();

                    oXL_KeHoachThucHanhInfo.XL_KeHoachThucHanhID = int.Parse(dtb.Rows[i]["XL_KeHoachThucHanhID"].ToString());
                    oXL_KeHoachThucHanhInfo.IDDM_Lop = int.Parse(dtb.Rows[i]["IDDM_Lop"].ToString());
                    oXL_KeHoachThucHanhInfo.IDXL_MonHocTrongKy = int.Parse(dtb.Rows[i]["IDXL_MonHocTrongKy"].ToString());
                    oXL_KeHoachThucHanhInfo.IDDM_MonHoc = int.Parse(dtb.Rows[i]["IDDM_MonHoc"].ToString());
                    oXL_KeHoachThucHanhInfo.IDDM_PhongHoc = int.Parse(dtb.Rows[i]["IDDM_PhongHoc"].ToString());
                    oXL_KeHoachThucHanhInfo.IDNS_GiaoVien = int.Parse(dtb.Rows[i]["IDNS_GiaoVien"].ToString());
                    oXL_KeHoachThucHanhInfo.SoBuoi = int.Parse(dtb.Rows[i]["SoBuoi"].ToString());
                    oXL_KeHoachThucHanhInfo.SoTiet = int.Parse(dtb.Rows[i]["SoTiet"].ToString());
                    oXL_KeHoachThucHanhInfo.SoTo = int.Parse(dtb.Rows[i]["SoTo"].ToString());
                    oXL_KeHoachThucHanhInfo.IDXL_KeHoachThucHanhKyHieu = int.Parse("0" + dtb.Rows[i]["IDXL_KeHoachThucHanhKyHieu"]);
                    
                    oXL_KeHoachThucHanhInfoList.Add(oXL_KeHoachThucHanhInfo);
                }
            }
            return oXL_KeHoachThucHanhInfoList;
        }
        
        public void ToDataRow(XL_KeHoachThucHanhInfo pXL_KeHoachThucHanhInfo, ref DataRow dr, EDIT_MODE edit)
        {
			dr[pXL_KeHoachThucHanhInfo.strXL_KeHoachThucHanhID] = pXL_KeHoachThucHanhInfo.XL_KeHoachThucHanhID;
            if (edit == EDIT_MODE.THEM)
            {
                dr[pXL_KeHoachThucHanhInfo.strIDDM_Lop] = pXL_KeHoachThucHanhInfo.IDDM_Lop;
                dr[pXL_KeHoachThucHanhInfo.strIDXL_MonHocTrongKy] = pXL_KeHoachThucHanhInfo.IDXL_MonHocTrongKy;
                dr[pXL_KeHoachThucHanhInfo.strIDDM_MonHoc] = pXL_KeHoachThucHanhInfo.IDDM_MonHoc;
            }
			dr[pXL_KeHoachThucHanhInfo.strIDDM_PhongHoc] = pXL_KeHoachThucHanhInfo.IDDM_PhongHoc;
			dr[pXL_KeHoachThucHanhInfo.strIDNS_GiaoVien] = pXL_KeHoachThucHanhInfo.IDNS_GiaoVien;
            dr[pXL_KeHoachThucHanhInfo.strSoBuoi] = pXL_KeHoachThucHanhInfo.SoBuoi;
			dr[pXL_KeHoachThucHanhInfo.strSoTiet] = pXL_KeHoachThucHanhInfo.SoTiet;
			dr[pXL_KeHoachThucHanhInfo.strSoTo] = pXL_KeHoachThucHanhInfo.SoTo;
            dr[pXL_KeHoachThucHanhInfo.strIDXL_KeHoachThucHanhKyHieu] = pXL_KeHoachThucHanhInfo.IDXL_KeHoachThucHanhKyHieu;
        }
        
        public void ToInfo(ref XL_KeHoachThucHanhInfo pXL_KeHoachThucHanhInfo, DataRow dr)
        {

			pXL_KeHoachThucHanhInfo.XL_KeHoachThucHanhID = int.Parse(dr[pXL_KeHoachThucHanhInfo.strXL_KeHoachThucHanhID].ToString());
			pXL_KeHoachThucHanhInfo.IDDM_Lop = int.Parse(dr[pXL_KeHoachThucHanhInfo.strIDDM_Lop].ToString());
			pXL_KeHoachThucHanhInfo.IDXL_MonHocTrongKy = int.Parse(dr[pXL_KeHoachThucHanhInfo.strIDXL_MonHocTrongKy].ToString());
			pXL_KeHoachThucHanhInfo.IDDM_MonHoc = int.Parse(dr[pXL_KeHoachThucHanhInfo.strIDDM_MonHoc].ToString());
			pXL_KeHoachThucHanhInfo.IDDM_PhongHoc = int.Parse(dr[pXL_KeHoachThucHanhInfo.strIDDM_PhongHoc].ToString());
			pXL_KeHoachThucHanhInfo.IDNS_GiaoVien = int.Parse(dr[pXL_KeHoachThucHanhInfo.strIDNS_GiaoVien].ToString());
            pXL_KeHoachThucHanhInfo.SoBuoi = int.Parse(dr[pXL_KeHoachThucHanhInfo.strSoBuoi].ToString());
			pXL_KeHoachThucHanhInfo.SoTiet = int.Parse(dr[pXL_KeHoachThucHanhInfo.strSoTiet].ToString());
			pXL_KeHoachThucHanhInfo.SoTo = int.Parse(dr[pXL_KeHoachThucHanhInfo.strSoTo].ToString());
            pXL_KeHoachThucHanhInfo.IDXL_KeHoachThucHanhKyHieu = int.Parse("0" + dr[pXL_KeHoachThucHanhInfo.strIDXL_KeHoachThucHanhKyHieu]);
        }
    }
}
