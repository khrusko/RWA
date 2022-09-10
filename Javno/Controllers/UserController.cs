using Javno.Models;
using Javno.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Javno.Controllers
{
	public class UserController : Controller
	{
		private readonly UserRepo _userRepository;

		public UserController()
		{
			_userRepository = new UserRepo();
		}


		[HttpGet]
		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Login(UserLoginVM user)
		{
			if (!ModelState.IsValid)
			{
				return View(user);
			}

			UserLoginVM user1 = _userRepository.AuthUser(user);
			if (user1 == null)
			{
				ViewBag.Error = "False Mail or Password";
				return View(user);
			}
			Session["currentUser"]=user1;
			return RedirectToAction("Search","Apartment");
		}


		[HttpGet]
		public ActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Register(User user)
		{
			if (!ModelState.IsValid)
				return View(user);

			_userRepository.CreateUser(user);
			return RedirectToAction("Login", "User");
		}

		[HttpGet]
		public ActionResult Logout(UserLoginVM user)
		{
			Session["currentUser"] = null;
			Session.Clear();

			return RedirectToAction("Login", "User");
		}
		}
}