using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;


/// <summary>
/// Summary description for Banner
/// </summary>
namespace ecommerce.Models
{
    public class Banner
    {
        string str = ConfigurationManager.ConnectionStrings["cons"].ToString();

        public Banner()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataTable getbanner()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getbanner", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public void deletebannerimage(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_deletebannerimage", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);


            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void addbannerimage(string image, string text)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_insertbannerimage", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@image", image);

            cmd.Parameters.AddWithValue("@text", text);
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
}