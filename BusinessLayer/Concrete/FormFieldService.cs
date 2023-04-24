using BusinessLayer.Abstarct;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using DataAccessLayer.EntityFramework;

namespace BusinessLayer.Concrete
{
    public class FormFieldService : IFormFieldService
    {
        IFormFieldDal _formFieldDal;

        public FormFieldService(IFormFieldDal formFieldDal)
        {
            _formFieldDal = formFieldDal;
        }

        public void Add(FormField formField)
        {
            _formFieldDal.Insert(formField);
        }

        public List<FormField> List(Expression<Func<FormField, bool>> filter)
        {
            return _formFieldDal.List(filter);
        }

        public FormField GetById(int id)
        {
            return _formFieldDal.Get(x => x.Id == id);
        }

        public void Delete(FormField formField)
        {
            _formFieldDal.Delete(formField);
        }

        public void Update(FormField formField)
        {
            _formFieldDal.Update(formField);
        }
    }
}
