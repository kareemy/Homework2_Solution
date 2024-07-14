using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Homework2_Solution.Pages;

public class ComplaintModel : PageModel
{
    private readonly ILogger<ComplaintModel> _logger;

    [BindProperty]
    [StringLength(30, MinimumLength = 3)]
    public string Name {get; set;} = string.Empty;

    [BindProperty]
    [EmailAddress]
    public string Email {get; set;} = string.Empty;

    [BindProperty]
    [StringLength(500)]
    public string Message {get; set;} = string.Empty;

    [BindProperty]
    [Required(ErrorMessage = "Please select a product.")]
    public int SelectedProduct {get; set;}

    public string ProductName {get; set;} = string.Empty;

    public ComplaintModel(ILogger<ComplaintModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }

    public void OnPost()
    {
        _logger.LogWarning($"OnPost() - '{Name}' '{Email}' '{Message}' '{SelectedProduct}'");
        switch (SelectedProduct)
        {
            case 1:
                ProductName = "MindSync";
                break;
            case 2:
                ProductName = "Seraphine";
                break;
            case 3:
                ProductName = "SoulSear";
                break;
            case 4:
                ProductName = "PhantomClaw";
                break;
            default:
                ProductName = string.Empty;
                break;
        }
    }
}