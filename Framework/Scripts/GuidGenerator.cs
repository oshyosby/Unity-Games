
namespace Framework;
public class GuidGenerator {
    private static string BaseGuid() {
        return Guid.NewGuid().ToString();
    }

    private static string FormattedGuid(string baseGuid, string prefix) {
        return string.IsNullOrEmpty(prefix) ? baseGuid : prefix + baseGuid.Substring(prefix.Length);
    }

    private static bool UniqueRecordGuid(string recordId) {
        return Game.Instance.SDataModel.Records.Any(x => x.Id == recordId) ? false : true;
    }

    private static string GetPrefix(string sObjectName) {
        var sObject = Game.Instance.SDataModel.GetSObjectByName(sObjectName);
        return sObject != null ? sObject.Prefix : "";
    }

    public static void SetRecordId(Record record) {
        bool isGenerated = false;
        string recordId = record.Id;
        while(isGenerated == false) {
            recordId = FormattedGuid(BaseGuid(),GetPrefix(record.SObjectName));
            isGenerated = UniqueRecordGuid(recordId);
        }
        record.Id = recordId; 
    }
}