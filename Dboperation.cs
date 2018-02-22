using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Studentmgmt_BO;
using System.Data.SqlClient;
using System.Data;


namespace Studentmgmt_DAL
{
    public class Dboperation
    {
        public int Register(Student sobj)
        {
            //1. open sqlconnection
            SqlConnection con = new SqlConnection("server=intvmsql01;user id=pj01test01;password=tcstvm;database=db01test01");
            con.Open();

            SqlCommand cmd = new SqlCommand("sp_register_stu", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@stuname", sobj.Name);
            cmd.Parameters.AddWithValue("@stucity", sobj.City);

            cmd.Parameters.AddWithValue("@stuid", 0);
            cmd.Parameters["@stuid"].Direction = ParameterDirection.Output;
            int rowaffected = cmd.ExecuteNonQuery();
            if (rowaffected > 0)
            {
                int studentid = Convert.ToInt32(cmd.Parameters["@stuid"].Value);
                return studentid;
            }
            else { return 0; }

        }

        public List<Student> Details()
        {
            //1. open sqlconnection
            SqlConnection con = new SqlConnection("server=intvmsql01;user id=pj01test01;password=tcstvm;database=db01test01");
            con.Open();

            SqlCommand cmd = new SqlCommand("sp_view_student", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();
            List<Student> lststudent = new List<Student>();
            while (reader.Read())
            {
                Student s = new Student();
                s.Id = Convert.ToInt32(reader["id"]);
                s.Name = reader["name"].ToString();
                s.City = reader["city"].ToString();
                lststudent.Add(s);

            }

            return lststudent;


        }

        public int Delete(int id)
        {
            //1. open sqlconnection
            SqlConnection con = new SqlConnection("server=intvmsql01;user id=pj01test01;password=tcstvm;database=db01test01");
            con.Open();

            SqlCommand cmd = new SqlCommand("sp_del_stu", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@stuid",id );
           
            int rowaffected = cmd.ExecuteNonQuery();
            return rowaffected;

        }
    }
}
