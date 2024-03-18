using Stock_API_Application.DbUtils;
using Dapper;
using Stock_API_Application.Model;

namespace Stock_API_Application.Repository
{
    public class StockPriceRepository : IStockPriceRepository
    {
        private readonly DapperDbContext _dbContext;
        public StockPriceRepository(DapperDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public dynamic FindPricesById(long stockId)
        {
            String query = "select stock.stock_id, stock.name, stock_price.price, stock_price.created_at " +
                            "from stock LEFT OUTER JOIN stock_price ON " +
                            "(stock.stock_id = stock_price.stock_id) where stock.stock_id = @Id";
            String stockName = null;
            using(var connection = _dbContext.GetConnection())
            {
                List<dynamic> priceDetails = connection.Query<Stock, StockPrice, dynamic>(query, (stock, stockPrice) =>
                {
                    stockName = stock.name;
                    if (stockPrice != null)
                        return new { price = stockPrice.price, createdAt = stockPrice.created_at};
                    else
                        return new {price = (double?)null};
                }, new {Id = stockId}, splitOn:"price").ToList();
                if (priceDetails.Count == 0)
                    return new { stockId = stockId, stockName = stockName, priceDetails = "No prices are listed for this stock." };
                return new { stockId = stockId, stockName = stockName, priceDetails = priceDetails };
            }
        }

        public List<dynamic> FindPricesByIdAndDate(long stockId, DateOnly date)
        {
            String query = "select stock.stock_id, stock.name, stock_price.price, stock_price.created_at " +
                            "from stock" +
                            "INNER JOIN stock_price " +
                            "ON (stock.stock_id = stock_price.stock_id) " +
                            "where stock.stock_id = @Id and CAST(stock_price.created_at as DATE) = @Date";
            using( var connection = _dbContext.GetConnection())
            {
                List<dynamic> result = connection.Query<dynamic>(query,new {Id = stockId,Date = date }).ToList();
                return result;
            }
        }
    }
}
