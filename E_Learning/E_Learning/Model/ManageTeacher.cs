using System.ComponentModel.DataAnnotations;
namespace E_Learning
    .Model
{
    public class ManageTeacher
    {
        [Key]
        public int MaTeacher { get; set; }
        public string TenTeacher { set; get; } = string.Empty;
        public string GioiTinh { set; get; } = string.Empty;
        public DateTime NgaySinh { set; get; }
        public string DiaChi { set; get; } = string.Empty;
    }
}
