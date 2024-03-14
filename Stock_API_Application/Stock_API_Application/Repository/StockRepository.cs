using Dapper;
using Microsoft.IdentityModel.Tokens;
using Stock_API_Application.DbUtils;
using Stock_API_Application.Extension_Methods;
using Stock_API_Application.Model;

namespace Stock_API_Application.Repository
{
    public class StockRepository : IStockRespository
    {
        private readonly DapperDbContext _dbContext;
        public StockRepository(DapperDbContext dbContext) { 
            this._dbContext = dbContext;
        }

        public Stock FindById(long stockId)
        {
            String query = "select * from stock where stock_id = @Id";
            using(var connection = _dbContext.GetConnection())
            {
                var stock = connection.QueryFirstOrDefault<Stock>(query,new { Id = stockId});
                return stock;
            }
        }

        public List<Stock> FindByInitialPattern(String pattern)
        {
            if (pattern.IsNullOrEmpty())
                return null;
            String[] patterns = pattern.Split("-");
            Dictionary<String,Object> queryParameters = new Dictionary<String,Object>();
            String query = "select * from stock where";
            for(int i = 0; i<patterns.Length; i++)
            {
                if(i>0)
                {
                    query += " or";
                }
                query += " name like @Pattern" + i;
                queryParameters.Add("Pattern" + i, patterns[i]+"%");
            }

            using(var connection = _dbContext.GetConnection())
            {
                return connection.Query<Stock>
                    (query, queryParameters).ToList();
            }
        }

        public Stock FindByName(string name)
        {
            String query = "select * from stock where name = @Name";
            using(var connection = _dbContext.GetConnection())
            {
                return connection.QueryFirstOrDefault<Stock>(query, new { Name = name });
            }
        }

        public List<Stock> GetAll()
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
