using System.ComponentModel.DataAnnotations;

namespace ArmorFeedApi.Payments.Resources;

public class SavePaymentResource
{
    [Required]
    public float Amount { get; set; }
    [Required]
    [MaxLength(20)]
    public string Currency { get; set; }
    [Required]
    public string PaymentDate { get; set; }

    [Required] public string Status { get; set; } = "Registed";
    [Required]
    public int ShipmentId { get; set; }
}