using System.ComponentModel.DataAnnotations;
namespace E_Learning.Model
{
    public class ManageLearning
    {
        [Key]
        public int Ma_KhoaHoc { get; set; }
        public string? Ten_KhoaHoa { get; set; }
        public string? MoTa { get; set; }
    }
}
