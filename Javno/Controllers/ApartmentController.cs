using Javno.Models;
using Javno.Repo;
using Recaptcha.Web.Configuration;
using Recaptcha.Web.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data;
using Recaptcha.Web;

namespace Javno.Controllers
{
	public class ApartmentController : Controller
	{

		private readonly ApartmentRepo _apartmentRepository;
		private readonly CityRepo _cityRepository;
		private readonly OrderRepo _orderRepository;

		public ApartmentController()
		{
			_apartmentRepository = new ApartmentRepo();
			_cityRepository = new CityRepo();
			_orderRepository = new OrderRepo();
		}

		public ActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public ActionResult ContactUs()
		{
			return View();
		}

		[HttpPost]
		public ActionResult ContactUs(ContactReservationVM model)
		{

			if (ModelState.IsValid)
			{
				return RedirectToAction(controllerName: "ApartmentController", actionName: "Search");
			}

			if (!ModelState.IsValid)
			{
				return View();
			}
			return View();
		}
		[HttpGet]
		public ActionResult AboutUs()
		{
			return View();
		}

		public ActionResult StarRating()
		{
			var model =
							new StarRatingVM
							{
								Question = "Ocijenite apartman",
								MaxRating = 10
							};
			return View(model);
		}


		[HttpPost]
		public ActionResult Search(SearchVM model)
		{
			ApartmentCookiesVM apartmentCookiesVM = new ApartmentCookiesVM();
			apartmentCookiesVM.FilterCity = model.FilterCity;
			apartmentCookiesVM.FilterAdults = model.FilterAdults;
			apartmentCookiesVM.FilterRooms = model.FilterRooms;
			apartmentCookiesVM.FilterChildren = model.FilterChildren;
			apartmentCookiesVM.Order = model.Order;
			HttpContext.Response.Cookies.Add(new HttpCookie("sortingFilterOptions", apartmentCookiesVM.CookiePrepare()));
			model.SearchResult = _apartmentRepository.Search(
										model.FilterRooms,
										model.FilterAdults,
										model.FilterChildren,
										model.FilterCity,
										model.Order);

			model.CityList = _cityRepository.GetCities();
			model.OrderList = _orderRepository.GetOrders();

			return PartialView("_partialApartments", model);
		}


		[HttpGet]
		public ActionResult Search()
		{
			ApartmentCookiesVM myFilters = ApartmentCookiesVM.CookieRead(HttpContext.Request.Cookies["sortingFilterOptions"]?.Value);
			SearchVM tempSearch = new SearchVM();
			List<SearchResultVM> searchResultVMs;
			if (myFilters != null)
			{
				searchResultVMs = _apartmentRepository.Search(myFilters.FilterRooms,
																																																myFilters.FilterAdults,
																																																myFilters.FilterChildren,
																																																myFilters.FilterCity,
																																																myFilters.Order);
				tempSearch.FilterCity = myFilters.FilterCity;
				tempSearch.FilterChildren = myFilters.FilterChildren;
				tempSearch.FilterAdults = myFilters.FilterAdults;
				tempSearch.FilterRooms = myFilters.FilterRooms;
				tempSearch.Order = myFilters.Order;
			}
			else
			{
				searchResultVMs = _apartmentRepository.LoadAllApartments();
			}
			tempSearch.SearchResult = searchResultVMs;
			tempSearch.CityList = _cityRepository.GetCities();
			tempSearch.OrderList = _orderRepository.GetOrders();


			return View(tempSearch);
		}

		[HttpGet]
		public ActionResult ClearCookies()
		{
			HttpCookie nameCookie = Request.Cookies["sortingFilterOptions"];
			if (nameCookie == null)
			{
				return RedirectToAction("Search");
			}
			nameCookie.Expires = DateTime.Now.AddDays(-1);
			Response.Cookies.Add(nameCookie);
			return RedirectToAction("Search");
		}


		public ActionResult Details(int id)
		{
			var model = _apartmentRepository.GetPublicApartmentDetails(id);
			model.Tags = _apartmentRepository.GetPublicApartmentTags(id);
			model.RepresentativePicture = _apartmentRepository.GetPublicApartmentRepresentativePicture(id);
			model.Pictures = _apartmentRepository.GetPublicApartmentPicturesWithoutRepresentative(id);
			return View(model);
		}

		[HttpPost]
		public ActionResult Details(ApartmentDetails model)
		{
			RecaptchaVerificationHelper recaptchaHelper = this.GetRecaptchaVerificationHelper();
			if (String.IsNullOrEmpty(recaptchaHelper.Response))
			{
				int id = int.Parse(Url.RequestContext.RouteData.Values["id"].ToString());
				var temp = _apartmentRepository.GetPublicApartmentDetails(id);
				temp.Tags = _apartmentRepository.GetPublicApartmentTags(id);
				temp.RepresentativePicture = _apartmentRepository.GetPublicApartmentRepresentativePicture(id);
				temp.Pictures = _apartmentRepository.GetPublicApartmentPicturesWithoutRepresentative(id);
				ModelState.AddModelError("", "Captcha cannot be empty.");
				return View(temp);
			}

			RecaptchaVerificationResult recaptchaResult = recaptchaHelper.VerifyRecaptchaResponse();
			if (!recaptchaResult.Success)
			{
				int id = int.Parse(Url.RequestContext.RouteData.Values["id"].ToString());
				var temp = _apartmentRepository.GetPublicApartmentDetails(id);
				temp.Tags = _apartmentRepository.GetPublicApartmentTags(id);
				temp.RepresentativePicture = _apartmentRepository.GetPublicApartmentRepresentativePicture(id);
				temp.Pictures = _apartmentRepository.GetPublicApartmentPicturesWithoutRepresentative(id);
				ModelState.AddModelError("", "Incorrect captcha answer.");
				return View(temp);
			}


			if (!ModelState.IsValid)
			{
				int id = int.Parse(Url.RequestContext.RouteData.Values["id"].ToString());
				var temp = _apartmentRepository.GetPublicApartmentDetails(id);
				temp.Tags = _apartmentRepository.GetPublicApartmentTags(id);
				temp.RepresentativePicture = _apartmentRepository.GetPublicApartmentRepresentativePicture(id);
				temp.Pictures = _apartmentRepository.GetPublicApartmentPicturesWithoutRepresentative(id);
				return View(temp);
			}

			_apartmentRepository.CreateReservation(model);
			return RedirectToAction("Search", "Apartment");
		}

		public ActionResult Picture(string path)
		{
			if (path == null || string.IsNullOrEmpty(path))
				return Content(content: "File missing"); // Rješenje "nabrzaka", nije najbolje

			// Popravi putanju do slike, u bazi nije cijela putanja!
			var javnoRoot = Server.MapPath("~");
			var adminRoot = Path.Combine(javnoRoot, "../Admin/Content/Pictures");
			var picturePath = Path.Combine(adminRoot, path);

			string mimeType = MimeMapping.GetMimeMapping(picturePath);

			return new FilePathResult(picturePath, mimeType);
		}

		[HttpPost]
		public ActionResult CreateApartmentReview(ApartmentReviewVM model)
		{
			model.UserId = (((UserLoginVM)Session["currentUser"]).Id);
			_apartmentRepository.CreateReview(model);
			return RedirectToAction("Search");
		}

	}
}
