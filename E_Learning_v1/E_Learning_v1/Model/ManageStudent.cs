using System.ComponentModel.DataAnnotations;
namespace E_Learning_v1.Model
{
    public class ManageStudent
    {
        [Key]
        public int MaStudent { get; set; }
        public string TenStudent { get; set; } = string.Empty;
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; } = string.Empty;
        public string DiaChia { get; set; } = string.Empty;
    }
}
