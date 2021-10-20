namespace TradingPlatform.Dtos
{
    public class ProductOrderReadDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public virtual OrderReadDto Order { get; set; }
        public virtual ProductReadDto Product { get; set; }
    }
}
