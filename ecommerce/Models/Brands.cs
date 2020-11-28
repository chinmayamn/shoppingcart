using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;
/// <summary>
/// Summary description for Brands
/// </summary>
namespace ecommerce.Models
{
    public class Brands
    {
        string str = ConfigurationManager.ConnectionStrings["cons"].ToString();

        public Brands()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        private int _id;
        private string _BrandName;
        private string _BrandImage;
        private string _BrandDetails;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string BrandName
        {
            get { return _BrandName; }
            set { _BrandName = value; }
        }

        public string BrandImage
        {
            get { return _BrandImage; }
            set { _BrandImage = value; }
        }


        public string BrandDetails
        {
            get { return _BrandDetails; }
            set { _BrandDetails = value; }
        }
        public void addbrand(string name, string desc, string image)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_addbrand", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@desc", desc);
            cmd.Parameters.AddWithValue("@image", image);

            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void deletebrand(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_deletebrand", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void updatebrand(string id, string name, string desc, string image)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_updatebrand", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@desc", desc);
            cmd.Parameters.AddWithValue("@image", image);

            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void updatebrand(string id, string name, string desc)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_updatebrandwithoutimage", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@desc", desc);


            cmd.ExecuteNonQuery();
            con.Close();

        }
        public DataTable getbrandsbyid(int id)
        {

            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getbrandsbyid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable checkproductbrand(int id)
        {

            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_checkproductbrand", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable fillbrands()
        {

            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_fillbrands", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}