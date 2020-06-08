using System;
namespace DAL.Entities
{
    public class customer
    {
        public int customer_id { get; set; }
        public string customer_name { get; set; }
        public string customer_email { get; set; }
        public string customer_password { get; set; }
    }
}
