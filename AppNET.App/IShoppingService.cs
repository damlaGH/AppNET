namespace AppNET.App
{
    public interface IShoppingService
    {
        void BuyProduct(int id, string name, int stock, decimal buyPrice);
        void SellProduct(int id, string name, int stock, decimal sellPrice);
        bool StockControlForSale(int id, int sellAmount);
    }
}