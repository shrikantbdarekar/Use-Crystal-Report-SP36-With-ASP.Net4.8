
````markdown
# CrystalDemo36

**CrystalDemo36** is a simple and educational ASP.NET Web Forms project built using **.NET Framework 4.8.1** and **SAP Crystal Reports SP36**.  
It is designed as a **hands-on guide for students and beginners** who want to learn how to integrate **Crystal Reports** into ASP.NET applications — and export reports in **PDF, Excel, and Word** formats.

---

## 🎯 Project Overview

This project demonstrates how to:
- Bind a Crystal Report (`RptStudentList.rpt`) with data dynamically from a `DataSet`.
- Display the report directly in a popup window (without leaving the page).
- Export the report as **PDF**, **Excel**, or **Word**.
- Generate dynamic filenames with timestamps.
- Avoid common Crystal Reports errors (like *Thread was being aborted*).

---

## 🧩 Technologies Used

| Component | Details |
|------------|----------|
| Framework | .NET Framework 4.8.1 |
| UI | ASP.NET Web Forms |
| Reporting Tool | SAP Crystal Reports for Visual Studio SP36 |
| IDE | Visual Studio 2022 |
| Language | C# |
| Output Formats | PDF, Excel, Word |

---

## 🧠 How It Works

### 1. **Creating the Report**
- The report file `RptStudentList.rpt` is designed using Crystal Reports and linked to a dataset (`TestDataSet.xsd`).
- The report displays student data (ID, Name, Address, Mobile, Email).

### 2. **Generating Data in Code**
Instead of fetching data from a database, this demo creates 10 dummy student records dynamically:

```csharp
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
````

This makes the project portable — no database setup required.

---

## 🖥️ Project Interface

On the main page (`Default.aspx`), you’ll see two buttons:

### 🔹 **View Student Report**

* Opens the generated report **in a centered popup window**.
* No address bar, menu, or toolbar.
* The PDF opens directly in the browser window.

```html
<asp:Button ID="ButtonView" 
            runat="server" 
            Text="View Student Report"
            OnClick="ButtonView_Click"
            OnClientClick="
                var w = 1000, h = 800;
                var left = (screen.width / 2) - (w / 2);
                var top = (screen.height / 2) - (h / 2);
                window.open('', 'ReportPopup',
                    'width=' + w + 
                    ',height=' + h + 
                    ',top=' + top + 
                    ',left=' + left + 
                    ',resizable=yes,scrollbars=yes,menubar=no,toolbar=no,location=no,status=no');
                this.form.target = 'ReportPopup';
            " />
```

### 🔹 **Download Report**

* Generates the same report but **forces the browser to download** it as a PDF file.

---

## 📂 Code Explanation (In Short)

### **View Report (Popup Mode)**

```csharp
Response.Clear();
Response.ContentType = "application/pdf";
Response.AddHeader("content-disposition", $"inline; filename=student_list_{timestamp}.pdf");
Response.BinaryWrite(pdfBytes);
Response.Flush();
HttpContext.Current.ApplicationInstance.CompleteRequest();
```

* `inline` → Opens the PDF inside the browser window.
* Centered popup window handled by JavaScript (`window.open`).

---

### **Download Report**

```csharp
Response.Clear();
Response.ContentType = "application/pdf";
Response.AddHeader("content-disposition", $"attachment; filename=student_list_{timestamp}.pdf");
Response.BinaryWrite(pdfBytes);
Response.Flush();
HttpContext.Current.ApplicationInstance.CompleteRequest();
```

* `attachment` → Forces browser to download the file instead of displaying it.

---

## 🧾 Supported Export Formats

Although the demo uses **PDF**, you can easily export to other formats by changing:

```csharp
ExportFormatType.PortableDocFormat   // PDF
ExportFormatType.Excel               // Excel (.xls)
ExportFormatType.WordForWindows      // Word (.doc)
```

Example:

```csharp
rptDoc.ExportToStream(ExportFormatType.Excel);
```

---

## ⚙️ Crystal Reports Runtime

You must install **SAP Crystal Reports Runtime SP36** on your development and target machines.

👉 [Download from SAP Official Page](https://www.sap.com/cmp/td/sap-crystal-reports-visual-studio-trial.html)

Choose the correct version:

* `CRRuntime_64bit_13_0_36.msi` for 64-bit
* `CRRuntime_32bit_13_0_36.msi` for 32-bit

---

## 🧑‍💻 For Students

This project helps you understand:

* How to integrate Crystal Reports in ASP.NET Web Forms.
* How to pass dynamic data using `DataSet` / `DataTable`.
* How to export reports without showing the Crystal viewer.
* How to handle report rendering safely (avoid `Thread was being aborted`).

You can extend it easily:

* Connect with a real database.
* Add filters, dropdowns, or parameters.
* Export directly to Excel or Word.

---

## 📜 License

This project is provided for **educational purposes** by [Sadu Consultancy Services](https://www.saducs.com).
You can modify and reuse it freely for academic and non-commercial learning.

---

### 🧩 Author

**CrystalDemo36**
Guided by [Sadu Consultancy Services](https://www.saducs.com)
📧 [info@saducs.com](mailto:info@saducs.com) | 📞 +91 9765975757

---

### ⭐ Star the Repository

If this project helped you learn Crystal Reports, please give it a ⭐ on GitHub —
it motivates others to explore reporting integration in ASP.NET Framework!

```

