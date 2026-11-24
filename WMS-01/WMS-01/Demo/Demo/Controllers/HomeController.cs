using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Controllers;
//Demo = package, Controllers = folder
//

// **HomeController(DB db); DB db = injection of dependency, DB = class, db = var
public class HomeController(DB db) : Controller //This is like a webpage
{
    // GET: Home/Index
    public IActionResult Index() //This is like a function
                                // Index() is a view file down there
    {
        var m = db.Students
           .Include(s => s.Program);

        return View(m);
    }

    // GET: Home/Detail
    public IActionResult Detail(string? id)
    {   
        var m = db.Students
                   .Include(s => s.Program)
                   .FirstOrDefault(s => s.Id == id);

        if (m == null)
        {
            return RedirectToAction("Index");
        }

        return View(m);
    }
}
