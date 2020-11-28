using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Filter
/// </summary>
namespace ecommerce.Models
{
    public class Filter
    {
        string str = ConfigurationManager.ConnectionStrings["cons"].ToString();
        public Filter()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        private int _id;
        private string _FilterName;
        private string _FilterValue;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string FilterName
        {
            get { return _FilterName; }
            set { _FilterName = value; }
        }


        public string FilterValue
        {
            get { return _FilterValue; }
            set { _FilterValue = value; }
        }

        public DataTable fillFiltermaster()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_fillfiltermaster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable getfiltermasterbyid(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getfiltermasterbyid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void updatefiltermaster(string filtername, int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_updatefiltermaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@filtername", filtername);

            cmd.Parameters.AddWithValue("@id", id);


            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deletefiltermaster(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_deletefiltermaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            cmd.Parameters.AddWithValue("@id", id);


            cmd.ExecuteNonQuery();
            con.Close();
        }


        public void addfiltermaster(string filtername)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_addfiltermaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@filtername", filtername);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        /* filter */
        public DataTable fillFilter()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_fillfilter", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable getfilterbyid(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getfilterbyid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable fillfilterbytype(string type)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_fillfilterbytype", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@type", type);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void updatefilter(int filterid, string filtervalue, int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_updatefilter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@filterid", filterid);
            cmd.Parameters.AddWithValue("@filtervalue", filtervalue);
            cmd.Parameters.AddWithValue("@id", id);


            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deletefilter(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_deletefilter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            cmd.Parameters.AddWithValue("@id", id);


            cmd.ExecuteNonQuery();
            con.Close();
        }



        public void addfilter(string filtervalue, int filter)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_addfilter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@filter", filter);
            cmd.Parameters.AddWithValue("@filtervalue", filtervalue);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}