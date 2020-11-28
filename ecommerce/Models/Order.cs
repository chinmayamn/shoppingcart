using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Order
/// </summary>
namespace ecommerce.Models
{
    public class Order
    {
        string str = ConfigurationManager.ConnectionStrings["cons"].ConnectionString;
        public Order()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        private int _id;
        private string _userid;
        private string _name;
        private string _address;
        private string _landmark;
        private string _city;
        private string _state;
        private string _postal;
        private string _mobile;
        private string _country;
        private string _date;
        private string _status;
        private string _paymentmethod;
        private string _shipping;
        private string _email;
        private int _isdelete;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


        public string Userid
        {
            get { return _userid; }
            set { _userid = value; }
        }


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string Landmark
        {
            get { return _landmark; }
            set { _landmark = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string State
        {
            get { return _state; }
            set { _state = value; }
        }

        public string Postal
        {
            get { return _postal; }
            set { _postal = value; }
        }


        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string Paymentmethod
        {
            get { return _paymentmethod; }
            set { _paymentmethod = value; }
        }

        public string Shipping
        {
            get { return _shipping; }
            set { _shipping = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }


        public int Isdelete
        {
            get { return _isdelete; }
            set { _isdelete = value; }
        }

        public DataTable getorders(string id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getorders", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            return dt;
        }
        public DataTable getordersproduct(string id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getordersproduct", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            return dt;
        }
        public DataTable getwishlistuser(string userid)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getwishlistuser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", userid);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            return dt;
        }
        public void insertwishlist(string user, int p, string brand, string size, string color, string qty)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_insertwishlist", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", user);
            cmd.Parameters.AddWithValue("@p", p);
            cmd.Parameters.AddWithValue("@brand", brand);
            cmd.Parameters.AddWithValue("@size", size);
            cmd.Parameters.AddWithValue("@color", color);
            cmd.Parameters.AddWithValue("@qty", qty);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void removewishlistuser(int id)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_removewishlistuser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void removewishlistuser(string userid, int id)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_removewishlistuser1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable getorderdet(string userid)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getorderdet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", userid);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            return dt;
        }
        public DataTable Insertorder(string userid, string name, string Address, string landmark, string City, string state, string postal, string mobile, string Country, string email)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_InsertOrder", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", userid);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@landmark", landmark);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@state", state);
            cmd.Parameters.AddWithValue("@postal", postal);
            cmd.Parameters.AddWithValue("@mobile", mobile);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@email", email);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
        public DataTable Updateorder(string id, string userid, string name, string Address, string landmark, string City, string state, string postal, string mobile, string Country, string email)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_UpdateOrder", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@landmark", landmark);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@state", state);
            cmd.Parameters.AddWithValue("@postal", postal);
            cmd.Parameters.AddWithValue("@mobile", mobile);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@email", email);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        public DataTable Select_orderbyuserid(string userid)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_select_orderid_byuserid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", userid);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            return dt;
        }



        public DataTable select_ordersid(string orders_id)
        {

            // selecting the order

            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_select_orders_id", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@orders_id", orders_id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;


        }

        public void update_delivary_address(string orders_id, string delivery_firstname, string delivery_lastname, string delivery_email, string delivery_address, string delivery_city, string delivery_state, string delivery_country, string delivery_phone, string delivery_mobile)
        {

            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_update_orders_delivery", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@orders_id", orders_id);
            cmd.Parameters.AddWithValue("@delivery_firstname", delivery_firstname);
            cmd.Parameters.AddWithValue("@delivery_lastname", delivery_lastname);
            cmd.Parameters.AddWithValue("@delivery_email", delivery_email);
            cmd.Parameters.AddWithValue("@delivery_address", delivery_address);

            cmd.Parameters.AddWithValue("@delivery_city", delivery_city);

            cmd.Parameters.AddWithValue("@delivery_state", delivery_state);
            cmd.Parameters.AddWithValue("@delivery_country", delivery_country);
            cmd.Parameters.AddWithValue("@delivery_phone", delivery_phone);
            cmd.Parameters.AddWithValue("@delivery_mobile", delivery_mobile);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void update_paymentmethod(string orders_id, string payment_method)
        {

            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_upd_payment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@orders_id", orders_id);
            cmd.Parameters.AddWithValue("@payment_method", payment_method);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void updateorderstatusvisible(int id)
        {

            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_updateorderstatusvisible", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@orders_id", id);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deleteordersummary(int id)
        {

            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_deleteordersummary", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Insertproduct_order(string orderid, string pid, string pname, string pimage, string qty, string discount, string linetotal, string color, string size, string price, string brand, string date, string tax)
        {

            //inserting category

            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_insert_into_order_prod", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@orderid", orderid);
            cmd.Parameters.AddWithValue("@pid", pid);
            cmd.Parameters.AddWithValue("@pname", pname);
            cmd.Parameters.AddWithValue("@pimage", pimage);
            cmd.Parameters.AddWithValue("@qty", qty);
            cmd.Parameters.AddWithValue("@discount", discount);
            cmd.Parameters.AddWithValue("@linetotal", linetotal);
            cmd.Parameters.AddWithValue("@color", color);
            cmd.Parameters.AddWithValue("@size", size);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@brand", brand);
            cmd.Parameters.AddWithValue("@date", date);

            cmd.Parameters.AddWithValue("@tax", tax);
            cmd.ExecuteNonQuery();
            con.Close();

        }


        public DataTable prod_disp_id(string products_id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_select_prod_by_id", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@products_id", products_id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable ds = new DataTable();
            da.Fill(ds);
            return ds;

        }



        public DataTable select_order_userid(string userid)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_select_orderid_byuserid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", userid);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            ad.Fill(dt);

            return dt;
        }

        public DataSet select_order(string userid)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_select_orderid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", userid);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);

            DataSet dt = new DataSet();
            ad.Fill(dt);

            return dt;
        }


        public void Insertproduct_order(string orders_id, string products_id, string products_name, string products_price, string final_price, string products_quantity, string city1, string city2, string discount)
        {

            //inserting category

            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_insert_into_order_prod", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@orders_id", orders_id);
            cmd.Parameters.AddWithValue("@products_id", products_id);
            cmd.Parameters.AddWithValue("@products_name", products_name);
            cmd.Parameters.AddWithValue("@products_price", Convert.ToDecimal(products_price));
            cmd.Parameters.AddWithValue("@final_price", Convert.ToDecimal(final_price));


            cmd.Parameters.AddWithValue("@products_quantity", Convert.ToInt32(products_quantity));
            cmd.Parameters.AddWithValue("@city1", city1);
            cmd.Parameters.AddWithValue("@city2", city2);
            cmd.Parameters.AddWithValue("@discount", discount);
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
}