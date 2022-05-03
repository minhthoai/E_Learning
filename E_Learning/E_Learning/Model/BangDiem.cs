using System.ComponentModel.DataAnnotations;
namespace E_Learning.Model
{
    public class BangDiem
    {
        [Key]
        public int MaBangDiem { get; set; }
        public string TenHocSinh { get; set; }= string.Empty;
        public DateTime NgaySinh { get; set; }
        public string ChuyenCan { get; set; }= string.Empty;
        public string DiemMieng { get; set; }= string.Empty;
        public string HeSo1 { get; set; }= string.Empty;
        public string HeSo2 { get; set; }= string.Empty;
        public string DiemTrungBinh { get; set; }= string.Empty;
        public string DiemTrungBinhCaNam { get; set; }= string.Empty;
        public string TrangThai { get; set; }= string.Empty;
        public DateTime NgayCapNhat { get; set; }

    }
}
