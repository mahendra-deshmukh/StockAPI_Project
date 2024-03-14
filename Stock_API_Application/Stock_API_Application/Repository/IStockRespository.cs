using Stock_API_Application.Model;

namespace Stock_API_Application.Repository
{
    public interface IStockRespository
    {
        List<Stock> getAll();
    }
}
