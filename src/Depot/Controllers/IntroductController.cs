using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

namespace Depot.Controllers
{
    public class IntroductController : Controller
    {
        // GET: Introduct
        private IHostingEnvironment _hostEnv;

        public IntroductController(IHostingEnvironment env)
        {
            _hostEnv = env;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}