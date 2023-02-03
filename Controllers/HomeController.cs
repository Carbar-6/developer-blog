using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DeveloperBlog.Models;
using DeveloperBlog.Core.ViewModels;
using DeveloperBlog.Core;
using DeveloperBlog.Data;

namespace DeveloperBlog.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBlogPostRepository _blogPostRepository;

    public HomeController(ILogger<HomeController> logger, IBlogPostRepository blogPostRepository)
    {
        _logger = logger;
        _blogPostRepository = blogPostRepository;
    }

    public IActionResult Index()
    {
        var indexViewModel = new IndexViewModel{ AllPosts = _blogPostRepository.GetBlogPosts()};
        return View(indexViewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

