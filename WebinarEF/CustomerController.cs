using Microsoft.AspNetCore.Mvc;
using WebinarEF.Interfaces;

namespace WebinarEF;

public class CustomerController : Controller
{
    // GET
    private readonly IUnitOfWork _unitOfWork;

    public CustomerController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        return View();
    }
}