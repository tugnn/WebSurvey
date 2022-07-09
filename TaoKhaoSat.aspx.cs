using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace WebSurvey
{
    public partial class TaoKhaoSat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if((int)Session["user"] == 0)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                ScriptManager.RegisterStartupScript(page, page.GetType(), "alert", "alert('Bạn cần đăng nhập để tạo khảo sát!'); window.location = 'DangNhap.aspx';", true);
            }
            Application["socauhoi"] = 0;

        }
        protected void btnluu_click(object sender, EventArgs e)
        {
            int createUserId = (int)Application["userid"];
            string constr = ConfigurationManager.ConnectionStrings["ConnectionStringWebSurvey"].ConnectionString;
            string topicName = txtchude.Value;
            //insert topic
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                string sqlInsertTopic = "Insert into tblTopic (topicName, createUserId) values ('" + topicName + "', " + createUserId + ")";
                string sqlSelectTopic = "Select * from tblTopic";
                SqlDataAdapter adapter = new SqlDataAdapter(sqlSelectTopic, cnn);
                DataTable dtTopic = new DataTable();
                adapter.Fill(dtTopic);
                using (SqlCommand cmd = new SqlCommand(sqlInsertTopic, cnn))
                {
                    cnn.Open();
                    cmd.CommandType = CommandType.Text;
                    int c = cmd.ExecuteNonQuery();
                    if (c != 0)
                    {
                        lbltest.InnerText = "Da luu";
                    }
                    cnn.Dispose();
                    cnn.Close();
                }

            }
            //string sch = txtsocauhoi.Value;


            // Lay topicId vua insert
            int topicId = 0;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                string sqlSelectTopicId = "Select * from tblTopic where topicName ='" + topicName + "'";
                using (SqlCommand cmd = new SqlCommand(sqlSelectTopicId, cnn))
                {
                    cnn.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        topicId = dr.GetInt32(0);
                    }
                    cnn.Close();
                }
            }

            //insert question
            int socauhoi = int.Parse(txtsocauhoi.Value);
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                for (int i = 1; i <= socauhoi; i++)
                {
                    var noidung = Request.Form["txtcauhoi" + i];
                    var dangcautraloi = Request.Form["dangcautraloi" + i];
                    string sqlInsertQuestion = "Insert into tblQuestion (topicId, questionName, typeAnswer) values (" + topicId + ", '" + noidung + "', " + dangcautraloi + ")";
                    string sqlSelectQuestion = "Select * from tblQuestion";
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlSelectQuestion, cnn);
                    DataTable dtTopic = new DataTable();
                    adapter.Fill(dtTopic);
                    using (SqlCommand cmd = new SqlCommand(sqlInsertQuestion, cnn))
                    {
                        cmd.CommandType = CommandType.Text;
                        int c = cmd.ExecuteNonQuery();
                        if (c != 0)
                        {
                            lbltest.InnerText = "Da luu";
                        }
                    }

                }
                cnn.Close();
            }

        }
    }
}