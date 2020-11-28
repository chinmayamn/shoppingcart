using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;
/// <summary>
/// Summary description for Freeshipping
/// </summary>
namespace ecommerce.Models
{
    public class Freeshipping
    {
        string str = ConfigurationManager.ConnectionStrings["cons"].ToString();
        public Freeshipping()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        private int _id;
        private int _price;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public DataTable freeshipping()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_freeshipping", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            return ds;
        }
        public DataTable getfreeshippingbyid(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_gtfreeshippingbyid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            return ds;
        }
        public void addfreeshipping(string value)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_addfreeshipping", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@value", value);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void updatefreeshipping(int id, string value)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_updatefreeshipping", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@value", value);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deletefreeshipping(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_deletefreeshipping", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}