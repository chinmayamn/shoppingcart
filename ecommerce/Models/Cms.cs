using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Cms
/// </summary>
namespace ecommerce.Models
{
    public class Cms
    {
        string str = ConfigurationManager.ConnectionStrings["cons"].ToString();
        public Cms()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        private int _id;
        private string _type;
        private string _description;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }


        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public DataTable getaboutus(string type)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getaboutus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@type", type);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public void insertaboutus(string type, string desc)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_insertaboutus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@text", desc);
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
}