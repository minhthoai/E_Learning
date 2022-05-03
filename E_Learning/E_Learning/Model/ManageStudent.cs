using System.ComponentModel.DataAnnotations;
namespace E_Learning.Model
{
    public class ManageStudent
    {
        [Key]
        public int MaStudent { get; set; }
        public string TenStudent { get; set; } = string.Empty;
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; } = string.Empty;
        public string DiaChi { get; set; } = string.Empty;
    }
}
