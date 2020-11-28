using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;
/// <summary>
/// Summary description for Newsletter
/// </summary>
namespace ecommerce.Models
{
    public class Newsletter
    {
        string str = ConfigurationManager.ConnectionStrings["cons"].ToString();
        public Newsletter()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        private int _id;
        private string _email;
        private string _date;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }


        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public DataTable getnewsletters()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getnewsletter", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            return ds;
        }
        public DataTable checknewsletter(string email)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_checknewsletter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", email);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            return ds;
        }

        public void addnewsletter(string email)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_addnewsletter", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", email);


            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}