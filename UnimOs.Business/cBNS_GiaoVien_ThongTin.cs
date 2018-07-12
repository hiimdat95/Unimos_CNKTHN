using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBNS_GiaoVien_ThongTin : cBBase
    {
        private cDNS_GiaoVien_ThongTin oDNS_GiaoVien_ThongTin;
        private NS_GiaoVien_ThongTinInfo oNS_GiaoVien_ThongTinInfo;

        public cBNS_GiaoVien_ThongTin()        
        {
            oDNS_GiaoVien_ThongTin = new cDNS_GiaoVien_ThongTin();
        }

        public DataTable Get(NS_GiaoVien_ThongTinInfo pNS_GiaoVien_ThongTinInfo)        
        {
            return oDNS_GiaoVien_ThongTin.Get(pNS_GiaoVien_ThongTinInfo);
        }

        public int Add(NS_GiaoVien_ThongTinInfo pNS_GiaoVien_ThongTinInfo)
        {
			int ID = 0;
            ID = oDNS_GiaoVien_ThongTin.Add(pNS_GiaoVien_ThongTinInfo);
            mErrorMessage = oDNS_GiaoVien_ThongTin.ErrorMessages;
            mErrorNumber = oDNS_GiaoVien_ThongTin.ErrorNumber;
            return ID;
        }

        public void Update(NS_GiaoVien_ThongTinInfo pNS_GiaoVien_ThongTinInfo)
        {
            oDNS_GiaoVien_ThongTin.Update(pNS_GiaoVien_ThongTinInfo);
            mErrorMessage = oDNS_GiaoVien_ThongTin.ErrorMessages;
            mErrorNumber = oDNS_GiaoVien_ThongTin.ErrorNumber;
        }
        
        public void Delete(NS_GiaoVien_ThongTinInfo pNS_GiaoVien_ThongTinInfo)
        {
            oDNS_GiaoVien_ThongTin.Delete(pNS_GiaoVien_ThongTinInfo);
            mErrorMessage = oDNS_GiaoVien_ThongTin.ErrorMessages;
            mErrorNumber = oDNS_GiaoVien_ThongTin.ErrorNumber;
        }

        public List<NS_GiaoVien_ThongTinInfo> GetList(NS_GiaoVien_ThongTinInfo pNS_GiaoVien_ThongTinInfo)
        {
            List<NS_GiaoVien_ThongTinInfo> oNS_GiaoVien_ThongTinInfoList = new List<NS_GiaoVien_ThongTinInfo>();
            DataTable dtb = Get(pNS_GiaoVien_ThongTinInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oNS_GiaoVien_ThongTinInfo = new NS_GiaoVien_ThongTinInfo();

                    oNS_GiaoVien_ThongTinInfo.NS_GiaoVien_ThongTinID = int.Parse(dtb.Rows[i]["NS_GiaoVien_ThongTinID"].ToString());
                    oNS_GiaoVien_ThongTinInfo.IDNS_GiaoVien = int.Parse(dtb.Rows[i]["IDNS_GiaoVien"].ToString());
                    oNS_GiaoVien_ThongTinInfo.NgheNghiepTuyenDung = dtb.Rows[i]["NgheNghiepTuyenDung"].ToString();
                    oNS_GiaoVien_ThongTinInfo.NgayTuyenDung = DateTime.Parse(dtb.Rows[i]["NgayTuyenDung"].ToString());
                    oNS_GiaoVien_ThongTinInfo.IDDM_ChucDanh = int.Parse(dtb.Rows[i]["IDDM_ChucDanh"].ToString());
                    oNS_GiaoVien_ThongTinInfo.IDDM_HocHam = int.Parse(dtb.Rows[i]["IDDM_HocHam"].ToString());
                    oNS_GiaoVien_ThongTinInfo.IDDM_HocVi = int.Parse(dtb.Rows[i]["IDDM_HocVi"].ToString());
                    oNS_GiaoVien_ThongTinInfo.TrinhDoPhoThong = dtb.Rows[i]["TrinhDoPhoThong"].ToString();
                    oNS_GiaoVien_ThongTinInfo.TrinhDoTinHoc = dtb.Rows[i]["TrinhDoTinHoc"].ToString();
                    oNS_GiaoVien_ThongTinInfo.IDDM_TrinhDoChuyenMon = int.Parse(dtb.Rows[i]["IDDM_TrinhDoChuyenMon"].ToString());
                    oNS_GiaoVien_ThongTinInfo.IDDM_TrinhDoLyLuan = int.Parse(dtb.Rows[i]["IDDM_TrinhDoLyLuan"].ToString());
                    oNS_GiaoVien_ThongTinInfo.IDDM_QuanLyHanhChinhNhaNuoc = int.Parse(dtb.Rows[i]["IDDM_QuanLyHanhChinhNhaNuoc"].ToString());
                    oNS_GiaoVien_ThongTinInfo.NgayVaoDang = DateTime.Parse(dtb.Rows[i]["NgayVaoDang"].ToString());
                    oNS_GiaoVien_ThongTinInfo.NgayVaoDangChinhThuc = DateTime.Parse(dtb.Rows[i]["NgayVaoDangChinhThuc"].ToString());
                    oNS_GiaoVien_ThongTinInfo.IDDM_DanhHieuDuocPhongTang = int.Parse(dtb.Rows[i]["IDDM_DanhHieuDuocPhongTang"].ToString());
                    oNS_GiaoVien_ThongTinInfo.SoTruongCongTac = dtb.Rows[i]["SoTruongCongTac"].ToString();
                    oNS_GiaoVien_ThongTinInfo.TinhTrangSucKhoe = dtb.Rows[i]["TinhTrangSucKhoe"].ToString();
                    oNS_GiaoVien_ThongTinInfo.ChieuCao = double.Parse(dtb.Rows[i]["ChieuCao"].ToString());
                    oNS_GiaoVien_ThongTinInfo.CanNang = double.Parse(dtb.Rows[i]["CanNang"].ToString());
                    oNS_GiaoVien_ThongTinInfo.NhomMau = dtb.Rows[i]["NhomMau"].ToString();
                    oNS_GiaoVien_ThongTinInfo.SoSoBaoHiemXaHoi = dtb.Rows[i]["SoSoBaoHiemXaHoi"].ToString();
                    
                    oNS_GiaoVien_ThongTinInfoList.Add(oNS_GiaoVien_ThongTinInfo);
                }
            }
            return oNS_GiaoVien_ThongTinInfoList;
        }
        
        public void ToDataRow(NS_GiaoVien_ThongTinInfo pNS_GiaoVien_ThongTinInfo, ref DataRow dr)
        {

			dr[pNS_GiaoVien_ThongTinInfo.strNS_GiaoVien_ThongTinID] = pNS_GiaoVien_ThongTinInfo.NS_GiaoVien_ThongTinID;
			dr[pNS_GiaoVien_ThongTinInfo.strIDNS_GiaoVien] = pNS_GiaoVien_ThongTinInfo.IDNS_GiaoVien;
			dr[pNS_GiaoVien_ThongTinInfo.strNgheNghiepTuyenDung] = pNS_GiaoVien_ThongTinInfo.NgheNghiepTuyenDung;
			dr[pNS_GiaoVien_ThongTinInfo.strNgayTuyenDung] = pNS_GiaoVien_ThongTinInfo.NgayTuyenDung;
			dr[pNS_GiaoVien_ThongTinInfo.strIDDM_ChucDanh] = pNS_GiaoVien_ThongTinInfo.IDDM_ChucDanh;
			dr[pNS_GiaoVien_ThongTinInfo.strIDDM_HocHam] = pNS_GiaoVien_ThongTinInfo.IDDM_HocHam;
            dr[pNS_GiaoVien_ThongTinInfo.strIDDM_HocVi] = pNS_GiaoVien_ThongTinInfo.IDDM_HocVi;
			dr[pNS_GiaoVien_ThongTinInfo.strTrinhDoPhoThong] = pNS_GiaoVien_ThongTinInfo.TrinhDoPhoThong;
			dr[pNS_GiaoVien_ThongTinInfo.strTrinhDoTinHoc] = pNS_GiaoVien_ThongTinInfo.TrinhDoTinHoc;
			dr[pNS_GiaoVien_ThongTinInfo.strIDDM_TrinhDoChuyenMon] = pNS_GiaoVien_ThongTinInfo.IDDM_TrinhDoChuyenMon;
			dr[pNS_GiaoVien_ThongTinInfo.strIDDM_TrinhDoLyLuan] = pNS_GiaoVien_ThongTinInfo.IDDM_TrinhDoLyLuan;
			dr[pNS_GiaoVien_ThongTinInfo.strIDDM_QuanLyHanhChinhNhaNuoc] = pNS_GiaoVien_ThongTinInfo.IDDM_QuanLyHanhChinhNhaNuoc;
			dr[pNS_GiaoVien_ThongTinInfo.strNgayVaoDang] = pNS_GiaoVien_ThongTinInfo.NgayVaoDang;
			dr[pNS_GiaoVien_ThongTinInfo.strNgayVaoDangChinhThuc] = pNS_GiaoVien_ThongTinInfo.NgayVaoDangChinhThuc;
			dr[pNS_GiaoVien_ThongTinInfo.strIDDM_DanhHieuDuocPhongTang] = pNS_GiaoVien_ThongTinInfo.IDDM_DanhHieuDuocPhongTang;
			dr[pNS_GiaoVien_ThongTinInfo.strSoTruongCongTac] = pNS_GiaoVien_ThongTinInfo.SoTruongCongTac;
			dr[pNS_GiaoVien_ThongTinInfo.strTinhTrangSucKhoe] = pNS_GiaoVien_ThongTinInfo.TinhTrangSucKhoe;
			dr[pNS_GiaoVien_ThongTinInfo.strChieuCao] = pNS_GiaoVien_ThongTinInfo.ChieuCao;
			dr[pNS_GiaoVien_ThongTinInfo.strCanNang] = pNS_GiaoVien_ThongTinInfo.CanNang;
			dr[pNS_GiaoVien_ThongTinInfo.strNhomMau] = pNS_GiaoVien_ThongTinInfo.NhomMau;
			dr[pNS_GiaoVien_ThongTinInfo.strSoSoBaoHiemXaHoi] = pNS_GiaoVien_ThongTinInfo.SoSoBaoHiemXaHoi;
        }
        
        public void ToInfo(ref NS_GiaoVien_ThongTinInfo pNS_GiaoVien_ThongTinInfo, DataRow dr)
        {

			pNS_GiaoVien_ThongTinInfo.NS_GiaoVien_ThongTinID = int.Parse(dr[pNS_GiaoVien_ThongTinInfo.strNS_GiaoVien_ThongTinID].ToString());
			pNS_GiaoVien_ThongTinInfo.IDNS_GiaoVien = int.Parse("0" + dr[pNS_GiaoVien_ThongTinInfo.strIDNS_GiaoVien]);
			pNS_GiaoVien_ThongTinInfo.NgheNghiepTuyenDung = dr[pNS_GiaoVien_ThongTinInfo.strNgheNghiepTuyenDung].ToString();
            if (dr[pNS_GiaoVien_ThongTinInfo.strNgayTuyenDung].ToString() != "")
			    pNS_GiaoVien_ThongTinInfo.NgayTuyenDung = DateTime.Parse(dr[pNS_GiaoVien_ThongTinInfo.strNgayTuyenDung].ToString());
			pNS_GiaoVien_ThongTinInfo.IDDM_ChucDanh = int.Parse("0" + dr[pNS_GiaoVien_ThongTinInfo.strIDDM_ChucDanh]);
			pNS_GiaoVien_ThongTinInfo.IDDM_HocHam = int.Parse("0" + dr[pNS_GiaoVien_ThongTinInfo.strIDDM_HocHam]);
            pNS_GiaoVien_ThongTinInfo.IDDM_HocVi = int.Parse("0" + dr[pNS_GiaoVien_ThongTinInfo.strIDDM_HocVi]);
			pNS_GiaoVien_ThongTinInfo.TrinhDoPhoThong = dr[pNS_GiaoVien_ThongTinInfo.strTrinhDoPhoThong].ToString();
			pNS_GiaoVien_ThongTinInfo.TrinhDoTinHoc = dr[pNS_GiaoVien_ThongTinInfo.strTrinhDoTinHoc].ToString();
			pNS_GiaoVien_ThongTinInfo.IDDM_TrinhDoChuyenMon = int.Parse("0" + dr[pNS_GiaoVien_ThongTinInfo.strIDDM_TrinhDoChuyenMon]);
			pNS_GiaoVien_ThongTinInfo.IDDM_TrinhDoLyLuan = int.Parse("0" + dr[pNS_GiaoVien_ThongTinInfo.strIDDM_TrinhDoLyLuan]);
			pNS_GiaoVien_ThongTinInfo.IDDM_QuanLyHanhChinhNhaNuoc = int.Parse("0" + dr[pNS_GiaoVien_ThongTinInfo.strIDDM_QuanLyHanhChinhNhaNuoc]);
            if (dr[pNS_GiaoVien_ThongTinInfo.strNgayVaoDang].ToString() != "")
                pNS_GiaoVien_ThongTinInfo.NgayVaoDang = DateTime.Parse(dr[pNS_GiaoVien_ThongTinInfo.strNgayVaoDang].ToString());
            if (dr[pNS_GiaoVien_ThongTinInfo.strNgayVaoDangChinhThuc].ToString() != "")
			    pNS_GiaoVien_ThongTinInfo.NgayVaoDangChinhThuc = DateTime.Parse(dr[pNS_GiaoVien_ThongTinInfo.strNgayVaoDangChinhThuc].ToString());
			pNS_GiaoVien_ThongTinInfo.IDDM_DanhHieuDuocPhongTang = int.Parse("0" + dr[pNS_GiaoVien_ThongTinInfo.strIDDM_DanhHieuDuocPhongTang]);
			pNS_GiaoVien_ThongTinInfo.SoTruongCongTac = dr[pNS_GiaoVien_ThongTinInfo.strSoTruongCongTac].ToString();
			pNS_GiaoVien_ThongTinInfo.TinhTrangSucKhoe = dr[pNS_GiaoVien_ThongTinInfo.strTinhTrangSucKhoe].ToString();
			pNS_GiaoVien_ThongTinInfo.ChieuCao = double.Parse("0" + dr[pNS_GiaoVien_ThongTinInfo.strChieuCao]);
			pNS_GiaoVien_ThongTinInfo.CanNang = double.Parse("0" + dr[pNS_GiaoVien_ThongTinInfo.strCanNang]);
			pNS_GiaoVien_ThongTinInfo.NhomMau = dr[pNS_GiaoVien_ThongTinInfo.strNhomMau].ToString();
			pNS_GiaoVien_ThongTinInfo.SoSoBaoHiemXaHoi = dr[pNS_GiaoVien_ThongTinInfo.strSoSoBaoHiemXaHoi].ToString();
        }
    }
}
