using System;
using System.Data;
using System.Configuration;
using System.Web;
/// <summary>
/// Summary description for RedirectToPaypal
/// </summary>
namespace ecommerce.Models
{
    public class RedirectToPaypal
    {
        public RedirectToPaypal()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static string getItemNameAndCost(double itemCost, string email, string name, string account)
        {

            //Converting String Money Value Into Decimal


            decimal price = Convert.ToDecimal(itemCost);


            //declaring empty String


            string returnURL = "";


            returnURL += "https://www.paypal.com/xclick/business= guy@007sec.com";


            //PassingItem Name as dynamic


            // returnURL += "&item_name=" + itemName;


            //AssigningName as Statically to Parameter


            //returnURL += "&first_name" + "Raghunadh Babu";


            //AssigningCity as Statically to Parameter


            //returnURL += "&city" + "Hyderabad";


            //Assigning State as Statically to Parameter


            // returnURL += "&state" + "Andhra Pradesh";


            //Assigning Country as Statically to Parameter


            // returnURL += "&country" + "India";


            //Passing Amount as Dynamic


            returnURL += "&amount=" + price;

            returnURL += "&email=" + email;

            returnURL += "&name=" + name;

            returnURL += "&account=" + account;


            //Passing Currency as your 


            returnURL += "&currency=USD";


            //retturn Url if Customer wants To return to Previous Page


            returnURL += "&return=http://zartshop.xlentfacilities.com/pramod/thankyou-paypal.aspx";


            //retturn Url if Customer Wants To Cancel the Transaction


            // returnURL += "&cancel_return=http://bangarubabupureti.spaces.live.com";


            return returnURL;


        }

    }
}