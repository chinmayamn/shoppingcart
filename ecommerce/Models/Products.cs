using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;
/// <summary>
/// Summary description for Products
/// </summary>
namespace ecommerce.Models
{
    public class Products
    {
        public Products()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        private int _id;
        private int _CategoryId;
        private int _SubCategoryId;
        private int _SubSubCategoryId;
        private string _Image;
        private string _ProductName;
        private int _Discount;
        private int _MrpPrice;
        private int _ActualPrice;
        private int _Rating;
        private string _Availability;
        private string _Details;
        private string _Reviews;
        private int _Brand;
        private string _ShortText;
        private string _Video;
        private string _Color;
        private string _Size;
        private int _NewArrival;
        private int _Entertainment;
        private int _HotOffers;
        private int _Exclusive;
        private float _Tax;


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int CategoryId
        {
            get { return _CategoryId; }
            set { _CategoryId = value; }
        }


        public int SubCategoryId
        {
            get { return _SubCategoryId; }
            set { _SubCategoryId = value; }
        }


        public int SubSubCategoryId
        {
            get { return _SubSubCategoryId; }
            set { _SubSubCategoryId = value; }
        }



        public string Image
        {
            get { return _Image; }
            set { _Image = value; }
        }


        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }


        public int Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }


        public int MrpPrice
        {
            get { return _MrpPrice; }
            set { _MrpPrice = value; }
        }

        public int ActualPrice
        {
            get { return _ActualPrice; }
            set { _ActualPrice = value; }
        }


        public int Rating
        {
            get { return _Rating; }
            set { _Rating = value; }
        }


        public string Availability
        {
            get { return _Availability; }
            set { _Availability = value; }
        }


        public string Details
        {
            get { return _Details; }
            set { _Details = value; }
        }

        public string Reviews
        {
            get { return _Reviews; }
            set { _Reviews = value; }
        }


        public int Brand
        {
            get { return _Brand; }
            set { _Brand = value; }
        }

        public string ShortText
        {
            get { return _ShortText; }
            set { _ShortText = value; }
        }


        public string Video
        {
            get { return _Video; }
            set { _Video = value; }
        }


        public string Color
        {
            get { return _Color; }
            set { _Color = value; }
        }

        public string Size
        {
            get { return _Size; }
            set { _Size = value; }
        }


        public int NewArrival
        {
            get { return _NewArrival; }
            set { _NewArrival = value; }
        }

        public int Entertainment
        {
            get { return _Entertainment; }
            set { _Entertainment = value; }
        }


        public int HotOffers
        {
            get { return _HotOffers; }
            set { _HotOffers = value; }
        }


        public int Exclusive
        {
            get { return _Exclusive; }
            set { _Exclusive = value; }
        }


        public float Tax
        {
            get { return _Tax; }
            set { _Tax = value; }
        }
        public DataTable getproductbyid(int id)
        {
            SqlConnection con = new SqlConnection(WebsiteSettings.DBConnectionString);
            SqlCommand cmd = new SqlCommand("sp_getproductbyid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void addproductpreview(string image, int id)
        {
            SqlConnection con = new SqlConnection(WebsiteSettings.DBConnectionString);
            SqlCommand cmd = new SqlCommand("sp_addproductpreview", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@image", image);
            cmd.Parameters.AddWithValue("@id", id);


            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable getproductpreview(int id)
        {
            SqlConnection con = new SqlConnection(WebsiteSettings.DBConnectionString);
            SqlCommand cmd = new SqlCommand("sp_getproductpreview", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable deleteproductpreview(int id)
        {
            SqlConnection con = new SqlConnection(WebsiteSettings.DBConnectionString);
            SqlCommand cmd = new SqlCommand("sp_deleteproductpreview", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable getproducts()
        {
            SqlConnection con = new SqlConnection(WebsiteSettings.DBConnectionString);
            SqlCommand cmd = new SqlCommand("sp_getproducts", con);
            cmd.CommandType = CommandType.StoredProcedure;


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void addproduct(string cat, string subcat, string subsubcat, string name, string image, string mrp, string actual, string discount, string avail, string brand, string intro, string youtube, string review, string details, string rating, string color, string size, int a, int b, int c, int d, string t)
        {
            SqlConnection con = new SqlConnection(WebsiteSettings.DBConnectionString);
            SqlCommand cmd = new SqlCommand("sp_addproduct", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@cat", cat);
            cmd.Parameters.AddWithValue("@subcat", subcat);
            cmd.Parameters.AddWithValue("@subsubcat", subsubcat);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@image", image);
            cmd.Parameters.AddWithValue("@mrp", mrp);
            cmd.Parameters.AddWithValue("@actual", actual);
            cmd.Parameters.AddWithValue("@discount", discount);
            cmd.Parameters.AddWithValue("@avail", avail);
            cmd.Parameters.AddWithValue("@brand", brand);
            cmd.Parameters.AddWithValue("@intro", intro);
            cmd.Parameters.AddWithValue("@youtube", youtube);
            cmd.Parameters.AddWithValue("@review", review);
            cmd.Parameters.AddWithValue("@details", details);
            cmd.Parameters.AddWithValue("@rating", rating);
            cmd.Parameters.AddWithValue("@color", color);
            cmd.Parameters.AddWithValue("@size", size);
            cmd.Parameters.AddWithValue("@a", a);
            cmd.Parameters.AddWithValue("@b", b);
            cmd.Parameters.AddWithValue("@c", c);
            cmd.Parameters.AddWithValue("@d", d);

            cmd.Parameters.AddWithValue("@t", t);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void updateproduct(int id, string cat, string subcat, string subsubcat, string name, string image, string mrp, string actual, string discount, string avail, string brand, string intro, string youtube, string review, string details, string rating, string color, string size, int a, int b, int c, int d, string t)
        {
            SqlConnection con = new SqlConnection(WebsiteSettings.DBConnectionString);
            SqlCommand cmd = new SqlCommand("sp_updateproduct", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@cat", cat);
            cmd.Parameters.AddWithValue("@subcat", subcat);
            cmd.Parameters.AddWithValue("@subsubcat", subsubcat);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@image", image);
            cmd.Parameters.AddWithValue("@mrp", mrp);
            cmd.Parameters.AddWithValue("@actual", actual);
            cmd.Parameters.AddWithValue("@discount", discount);
            cmd.Parameters.AddWithValue("@avail", avail);
            cmd.Parameters.AddWithValue("@brand", brand);
            cmd.Parameters.AddWithValue("@intro", intro);
            cmd.Parameters.AddWithValue("@youtube", youtube);
            cmd.Parameters.AddWithValue("@review", review);
            cmd.Parameters.AddWithValue("@details", details);
            cmd.Parameters.AddWithValue("@rating", rating);
            cmd.Parameters.AddWithValue("@color", color);
            cmd.Parameters.AddWithValue("@size", size);
            cmd.Parameters.AddWithValue("@a", a);
            cmd.Parameters.AddWithValue("@b", b);
            cmd.Parameters.AddWithValue("@c", c);
            cmd.Parameters.AddWithValue("@d", d);

            cmd.Parameters.AddWithValue("@t", t);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable getproductbysubsubcategory(int id)
        {
            SqlConnection con = new SqlConnection(WebsiteSettings.DBConnectionString);
            SqlCommand cmd = new SqlCommand("sp_getproductbysubsubcategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}