using Stock_API_Application.DbUtils;
using Dapper;

namespace Stock_API_Application.Repository
{
    public class StockPriceRepository : IStockPriceRepository
    {
        private readonly DapperDbContext _dbContext;
        public StockPriceRepository(DapperDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public double[] FindPricesById(long stockId)
        {
            String query = "select price from stock " +
                            "INNER JOIN stock_price ON " +
                            "(stock.stock_id = stock_price.stock_id) where stock.stock_id = @Id";
            using (var connection = _dbContext.GetConnection())
            {
                return connection.Query<double>(query, new { Id = stockId }).ToArray<double>();
            }
        }
    }
}
