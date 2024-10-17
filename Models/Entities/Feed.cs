using QFeedMill.Models.Enum;

namespace QFeedMill.Models.Entities
{
    public class Feed : Auditability
    {
        public FeedPhases Phase { get; set; }
        public Guid FeedCategoryId { get; set; }
        public FeedCategory FeedCategory { get; set; }
        public float Kilogram { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
	}
}

