using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBSV_QuyetDinhKyLuat : cBBase
    {
        private cDSV_QuyetDinhKyLuat oDSV_QuyetDinhKyLuat;
        private SV_QuyetDinhKyLuatInfo oSV_QuyetDinhKyLuatInfo;

        public cBSV_QuyetDinhKyLuat()        
        {
            oDSV_QuyetDinhKyLuat = new cDSV_QuyetDinhKyLuat();
        }

        public DataTable Get(SV_QuyetDinhKyLuatInfo pSV_QuyetDinhKyLuatInfo)        
        {
            return oDSV_QuyetDinhKyLuat.Get(pSV_QuyetDinhKyLuatInfo);
        }

        public DataTable GetByHocKyNamHoc(int IDDM_NamHoc, int HocKy)
        {
            return oDSV_QuyetDinhKyLuat.GetByHocKyNamHoc(IDDM_NamHoc, HocKy);
        }

        public int Add(SV_QuyetDinhKyLuatInfo pSV_QuyetDinhKyLuatInfo)
        {
			int ID = 0;
            ID = oDSV_QuyetDinhKyLuat.Add(pSV_QuyetDinhKyLuatInfo);
            mErrorMessage = oDSV_QuyetDinhKyLuat.ErrorMessages;
            mErrorNumber = oDSV_QuyetDinhKyLuat.ErrorNumber;
            return ID;
        }

        public void Update(SV_QuyetDinhKyLuatInfo pSV_QuyetDinhKyLuatInfo)
        {
            oDSV_QuyetDinhKyLuat.Update(pSV_QuyetDinhKyLuatInfo);
            mErrorMessage = oDSV_QuyetDinhKyLuat.ErrorMessages;
            mErrorNumber = oDSV_QuyetDinhKyLuat.ErrorNumber;
        }
        
        public void Delete(SV_QuyetDinhKyLuatInfo pSV_QuyetDinhKyLuatInfo)
        {
            oDSV_QuyetDinhKyLuat.Delete(pSV_QuyetDinhKyLuatInfo);
            mErrorMessage = oDSV_QuyetDinhKyLuat.ErrorMessages;
            mErrorNumber = oDSV_QuyetDinhKyLuat.ErrorNumber;
        }

        public List<SV_QuyetDinhKyLuatInfo> GetList(SV_QuyetDinhKyLuatInfo pSV_QuyetDinhKyLuatInfo)
        {
            List<SV_QuyetDinhKyLuatInfo> oSV_QuyetDinhKyLuatInfoList = new List<SV_QuyetDinhKyLuatInfo>();
            DataTable dtb = Get(pSV_QuyetDinhKyLuatInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oSV_QuyetDinhKyLuatInfo = new SV_QuyetDinhKyLuatInfo();

                    oSV_QuyetDinhKyLuatInfo.SV_QuyetDinhKyLuatID = int.Parse(dtb.Rows[i]["SV_QuyetDinhKyLuatID"].ToString());
                    oSV_QuyetDinhKyLuatInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
                    oSV_QuyetDinhKyLuatInfo.HocKy = int.Parse(dtb.Rows[i]["HocKy"].ToString());
                    oSV_QuyetDinhKyLuatInfo.SoQuyetDinh = dtb.Rows[i]["SoQuyetDinh"].ToString();
                    oSV_QuyetDinhKyLuatInfo.NgayQuyetDinh = DateTime.Parse(dtb.Rows[i]["NgayQuyetDinh"].ToString());
                    oSV_QuyetDinhKyLuatInfo.IDDM_CapKhenThuong = int.Parse(dtb.Rows[i]["IDDM_CapKhenThuong"].ToString());
                    oSV_QuyetDinhKyLuatInfo.IDDM_HanhVi = int.Parse(dtb.Rows[i]["IDDM_HanhVi"].ToString());
                    oSV_QuyetDinhKyLuatInfo.NoiDung = dtb.Rows[i]["NoiDung"].ToString();
                    
                    oSV_QuyetDinhKyLuatInfoList.Add(oSV_QuyetDinhKyLuatInfo);
                }
            }
            return oSV_QuyetDinhKyLuatInfoList;
        }
        
        public void ToDataRow(SV_QuyetDinhKyLuatInfo pSV_QuyetDinhKyLuatInfo, ref DataRow dr)
        {

			dr[pSV_QuyetDinhKyLuatInfo.strSV_QuyetDinhKyLuatID] = pSV_QuyetDinhKyLuatInfo.SV_QuyetDinhKyLuatID;
			dr[pSV_QuyetDinhKyLuatInfo.strIDDM_NamHoc] = pSV_QuyetDinhKyLuatInfo.IDDM_NamHoc;
			dr[pSV_QuyetDinhKyLuatInfo.strHocKy] = pSV_QuyetDinhKyLuatInfo.HocKy;
			dr[pSV_QuyetDinhKyLuatInfo.strSoQuyetDinh] = pSV_QuyetDinhKyLuatInfo.SoQuyetDinh;
			dr[pSV_QuyetDinhKyLuatInfo.strNgayQuyetDinh] = pSV_QuyetDinhKyLuatInfo.NgayQuyetDinh;
			dr[pSV_QuyetDinhKyLuatInfo.strIDDM_CapKhenThuong] = pSV_QuyetDinhKyLuatInfo.IDDM_CapKhenThuong;
			dr[pSV_QuyetDinhKyLuatInfo.strIDDM_HanhVi] = pSV_QuyetDinhKyLuatInfo.IDDM_HanhVi;
			dr[pSV_QuyetDinhKyLuatInfo.strNoiDung] = pSV_QuyetDinhKyLuatInfo.NoiDung;
        }
        
        public void ToInfo(ref SV_QuyetDinhKyLuatInfo pSV_QuyetDinhKyLuatInfo, DataRow dr)
        {

			pSV_QuyetDinhKyLuatInfo.SV_QuyetDinhKyLuatID = int.Parse(dr[pSV_QuyetDinhKyLuatInfo.strSV_QuyetDinhKyLuatID].ToString());
			pSV_QuyetDinhKyLuatInfo.IDDM_NamHoc = int.Parse(dr[pSV_QuyetDinhKyLuatInfo.strIDDM_NamHoc].ToString());
			pSV_QuyetDinhKyLuatInfo.HocKy = int.Parse(dr[pSV_QuyetDinhKyLuatInfo.strHocKy].ToString());
			pSV_QuyetDinhKyLuatInfo.SoQuyetDinh = dr[pSV_QuyetDinhKyLuatInfo.strSoQuyetDinh].ToString();
			pSV_QuyetDinhKyLuatInfo.NgayQuyetDinh = DateTime.Parse(dr[pSV_QuyetDinhKyLuatInfo.strNgayQuyetDinh].ToString());
			pSV_QuyetDinhKyLuatInfo.IDDM_CapKhenThuong = int.Parse(dr[pSV_QuyetDinhKyLuatInfo.strIDDM_CapKhenThuong].ToString());
			pSV_QuyetDinhKyLuatInfo.IDDM_HanhVi = int.Parse(dr[pSV_QuyetDinhKyLuatInfo.strIDDM_HanhVi].ToString());
			pSV_QuyetDinhKyLuatInfo.NoiDung = dr[pSV_QuyetDinhKyLuatInfo.strNoiDung].ToString();
        }
    }
}
