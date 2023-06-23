using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LeAnhTuan0647.Models
{
    [Table("LAT647Employee")]
    public class LAT647Employee{
        [Key]
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public float Age { get; set; }
    }
}