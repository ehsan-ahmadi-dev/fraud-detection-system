using System.Collections.Generic;

namespace FraudPortal.Data
{
    public class WorkGroup
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { set; get; }


        public ICollection<UserInGroup> userInGroups { get; set; }

    }
}
