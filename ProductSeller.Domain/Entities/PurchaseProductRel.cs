

namespace ProductSeller.Domain.Entities
{
    public class PurchaseProductRel: BaseEntity
    {
        public int PurchaseId { get; set; }

        public int ProductId { get; set; }

        public PurchaseProductRel(int purchaseId, int productId)
        {
            PurchaseId = purchaseId;
            ProductId = productId;
        }
    }
}
