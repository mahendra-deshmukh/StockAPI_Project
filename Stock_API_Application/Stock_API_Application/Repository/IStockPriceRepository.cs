namespace Stock_API_Application.Repository
{
    public interface IStockPriceRepository
    {
        dynamic FindPricesById(long stockId);
        List<dynamic> FindPricesByIdAndDate(long stockId, DateOnly date);
    }
}
