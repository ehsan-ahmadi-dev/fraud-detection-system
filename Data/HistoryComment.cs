using System;

namespace FraudPortal.Data
{
    public class HistoryComment
    {
        public Int64 id { set; get; }

        public string actionType { set; get; }
        public string actionDueDate { set; get; }
        public string actionStatus { set; get; }
        public string description { set; get; }
        public string editDate { set; get; }
        public string userEdit { set; get; }
        public string workGroup { set; get; }

        public Int64 processId { set; get; }
        public process process { set; get; }
    }
}
