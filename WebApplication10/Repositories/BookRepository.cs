using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebApplication10.Repositories
{
    public class BookRepository
    {
        string connStr = WebConfigurationManager.ConnectionStrings["connStrMyDB"].ConnectionString;
        DataSet callDbWithValue(string cmdText)
        {
            SqlConnection conn = new SqlConnection(connStr);
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(ds);
            return ds;
        }

        void callDb(string cmdText)
        {
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }

        public DataSet getBookList()
        {

           
            string cmdText = "Select * FROM[book]";
            return callDbWithValue(cmdText);
        }

    
    public void insertBook(BookModel data)
        {
            string cmdTextRaw = "INSERT INTO [book] VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', GETDATE(), GETDATE())";
            string cmdText = string.Format(cmdTextRaw, data.title, data.image, data.language, data.Price, data.Page, data.FirstDate);
            callDb(cmdText);
    }
    public void deleteBook(int id)
    {
        string cmdText = "DELETE FROM [Book] WHERE id = " + id;
        callDb(cmdText);
    }
        public DataSet getBookById(int id)
        {
            string cmdText = "SELECT * FROM [Book] WHERE id = " + id;
            return callDbWithValue(cmdText);
        }

        public void updateBook(BookModel data)
        {
            string cmdTextRaw = "UPDATE [Book] SET " +
                "title = '{0}', " +
                "image = '{1}', " +
                "language = '{2}', " +
                "Price = '{3}', " +
                "Page = {4}, " +
                "FirstDate = {5}"+
                "CreateDate = GETDATE() " +
                "ModifyDate = GETDATE() " + 
                "WHERE id = {6} ";
            string cmdText = string.Format(cmdTextRaw, data.title, data.image, data.language, data.Price, data.Page, data.FirstDate, data.id);
            callDb(cmdText);
        }
    }

   

public class BookModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string language { get; set; }
        public int Price { get; set; }
        public int Page { get; set; }
        public string image { get; set; }
        public DateTime FirstDate { get; set; }
        
    }
  }



