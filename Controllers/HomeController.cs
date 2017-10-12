using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace RandomPasscode.Controllers
{

    public class HomeController : Controller
    {
		private string GenerateRndString(int DesiredLen = 14)
		{
			string RdnString = "";
			Random r = new Random();
			while (RdnString.Length < DesiredLen)
			{
				var thisChar = ' ';
				var anInt = r.Next(0, (26 + 26 + 10));
				if (anInt < 26)
					thisChar = (char)((int)'a' + anInt);
				else
				{
					if (anInt < (26 + 26))
						thisChar = (char)((int)'A' + anInt - 26);
					else
						thisChar = (char)((int)'0' + anInt - (26 + 26));
				}
				RdnString += thisChar.ToString();
			}
			return RdnString;
		}
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            int actCount = 1 + (HttpContext.Session.GetInt32("Count") ?? 0);
			HttpContext.Session.SetInt32("Count", actCount);
            ViewBag.Count = actCount;

            string RdnString = GenerateRndString();
            // HttpContext.Session.SetString("RdnString", RdnString);
            ViewBag.RndString = RdnString;
			return View();
        }
    }
}
