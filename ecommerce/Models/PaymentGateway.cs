using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;
/// <summary>
/// Summary description for PaymentGateway
/// </summary>
namespace ecommerce.Models
{
    public class PaymentGateway
    {
        string str = ConfigurationManager.ConnectionStrings["cons"].ToString();

        public PaymentGateway()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        private string _Paypal;
        private string _TimesofMoney;
        private string _EBS;
        private string _TechProcess;
        private string _Booking;



        public string Paypal
        {
            get { return _Paypal; }
            set { _Paypal = value; }
        }
        public string TimesofMoney
        {
            get { return _TimesofMoney; }
            set { _TimesofMoney = value; }
        }
        public string EBS
        {
            get { return _EBS; }
            set { _EBS = value; }
        }
        public string TechProcess
        {
            get { return _TechProcess; }
            set { _TechProcess = value; }
        }
        public string Booking
        {
            get { return _Booking; }
            set { _Booking = value; }
        }
        public void addpaymentgateway(int a, int b, int c, int d, int e)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_addpaymentgateway", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@a", a);
            cmd.Parameters.AddWithValue("@b", b);
            cmd.Parameters.AddWithValue("@c", c);
            cmd.Parameters.AddWithValue("@d", d);
            cmd.Parameters.AddWithValue("@e", e);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable getpaymentgateway()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("sp_getpaymentgateway", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            return ds;
        }
    }
}