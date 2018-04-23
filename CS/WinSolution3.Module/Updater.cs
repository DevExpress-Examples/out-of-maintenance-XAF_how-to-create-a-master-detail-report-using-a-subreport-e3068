using System;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Reports;
using System.Collections;

namespace WinSolution3.Module {
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            CreateReport("DetailReport");
            CreateReport("MasterReport");
            CreateMaster("Master 1", new object[]{  CreateDetail("Detail 1"),
                                                    CreateDetail("Detail 2"),
                                                    CreateDetail("Detail 3")});
            CreateMaster("Master 2", new object[]{  CreateDetail("Detail 4"),
                                                    CreateDetail("Detail 5")});
            CreateMaster("Master 3", new object[]{  CreateDetail("Detail 6"),
                                                    CreateDetail("Detail 7"),
                                                    CreateDetail("Detail 8"),
                                                    CreateDetail("Detail 9")});
        }
        private void CreateReport(string reportName) {
            ReportData reportdata = ObjectSpace.FindObject<ReportData>(new BinaryOperator("Name", reportName));
            if (reportdata == null) {
                reportdata = ObjectSpace.CreateObject<ReportData>();
                XafReport rep = new XafReport();
                rep.ObjectSpace = ObjectSpace;
                rep.LoadLayout(GetType().Assembly.GetManifestResourceStream(
                   "WinSolution3.Module.SavedReports." + reportName + ".repx"));
                rep.ReportName = reportName;
                reportdata.SaveReport(rep);
                reportdata.Save();
            }
        }
        private DomainObject1 CreateMaster(string name, ICollection details) {
            DomainObject1 master = ObjectSpace.FindObject<DomainObject1>(new BinaryOperator("Name", name));
            if (master == null) {
                master = ObjectSpace.CreateObject<DomainObject1>();
                master.Name = name;
                foreach(DomainObject2 detail in details) {
                    master.DomainObject2s.Add(detail);
                }
                master.Save();
            }
            return master;
        }
        private DomainObject2 CreateDetail(string name) {
            DomainObject2 detail = ObjectSpace.FindObject<DomainObject2>(new BinaryOperator("Name", name));
            if (detail == null) {
                detail = ObjectSpace.CreateObject<DomainObject2>();
                detail.Name = name;
                detail.Save();
            }
            return detail;
        }
    }
}
