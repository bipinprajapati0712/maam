using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studentmgmt_BO;
using Studentmgmt_DAL;

namespace StudentMgmt_UI
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string city = ddlCity.SelectedItem.Value;

            Student s = new Student(name, city);
            Dboperation db = new Dboperation();
            int studentid = db.Register(s);
            if(studentid>0)
            {

                Response.Write("<script>alert('Added successfully with the id" + studentid + "')</script>");

            }
            else
                Response.Write("<script>alert('something went wrong')</script>");
            //Response.Write("Added successfully with the id" + studentid);



        }
    }
}
