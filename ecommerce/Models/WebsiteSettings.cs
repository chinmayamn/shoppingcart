using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;
/// <summary>
/// Summary description for WebsiteSettings
/// </summary>
namespace ecommerce.Models
{
    public class WebsiteSettings
    {
        string str = ConfigurationManager.ConnectionStrings["cons"].ToString();
        public WebsiteSettings()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        private string _title;
        private string _keywords;
        private string _description;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string Keywords
        {
            get { return _keywords; }
            set { _keywords = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public DataTable getwebsitesettings()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getwebsitesettings", con);
            cmd.CommandType = CommandType.StoredProcedure;


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public void updatewebsitesettings(string title, string key, string desc)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_updatewebsitesettings", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@key", key);
            cmd.Parameters.AddWithValue("@desc", desc);
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
}