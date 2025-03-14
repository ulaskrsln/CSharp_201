using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Üye Giriş Paneli");
            Console.WriteLine();
            Console.WriteLine("--------------------------------");

            Console.WriteLine("1. Giriş Yap");
            Console.WriteLine("2. Kayıt Ol");
            Console.WriteLine("3. Çıkış");
            Console.WriteLine("--------------------------------");
            Console.Write("Seçiminizi yapınız: ");
            int secim = Convert.ToInt32(Console.ReadLine());


            #region Giriş Yap
            void Giris()
            {
                Console.WriteLine("Giriş Yap");
                Console.Write("Kullanıcı Adınızı Giriniz: ");
                string kullaniciAdi = Console.ReadLine();

                Console.Write("Şifrenizi Giriniz: ");
                string sifre = Console.ReadLine();

                SqlConnection connection = new SqlConnection("Data Source = DESKTOP-PBC004P; initial Catalog=AccountDB;integrated security = true");
                connection.Open();
                SqlCommand command = new SqlCommand("Select * from Tbl_Userİnfo", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                bool giris = false;

                foreach (DataRow item in dataTable.Rows)
                {
                    do
                    {
                        if (item["UserName"].ToString() == kullaniciAdi && item["Password"].ToString() == sifre)
                        {
                            giris = true;
                            Console.WriteLine("Giriş Başarılı");
                            Console.WriteLine("Hoşgeldiniz " + kullaniciAdi);
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Kullanıcı Adı veya Şifre Hatalı");
                            giris = false;
                            Console.Write("Kullanıcı Adınızı Giriniz: ");
                            kullaniciAdi = Console.ReadLine();

                            Console.Write("Şifrenizi Giriniz: ");
                            sifre = Console.ReadLine();

                        }
                    } while (giris == false);

                }
            }
            #endregion

            #region Kayıt Ol

            void Kayit()
            {
                string kullaniciAdiKayit;
                string sifreKayit;
                string sifreonay;
                bool Status;
                Console.Write("Kullanıcı Adınızı Giriniz: ");
                kullaniciAdiKayit = Console.ReadLine();

                Console.Write("Şifrenizi Giriniz: ");
                sifreKayit = Console.ReadLine();

                Console.Write("Şifrenizi Tekrar Giriniz: ");
                sifreonay = Console.ReadLine();

                if (sifreKayit == sifreonay)
                {
                    do
                    {
                        if (sifreKayit.Length < 6)
                        {
                            Console.WriteLine("Şifreniz 6 karakterden az olamaz");
                            Status = false;
                           Console.Write("Şifrenizi Giriniz: ");
                            sifreKayit = Console.ReadLine();
                        }
                        if (sifreKayit.Length > 16)
                        {
                            Console.WriteLine("Şifreniz 16 karakterden fazla olamaz");
                            Status = false;
                            Console.Write("Şifrenizi Giriniz: ");
                            sifreKayit = Console.ReadLine();
                        }
                        if (sifreKayit.Any(char.IsDigit) == false)
                        {
                            Console.WriteLine("Şifreniz en az bir rakam içermelidir");
                            Status = false;
                            Console.Write("Şifrenizi Giriniz: ");
                            sifreKayit = Console.ReadLine();
                        }
                        if (sifreKayit.Any(char.IsUpper) == false)
                        {
                            Console.WriteLine("Şifreniz en az bir büyük harf içermelidir");
                            Status = false;
                            Console.Write("Şifrenizi Giriniz: ");
                            sifreKayit = Console.ReadLine();
                        }
                        if (sifreKayit.Any(char.IsLower) == false)
                        {
                            Console.WriteLine("Şifreniz en az bir küçük harf içermelidir");
                            Status = false;
                            Console.Write("Şifrenizi Giriniz: ");
                            sifreKayit = Console.ReadLine();
                        }
                        else Status = true;


                    } while (Status == false);
                
                        SqlConnection connection1 = new SqlConnection("Data Source = DESKTOP-PBC004P; initial Catalog=AccountDB;integrated security = true");
                        connection1.Open();
                        SqlCommand command1 = new SqlCommand("Insert into Tbl_Userİnfo (UserName,Password) values (@p1,@p2)", connection1);
                        command1.Parameters.AddWithValue("@p1", kullaniciAdiKayit);
                        command1.Parameters.AddWithValue("@p2", sifreKayit);
                        command1.ExecuteNonQuery();
                        connection1.Close();

                        Console.WriteLine("Kayıt Başarılı");
                    
                }
                else
                {
                    Console.WriteLine("Şifreler Uyuşmuyor");
                    return;
                }

            }
            #endregion

            switch (secim)
            {
                case 1:
                    Giris();
                    break;
                case 2:
                    Kayit();
                    break;
                case 3:
                    Console.WriteLine("Çıkış Yapıldı");
                    break;
                default:
                    Console.WriteLine("Hatalı Seçim Yaptınız");
                    break;
            }
        }
    }
}
