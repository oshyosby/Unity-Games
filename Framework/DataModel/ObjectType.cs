using System.Text.Json;

namespace DataModel;

public enum DML_TYPES {
    INSERT,UPDATE,DELETE
}

public class ObjectType {

    public ObjectType() {}

    public ObjectType(string name, string label, string description, List<ObjectField>? fields, List<ObjectValidation>? validations) {
        this.name = name;
        this.label = label;
        this.description = description;
        this.fields = DEFAULT_FIELDS;
        if(fields != null) fields.ForEach(field => AddField(field));
        if(validations == null) {
            Console.WriteLine("No Validations Populated");
            this.validations = new List<ObjectValidation>();
        } else {
            Console.WriteLine("Number of Validations Inserted: "+validations.Count);
            this.validations = validations;
        }
    }
    
    private string? name;
    public string Name {
        get => name ?? "";
        set => name = value;
    }

    private string? label;
    public string Label {
        get => label ?? "";
        set => label = value;
    }

    private string? description;
    public string Description {
        get => description ?? "";
        set => description = value;
    }

    private List<ObjectField>? fields;
    public List<ObjectField> Fields {
        get => fields ?? new List<ObjectField>();
    }
    public ObjectField GetField(string fieldName) {
        ObjectField? field = Fields.FirstOrDefault(field => field.Name == fieldName);
        return field ?? new ObjectField();
    }
    public void AddField(ObjectField newField) {
        if(Fields.Find(field => field.Name == newField.Name) == null) {
            Fields.Add(newField);
        } else {
            Console.WriteLine("Field Name already Exists");
            //throw new Exception("Field Name already Exists");
        }
    }

    private List<ObjectValidation>? validations;
    public List<ObjectValidation> Validations {
        get => validations ?? new List<ObjectValidation>();
    }
    public ObjectValidation GetValidation(string validationName) {
        ObjectValidation? validation = Validations.FirstOrDefault(validation => validation.Name == validationName);
        return validation ?? new ObjectValidation();
    }
    public void AddValidation(ObjectValidation newValidation) {
        if(Validations.Find(validation => validation.Name == newValidation.Name) == null) {
            Validations.Add(newValidation);
        } else {
            Console.WriteLine("Validation Name already Exists");
            //throw new Exception("Field Name already Exists");
        }
    }
    private static List<ObjectField> DEFAULT_FIELDS = new List<ObjectField>{
        new ObjectField("id", "Id","Id of Record",typeof(string),true),
        new ObjectField("name", "Name","Name of Record",typeof(string),true),
        new ObjectField("objectName", "ObjectType","Record ObjectType Name",typeof(string),true),
    };

    public void DML(ObjectRecord record, DML_TYPES action) {
        switch (action)
        {
            case DML_TYPES.INSERT:
                Insert(record); return;
            case DML_TYPES.UPDATE:
                Update(record); return;
            case DML_TYPES.DELETE:
                Delete(record); return;
            default:
                return;
        }
    }
    private void Insert(ObjectRecord record) {
        // Logic
        // Formulas
        if(record.Id != "") return; // Can't Insert an existing record
        record.Id = Guid.NewGuid().ToString(); // Should be checked against existing Ids
        if(!ValidateRecord(record,null)) return;
        // Insert Record
    }
    private void Update(ObjectRecord record) {
        // Logic
        // Formulas
        // Validate
    }
    private void Delete(ObjectRecord record) {
        // Logic
        // Validate
    }

    private bool ValidateRecord(ObjectRecord newRecord, Dictionary<string,ObjectRecord>? oldRecordMap) {
        Dictionary<string,string> validationErrors;
        validationErrors = Validation(newRecord);
        if(validationErrors.Count > 0) return false;
        return true;
    }

    private Dictionary<string,string> Validation(ObjectRecord record) {
        Dictionary<string,string> validationErrors = new Dictionary<string,string>();
        Fields.ForEach(field => {
            if(field.IsRequired && IsEmpty(record.Data[field.Name])) validationErrors.Add(field.Name,"Required Field Missing Value");
        });
        if(validationErrors.Count > 0) {
            Console.WriteLine("Required Field Errors: "+JsonSerializer.Serialize(validationErrors));
            return validationErrors;
        }
        foreach(ObjectValidation validation in Validations) {
                if(validation.Valid(record)) continue;
                validationErrors.Add(validation.Location,$"Failed Validation Rule: {validation.Name}");
        }
        return validationErrors;
    }

    private static bool IsEmpty(object value) {
        
        if (value == null) return true;
        if (value is string str && string.IsNullOrWhiteSpace(str)) return true;
        if (value is System.Collections.ICollection collection && collection.Count == 0) return true;
        if (value is Array array && array.Length == 0) return true;

        return false;
    }

    // Logic
    // Formulas
}