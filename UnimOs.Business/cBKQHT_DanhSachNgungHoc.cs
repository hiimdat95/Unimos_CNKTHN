using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_DanhSachNgungHoc : cBBase
    {
        private cDKQHT_DanhSachNgungHoc oDKQHT_DanhSachNgungHoc;
        private KQHT_DanhSachNgungHocInfo oKQHT_DanhSachNgungHocInfo;

        public cBKQHT_DanhSachNgungHoc()        
        {
            oDKQHT_DanhSachNgungHoc = new cDKQHT_DanhSachNgungHoc();
        }

        public DataTable Get(KQHT_DanhSachNgungHocInfo pKQHT_DanhSachNgungHocInfo)        
        {
            return oDKQHT_DanhSachNgungHoc.Get(pKQHT_DanhSachNgungHocInfo);
        }
        public DataTable GetSinhVien(DM_LopInfo pDM_LopInfo, string NamHoc, int IDDM_NamHoc)
        {
            return oDKQHT_DanhSachNgungHoc.GetSinhVien(pDM_LopInfo,  NamHoc,  IDDM_NamHoc);
        }
        public DataTable GetSinhVienTKSoLuong( int Nam,int tuthang, int denthang)
        {
            DataTable dbothongkeTuThang = oDKQHT_DanhSachNgungHoc.GetSinhVienTKTongTuThang(Nam, tuthang, denthang);

            DataTable dbothongkeTuThangThem = oDKQHT_DanhSachNgungHoc.GetSinhVienTKTongTuThangThem(Nam, tuthang, denthang);
            DataTable dbothongkeTuThangBot = oDKQHT_DanhSachNgungHoc.GetSinhVienTKTongTuThangBot(Nam, tuthang, denthang);
           
            DataTable dtb = new DataTable();
            dtb.Columns.Add("DM_LopID", typeof(int));
            dtb.Columns.Add("TenLop", typeof(string));
            dtb.Columns.Add("Tong", typeof(int));
            for (int i = tuthang; i <= denthang; i++)
            {
                dtb.Columns.Add("T"+i.ToString(), typeof(double));
            }

            int DM_LopID = 0;
            int thang = tuthang;
            int tongSo = 0;
            DataRow dr = dtb.NewRow();
            if (dbothongkeTuThang.Rows.Count > 0)
            {
              for (int i=0;i<dbothongkeTuThang.Rows.Count;i++)
                    {
                for (int j = tuthang; j <= denthang; j++)
                {
                    if (DM_LopID != int.Parse(dbothongkeTuThang.Rows[i]["DM_LopID"].ToString()))
                    {
                        tongSo = 0;
                        
                        DM_LopID = int.Parse(dbothongkeTuThang.Rows[i]["DM_LopID"].ToString());

                        dr = dtb.NewRow();
                       
                            if (int.Parse("0"+ dbothongkeTuThang.Rows[i]["Tong"].ToString()) != 0)
                            {
                                dr["T" + j.ToString()] = int.Parse("0" + dbothongkeTuThang.Rows[i]["Tong"].ToString());
                            }
                            else
                            {
                                dr["T" + j.ToString()] = 0;
                            }
                       
                        dr["DM_LopID"] = dbothongkeTuThang.Rows[i]["DM_LopID"].ToString();
                        dr["TenLop"] = dbothongkeTuThang.Rows[i]["TenLop"].ToString();
                        dtb.Rows.Add(dr);
                        tongSo = int.Parse("0" + dbothongkeTuThang.Rows[i]["Tong"].ToString());

                    }
                    else
                    {
                        if (dbothongkeTuThangBot.Rows.Count > 0)
                        {
                            for (int k = 0; k < dbothongkeTuThangBot.Rows.Count; k++)
                            {
                                if (int.Parse(dbothongkeTuThangBot.Rows[k]["DM_LopID"].ToString()) == DM_LopID && j == int.Parse(dbothongkeTuThangBot.Rows[k]["Thang"].ToString()))
                                {
                                    tongSo = tongSo - int.Parse(dbothongkeTuThangBot.Rows[k]["Tong"].ToString());
                                }
                            }
                        }
                        if (dbothongkeTuThangThem.Rows.Count > 0)
                        {
                            for (int k = 0; k < dbothongkeTuThangThem.Rows.Count; k++)
                            {
                                if (int.Parse(dbothongkeTuThangThem.Rows[k]["DM_LopID"].ToString()) == DM_LopID && j == int.Parse(dbothongkeTuThangThem.Rows[k]["Thang"].ToString()))
                                {
                                    tongSo = tongSo + int.Parse(dbothongkeTuThangThem.Rows[k]["Tong"].ToString());
                                }
                            }
                        }

                        dr["T" + j.ToString()] = tongSo;
                    }  
                }
              }

            }

            return dtb;
        }
        public int Add(KQHT_DanhSachNgungHocInfo pKQHT_DanhSachNgungHocInfo)
        {
			int ID = 0;
            ID = oDKQHT_DanhSachNgungHoc.Add(pKQHT_DanhSachNgungHocInfo);
            mErrorMessage = oDKQHT_DanhSachNgungHoc.ErrorMessages;
            mErrorNumber = oDKQHT_DanhSachNgungHoc.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_DanhSachNgungHocInfo pKQHT_DanhSachNgungHocInfo)
        {
            oDKQHT_DanhSachNgungHoc.Update(pKQHT_DanhSachNgungHocInfo);
            mErrorMessage = oDKQHT_DanhSachNgungHoc.ErrorMessages;
            mErrorNumber = oDKQHT_DanhSachNgungHoc.ErrorNumber;
        }
        
        public void Delete(KQHT_DanhSachNgungHocInfo pKQHT_DanhSachNgungHocInfo)
        {
            oDKQHT_DanhSachNgungHoc.Delete(pKQHT_DanhSachNgungHocInfo);
            mErrorMessage = oDKQHT_DanhSachNgungHoc.ErrorMessages;
            mErrorNumber = oDKQHT_DanhSachNgungHoc.ErrorNumber;
        }

        public void DeleteQĐ(string SV_SinhVienIDs,int IDDM_Lop, int IDDM_NamHoc)
        {
            oDKQHT_DanhSachNgungHoc.DeleteQĐ(SV_SinhVienIDs, IDDM_Lop, IDDM_NamHoc);
            mErrorMessage = oDKQHT_DanhSachNgungHoc.ErrorMessages;
            mErrorNumber = oDKQHT_DanhSachNgungHoc.ErrorNumber;
        }

        public List<KQHT_DanhSachNgungHocInfo> GetList(KQHT_DanhSachNgungHocInfo pKQHT_DanhSachNgungHocInfo)
        {
            List<KQHT_DanhSachNgungHocInfo> oKQHT_DanhSachNgungHocInfoList = new List<KQHT_DanhSachNgungHocInfo>();
            DataTable dtb = Get(pKQHT_DanhSachNgungHocInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_DanhSachNgungHocInfo = new KQHT_DanhSachNgungHocInfo();

                    oKQHT_DanhSachNgungHocInfo.KQHT_DanhSachNgungHocID = int.Parse(dtb.Rows[i]["KQHT_DanhSachNgungHocID"].ToString());
                    oKQHT_DanhSachNgungHocInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oKQHT_DanhSachNgungHocInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
                    oKQHT_DanhSachNgungHocInfo.HocKy = int.Parse(dtb.Rows[i]["HocKy"].ToString());
                    oKQHT_DanhSachNgungHocInfo.SoQuyetDinh = dtb.Rows[i]["SoQuyetDinh"].ToString();
                    oKQHT_DanhSachNgungHocInfo.NgayQuyetDinh = DateTime.Parse(dtb.Rows[i]["NgayQuyetDinh"].ToString());
                    oKQHT_DanhSachNgungHocInfo.NoiDung = dtb.Rows[i]["NoiDung"].ToString();
                    oKQHT_DanhSachNgungHocInfo.IDDM_LopCu = int.Parse(dtb.Rows[i]["IDDM_LopCu"].ToString());
                    oKQHT_DanhSachNgungHocInfo.TrangThai = int.Parse(dtb.Rows[i]["TrangThai"].ToString());
                    
                    oKQHT_DanhSachNgungHocInfoList.Add(oKQHT_DanhSachNgungHocInfo);
                }
            }
            return oKQHT_DanhSachNgungHocInfoList;
        }
        
        public void ToDataRow(KQHT_DanhSachNgungHocInfo pKQHT_DanhSachNgungHocInfo, ref DataRow dr)
        {

			dr[pKQHT_DanhSachNgungHocInfo.strKQHT_DanhSachNgungHocID] = pKQHT_DanhSachNgungHocInfo.KQHT_DanhSachNgungHocID;
			dr[pKQHT_DanhSachNgungHocInfo.strIDSV_SinhVien] = pKQHT_DanhSachNgungHocInfo.IDSV_SinhVien;
			dr[pKQHT_DanhSachNgungHocInfo.strIDDM_NamHoc] = pKQHT_DanhSachNgungHocInfo.IDDM_NamHoc;
			dr[pKQHT_DanhSachNgungHocInfo.strHocKy] = pKQHT_DanhSachNgungHocInfo.HocKy;
			dr[pKQHT_DanhSachNgungHocInfo.strSoQuyetDinh] = pKQHT_DanhSachNgungHocInfo.SoQuyetDinh;
			dr[pKQHT_DanhSachNgungHocInfo.strNgayQuyetDinh] = pKQHT_DanhSachNgungHocInfo.NgayQuyetDinh;
			dr[pKQHT_DanhSachNgungHocInfo.strNoiDung] = pKQHT_DanhSachNgungHocInfo.NoiDung;
			dr[pKQHT_DanhSachNgungHocInfo.strIDDM_LopCu] = pKQHT_DanhSachNgungHocInfo.IDDM_LopCu;
            dr[pKQHT_DanhSachNgungHocInfo.strTrangThai] = pKQHT_DanhSachNgungHocInfo.TrangThai;
        }
        
        public void ToInfo(ref KQHT_DanhSachNgungHocInfo pKQHT_DanhSachNgungHocInfo, DataRow dr)
        {

			pKQHT_DanhSachNgungHocInfo.KQHT_DanhSachNgungHocID = int.Parse(dr[pKQHT_DanhSachNgungHocInfo.strKQHT_DanhSachNgungHocID].ToString());
			pKQHT_DanhSachNgungHocInfo.IDSV_SinhVien = int.Parse(dr[pKQHT_DanhSachNgungHocInfo.strIDSV_SinhVien].ToString());
			pKQHT_DanhSachNgungHocInfo.IDDM_NamHoc = int.Parse(dr[pKQHT_DanhSachNgungHocInfo.strIDDM_NamHoc].ToString());
			pKQHT_DanhSachNgungHocInfo.HocKy = int.Parse(dr[pKQHT_DanhSachNgungHocInfo.strHocKy].ToString());
			pKQHT_DanhSachNgungHocInfo.SoQuyetDinh = dr[pKQHT_DanhSachNgungHocInfo.strSoQuyetDinh].ToString();
			pKQHT_DanhSachNgungHocInfo.NgayQuyetDinh = DateTime.Parse(dr[pKQHT_DanhSachNgungHocInfo.strNgayQuyetDinh].ToString());
			pKQHT_DanhSachNgungHocInfo.NoiDung = dr[pKQHT_DanhSachNgungHocInfo.strNoiDung].ToString();
			pKQHT_DanhSachNgungHocInfo.IDDM_LopCu = int.Parse(dr[pKQHT_DanhSachNgungHocInfo.strIDDM_LopCu].ToString());
            pKQHT_DanhSachNgungHocInfo.TrangThai = int.Parse(dr[pKQHT_DanhSachNgungHocInfo.strTrangThai].ToString());
        }
    }
}
