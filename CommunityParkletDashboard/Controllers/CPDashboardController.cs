using System;
using System.IO;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityParkletDashboard.Context;
using CommunityParkletDashboard.Models;
using CommunityParkletDashboard.ViewModels;

namespace CommunityParkletDashboard.Controllers
{
    public class CPDashboardController : Controller
    {
        EformsContext _context = new EformsContext();

        [HttpGet]
        public ActionResult CPDashboard(int? page)
        {
            var parklets = _context.GetParkletApplications();
            var model = new CPDashboardModel(parklets, page);
            return View(model);
        }

        public ActionResult CPEmailDashboard(int? page)
        {
            var parklets = _context.GetParkletApplicationsEmails();
            var model = new CPEmailDashboardModel(parklets, page);
            return View(model);
        }

        public ActionResult EditCP(int refNumber)
        {
            try
            {
                var item1 = _context.EditParkletApplication(refNumber);
                var item2 = new CPDashboardModel(item1);
                var model = new EditCPModel
                {
                    Item1 = item1,
                    Item2 = item2
                };
                return View(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        [HttpPost]
        public ActionResult EditCP(EditCPModel cpa, int refNumber)
        {
            _context.UpdateParkletApplication(cpa.Item1, refNumber);
            return RedirectToAction("CPDashboard");
        }

        [HttpGet]
        public ActionResult DeleteCPEmail(int id)
        {
            _context.DeleteParkletApplicationEmail(id);
            return RedirectToAction("CPEmailDashboard");
        }

        [HttpGet]
        public ActionResult DeleteCP(int refNumber)
        {
            _context.DeleteParkletApplication(refNumber);
            return RedirectToAction("CPDashboard");
        }

        public ActionResult SaveCP(string status, string notes, int refNumber)
        {
            string viewStatus = Request.Form["status"];
            _context.SaveCP(viewStatus, notes, refNumber);
            return RedirectToAction("CPDashboard");
        }

        public void ExportCPToExcel(int? page)
        {
            var grid = new GridView();
            var cpDashboardModel = new CPDashboardModel(_context.GetParkletApplications(), page);
            string fileName = String.Format("attachment;filename=CPApplications_{0:yyyyMMdd_Hmm}.xls", DateTime.Now);

            grid.DataSource = cpDashboardModel.lParkletApplicationDtos;
            grid.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition", (fileName));
            Response.ContentType = "application/excel";

            var stringWriter = new StringWriter();
            var htmlTextWriter = new HtmlTextWriter(stringWriter);

            grid.RenderControl(htmlTextWriter);
            Response.Write(stringWriter.ToString());
            Response.End();
        }

        public void ExportCPEmailToExcel(int? page)
        {
            var grid = new GridView();
            var cpDashboardModel = new CPEmailDashboardModel(_context.GetParkletApplicationsEmails(), page);
            string fileName = String.Format("attachment;filename=CPEmails_{0:yyyyMMdd_Hmm}.xls", DateTime.Now);

            grid.DataSource = cpDashboardModel.lParkletApplicationEmailDtos;
            grid.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition", (fileName));
            Response.ContentType = "application/excel";

            var stringWriter = new StringWriter();
            var htmlTextWriter = new HtmlTextWriter(stringWriter);

            grid.RenderControl(htmlTextWriter);
            Response.Write(stringWriter.ToString());
            Response.End();
        }

        public ActionResult DownloadAttachment(string filePath)
        {
            string virtualFilePath = System.Configuration.ConfigurationManager.AppSettings["VirtualDirectoryPath"] + filePath;

            return File(virtualFilePath, System.Net.Mime.MediaTypeNames.Application.Octet);
        }
    }
}