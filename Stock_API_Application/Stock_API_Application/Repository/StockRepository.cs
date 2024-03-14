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
