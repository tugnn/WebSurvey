using System;
using System.Configuration;
using System.Data.SqlClient;

namespace WebSurvey
{
    public partial class DangNhap1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string name = txtusername.Value;
            string pass = txtpassword.Value;
            //if (name == "")
            //{
            //    lblthongbao.InnerText = "Bạn cần nhập tên người dùng!";
            //    txtusername.Focus();
            //}
            //else
            //{
            //    if (pass == "")
            //    {
            //        lblthongbao.InnerText = "Bạn cần nhập mật khẩu!";
            //        txtpassword.Focus();
            //    }
            //    else
                {
                    string constr = ConfigurationManager.ConnectionStrings["ConnectionStringWebSurvey"].ConnectionString;
                    string sql = "Select * from tblUser where userName = '" + name + "' and passWord = '" + pass + "'";
                    using (SqlConnection cnn = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand(sql, cnn))
                        {
                            cnn.Open();
                            cmd.CommandType = System.Data.CommandType.Text;
                            SqlDataReader dr = cmd.ExecuteReader();
                            if (dr.HasRows)
                            {
                                Session["user"] = 1;

                                while (dr.Read())
                                {
                                    Application["userid"] = dr.GetInt32(0);
                                    Response.Redirect("TrangChu.aspx");
                                }
                            }
                            else
                            {
                                lblthongbao.InnerText = "Nhập sai";
                            }
                            cnn.Close();
                        }
                    }
                }
            }
        }
    }
