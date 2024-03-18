using System.ComponentModel.DataAnnotations.Schema;

namespace Stock_API_Application.Model
{
    public class StockPrice
    {
        public long id {  get; set; }
        public double price { get; set; }

        public DateTime created_at { get; set; }

        public DateTime updated_at { get; set; }
    }
}
