using System.ComponentModel.DataAnnotations;
namespace E_Learning.Model
{
    public class HoiDap
    {
        [Key]
        public int MaHoiDap { get; set; }
        public string CauHoi { get; set; }= string.Empty;   
        public string CauTraLoi { get; set; }= string.Empty;

    }
}
