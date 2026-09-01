using System.ComponentModel.DataAnnotations;

namespace CRNProductAPI.DTOs;

public class ProductCreateDto
{
    [Required]
    [StringLength(255)]
    public string ProductName { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string CreatedBy { get; set; } = string.Empty;
}