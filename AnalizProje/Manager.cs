using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.IO;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AnalizProje
{
    public class Manager
    {
        private DirectoryInfo di = new DirectoryInfo(".");
        public string conStrAnaliz;
        public string conStrWolvox;

        public Manager()
        {
            string ExeDosyaYolu = Application.StartupPath.ToString();
            if (ExeDosyaYolu != "C:\\Axima")
            {
                // Ev
                //conStrAnaliz = "User ID=sysdba;Password=masterkey;" + @"Database=F:\Axima\firebird\AKTARDETAY.FDB; Datasource=localhost; Port=3050 ; Dialect = 3;" + "Charset =NONE;";
                //conStrWolvox = "User ID=sysdba;Password=masterkey;" + @"Database=F:\Axima\firebird\WOLVOX.FDB; Datasource=localhost; Port=3050 ; Dialect = 3;" + "Charset =NONE;";

                // Laptop
                conStrAnaliz = "User ID=sysdba;Password=masterkey;" + @"Database=D:\Axima\firebird\AKTARDETAY.FDB; Datasource=localhost; Port=3050 ; Dialect = 3;" + "Charset =NONE;";
                //conStrWolvox = "User ID=sysdba;Password=masterkey;" + @"Database=D:\Axima\firebird\WOLVOX.FDB; Datasource=localhost; Port=3050 ; Dialect = 3;" + "Charset =NONE;";

                // iş
                //conStrAnaliz = "User ID=sysdba;Password=masterkey;" + @"Database=D:\Axima\firebird\AKTARDETAY.FDB; Datasource=192.168.1.56; Port=3050 ; Dialect = 3;" + "Charset=NONE;";
                //conStrWolvox = "User ID=sysdba;Password=masterkey;" + @"Database=D:\Axima\firebird\WOLVOX.FDB; Datasource=192.168.1.56; Port=3050 ; Dialect = 3;" + "Charset=NONE;";
            }
            else
            {
                conStrAnaliz = "User ID=sysdba;Password=masterkey;" + @"Database=C:\Axima\firebird\AKTARDETAY.FDB; Datasource=localhost; Port=3050 ; Dialect = 3;" + "Charset =NONE;";
                //conStrWolvox = "User ID=sysdba;Password=masterkey;" + @"Database=C:\Axima\firebird\WOLVOX.FDB; Datasource=localhost; Port=3050 ; Dialect = 3;" + "Charset =NONE;";
            }

            // Uzak
            conStrWolvox = "User = SYSDBA; Password = Passvip$11; Database = C:\\AKINSOFT\\Wolvox8\\Database_FB\\AKTAR\\2017\\WOLVOX.FDB; DataSource = 77.245.158.245; Port = 3050; Dialect = 3; Charset = NONE; Role =; Connection lifetime = 15; Pooling = true; MinPoolSize = 0; MaxPoolSize = 50; Packet Size = 8192; ServerType = 0";

            // Şablon
            //User = SYSDBA; Password = masterkey; Database = SampleDatabase.fdb; DataSource = localhost;
            //Port = 3050; Dialect = 3; Charset = NONE; Role =; Connection lifetime = 15; Pooling = false;
            //Packet Size = 8192; ServerType = 0;

        }

        public static object _veriTasi;
        public static object VeriTasi
        {
            get { return _veriTasi; }
            set { _veriTasi = value; }
        }

        public static object _nodTasi;
        public static object NodTasi
        {
            get { return _nodTasi; }
            set { _nodTasi = value; }
        }

        public static object _nodId;
        public static object NodId
        {
            get { return _nodId; }
            set { _nodId = value; }
        }

        public static object _kullaniciID;
        public static object KullaniciID
        {
            get { return _kullaniciID; }
            set { _kullaniciID = value; }
        }

        public static object _kullaniciAdSoyad;
        public static object KullaniciAdSoyad
        {
            get { return _kullaniciAdSoyad; }
            set { _kullaniciAdSoyad = value; }
        }

        public static object _yetkiEkraniAcik;
        public static object YetkiEkraniAcik
        {
            get { return _yetkiEkraniAcik; }
            set { _yetkiEkraniAcik = value; }
        }

        public static object _cariIdTasi;
        public static object CariIdTasi
        {
            get { return _cariIdTasi; }
            set { _cariIdTasi = value; }
        }

        public static object _cariAdTasi;
        public static object CariAdTasi
        {
            get { return _cariAdTasi; }
            set { _cariAdTasi = value; }
        }

        public static object _hataMesajiTasi;
        public static object HataMesajiTasi
        {
            get { return _hataMesajiTasi; }
            set { _hataMesajiTasi = value; }
        }

        public DataSet BasitSorguDS(string sorgu, string hedef)
        {
            DataSet sonuc = new DataSet();
            FbDataAdapter FbDataAdapter = new FbDataAdapter(sorgu, hedef);
             FbDataAdapter.Fill(sonuc, "table");
            FbConnection.ClearAllPools();
            return sonuc;
        }

        /* Data Table Döndürür
         * SQL stringi tam yazılmalıdır
         * sonuc oluşmassa null değer döndürür.
         */
        public DataTable BasitSorguDT(string sorgu, string hedef)
        {
            DataSet ds = new DataSet();
            DataTable sonuc = new DataTable();
            FbDataAdapter fbDataAdapter ;
            try
            {
            fbDataAdapter = new FbDataAdapter(sorgu, hedef);
            fbDataAdapter.Fill(ds, "table");
            sonuc= ds.Tables["table"];

                //fbDataAdapter.Dispose();
                FbConnection.ClearAllPools();
            return sonuc;
            }
            catch (Exception ex)
            {
                Manager.HataMesajiTasi = ex.ToString();
                FbConnection.ClearAllPools();
                return null;
            }
        }

        public bool YetkiSorgula(string uygulama, string yetki)
        {
            DataTable yetkiKontrol = new DataTable();
            yetkiKontrol = BasitSorguDT("SELECT YETKI_ID FROM YETKI WHERE UYGULAMA_ADI = '" + uygulama + "' AND YETKI_ADI = '" + yetki + "'",conStrAnaliz);
            if (yetkiKontrol == null || yetkiKontrol.Rows.Count==0) 
            {
                string sorguYetkiYaz= "INSERT INTO YETKI "+
                    "(UYGULAMA_ADI, YETKI_ADI, AKTIF, KAYDEDEN, KAYIT_TARIHI, GUNCELLEYEN, GUNCELLEME_TARIHI) "+
                    "VALUES('" + uygulama + "', '" + yetki + "', 1, '"+ Manager.KullaniciAdSoyad + "', NULL, '"+ Manager.KullaniciAdSoyad + "', NULL)";

                if (!(sqlCalistir(sorguYetkiYaz, conStrAnaliz)))
                {
                    return false;
                }
            }

            try
            {
                string sorgu = "SELECT KULLANICI_ID, YETKI_ID, GECERLILIK_TARIHI, AKTIF " +
                    "FROM KULLANICI_YETKI " +
                    "WHERE KULLANICI_ID = "+Manager.KullaniciID.ToString()+" AND "+
                    "YETKI_ID = (SELECT YETKI_ID FROM YETKI WHERE UYGULAMA_ADI = '"+uygulama+"' AND YETKI_ADI = '"+yetki+"')";
                DataSet ds = new DataSet();
                DataTable sonuc = new DataTable();
                FbDataAdapter FbDataAdapter = new FbDataAdapter(sorgu, conStrAnaliz);
                FbDataAdapter.Fill(ds, "table");
                sonuc = ds.Tables["table"];

                if (sonuc != null && sonuc.Rows.Count > 0 ) 
                {
                    return true;
                }
                else
                {
                    return false;
                }
             
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool sqlCalistir(string sorgu, string hedef)
        {
            try
            {
                FbConnection myConnection = new FbConnection(hedef);
                myConnection.Open();

                FbTransaction addDetailsTransaction = myConnection.BeginTransaction();
                string SQLCommandText = sorgu;
                FbCommand addDetailsCommand = new FbCommand(SQLCommandText, myConnection, addDetailsTransaction);
                addDetailsCommand.ExecuteNonQuery();
                addDetailsTransaction.Commit();
                myConnection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public DataTable GetDataTableFull(string tableName, string kriter, string hedef)
        {
            DataTable dt = new DataTable();
            string str_Sql = "SELECT * FROM " + tableName + " WHERE " + kriter;
            return dt = BasitSorguDT(str_Sql,hedef);
        }

        public DataTable GetDataTableFull(string tableName, string kriter,string siralama, string hedef)
        {
            DataTable dt = new DataTable();
            string str_Sql = "SELECT * FROM " + tableName + " WHERE " + kriter+" ORDER BY "+siralama;
            return dt = BasitSorguDT(str_Sql, hedef);
        }

        public DataTable GetDataTableFull(string tableName,string sahalar, string kriter, string siralama, string hedef)
        {
            DataTable dt = new DataTable();
            string str_Sql = "SELECT "+sahalar+" FROM " + tableName + " WHERE " + kriter + " ORDER BY " + siralama;
            return dt = BasitSorguDT(str_Sql, hedef);
        }

        public bool kaydetGuncelle(string tableName, string saha, int deger, DataTable dt, string hedef)
        {
            //Yeni Kayıt için değer 0 gelir
            if (deger == 0)
            {
                FbConnection myConnection = new FbConnection(hedef);
                myConnection.Open();
                FbTransaction addDetailsTransaction = myConnection.BeginTransaction();
                string SQLCommandText = "INSERT INTO "+tableName+" (KAYDEDEN) VALUES ('" + Manager._kullaniciAdSoyad.ToString()+"')" ;
                FbCommand addDetailsCommand = new FbCommand(SQLCommandText, myConnection, addDetailsTransaction);
                addDetailsCommand.ExecuteNonQuery();
                addDetailsTransaction.Commit();

                string sorgu = "SELECT FIRST 1 MAX(" + saha + "), KAYIT_TARIHI FROM " + tableName + " WHERE KAYDEDEN = '" + Manager._kullaniciAdSoyad + "' GROUP BY " + saha + ", KAYIT_TARIHI ORDER BY " + saha + " DESC";

                DataTable yeniId = BasitSorguDT(sorgu, hedef);
                deger = int.Parse(yeniId.Rows[0][0].ToString());
                dt.Rows[0]["KAYIT_TARIHI"] = yeniId.Rows[0]["KAYIT_TARIHI"];
            }

            try
            {
                FbConnection myConnection = new FbConnection(hedef);
                myConnection.Open();
                FbTransaction myTransaction = myConnection.BeginTransaction();
                FbCommand myCommand = new FbCommand();
                myCommand.CommandText = "UPDATE " + tableName + " SET ";
                for (int i = 1; i < dt.Columns.Count-1; i++)
                {
                    myCommand.CommandText += dt.Columns[i].Caption + "= @" + dt.Columns[i].Caption + ", ";
                }
                myCommand.CommandText +=  dt.Columns[dt.Columns.Count-1].Caption + "= @" + dt.Columns[dt.Columns.Count-1].Caption + " " +
                "WHERE " + saha + " = " + deger;
                myCommand.Connection = myConnection;
                myCommand.Transaction = myTransaction;
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    myCommand.Parameters.AddWithValue("@" + dt.Columns[i].Caption, dt.Rows[0][i]);
                }
                // Execute Update
                myCommand.ExecuteNonQuery();
                // Commit changes
                myTransaction.Commit();
                // Free command resources in Firebird Server
                myCommand.Dispose();
                // Close connection
                myConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool kaydetGuncelleCari(string tableName, string saha, int deger,int blkodu, DataTable dt, string hedef)
        {
            //Yeni Kayıt için değer 0 gelir
            if (deger == 0)
            {
                FbConnection myConnection = new FbConnection(hedef);
                myConnection.Open();
                FbTransaction addDetailsTransaction = myConnection.BeginTransaction();

                string SQLCommandText = "INSERT INTO " + tableName + " (CARI_ID,BLKODU,KAYDEDEN) VALUES (" + 
                    dt.Rows[0]["CARI_ID"].ToString()+","+ dt.Rows[0]["BLKODU"].ToString()+",'"+ Manager._kullaniciAdSoyad.ToString() + "')";

                FbCommand addDetailsCommand = new FbCommand(SQLCommandText, myConnection, addDetailsTransaction);
                addDetailsCommand.ExecuteNonQuery();
                addDetailsTransaction.Commit();

                string sorgu = "SELECT * FROM " + tableName + " WHERE KAYDEDEN = '" + Manager._kullaniciAdSoyad + "' AND CARI_ID="+ dt.Rows[0]["CARI_ID"].ToString() + 
                    " AND BLKODU="+ dt.Rows[0]["BLKODU"].ToString();

                DataTable yeniId = BasitSorguDT(sorgu, hedef);
                //deger = int.Parse(yeniId.Rows[0][0].ToString());
            //    deger = int.Parse(dt.Rows[0]["CARI_ID"].ToString());
            //    dt.Rows[0]["KAYIT_TARIHI"] = yeniId.Rows[0]["KAYIT_TARIHI"];
            }

            try
            {
                FbConnection myConnection = new FbConnection(hedef);
                myConnection.Open();
                FbTransaction myTransaction = myConnection.BeginTransaction();
                FbCommand myCommand = new FbCommand();
                myCommand.CommandText = "UPDATE " + tableName + " SET ";
                for (int i = 0; i < dt.Columns.Count - 1; i++)
                {
                    myCommand.CommandText += dt.Columns[i].Caption + "= @" + dt.Columns[i].Caption + ", ";
                }
                myCommand.CommandText += dt.Columns[dt.Columns.Count - 1].Caption + "= @" + dt.Columns[dt.Columns.Count - 1].Caption + " " +
                "WHERE KAYDEDEN = '" + Manager._kullaniciAdSoyad + "' AND CARI_ID=" + dt.Rows[0]["CARI_ID"].ToString() + " AND BLKODU=" + dt.Rows[0]["BLKODU"].ToString();
                myCommand.Connection = myConnection;
                myCommand.Transaction = myTransaction;
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    myCommand.Parameters.AddWithValue("@" + dt.Columns[i].Caption, dt.Rows[0][i]);
                }
                // Execute Update
                myCommand.ExecuteNonQuery();
                // Commit changes
                myTransaction.Commit();
                // Free command resources in Firebird Server
                myCommand.Dispose();
                // Close connection
                myConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool Sil(string tabloAdi,string kriter ,string hedef)
        {
            try
            {
                FbConnection myConnection = new FbConnection(hedef);
                myConnection.Open();

                FbTransaction addDetailsTransaction = myConnection.BeginTransaction();
                string SQLCommandText = "DELETE FROM "+tabloAdi+ " WHERE "+ kriter;
                FbCommand addDetailsCommand = new FbCommand(SQLCommandText, myConnection, addDetailsTransaction);
                addDetailsCommand.ExecuteNonQuery();
                addDetailsTransaction.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string parametreTreeYolBul(string arananParametreId)
        {
            bool arama = true;
            string yol = "";
            string noduTasi = "";
            string sorgu = "";
            DataTable yolSor = new DataTable();

            sorgu = "SELECT * FROM PARAMETRE WHERE PARAMETRE_ID=" + arananParametreId;

            yolSor = BasitSorguDT(sorgu, conStrAnaliz);

            if (yolSor == null || yolSor.Rows.Count == 0)
            {
                noduTasi = "";
                return null;
            }

            yol = yolSor.Rows[0]["SEVIYE_ADI"].ToString();

            if (yolSor.Rows[0]["UST_SEVIYE_ID"].ToString() != "0")
            {
                do
                {
                    sorgu = "SELECT * FROM PARAMETRE WHERE PARAMETRE_ID=" + yolSor.Rows[0]["UST_SEVIYE_ID"].ToString();
                    yolSor = BasitSorguDT(sorgu, conStrAnaliz);
                    yol = yolSor.Rows[0]["SEVIYE_ADI"].ToString() + @" \ " + yol;
                    noduTasi = yolSor.Rows[0]["SEVIYE_ADI"].ToString() + @"\" + noduTasi;
                    if (yolSor.Rows[0]["UST_SEVIYE_ID"].ToString() == "0")
                    {
                        arama = false;
                    }

                } while (arama);
            }
            Manager.NodTasi = noduTasi;
            return yol;
        }
    }
}
