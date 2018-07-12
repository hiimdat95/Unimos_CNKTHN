using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBSV_QuyetDinhKhenThuong : cBBase
    {
        private cDSV_QuyetDinhKhenThuong oDSV_QuyetDinhKhenThuong;
        private SV_QuyetDinhKhenThuongInfo oSV_QuyetDinhKhenThuongInfo;

        public cBSV_QuyetDinhKhenThuong()        
        {
            oDSV_QuyetDinhKhenThuong = new cDSV_QuyetDinhKhenThuong();
        }

        public DataTable Get(SV_QuyetDinhKhenThuongInfo pSV_QuyetDinhKhenThuongInfo)        
        {
            return oDSV_QuyetDinhKhenThuong.Get(pSV_QuyetDinhKhenThuongInfo);
        }

        public DataTable GetByHocKyNamHoc(int IDDM_NamHoc, int HocKy)
        {
            return oDSV_QuyetDinhKhenThuong.GetByHocKyNamHoc(IDDM_NamHoc, HocKy);
        }

        public int Add(SV_QuyetDinhKhenThuongInfo pSV_QuyetDinhKhenThuongInfo)
        {
			int ID = 0;
            ID = oDSV_QuyetDinhKhenThuong.Add(pSV_QuyetDinhKhenThuongInfo);
            mErrorMessage = oDSV_QuyetDinhKhenThuong.ErrorMessages;
            mErrorNumber = oDSV_QuyetDinhKhenThuong.ErrorNumber;
            return ID;
        }

        public void Update(SV_QuyetDinhKhenThuongInfo pSV_QuyetDinhKhenThuongInfo)
        {
            oDSV_QuyetDinhKhenThuong.Update(pSV_QuyetDinhKhenThuongInfo);
            mErrorMessage = oDSV_QuyetDinhKhenThuong.ErrorMessages;
            mErrorNumber = oDSV_QuyetDinhKhenThuong.ErrorNumber;
        }
        
        public void Delete(SV_QuyetDinhKhenThuongInfo pSV_QuyetDinhKhenThuongInfo)
        {
            oDSV_QuyetDinhKhenThuong.Delete(pSV_QuyetDinhKhenThuongInfo);
            mErrorMessage = oDSV_QuyetDinhKhenThuong.ErrorMessages;
            mErrorNumber = oDSV_QuyetDinhKhenThuong.ErrorNumber;
        }

        public List<SV_QuyetDinhKhenThuongInfo> GetList(SV_QuyetDinhKhenThuongInfo pSV_QuyetDinhKhenThuongInfo)
        {
            List<SV_QuyetDinhKhenThuongInfo> oSV_QuyetDinhKhenThuongInfoList = new List<SV_QuyetDinhKhenThuongInfo>();
            DataTable dtb = Get(pSV_QuyetDinhKhenThuongInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oSV_QuyetDinhKhenThuongInfo = new SV_QuyetDinhKhenThuongInfo();

                    oSV_QuyetDinhKhenThuongInfo.SV_QuyetDinhKhenThuongID = int.Parse(dtb.Rows[i]["SV_QuyetDinhKhenThuongID"].ToString());
                    oSV_QuyetDinhKhenThuongInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
                    oSV_QuyetDinhKhenThuongInfo.HocKy = int.Parse(dtb.Rows[i]["HocKy"].ToString());
                    oSV_QuyetDinhKhenThuongInfo.SoQuyetDinh = dtb.Rows[i]["SoQuyetDinh"].ToString();
                    oSV_QuyetDinhKhenThuongInfo.NgayQuyetDinh = DateTime.Parse(dtb.Rows[i]["NgayQuyetDinh"].ToString());
                    oSV_QuyetDinhKhenThuongInfo.IDDM_CapKhenThuong = int.Parse(dtb.Rows[i]["IDDM_CapKhenThuong"].ToString());
                    oSV_QuyetDinhKhenThuongInfo.IDDM_LoaiKhenThuong = int.Parse(dtb.Rows[i]["IDDM_LoaiKhenThuong"].ToString());
                    oSV_QuyetDinhKhenThuongInfo.NoiDung = dtb.Rows[i]["NoiDung"].ToString();
                    
                    oSV_QuyetDinhKhenThuongInfoList.Add(oSV_QuyetDinhKhenThuongInfo);
                }
            }
            return oSV_QuyetDinhKhenThuongInfoList;
        }
        
        public void ToDataRow(SV_QuyetDinhKhenThuongInfo pSV_QuyetDinhKhenThuongInfo, ref DataRow dr)
        {

			dr[pSV_QuyetDinhKhenThuongInfo.strSV_QuyetDinhKhenThuongID] = pSV_QuyetDinhKhenThuongInfo.SV_QuyetDinhKhenThuongID;
			dr[pSV_QuyetDinhKhenThuongInfo.strIDDM_NamHoc] = pSV_QuyetDinhKhenThuongInfo.IDDM_NamHoc;
			dr[pSV_QuyetDinhKhenThuongInfo.strHocKy] = pSV_QuyetDinhKhenThuongInfo.HocKy;
			dr[pSV_QuyetDinhKhenThuongInfo.strSoQuyetDinh] = pSV_QuyetDinhKhenThuongInfo.SoQuyetDinh;
			dr[pSV_QuyetDinhKhenThuongInfo.strNgayQuyetDinh] = pSV_QuyetDinhKhenThuongInfo.NgayQuyetDinh;
			dr[pSV_QuyetDinhKhenThuongInfo.strIDDM_CapKhenThuong] = pSV_QuyetDinhKhenThuongInfo.IDDM_CapKhenThuong;
			dr[pSV_QuyetDinhKhenThuongInfo.strIDDM_LoaiKhenThuong] = pSV_QuyetDinhKhenThuongInfo.IDDM_LoaiKhenThuong;
			dr[pSV_QuyetDinhKhenThuongInfo.strNoiDung] = pSV_QuyetDinhKhenThuongInfo.NoiDung;
        }
        
        public void ToInfo(ref SV_QuyetDinhKhenThuongInfo pSV_QuyetDinhKhenThuongInfo, DataRow dr)
        {

			pSV_QuyetDinhKhenThuongInfo.SV_QuyetDinhKhenThuongID = int.Parse(dr[pSV_QuyetDinhKhenThuongInfo.strSV_QuyetDinhKhenThuongID].ToString());
			pSV_QuyetDinhKhenThuongInfo.IDDM_NamHoc = int.Parse(dr[pSV_QuyetDinhKhenThuongInfo.strIDDM_NamHoc].ToString());
			pSV_QuyetDinhKhenThuongInfo.HocKy = int.Parse(dr[pSV_QuyetDinhKhenThuongInfo.strHocKy].ToString());
			pSV_QuyetDinhKhenThuongInfo.SoQuyetDinh = dr[pSV_QuyetDinhKhenThuongInfo.strSoQuyetDinh].ToString();
			pSV_QuyetDinhKhenThuongInfo.NgayQuyetDinh = DateTime.Parse(dr[pSV_QuyetDinhKhenThuongInfo.strNgayQuyetDinh].ToString());
			pSV_QuyetDinhKhenThuongInfo.IDDM_CapKhenThuong = int.Parse(dr[pSV_QuyetDinhKhenThuongInfo.strIDDM_CapKhenThuong].ToString());
			pSV_QuyetDinhKhenThuongInfo.IDDM_LoaiKhenThuong = int.Parse(dr[pSV_QuyetDinhKhenThuongInfo.strIDDM_LoaiKhenThuong].ToString());
			pSV_QuyetDinhKhenThuongInfo.NoiDung = dr[pSV_QuyetDinhKhenThuongInfo.strNoiDung].ToString();
        }
    }
}
