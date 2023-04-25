using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Enums;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcProje.Models;

namespace MvcProje.Controllers
{
    public class FormFieldController : Controller
    {
        FormFieldService _formFieldService = new FormFieldService(new EfFormFieldDal());


        [HttpGet]
        public ActionResult Add(int formId)
        {
            var sessionUser = HttpContext.Session.GetString("username");
            if (sessionUser == null)
                return RedirectToAction("Login", "User");

            var addFormFieldViewModel = new AddFormFieldViewModel()
            {
                FormId = formId
            };

            var dataTypeSelectListItem = new List<SelectListItem>()
            {
                new SelectListItem
                {
                     Text = DataTypeEnum.String.ToString(),
                     Value = DataTypeEnum.String.ToString()
                },
                new SelectListItem
                {
                     Text = DataTypeEnum.DateTime.ToString(),
                     Value = DataTypeEnum.DateTime.ToString()
                },
                new SelectListItem
                {
                     Text = DataTypeEnum.Int.ToString(),
                     Value = DataTypeEnum.Int.ToString()
                },
                new SelectListItem
                {
                     Text = DataTypeEnum.Boolen.ToString(),
                     Value = DataTypeEnum.Boolen.ToString()
                }
            };

            ViewBag.DataTypeSelectListItem = dataTypeSelectListItem;

            return View(addFormFieldViewModel);
        }

        [HttpPost]
        public ActionResult Add(AddFormFieldViewModel model)
        {
            var sessionUser = HttpContext.Session.GetString("username");
            if (sessionUser == null)
                return RedirectToAction("Login", "User");

            var entity = new FormField()
            {
                ColumnName = model.ColumnName,
                DataType = model.DataType,
                FormId = model.FormId,
                Required = model.Required,
            };

            _formFieldService.Add(entity);
            return RedirectToAction("Edit", "Form", new { id = model.FormId, isActiveFieldTab = true });
        }


        public ActionResult Delete(int id, int formId)
        {
            var sessionUser = HttpContext.Session.GetString("username");
            if (sessionUser == null)
                return RedirectToAction("Login", "User");

            var form = _formFieldService.GetById(id);
            _formFieldService.Delete(form);
            return RedirectToAction("Edit", "Form", new { id = formId, isActiveFieldTab = true });
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var sessionUser = HttpContext.Session.GetString("username");
            if (sessionUser == null)
                return RedirectToAction("Login", "User");

            var formField = _formFieldService.GetById(id);

            var editFormFieldViewModel = new EditFormFieldViewModel()
            {
                Id = id,
                ColumnName = formField.ColumnName,
                DataType = formField.DataType,
                Required = formField.Required
            };

            var dataTypeSelectListItem = new List<SelectListItem>()
            {
                new SelectListItem
                {
                     Text = DataTypeEnum.String.ToString(),
                     Value = DataTypeEnum.String.ToString()
                },
                new SelectListItem
                {
                     Text = DataTypeEnum.DateTime.ToString(),
                     Value = DataTypeEnum.DateTime.ToString()
                },
                new SelectListItem
                {
                     Text = DataTypeEnum.Int.ToString(),
                     Value = DataTypeEnum.Int.ToString()
                },
                new SelectListItem
                {
                     Text = DataTypeEnum.Boolen.ToString(),
                     Value = DataTypeEnum.Boolen.ToString()
                }
            };

            ViewBag.DataTypeSelectListItem = dataTypeSelectListItem;

            return View(editFormFieldViewModel);
        }

        [HttpPost]
        public ActionResult Edit(EditFormFieldViewModel model)
        {
            var sessionUser = HttpContext.Session.GetString("username");
            if (sessionUser == null)
                return RedirectToAction("Login", "User");

            var formField = _formFieldService.GetById(model.Id);
            formField.ColumnName = model.ColumnName;
            formField.DataType = model.DataType;
            formField.Required = model.Required;

            _formFieldService.Update(formField);
            return RedirectToAction("Edit", "Form", new { id = formField.FormId, isActiveFieldTab = true });
        }
    }
}
