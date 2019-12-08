using ApplicationCore.Interfaces;

namespace Documents.Tracker.Core
{
    public class DocumentBaseOTO : IAuditable
    {
        public int RefId { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime? ModifiedAt { get; set; }
        //public string ModifiedBy { get; set; }
    }
}