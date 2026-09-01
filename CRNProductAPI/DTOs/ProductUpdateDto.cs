using System.ComponentModel.DataAnnotations;

namespace CRNProductAPI.DTOs;

public class ProductUpdateDto
{
    [Required]
    [StringLength(255)]
    public string ProductName { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string ModifiedBy { get; set; } = string.Empty;
}