using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebSurvey
{
    public partial class LamKhaoSat : System.Web.UI.Page
    {
        class Global
        {
            public static List<int> idcauhoi = new List<int>();
            public static List<int> cautraloi = new List<int>();
            public static int socauhoi = 0;

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //if ((int)Session["user"] == 0)
            //{
            //    var page = HttpContext.Current.CurrentHandler as Page;
            //    ScriptManager.RegisterStartupScript(page, page.GetType(), "alert", "alert('Bạn cần đăng nhập để làm khảo sát!'); window.location = 'DangNhap.aspx';", true);
            //}

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
                string sqlSelectQuestion = "Select questionName, typeAnswer, questionId from tblTopic inner join tblQuestion on tblTopic.topicId = tblQuestion.topicId where topicName = N'" + tenkhaosat + "' and createUserId = " + createUserId + "";
                using (SqlConnection cnn = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlSelectQuestion, cnn))
                    {
                        cnn.Open();
                        cmd.CommandType = System.Data.CommandType.Text;
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            int i = 1;
                            while (dr.Read())
                            {
                                
                                string quesName = dr.GetString(0);
                                int ansType = dr.GetInt32(1);
                                int quesId = dr.GetInt32(2);

                                System.Web.UI.HtmlControls.HtmlGenericControl createDiv =
                                    new System.Web.UI.HtmlControls.HtmlGenericControl("Div");
                                createDiv.ID = "createDiv" + i;
                                createDiv.Attributes.Add("name", "div"+i);
                                //hien stt
                                Label lblquesnum = new Label();
                                lblquesnum.Text = "Câu " + i + ": ";
                                createDiv.Controls.Add(lblquesnum);
                                //hien ten cau hoi
                                Label lblquestion = new Label();
                                lblquestion.Text = quesName;
                                createDiv.Controls.Add(lblquestion);

                                //hien radio
                                Label lblradio1 = new Label();
                                Label lblradio2 = new Label();
                                createDiv.Controls.Add(new LiteralControl("<br />"));
                                
                                if (ansType == 1)
                                {
                                    
                                    lblradio1.Text = "Có ";
                                    lblradio2.Text = "Không ";
                                }
                                else
                                {
                                    lblradio1.Text = "Đồng ý ";
                                    lblradio2.Text = "Không đồng ý ";
                                }
                                HtmlInputRadioButton radio1 = new HtmlInputRadioButton();
                                radio1.ID = "rd" + i +"_1";
                                radio1.Value = "1";
                                radio1.Checked = true;
                                radio1.Name = "RadioSet"+i;
                                createDiv.Controls.Add(radio1);
                                createDiv.Controls.Add(lblradio1);

                                //hien khoagn cach


                                HtmlInputRadioButton radio2 = new HtmlInputRadioButton();
                                radio2.ID = "rd" + i + "_2";
                                radio2.Value = "2";
                                radio2.Checked = false;
                                radio2.Name = "RadioSet"+i;
                                createDiv.Controls.Add(radio2);
                                createDiv.Controls.Add(lblradio2); 
                                noidungkhaosat.Controls.Add(createDiv);

                                //
                                Global.idcauhoi.Add(quesId);

                                i++;
                            }
                            Global.socauhoi = i-1;
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
            for(int i = 0; i < Global.socauhoi; i++)
            lblthongbao.InnerText = Global.idcauhoi[i].ToString();
        }
    }
}