<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128588715/10.2.6%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3068)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [DomainObject1.cs](./CS/WinSolution3.Module/DomainObject1.cs) (VB: [DomainObject1.vb](./VB/WinSolution3.Module/DomainObject1.vb))
* [DomainObject2.cs](./CS/WinSolution3.Module/DomainObject2.cs) (VB: [DomainObject2.vb](./VB/WinSolution3.Module/DomainObject2.vb))
* **[Updater.cs](./CS/WinSolution3.Module/Updater.cs) (VB: [Updater.vb](./VB/WinSolution3.Module/Updater.vb))**
<!-- default file list end -->
# How to create a master-detail report using a Subreport


<p>The <a href="http://documentation.devexpress.com/#XtraReports/CustomDocument1466"><u>Master-Detail Report</u></a> article in the XtraReports documentation describes how to create master-detail reports in two ways - via the DetailReportBand and XRSubreport controls. The first approach is preferable and can be easily used in XAF. However, if you need to use the second approach, steps required to implement it in XAF should be slightly modified, because generally the class on the Many side of an association does not have a simple property with the master's ID. You can filter a detail report by the master object's ID:</p>

```cs
using DevExpress.ExpressApp.Reports;
private void subreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e) {
  XRSubreport subreport = (XRSubreport)sender;
  subreport.ReportSource.Parameters["MasterID"].Value = ((XafReport)xafReport1).ObjectSpace.GetKeyValue(GetCurrentRow());
}


```

<p>For additional information, please see reports in the attached example.</p><p>Note, this example is now included as a part of the FeatureCenter demo.</p><p><strong>IM</strong><strong>PORTANT NOTES<br />
</strong>If you use the ViewDataSource (from the ReportsV2 module) for the master report, then you will have to modify your script as follows:<br />


```cs
using DevExpress.Xpo;
private void subreport2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e) {
  XRSubreport subreport = (XRSubreport)sender;
  subreport.ReportSource.Parameters["MasterID"].Value = ((ViewRecord)GetCurrentRow())["Oid"];
}

```

 </p>

<br/>


