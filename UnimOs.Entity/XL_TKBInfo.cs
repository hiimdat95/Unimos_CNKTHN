using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class TKBInfo
    {
        private int[,] _TKB;
        private eLOAI_SK[,] _LOAI_SK;
        private HT_ThamSoXepLichInfo objThamSoTKB;

        public TKBInfo(HT_ThamSoXepLichInfo pThamSoTKB)
        {
            objThamSoTKB = pThamSoTKB;
            _TKB = new int[objThamSoTKB.THU_KET_THUC + 1, objThamSoTKB.SO_TIET_NGAY];
            _LOAI_SK = new eLOAI_SK[objThamSoTKB.THU_KET_THUC + 1, objThamSoTKB.SO_TIET_NGAY];
            for (int i = objThamSoTKB.THU_BAT_DAU; i <= objThamSoTKB.THU_KET_THUC; i++)
            {
                for (int j = 0; j < objThamSoTKB.SO_TIET_NGAY; j++)
                {
                    _TKB[i, j] = -1;
                    _LOAI_SK[i, j] = eLOAI_SK.LICH_HOC;
                }
            }
        }

        public eLOAI_SK this[int Thu, int Tiet, bool LOAI_SK]
        {
            get { return _LOAI_SK[Thu, Tiet]; }
            set { _LOAI_SK[Thu, Tiet] = value; }
        }

        public int this[int Thu, int Tiet]
        {
            get { return _TKB[Thu, Tiet]; }
            set { _TKB[Thu, Tiet] = value; }
        }
    }
}
