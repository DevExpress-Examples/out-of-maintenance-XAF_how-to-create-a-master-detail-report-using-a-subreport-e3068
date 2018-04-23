
using DevExpress.Xpo;

using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Editors;

namespace WinSolution3.Module {
    [DefaultClassOptions]
    public class DomainObject1 : BaseObject {
        public DomainObject1(Session session)
            : base(session) { }
        private string _Name;
        public string Name {
            get { return _Name; }
            set { SetPropertyValue("Name", ref _Name, value); }
        }
        private string _Description;
        public string Description {
            get { return _Description; }
            set { SetPropertyValue("Description", ref _Description, value); }
        }
        private int _Value;
        public int Value {
            get { return _Value; }
            set { SetPropertyValue("Value", ref _Value, value); }
        }
        [Association("DomainObject1-DomainObject2s")]
        public XPCollection<DomainObject2> DomainObject2s {
            get {
                return GetCollection<DomainObject2>("DomainObject2s");
            }
        }
    }
}
