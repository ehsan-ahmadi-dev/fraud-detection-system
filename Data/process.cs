using System;
using System.Collections.Generic;

namespace FraudPortal.Data
{
    public class process
    {
        public Int64 id { set; get; }
        public Int64 refineId { set; get; }
        public Int64? Date_id { set; get; }
        public int? Rull_id { set; get; }
        public string Condition { set; get; }

        public Int64? Period { set; get; }
        public string TypePeriod { set; get; }
        public decimal? Risk { set; get; }
        public string SourcePan { set; get; }
        public Byte[] DestinationSECPAN { set; get; }
        public string EncryptDestinationPAN { set; get; }
        public Int64? Terminal { set; get; }
        public Int64? User_Id { set; get; }
        public string GuildTitle { set; get; }
        public string BankBin { set; get; }
        public int? PrCode_Id { set; get; }
        public string PosConnectionType { set; get; }
        public int? CountOfTransaction_Success { set; get; }
        public int? CountOfTransaction_unSuccess { set; get; }
        public decimal? Amount_Success { set; get; }
        public decimal? Amount_unSuccess { set; get; }
        public int? CountOfTerminal { set; get; }
        public int? CountOfSourcePan { set; get; }
        public int? CountOfRepeat { set; get; }
        public int? DiffTime1 { set; get; }
        public int? DiffTime2 { set; get; }
        public decimal? P_Unsucsess { set; get; }
        public decimal? P_SorcePan { set; get; }
        public string Detail1 { set; get; }
        public Int64? Detail2 { set; get; }
        public decimal? Detail3 { set; get; }
        public string Detail4 { set; get; }

        public string actionType { set; get; }
        public string actionDueDate { set; get; }
        public string actionStatus { set; get; }
        public string description { set; get; }
        public string editDate { set; get; }
        public string userEdit { set; get; }
        public string workGroup { set; get; }


        public ICollection<HistoryComment> HistoryComments { set; get; }

    }
}
