﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Javno.Controllers
{
	public class ErrorController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public ActionResult Error404()
		{
			return View();
		}
		[HttpGet]
		public ActionResult Error500()
		{
			return View();
		}
	}
}