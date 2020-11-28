using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace ecommerce.Models
{
    public class Category
    {
        string str = ConfigurationManager.ConnectionStrings["cakeconnection"].ToString();
        public Category()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        private int _id;
        private string _categoryname;
        private int _parentid;
        private int _visible;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string CategoryName
        {
            get { return _categoryname; }
            set { _categoryname = value; }
        }

        public int Parentid
        {
            get { return _parentid; }
            set { _parentid = value; }
        }


        public int Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }
        public DataTable fillcategory()
        {

            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_fillcategory", con);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public DataTable fillsubcategory(int id)
        {

            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_fillsubcategorybycategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable fillsubcategory()
        {

            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_fillsubcategory", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void createsubcategory(string id, string name)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_createsubcategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);

            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void addsubcategory(string cat, string subcat)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_addsubcategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@cat", cat);
            cmd.Parameters.AddWithValue("@subcat", subcat);


            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void updatesubcategory(string id, string cat, string subcat)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_updatesubcategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@cat", cat);
            cmd.Parameters.AddWithValue("@subcat", subcat);


            cmd.ExecuteNonQuery();
            con.Close();

        }

        public DataTable checksubcategory(int id)
        {

            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_checksubcategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /*subcategory ends */
        public void deletecategory(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_deletecategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void updatecategory(int id, string name)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_updatecategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public DataTable getsubsubcategorybyid(int id)
        {

            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getsubsubcategorybyid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable getcategorybyid(int id)
        {

            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getcategorybyid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable getsubcategorybyid(int id)
        {

            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getsubcategorybyid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void createcategory(string name)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_createcategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@name", name);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public DataTable getsubsubcategory()
        {

            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getsubsubcategory", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable getsubcategorybycategory(int id)
        {

            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getsubcategorybycategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable getsubsubcategorybysubcategory(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getsubsubcategorybysubcategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
    }
}