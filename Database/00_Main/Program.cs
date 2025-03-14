using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
// MyDB database i içerisindeki TblCategory tablosundaki tüm İçerikleri ekrana yazdırır.
    internal class Program
    {
        static void Main(string[] args)
        {

        SqlConnection conn = new SqlConnection("Data Source = DESKTOP-PBC004P;initial Catalog = MyDB;integrated security = true");
        conn.Open();

        SqlCommand cmd = new SqlCommand("Select * From TblCategory", conn);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        adapter.Fill(dt);

        foreach (DataRow dr in dt.Rows)
        {
            foreach (var item in dr.ItemArray)
            {
                Console.Write(item.ToString());
            }
            Console.WriteLine();
        }
            Console.Read();


        }
    }
