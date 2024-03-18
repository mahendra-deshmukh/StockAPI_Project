using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Stock_API_Application.Model
{
    public class Stock
    {
        public long stock_id { get; set; }
        public string name { get; set;}
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
