namespace ProductSeller.Domain.Entities
{
    public class PurchaseOrder : BaseEntity
    {
        public int UserId { get; set; }

        public DateTime PurchasedAt { get; set; }

        public double TotalValue { get; set; }

        public bool PurchaseMailed { get; set; }

        public PurchaseOrder(int id, int userId, DateTime purchasedAt, double totalValue, bool purchaseMailed)
        {
            Id = id;
            UserId = userId;
            PurchasedAt = purchasedAt;
            TotalValue = totalValue;
            PurchaseMailed = purchaseMailed;
        }
    }
}