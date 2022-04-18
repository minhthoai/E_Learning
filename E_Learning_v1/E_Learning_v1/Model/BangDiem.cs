using System.ComponentModel.DataAnnotations;
namespace E_Learning_v1.Model
{
    public class BangDiem
    {
        [Key]
        public int MaBangDiem { get; set; }
        public string TenHocSinh { get; set; }= string.Empty;
        public DateTime NgaySinh { get; set; }
        public string DiemHocKi { get; set; }= string.Empty;
        public string DiemTrungBinh { get; set; }= string.Empty;
        public string TrangThai { get; set; }= string.Empty;
        public DateTime NgayCapNhat { get; set; }

    }
}
