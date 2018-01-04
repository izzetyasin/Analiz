using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizProje
{
    public class ParametreSanal
    {
        private int PARAMETRE_ID;
        private string SEVIYE_ADI;
        private int UST_SEVIYE_ID;
        private int SEVIYE;
        private int ISPARENT;

        public ParametreSanal(int PARAMETRE_ID,  string SEVIYE_ADI, int UST_SEVIYE_ID, int SEVIYE, int ISPARENT)
        {
            this.PARAMETRE_ID = PARAMETRE_ID;
            this.SEVIYE_ADI = SEVIYE_ADI;
            this.UST_SEVIYE_ID = UST_SEVIYE_ID;
            this.SEVIYE = SEVIYE;
            this.ISPARENT = ISPARENT;
        }

        public int Parametre_Id
        {
            get { return PARAMETRE_ID; }
            set { PARAMETRE_ID = value; }
        }

        public string Seviye_Adi
        {
            get { return SEVIYE_ADI; }
            set { SEVIYE_ADI = value; }
        }

        public int Ust_Seviye_Id
        {
            get { return UST_SEVIYE_ID; }
            set { UST_SEVIYE_ID = value; }
        }

        public int Seviye
        {
            get { return SEVIYE; }
            set { SEVIYE = value; }
        }
        public int IsParent
        {
            get { return ISPARENT; }
            set { ISPARENT = value; }
        }
        public override string ToString() // <------ DataTreeNode sınıfında temel constructora gönderilecek ToString() işte burası.
        {
            //return  PARAMETRE_ID.ToString()+"\\"+ SEVIYE_ADI + "\\" + UST_SEVIYE_ID.ToString()+"\\"+ SEVIYE.ToString();
            return SEVIYE_ADI;
        }
    }
}
