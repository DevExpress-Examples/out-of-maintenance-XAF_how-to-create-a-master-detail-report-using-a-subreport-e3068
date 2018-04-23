using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace WinSolution3.Module {
    [DefaultClassOptions]
    public class DomainObject2 : BaseObject {
        public DomainObject2(Session session)
            : base(session) { }
        private string _Name;
        public string Name {
            get { return _Name; }
            set { SetPropertyValue("Name", ref _Name, value); }
        }
        private DomainObject1 _DomainObject1;
        [Association("DomainObject1-DomainObject2s")]
        public DomainObject1 DomainObject1 {
            get { return _DomainObject1; }
            set { SetPropertyValue("DomainObject1", ref _DomainObject1, value); }
        }
    }
}
