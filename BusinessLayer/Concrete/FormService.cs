using BusinessLayer.Abstarct;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class FormService : IFormService
    {
        IFormDal _formDal;

        public FormService(IFormDal formDal)
        {
            _formDal = formDal;
        }

        public void Add(Form form)
        {
            _formDal.Insert(form);
        }

        public List<Form> GetAllList()
        {
            return _formDal.List();
        }

        public Form GetById(int id)
        {
            return _formDal.Get(x => x.Id == id);
        }

        public void Delete(Form form)
        {
            _formDal.Delete(form);
        }

        public void Update(Form form)
        {
            _formDal.Update(form);
        }
    }
}

