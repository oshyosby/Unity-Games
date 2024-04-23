using System.Collections.Generic;
using UnityEngine;

public static class BaseObjects {

    public static List<DataObject> Collection() {
        Debug.Log("Get Base Objects Collection");
        return new List<DataObject>{
            Individual(),Organisation()
        };
    }

    private static DataObject Individual() {
        Debug.Log("Build Individual Object");
        DataObject dataObject = new DataObject("individual","Individual");
        List<DataField> fields = new List<DataField>(){
            DataField.String("firstName","First Name",true,(string)("")),
            DataField.String("lastName","Last Name",true,(string)("")),
            //DataField.String("location","Location",true,(string)("")),
        };
        dataObject.AddFields(fields);
        return dataObject;
    }

    private static DataObject Organisation() {
        Debug.Log("Build Organisation Object");
        DataObject dataObject = new DataObject("organisation","Organisation");
        List<DataField> fields = new List<DataField>(){
            DataField.Lookup("ownerId","Owner Id",true,(string)(""),"individual","myOrgs","My Organisations")
        };
        dataObject.AddFields(fields);
        return dataObject;
    }
}