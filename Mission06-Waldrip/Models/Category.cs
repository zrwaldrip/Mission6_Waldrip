using System.ComponentModel.DataAnnotations;

namespace Mission06_Waldrip.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}