using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studentmgmt_DAL;

namespace StudentMgmt_UI
{
    public partial class Details : System.Web.UI.Page
    {
        Dboperation db = new Dboperation();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                showData();
            }


        }

        public void showData()
        {
            GridView1.DataSource = db.Details();
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("del"))
            {
                int id = Convert.ToInt32(e.CommandArgument);
                int rowaff = db.Delete(id);
                if (rowaff > 0)
                {
                    showData();
                    Response.Write("<script>alert('Deleted successfully')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Unsuccess')</script>");
                }
            }

            else
            {

            }

        }
    }
}
