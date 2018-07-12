using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class KQHT_QuyChe_ThamSoQuyCheInfo
    {

        private int mKQHT_QuyChe_ThamSoQuyCheID;
        private int mIDKQHT_QuyChe;
        private int mIDKQHT_ThamSoQuyChe;
        private string mGiaTri;

        public string strKQHT_QuyChe_ThamSoQuyCheID = "KQHT_QuyChe_ThamSoQuyCheID";
        public string strIDKQHT_QuyChe = "IDKQHT_QuyChe";
        public string strIDKQHT_ThamSoQuyChe = "IDKQHT_ThamSoQuyChe";
        public string strGiaTri = "GiaTri";

        public KQHT_QuyChe_ThamSoQuyCheInfo()
        { }

        public int KQHT_QuyChe_ThamSoQuyCheID{
        	set{ mKQHT_QuyChe_ThamSoQuyCheID = value;}
        	get{ return mKQHT_QuyChe_ThamSoQuyCheID;}
        }
        public int IDKQHT_QuyChe{
        	set{ mIDKQHT_QuyChe = value;}
        	get{ return mIDKQHT_QuyChe;}
        }
        public int IDKQHT_ThamSoQuyChe{
        	set{ mIDKQHT_ThamSoQuyChe = value;}
        	get{ return mIDKQHT_ThamSoQuyChe;}
        }
        public string GiaTri{
        	set{ mGiaTri = value;}
        	get{ return mGiaTri;}
        }
    }
}
