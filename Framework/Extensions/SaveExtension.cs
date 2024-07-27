namespace Extensions {
    
    using Interfaces;
    using Framework;

    public static class SaveExtension {

        public static void Check(this GameInterface game) {
            bool hasSaves = game.SDataModel.GetRecordsBySObjectName("save").Count > 0 ? true : false;
            List<string> saveMenuItems = new List<string>{"resume","loadGame"};
            List<Record> menuItems = game.SDataModel.GetRecordsBySObjectName("menuItem").Where(x => saveMenuItems.Contains(x.Name)).ToList();
            foreach(Record record in menuItems) {
                record["isActive"] = hasSaves;
            }
        } 
    }
}