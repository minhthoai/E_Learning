using System.ComponentModel.DataAnnotations;
namespace E_Learning_v1.Model
{
    public class Detail_Class
    {
        [Key]
        public int MaLop { get; set; }
        public string TenGiaoVien { get; set; }= string.Empty;
        public string BoMon { get; set; }= string.Empty;
        public string MoTa { get; set; }= string.Empty;
        public int SoBuoi { get; set; }
        public string ThoiLuong { get; set; }= string.Empty;
        public DateTime NgayBatDau { get; set; }= DateTime.Now;
        public DateTime NgayKetThuc { get; set; }= DateTime.Now;
    }
}
