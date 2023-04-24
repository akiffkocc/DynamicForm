namespace MvcProje.Models
{
    public class FormFieldListViewModel
    {
        public int Id { get; set; }
        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public bool Required { get; set; }
        public int FormId { get; set; }
    }
}
