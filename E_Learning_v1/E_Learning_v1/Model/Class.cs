using System.ComponentModel.DataAnnotations;
namespace E_Learning_v1.Model
{
    public class Class
    {
        [Key]
        public int MaLop { get; set; }
        public string MonHoc { get; set; }= string.Empty;
        public string ThoiGian { get; set; }= string.Empty;
        public string TrangThai { get; set; }= string.Empty;

    }
}
