using System.ComponentModel.DataAnnotations;
namespace E_Learning_v1.Model
{
    public class BanGiamHieu
    {
        [Key]
        public int MaBGH { get; set; }
        public string TenBGH { get; set; }= string.Empty;
    }
}
