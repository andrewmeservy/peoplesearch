using PeopleSearch.Converters;
using PeopleSearchBusinessLogic.IServices;
using System;
using System.Linq;
using System.Web.Mvc;

namespace PeopleSearch.Controllers
{
	public class PersonController : Controller
	{
		private readonly IPersonService personService;

		public PersonController(IPersonService personService)
		{
			this.personService = personService;
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult GetAll()
		{
			try
			{
				var models = PersonConverter.ToModel(personService.Get()).ToList();
				return Json(models, JsonRequestBehavior.AllowGet);
			}
			catch (Exception)
			{
				return View("Error");
			}
		}

		public ActionResult GetByName(string name)
		{
			try
			{
				var models = PersonConverter.ToModel(personService.GetByName(name)).ToList();
				return Json(models, JsonRequestBehavior.AllowGet);
			}
			catch (Exception)
			{
				return View("Error");
			}
		}
	}
}