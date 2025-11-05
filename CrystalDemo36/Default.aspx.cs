using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace CrystalDemo36
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonView_Click(object sender, EventArgs e)
        {
            // Create instance of your Crystal Report
            ReportDocument rptDoc = new CrystalDemo36.Report.RptStudentList();

            // Create DataTable from your dataset
            DataTable dataTable = new Data.TestDataSet().Student.Copy();

            // Add 10 dummy rows
            for (int i = 1; i <= 10; i++)
            {
                DataRow row = dataTable.NewRow();
                row["StudentId"] = i;
                row["StudentName"] = "Student " + i;
                row["Address"] = "Address " + i;
                row["Mobile"] = "99999999" + i.ToString("00");
                row["Email"] = "student" + i + "@example.com";
                dataTable.Rows.Add(row);
            }

            // Assign data to report
            rptDoc.SetDataSource(dataTable);

            // Generate filename with timestamp: student_list_yyyy_mm_dd_hhmmss.pdf
            string timestamp = DateTime.Now.ToString("yyyy_MM_dd_HHmmss");
            string fileName = $"student_list_{timestamp}.pdf";

            // === Export to PDF ===
            try
            {
                // Export report to PDF stream
                using (Stream stream = rptDoc.ExportToStream(ExportFormatType.PortableDocFormat))
                {
                    byte[] pdfBytes = new byte[stream.Length];
                    stream.Read(pdfBytes, 0, pdfBytes.Length);

                    // ============================================================
                    // OPTION 1: OPEN PDF IN NEW TAB/WINDOW
                    // ============================================================
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", $"inline; filename={fileName}");
                    //Response.AddHeader("content-disposition", "inline; filename=StudentList.pdf");
                    Response.BinaryWrite(pdfBytes);
                    Response.Flush();
                    HttpContext.Current.ApplicationInstance.CompleteRequest();

                    // ============================================================
                    // OPTION 2: FORCE DOWNLOAD PDF FILE
                    // ============================================================
                    //Response.Clear();
                    //Response.ContentType = "application/pdf";
                    //Response.AddHeader("content-disposition", "attachment; filename=StudentList.pdf");
                    //Response.BinaryWrite(pdfBytes);
                    //Response.Flush();
                    //HttpContext.Current.ApplicationInstance.CompleteRequest();

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Export error: " + ex.Message.Replace("'", "") + "');</script>");
            }
            finally
            {
                rptDoc.Close();
                rptDoc.Dispose();
            }
        }
        protected void ButtonDownload_Click(object sender, EventArgs e)
        {
            // Create instance of your Crystal Report
            ReportDocument rptDoc = new CrystalDemo36.Report.RptStudentList();

            // Create DataTable from your dataset
            DataTable dataTable = new Data.TestDataSet().Student.Copy();

            // Add 10 dummy rows
            for (int i = 1; i <= 10; i++)
            {
                DataRow row = dataTable.NewRow();
                row["StudentId"] = i;
                row["StudentName"] = "Student " + i;
                row["Address"] = "Address " + i;
                row["Mobile"] = "99999999" + i.ToString("00");
                row["Email"] = "student" + i + "@example.com";
                dataTable.Rows.Add(row);
            }

            // Assign data to report
            rptDoc.SetDataSource(dataTable);

            // Generate filename with timestamp: student_list_yyyy_mm_dd_hhmmss.pdf
            string timestamp = DateTime.Now.ToString("yyyy_MM_dd_HHmmss");
            string fileName = $"student_list_{timestamp}.pdf";

            // === Export to PDF ===
            try
            {
                // Export report to PDF stream
                using (Stream stream = rptDoc.ExportToStream(ExportFormatType.PortableDocFormat))
                {
                    byte[] pdfBytes = new byte[stream.Length];
                    stream.Read(pdfBytes, 0, pdfBytes.Length);

                    // ============================================================
                    // OPTION 1: OPEN PDF IN NEW TAB/WINDOW
                    // ============================================================
                    //Response.Clear();
                    //Response.ContentType = "application/pdf";
                    //Response.AddHeader("content-disposition", "inline; filename=StudentList.pdf");
                    //Response.BinaryWrite(pdfBytes);
                    //Response.Flush();
                    //HttpContext.Current.ApplicationInstance.CompleteRequest();

                    // ============================================================
                    // OPTION 2: FORCE DOWNLOAD PDF FILE
                    // ============================================================
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", $"attachment; filename={fileName}");
                    //Response.AddHeader("content-disposition", "attachment; filename={fileName}");
                    Response.BinaryWrite(pdfBytes);
                    Response.Flush();
                    HttpContext.Current.ApplicationInstance.CompleteRequest();

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Export error: " + ex.Message.Replace("'", "") + "');</script>");
            }
            finally
            {
                rptDoc.Close();
                rptDoc.Dispose();
            }
        }
    }
}