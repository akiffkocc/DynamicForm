using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace BusinessLayer.Abstarct
{
    public interface IFormFieldService
    {
        void Add(FormField formField);
        List<FormField> List(Expression<Func<FormField, bool>> filter);
        FormField GetById(int id);
        void Delete(FormField formField);
        void Update(FormField formField);
    }
}
