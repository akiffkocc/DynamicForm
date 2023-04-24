namespace MvcProje.Models
{
    public class AddFormFieldViewModel
    {
        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public bool Required { get; set; }
        public int FormId { get; set; }
    }
}
