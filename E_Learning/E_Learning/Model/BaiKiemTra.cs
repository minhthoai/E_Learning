using System.ComponentModel.DataAnnotations;
namespace E_Learning.Model
{
    public class BaiKiemTra
    {
        [Key]
        public int MaBaiKiemTra { get; set; }
        public string Lop { get; set; }= string.Empty;
        public string NoiDungKiemTra { get; set; }= string.Empty;
        public string MonHoc { get; set; }= string.Empty;
        public DateTime NgayLamBai { get; set; }
        public string ThoiLuong { get; set; }= string.Empty;
        public string TinhTrang { get; set; }= string.Empty;
    }
}
