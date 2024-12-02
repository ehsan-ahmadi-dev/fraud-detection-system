using FraudPortal.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FraudPortal.Controllers
{
    public class GridController : Controller
    {
        public Dictionary<string, string> actionTypeRecord = new Dictionary<string, string>() { { "اصلاح", "اصلاح" }, { "قطع همکاری", "قطع همکاری" }, { "اقدام", "اقدام" } };
        public Dictionary<string, string> statusRecord = new Dictionary<string, string>() { { "در حال انجام", "در حال انجام" }, { "در انتظار", "انتظار" }, { "خاتمه یافته", "خاتمه یافته" } };

        private readonly ApplicationDbContext _Db;
        private readonly IConfiguration _Config;
        public GridController(ApplicationDbContext db, IConfiguration config)
        {
            _Db = db;
            _Config = config;
        }
        public IActionResult Refine()
        {
            @ViewData["main-title"] = "پایش و کنترل داده";
            @ViewData["section-titile-1"] = "جستجو و اقدام";
            @ViewData["section-titile-2"] = "نمایش داده";
            var list = _Db.IdentifyDailyFrauds_RuleList.ToList();
            ViewData["RuleOptions"] = new SelectList(_Db.IdentifyDailyFrauds_RuleList, "RuleID", "Description");

            return View();
        }
        public async Task<IActionResult> RefineData(int startDate = 0, int endDate = 0, int ruleId = 0)
        {
            dynamic farudLList = null;
            int coutRow;
            if (startDate == 0 || endDate == 0)
            {
                farudLList = await _Db.fraud_Fact_Portal.OrderByDescending(x => x.id).Take(700000).ToListAsync();
            }
            else
            {
                if (ruleId != 0)
                {
                    coutRow = await _Db.fraud_Fact_Portal.Where(x => x.Date_id >= startDate && x.Date_id <= endDate && x.Rull_id == ruleId).CountAsync();
                    if (coutRow > 700000)
                    {
                        return Json(farudLList);
                    }
                    else
                    {
                        farudLList = await _Db.fraud_Fact_Portal.Where(x => x.Date_id >= startDate && x.Date_id <= endDate && x.Rull_id == ruleId).ToListAsync();
                        return Json(farudLList);
                    }
                }

                coutRow = await _Db.fraud_Fact_Portal.Where(x => x.Date_id >= startDate && x.Date_id <= endDate).CountAsync();
                if (coutRow > 700000)
                {
                    return Json(farudLList);
                }
                farudLList = await _Db.fraud_Fact_Portal.Where(x => x.Date_id >= startDate && x.Date_id <= endDate).ToListAsync();
            }

            return Json(farudLList);
        }

        [HttpPost]

        public async Task<IActionResult> RefineUpdate([FromBody] refineIds listIds)
        {


            long[] idArray = listIds.listIds;
            string date = DateTime.Now.ToString("MM/dd/yyyy");
            string user = User.Identity.Name;
            await _Db.fraud_Fact_Portal.Where(x => idArray.Contains(x.id)).UpdateFromQueryAsync(x => new Fraud_Fact_Portal
            {
                NeedToAction = "Yes",
                editdate = date,
                userEdit = user
            });
            await _Db.fraud_Fact_Portal.Where(x => idArray.Contains(x.id)).InsertFromQueryAsync("processes", x => new process()
            {
                refineId = x.id,
                Date_id = x.Date_id,
                Rull_id = x.Rull_id,
                Condition = x.Condition,

                Period = x.Period,
                TypePeriod = x.TypePeriod,
                Risk = x.Risk,
                SourcePan = x.SourcePan,
                DestinationSECPAN = x.DestinationSECPAN,
                EncryptDestinationPAN = x.EncryptDestinationPAN,
                Terminal = x.Terminal,
                User_Id = x.User_Id,
                GuildTitle = x.GuildTitle,
                BankBin = x.BankBin,
                PrCode_Id = x.PrCode_Id,
                PosConnectionType = x.PosConnectionType,
                CountOfTransaction_Success = x.CountOfTransaction_Success,
                CountOfTransaction_unSuccess = x.CountOfTransaction_unSuccess,
                Amount_Success = x.Amount_Success,
                Amount_unSuccess = x.Amount_unSuccess,
                CountOfTerminal = x.CountOfTerminal,
                CountOfSourcePan = x.CountOfSourcePan,
                CountOfRepeat = x.CountOfRepeat,
                DiffTime1 = x.DiffTime1,
                DiffTime2 = x.DiffTime2,
                P_Unsucsess = x.P_Unsucsess,
                P_SorcePan = x.P_SorcePan,
                Detail1 = x.Detail1,
                Detail2 = x.Detail2,
                Detail3 = x.Detail3,
                Detail4 = x.Detail4,
                workGroup = "اداره پولشویی",
                actionStatus = statusRecord["در حال انجام"],
            });

            return Content("آپدیت انجام شد");
        }


        public IActionResult Pivot()
        {
            @ViewData["main-title"] = "گزارش و آمار";
            @ViewData["section-titile-1"] = "جستجو ";
            @ViewData["section-titile-2"] = "آمار و نمودار (استفاده از مرورگر فایرفاکس برای این بخش توصیه می شود)";
            var list = _Db.IdentifyDailyFrauds_RuleList.ToList();
            ViewData["RuleOptions"] = new SelectList(_Db.IdentifyDailyFrauds_RuleList, "RuleID", "Description");

            return View();
        }

        public async Task<IActionResult> PivotData(int startDate = 0, int endDate = 0, int ruleId = 0)
        {
            dynamic farudLList = null;
            int coutRow;
            if (startDate == 0 || endDate == 0)
            {
                farudLList = await _Db.fraud_Fact_Portal.OrderByDescending(x => x.id).Take(1500000).ToListAsync();
            }
            else
            {
                if (ruleId != 0)
                {
                    coutRow = await _Db.fraud_Fact_Portal.Where(x => x.Date_id >= startDate && x.Date_id <= endDate && x.Rull_id == ruleId).CountAsync();
                    if (coutRow > 1500000)
                    {
                        return Json(farudLList);
                    }
                    else
                    {
                        farudLList = await _Db.fraud_Fact_Portal.Where(x => x.Date_id >= startDate && x.Date_id <= endDate && x.Rull_id == ruleId).ToListAsync();

                        return Json(farudLList);
                    }
                }

                coutRow = await _Db.fraud_Fact_Portal.Where(x => x.Date_id >= startDate && x.Date_id <= endDate).CountAsync();
                if (coutRow > 1500000)
                {
                    return Json(farudLList);
                }
                farudLList = await _Db.fraud_Fact_Portal.Where(x => x.Date_id >= startDate && x.Date_id <= endDate).ToListAsync();
            }


            return Json(farudLList);
        }


        public IActionResult Process()
        {
            @ViewData["main-title"] = "موارد مربوط به من";
            @ViewData["section-titile-1"] = "عملیات";
            @ViewData["section-titile-2"] = "نمایش داده";

            ViewData["actionTypeOption"] = new SelectList(actionTypeRecord, "Key", "Value");
            ViewData["actionStatusOption"] = new SelectList(statusRecord, "Key", "Value");
            ViewData["workGroupption"] = new SelectList(_Db.WorkGroups, "Name", "Name");

            return View();
        }
        public async Task<IActionResult> ProcessData()
        {
            var claimWorkGroup = User.Claims.FirstOrDefault(c => c.Type == "WorkGroup").Value;
            dynamic farudLList;

            if (claimWorkGroup == "admin")
            {
                farudLList = await _Db.processes.OrderByDescending(x => x.id).ToListAsync();
            }
            else
            {
                farudLList = await _Db.processes.Where(x => x.workGroup == claimWorkGroup).OrderByDescending(x => x.id).ToListAsync();
            }



            return Json(farudLList);
        }

        [HttpPost]

        public async Task<IActionResult> ProcessUpdate([FromBody] processUpdate list)
        {


            List<process> listRows = list.listRows;

            if (listRows.Count > 0)
            {
                foreach (var row in listRows)
                {
                    await _Db.processes.Where(x => x.id == row.id).UpdateFromQueryAsync(x => new process
                    {
                        actionType = row.actionType == "" ? x.actionType : row.actionType,
                        actionStatus = row.actionStatus == "" ? x.actionStatus : row.actionStatus,
                        workGroup = row.workGroup == "" ? x.workGroup : row.workGroup,
                        actionDueDate = row.actionDueDate == "" ? x.actionDueDate : row.actionDueDate,
                        description = row.description == "" ? x.description : row.description,
                        editDate = row.editDate,
                        userEdit = row.userEdit,
                    });
                    var t = await _Db.processes.Where(x => x.id == row.id).InsertFromQueryAsync("historyComments", x => new HistoryComment()
                    {

                        actionType = x.actionType,
                        actionDueDate = x.actionDueDate,
                        actionStatus = x.actionStatus,
                        description = x.description,
                        editDate = x.editDate,
                        userEdit = x.userEdit,
                        workGroup = x.workGroup,

                        processId = x.id,

                    });
                }
            }
            else
            {
                return BadRequest("یکی از فیلد ها را تغییر دهید");
            }




            return Content("آپدیت انجام شد");
        }

        public async Task<IActionResult> ProcessCycle(int id)
        {
            string content = "";
            var listHistory = await _Db.historyComments.Where(x => x.processId == id).OrderByDescending(x => x.id).ToListAsync();
            if (listHistory.Count == 0)
            {
                return Content("تاریخچه ای وجود ندارد");
            }
            else
            {
                foreach (var history in listHistory)
                {
                    content += @"<div style='border-bottom: 1px dashed black;'>
                            <h5 style='color:#7066e0'><span><i class='fa fa-hand-o-left'> ثبت کننده: " + history.userEdit + @" </i> </span> &nbsp&nbsp&nbsp<span> <i class='fa fa-chevron-left'> تاریخ ثبت : " + history.editDate + @"</i> </span></h5>
                            <div style=' text-align: right;direction: rtl; '>
                            <span style='font-weight:bold;'> توضیحات : </span>
                            <p>" + history.description +
                            @"</p>
                            </div>
                            <h5 style='color:#6f7578c7'><span><i class='fa fa-chevron-circle-left'> نوع اقدام: " + history.actionType + @" </i> </span> &nbsp&nbsp&nbsp<span> <i class='fa fa-chevron-circle-left'> وضعیت : " + history.actionStatus + @"</i> </span> &nbsp&nbsp&nbsp<span> <i class='fa fa-chevron-circle-left'> تاریخ تحویل : " + history.actionDueDate + @"</i> </span></h5>
                            </div>";

                }

                return Content(content, "text/html");
            }


        }

        //public IActionResult RefineData(int startRow, int endRow)
        //{
        //    var farudLList = _Db.fraud_Fact_Portal.Where(x => x.id >= startRow && x.id <= endRow).ToList();

        //    return Json(farudLList);
        //}

        public class refineIds
        {
            public long[] listIds { set; get; }
        }

        public class processUpdate
        {
            public List<process> listRows { set; get; }
        }
    }
}
