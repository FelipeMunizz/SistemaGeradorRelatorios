using Microsoft.AspNetCore.Mvc;
using RelatorioStimulsoft.Data;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace RelatorioStimulsoft.Controllers
{
    public class ViewerController : Controller
    {
        bd data = new bd();

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult GetReport()
        {
            StiReport report = new StiReport();
            report.Load(StiNetCoreHelper.MapPath(this, "Reports/relatorio_dados.mrt"));
            DataSet dataSet = new DataSet("dataSet");
            DataTable dataTable = new DataTable("Gastos");
            string sql = @"select CONVERT(VARCHAR(10),Data,103) as Data
                ,Area
                ,FORMAT(VALOR, 'c', 'pt-BR') as Valor 
                from Gastos";
            dataTable = data.retornaDataTable<SqlConnection>(sql);
            dataSet.Tables.Add(dataTable);
            report.RegData("dataSet", "dataSet", dataSet);
            return StiNetCoreViewer.GetReportResult(this, report);
        }

        public ActionResult ViewerEvent()
        {
            return StiNetCoreViewer.ViewerEventResult(this);
        }
    }
}
