
namespace DataModel;
public static class User {

    private static List<ObjectField> Fields = new List<ObjectField>{
        new ObjectField("firstName", "First Name","User's First Name",typeof(string),true),
        new ObjectField("lastName", "Last Name","User's Last Name",typeof(string),true)
    };

    private static List<ObjectValidation> ValidationRules = new List<ObjectValidation>{
        new ObjectValidation("Username Validation","Field","name",new List<Func<ObjectRecord, bool>>{
            record => (string)record["name"] != "oscar-shen"
        })
    };

    public static ObjectType Info = new ObjectType(
        "user","User","User Information Object", Fields, ValidationRules
    );
}