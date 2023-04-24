using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstarct
{
    public interface IFormService
    {
        List<Form> GetAllList();
        void Add(Form form);
        Form GetById(int id);
        void Delete(Form form);
        void Update(Form form);
    }
}
