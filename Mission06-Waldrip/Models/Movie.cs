using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Waldrip.Models;

public class Movie
{
    [Key]
    [Required]
    public int MovieId { get; set; }
    [ForeignKey("CategoryId")]
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    [Required]
    public string Title {get; set;}
    [Required]
    // limiting the year to be a minimum of 1888 and essentially no max to account for future movies
    [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
    public int Year { get; set; }
    public string? Director { get; set; }
    public string? Rating { get; set; }
    
    [Required]
    public bool Edited { get; set; }
    
    public string? LentTo { get; set; }
    
    [Required]
    public bool CopiedToPlex { get; set; }
    
    public string? Notes { get; set; }
}