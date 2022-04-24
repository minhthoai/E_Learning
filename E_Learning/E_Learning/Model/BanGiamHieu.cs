using System.ComponentModel.DataAnnotations;
namespace E_Learning.Model
{
    public class BanGiamHieu
    {
        [Key]
        public int MaBGH { get; set; }
        public string TenBGH { get; set; }= string.Empty;
    }
}
