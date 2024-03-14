using Dapper;
using Stock_API_Application.DbUtils;
using Stock_API_Application.Model;

namespace Stock_API_Application.Repository
{
    public class StockRepository : IStockRespository
    {
        private readonly DapperDbContext _dbContext;
        public StockRepository(DapperDbContext dbContext) { 
            this._dbContext = dbContext;
        }

        public Stock findById(long stockId)
        {
            String query = "select * from stock where stock_id = @Id";
            using(var connection = _dbContext.GetConnection())
            {
                var stock = connection.QueryFirstOrDefault<Stock>(query,new { Id = stockId});
                return stock;
            }
        }

        public List<Stock> getAll()
        {
            String query = "select * from stock";
            using(var connection  = _dbContext.GetConnection())
            {
                var list = connection.Query<Stock>(query).ToList();
                return list;
            }
        }
    }
}
