using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSurvey
{
    public partial class LamKhaoSat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)Session["user"] == 0)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                ScriptManager.RegisterStartupScript(page, page.GetType(), "alert", "alert('Bạn cần đăng nhập để làm khảo sát!'); window.location = 'DangNhap.aspx';", true);
            }
        }

        protected void btntim_click(object sender, EventArgs e)
        {
            int kt = 0;
            int createUserId = 0;
            string constr = ConfigurationManager.ConnectionStrings["ConnectionStringWebSurvey"].ConnectionString;
            //lay id nguoi tao
            string nguoitaokhaosat = txtnguoitaokhaosat.Value;

            string sql = "Select userId from tblUser where userName = '" + nguoitaokhaosat + "'";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cnn.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            createUserId = dr.GetInt32(0);
                            kt = 1;
                        }
                    }
                    cnn.Close();
                }
            }
            if (kt == 1)
            {

                //lay bai khao sat
                string tenkhaosat = txttenkhaosat.Value;
                string sqlSelectQuestion = "Select questionName, typeAnswer from tblTopic inner join tblQuestion on tblTopic.topicId = tblQuestion.topicId where topicName = '" + tenkhaosat + "' and createUserId = " + createUserId + "";
                using (SqlConnection cnn = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlSelectQuestion, cnn))
                    {
                        cnn.Open();
                        cmd.CommandType = System.Data.CommandType.Text;
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            int i = 0;
                            while (dr.Read())
                            {
                                string quesName = dr.GetString(0);
                                int ansType = dr.GetInt32(1);

                                System.Web.UI.HtmlControls.HtmlGenericControl createDiv =
                                    new System.Web.UI.HtmlControls.HtmlGenericControl("Div");
                                createDiv.ID = "createDiv" + i;
                                createDiv.Attributes.Add("name", "div1");
                                Label lbl1 = new Label();
                                lbl1.Text = quesName;
                                createDiv.Controls.Add(lbl1);

                                noidungkhaosat.Controls.Add(createDiv);

                                i++;
                            }
                            lblthongbao.InnerText = "Có khảo sát!";
                        }
                        cnn.Close();
                    }
                }
            }
            else
            {
                lblthongbao.InnerText = "Không tìm thấy bài khảo sát!";
            }

        }
        protected void btngui_click(object sender, EventArgs e)
        {

        }
    }
}