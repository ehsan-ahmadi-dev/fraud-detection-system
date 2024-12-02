using System.ComponentModel.DataAnnotations;

namespace FraudPortal.Data
{
    public class IdentifyDailyFrauds_RuleList
    {
        [Key]
        public int RuleID { set; get; }

        public string Entity { set; get; }
        public string condition { set; get; }
        public string RuleName { set; get; }
        public decimal? WeightRule { set; get; }
        public string Description { set; get; }
        public bool? IsActive { set; get; }
    }
}
