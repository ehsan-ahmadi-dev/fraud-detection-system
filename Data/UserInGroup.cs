using System.ComponentModel.DataAnnotations;

namespace FraudPortal.Data
{
    public class UserInGroup
    {
        [Key]
        public string UserName { get; set; }

        [Required]
        public string WorkGroupName { set; get; }

        public int WorkGroupId { set; get; }
        public WorkGroup WorkGroup { get; set; }
    }
}
