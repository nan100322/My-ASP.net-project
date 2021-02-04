using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication10.Controller;
using WebApplication10.Repositories;

namespace WebApplication10
{
    public partial class BookList : BasePage

    {
        BookRepository BookRepo = new BookRepository();
        protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    bindDataBook();
                }
            }

            void bindDataBook()
            {
                
                gvBook.DataSource = BookRepo.getBookList();
                gvBook.DataBind();
            }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var btnDelete = (Button)sender;
                var row = (GridViewRow)btnDelete.NamingContainer;
                var img = (Image)row.FindControl("img");
                string pathImg = Server.MapPath("~") + img.ImageUrl;
                if (File.Exists(pathImg))
                {
                    File.Delete(pathImg);
                }
                int id = int.Parse(row.Cells[0].Text);
                BookRepo.deleteBook(id);
                bindDataBook();
                showAlertSuccess("alertDelSuccess", "Delete success");
            }
            catch (SqlException sqlEx)
            {
                showAlertError("alertSqlErr", sqlEx.Message);
            }
            catch (Exception ex)
            {
                showAlertError("alertErr", ex.Message);
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var btnEdit = (Button)sender;
            var row = (GridViewRow)btnEdit.NamingContainer;
            int id = int.Parse(row.Cells[0].Text);
            Response.Redirect("~/BookListEdit.aspx?id=" + id);
        }
    }
}
    
