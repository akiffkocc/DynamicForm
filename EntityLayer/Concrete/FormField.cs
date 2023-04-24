using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class FormField
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string ColumnName { get; set; }

        [StringLength(50)]
        public string DataType { get; set; }

        public bool Required { get; set; }


        public int FormId { get; set; }
        public virtual Form Form { get; set; }
    }
}
