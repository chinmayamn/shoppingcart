using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;


/// <summary>
/// Summary description for Ads
/// </summary>
namespace ecommerce.Models
{
    public class Ads
    {
        string str = ConfigurationManager.ConnectionStrings["cons"].ToString();

        public Ads()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        private int _id;
        private string _Position;
        private string _Image;
        private string _Link;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Position
        {
            get { return _Position; }
            set { _Position = value; }
        }

        public string Image
        {
            get { return _Image; }
            set { _Image = value; }
        }


        public string Link
        {
            get { return _Link; }
            set { _Link = value; }
        }
        public DataTable fillads()
        {

            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_fillads", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable addcount(string pos)
        {

            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_addcount", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pos", pos);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void addads(string pos, string image, string link)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_addads", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@pos", pos);
            cmd.Parameters.AddWithValue("@image", image);
            cmd.Parameters.AddWithValue("@link", link);

            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void deletead(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_deletead", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void updatead(string id, string pos, string image, string link)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_updatead", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@pos", pos);
            cmd.Parameters.AddWithValue("@image", image);
            cmd.Parameters.AddWithValue("@link", link);

            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void updatead(string id, string pos, string link)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_updateadwithoutimage", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@pos", pos);

            cmd.Parameters.AddWithValue("@link", link);

            cmd.ExecuteNonQuery();
            con.Close();

        }
        public DataTable getadsbyid(int id)
        {

            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getadsbyid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}