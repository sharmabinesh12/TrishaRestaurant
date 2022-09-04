using System.ComponentModel.DataAnnotations;

namespace Trisha.Services.ShoppingCartAPI.Models
{
    public class CartHeader
    {
        [Key]
        public int CartHeaderId { get; set; }
        public string UserId { get; set; }
        public string? CouponCode { get; set; }

    }
}
