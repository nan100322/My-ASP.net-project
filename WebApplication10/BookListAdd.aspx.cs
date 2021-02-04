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
    public partial class BookListAdd : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)

        {
            if (!IsPostBack)
            {
                txtDate.Value = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate
                if (string.IsNullOrEmpty(txtTitle.Text))
                {
                    showAlertError("alertTitleErr", "กรุณากรอกชื่อหนังสือ");
                    return;
                }
                if (string.IsNullOrEmpty(ddlLanguage.Text))
                {
                    showAlertError("alertlangErr", "กรุณาเลือกภาษา");
                    return;
                }
                if (string.IsNullOrEmpty(txtPrice.Text))
                {
                    showAlertError("alertPriceErr", "กรุณาระบุราคาหนังสือ");
                    return;
                }
                int numPrice;
                if (!int.TryParse(txtPrice.Text, out numPrice))
                {
                    showAlertError("alertPriceNotNum", "กรุณาราคาให้เป็นตัวเลขเท่านั้น");
                    return;
                }
                if (string.IsNullOrEmpty(txtPage.Text))
                {
                    showAlertError("alertPageErr", "กรุณาระบุจำหนวนหน้าของหนังสือ");
                    return;
                }
                int numPage;
                if (!int.TryParse(txtPage.Text, out numPage))
                {
                    showAlertError("alertPageNotNum", "กรุณากรอกจำนวนหนังสือ ให้เป็นตัวเลขเท่านั้น");
                    return;
                }

                if (!fuCoverImg.HasFile)
                {
                    showAlertError("alertFileErr", "กรุณาเลือกไฟล์รูปภาพ");
                    return;
                }
                    string extFile = Path.GetExtension(fuCoverImg.FileName);
                    if (!(extFile == ".jpg" || extFile == ".png"))
                    {
                        showAlertError("alertExtErr", "กรุณาเลือกไฟล์รูปภาพเป็น .jpg หรือ .png เท่านั้น");
                        return;
                    }
                    string folderImg = "/images";
                    string pathFolderImg = Server.MapPath("~/" + folderImg);
                     if (!Directory.Exists(pathFolderImg))
                     {
                         Directory.CreateDirectory(pathFolderImg);
                     }
              string fileName = Guid.NewGuid().ToString();
              string fileNameExt = "/" + fileName + extFile;
              fuCoverImg.SaveAs(pathFolderImg + fileNameExt);
             string image = folderImg + fileNameExt;
             int Price = int.Parse(txtPrice.Text);
              int Page = int.Parse(txtPage.Text);
             DateTime FirstDate = DateTime.Parse(txtDate.Value);
              BookRepository BookRepo = new BookRepository();
             BookModel data = new BookModel()
            {
                title = txtTitle.Text,
                image = image,
                language = ddlLanguage.Text,
                Price = Price,
                Page = Page,
                FirstDate = FirstDate
            };
                    BookRepo.insertBook(data);
                    showAlertSuccess("alertSuccess", "Insert new info success"); 
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

       
    }
}
