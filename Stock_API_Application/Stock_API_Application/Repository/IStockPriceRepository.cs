namespace Stock_API_Application.Repository
{
    public interface IStockPriceRepository
    {
        double[] FindPricesById(long stockId);
    }
}
