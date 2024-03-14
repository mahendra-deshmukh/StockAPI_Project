using Stock_API_Application.Model;

namespace Stock_API_Application.Repository
{
    public interface IStockRespository
    {
        List<Stock> GetAll();
        Stock FindById(long stockId);
        List<Stock> FindByInitialPattern(String pattern);
        Stock FindByName(String name);
    }
}
