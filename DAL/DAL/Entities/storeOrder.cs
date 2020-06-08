using System;
namespace DAL.Entities
{
    public class storeOrder
    {
        public int order_id { get; set; }
        public float total_price { get; set; }
        public string delivery_type { get; set; }
        public int customer_id { get; set; }
        public int items_id { get; set; }
    }
}
