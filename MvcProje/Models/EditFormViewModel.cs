using EntityLayer.Concrete;

namespace MvcProje.Models
{
    public class EditFormViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<FormFieldListViewModel> FormFields { get; set; }
    }
}
