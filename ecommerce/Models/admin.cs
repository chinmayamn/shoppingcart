using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;
/// <summary>
/// Summary description for admin
/// </summary>menty
/// 
namespace ecommerce.Models
{
    public class admin
    {
        string str = ConfigurationManager.ConnectionStrings["cons"].ToString();
        public admin()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataTable getdefaultshippingtax()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getdefaultshippingtax", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            return ds;
        }

        public DataTable getuserspassword(Guid user)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getuserspassword", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user", user);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            return ds;
        }
        public DataTable fillsimiliar(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_fillsimiliar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            return ds;
        }
        public DataTable deletenewsuser(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_deletenewsuser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            return ds;
        }

        public DataTable filllikethis(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_filllikethis", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            return ds;
        }


        public DataTable getfreeshippinguser()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getfreeshippinguser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            return ds;
        }
        public void deleteuser(string y)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_deleteuser", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@y", y);


            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void addshippingtax(string shipping, string tax)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_addshippingtax", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@shipping", shipping);
            cmd.Parameters.AddWithValue("@Tax", tax);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deleteshippingtax(string shipping)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_deleteshippingtax", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@shipping", shipping);


            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void updateproductview(string type, string id, string value)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_updateproductview", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@value", value);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable brandfilter(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_brandfilter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ssid", id);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable getnewarrivals()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getnewarrivals", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable gettop4newarrivals()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_gettop4newarrivals", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable getexclusive()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getexclusive", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable gettop6exclusive()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_gettop6exclusive", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable getentertainmentgadgets()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getentertainment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable gettop4entertainmentgadgets()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_gettop4entertainment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable gethotoffers()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_gethotoffers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable gettop6hotoffers()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_gettop6hotoffers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable getproductsbycombination(int cid, int sid, int ssid)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getproductsbycombination", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ssid", ssid);
            cmd.Parameters.AddWithValue("@sid", sid);
            cmd.Parameters.AddWithValue("@cid", cid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable brandfiltersub(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_brandfiltersub", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sid", id);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable getproductsbyid(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getproductsbyid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable getcolorfilterbyid(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getcolorfilterbyid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable getsizefilterbyid(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getsizefilterbyid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable getcategorydatabysub(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getcategorydatabysub", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sid", id);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable getcategorydata(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getcategorydata", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ssid", id);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable getnavigation(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getnavigation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ssid", id);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable getnavigation1(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getnavigation1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cid", id);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable getnavigation2(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getnavigation2", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sid", id);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable getproductnavigate(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_productnavigate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }





        public DataTable getsubsubcategorywithcountbysubcategory(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getsubsubcategorywithcountbysubcategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
       
        public DataTable getsubsubcategorybysubcategoryuser(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getsubsubcategorybysubcategoryuser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public DataTable checkuser(string user, string pass)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_checkusers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public DataTable getuserpassword(string user)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getuserpassword", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user", user);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }



        public void deleteproduct(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_deleteproduct", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);


            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void updatecategoryadmin(string pos, string t)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_updatecategoryadmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@pos", pos);

            cmd.Parameters.AddWithValue("@t", t);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void updateuserpassword(string user, string pass)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_updateuserpassword", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);

            cmd.ExecuteNonQuery();
            con.Close();

        }









        public DataTable getsubcategorybycategoryuser(int id)
        {

            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getsubcategorybycategoryuser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }




        public DataTable checkproducts(int id)
        {

            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_checkproducts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable getproductbysubcategoryuser(int id)
        {

            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getproductbysubcategoryuser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sid", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable fillcategoryuser()
        {

            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_fillcategoryuser", con);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public DataTable fillleftcategory()
        {

            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_fillleftcategory", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
            con.Close();
        }
        public DataTable fillrightcategory()
        {

            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_fillrightcategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void updatepassword(string pass)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_updatepassword", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@pass", pass);

            cmd.ExecuteNonQuery();
            con.Close();

        }

        public DataTable getadsbyposition(string type)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getadsbyposition", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@type", type);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public DataTable getadminlogin()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getadminlogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        public DataTable GetHomePageProducts(int no)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_gethomepageproducts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@no", no);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }


    }
}