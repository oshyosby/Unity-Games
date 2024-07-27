// Script Data Model


namespace Framework {

    using System.Linq;

    public class SDataModel {
        
        private List<SObject> sObjects = new List<SObject>();
        public List<SObject> SObjects {
            get {
                return sObjects;
            }
            set {
                sObjects = value;
            }
        }

        public SDataModel(List<SObject> sObjects) {
            SObjects = BaseObjects.List();
            SObjects.AddRange(sObjects);
            Records = BaseRecords.MenuItems();
        }

        public SObject? GetSObjectByName(string name) {
            try {
                return SObjects.First(x => x.Name == name); 
            }
            catch {
                return null;
            }
        }
        public void AddSObject(SObject sObject) {
            if(SObjects.Any(x => x.Name == sObject.Name)) {
                return;
            }
            SObjects.Add(sObject);
        }

        private List<Record> _records = new List<Record>();
        public List<Record> Records {
            get {
                return _records;
            }
            set {
                _records = value; 
            }
        }
        public List<Record> GetRecordsBySObjectName(string sObjectName) {
            return _records.Where(x => x.SObjectName == sObjectName).ToList();
        }
        public Record? GetRecordById(string recordId) {
            return _records.FirstOrDefault(x => x.Id == recordId);
        }
        public void AddRecord(Record record) {
            GuidGenerator.SetRecordId(record);
            _records.Add(record);
        }
    }

    public static class BaseObjects {
        private static SObject MenuItem() {
            SObject sObject = new SObject("menuItem","Menu Item","mit");
            List<Field> fields = new List<Field>{
                new Field("label","Label","string",true),
                new Field("order","Order","int",true),
                new Field("isActive","Active?","bool",true)
            };
            sObject.NewFields(fields);
            return sObject;
        }

        private static SObject Save() {
            SObject sObject = new SObject("save","Save","sav");
            List<Field> fields = new List<Field>{
                new Field("createdDate","Created Date/Time","DateTime",true),
                new Field("modifiedDate","Last Modified Date/Time","DateTime",true),
                new Field("data","Data","SDataModel",true)
            };
            sObject.NewFields(fields);
            return sObject;
        }

        public static List<SObject> List() {
                return new List<SObject>
                {MenuItem(), Save()};
            }
    }

    public static class BaseRecords {
        public static List<Record> MenuItems() {
            return new List<Record>{
                new Record(new Dictionary<string,object>{
                    {"id", "menuItem-resume"},
                    {"sObjectName", "menuItem"},
                    {"name", "resume"},
                    {"label", "Resume"},
                    {"order", 0},
                    {"isActive", false}
                }),
                new Record(new Dictionary<string,object>{
                    {"id", "menuItem-newGame"},
                    {"sObjectName", "menuItem"},
                    {"name", "newGame"},
                    {"label", "New Game"},
                    {"order", 1},
                    {"isActive", true}
                }),
                new Record(new Dictionary<string,object>{
                    {"id", "menuItem-loadGame"},
                    {"sObjectName", "menuItem"},
                    {"name", "loadGame"},
                    {"label", "Load Game"},
                    {"order", 2},
                    {"isActive", false}
                }),
                new Record(new Dictionary<string,object>{
                    {"id", "menuItem-settings"},
                    {"sObjectName", "menuItem"},
                    {"name", "settings"},
                    {"label", "Settings"},
                    {"order", 3},
                    {"isActive", true}
                }),
            };
        }
    }
}