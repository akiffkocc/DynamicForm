using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using MvcProje.Models;

namespace MvcProje.Controllers
{
    public class FormController : Controller
    {
        FormService _formService = new FormService(new EfFormDal());
        FormFieldService _formFieldService = new FormFieldService(new EfFormFieldDal());
        public IActionResult Index()
        {
            var sessionUser = HttpContext.Session.GetString("username");
            if (sessionUser == null)
                return RedirectToAction("Login", "User");

            var formList = _formService.GetAllList();

            var formListViewModels = new List<FormListViewModel>();
            foreach (var item in formList)
            {
                var formListViewModel = new FormListViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    CreatedBy = item.CreatedBy,
                    CreatedAt = item.CreatedAt
                };

                formListViewModels.Add(formListViewModel);
            }

            return View(formListViewModels);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var sessionUser = HttpContext.Session.GetString("username");
            if (sessionUser == null)
                return RedirectToAction("Login", "User");

            return View();
        }

        [HttpPost]
        public ActionResult Add(AddFormViewModel model)
        {
            var sessionUser = HttpContext.Session.GetString("username");
            if (sessionUser == null)
                return RedirectToAction("Login", "User");

            var entity = new Form()
            {
                CreatedAt = DateTime.Now,
                CreatedBy = 1, // sisteme giriş yapan kişiden alınacak.
                Description = model.Description,
                Name = model.Name,
            };

            _formService.Add(entity);
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var sessionUser = HttpContext.Session.GetString("username");
            if (sessionUser == null)
                return RedirectToAction("Login", "User");

            var form = _formService.GetById(id);
            _formService.Delete(form);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var sessionUser = HttpContext.Session.GetString("username");
            if (sessionUser == null)
                return RedirectToAction("Login", "User");

            var form = _formService.GetById(id);

            var editFormViewModel = new EditFormViewModel()
            {
                Id = id,
                Name = form.Name,
                Description = form.Description,
                FormFields = new List<FormFieldListViewModel>()
            };

            var formFields = _formFieldService.List(x => x.FormId == id);

            foreach (var item in formFields)
            {
                var model = new FormFieldListViewModel()
                {
                    Id = item.Id,
                    ColumnName = item.ColumnName,
                    DataType = item.DataType,
                    FormId = item.FormId,
                    Required = item.Required
                };

                editFormViewModel.FormFields.Add(model);
            }

            return View(editFormViewModel);
        }

        [HttpPost]
        public ActionResult Edit(EditFormViewModel model)
        {
            var sessionUser = HttpContext.Session.GetString("username");
            if (sessionUser == null)
                return RedirectToAction("Login", "User");

            var form = _formService.GetById(model.Id);
            form.Name = model.Name;
            form.Description = model.Description;

            _formService.Update(form);
            return RedirectToAction("Index");
        }

        public ActionResult View(int id)
        {
            var sessionUser = HttpContext.Session.GetString("username");
            if (sessionUser == null)
                return RedirectToAction("Login", "User");

            var form = _formService.GetById(id);

            var editFormViewModel = new EditFormViewModel()
            {
                Id = id,
                Name = form.Name,
                Description = form.Description,
                FormFields = new List<FormFieldListViewModel>()
            };

            var formFields = _formFieldService.List(x => x.FormId == id);

            foreach (var item in formFields)
            {
                var model = new FormFieldListViewModel()
                {
                    Id = item.Id,
                    ColumnName = item.ColumnName,
                    DataType = item.DataType,
                    FormId = item.FormId,
                    Required = item.Required
                };

                editFormViewModel.FormFields.Add(model);
            }

            return View(editFormViewModel);
        }
    }
}
