using Microsoft.AspNetCore.Mvc;
using System;

namespace MvcDb.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			try
			{
				int a = 10, b = 0, c = 0;
				c = a / b;
			}
			catch(Exception ex)
			{
				ViewBag.ErrorMessage = ex.Message;
				return View("Error");
			}
			return View();
		}
	}
}
