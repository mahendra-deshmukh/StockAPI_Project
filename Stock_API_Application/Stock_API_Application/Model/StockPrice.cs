using System.ComponentModel.DataAnnotations.Schema;

namespace Stock_API_Application.Model
{
    public class StockPrice
    {
        private long id {  get; set; }
        private double price { get; set; }

        [Column("created_at")]
        private DateTime createdAt { get; set; }

        [Column("updated_at")]
        private DateTime updatedAt { get; set; }
        private Stock stock { get; set; }
    }
}
