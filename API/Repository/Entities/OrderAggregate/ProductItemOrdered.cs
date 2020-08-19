namespace Repository.Entities.OrderAggregate
{
    public class ProductItemOrdered
    {
        public ProductItemOrdered()
        {
        }

        public ProductItemOrdered(int productItemId, string productName, string image)
        {
            ProductItemId = productItemId;
            ProductName = productName;
            Image = image;
        }

        public int ProductItemId { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
    }
}
