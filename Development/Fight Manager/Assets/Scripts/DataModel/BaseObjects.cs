using System.Collections.Generic;
using UnityEngine;

public static class BaseObjects {

    public static List<DataObject> Collection() {
        Debug.Log("Get Base Objects Collection");
        return new List<DataObject>{
            Individual(),Organisation(),Affiliation()
        };
    }

    private static DataObject Individual() {
        Debug.Log("Build Individual Object");
        DataObject dataObject = new DataObject("individual","Individual");
        List<ObjectField> fields = new List<ObjectField>(){
            ObjectField.String("firstName","First Name",true,(string)("")),
            ObjectField.String("lastName","Last Name",true,(string)("")),
            //ObjectField.String("location","Location",true,(string)("")),
        };
        dataObject.AddFields(fields);
        return dataObject;
    }

    private static DataObject Organisation() {
        Debug.Log("Build Organisation Object");
        DataObject dataObject = new DataObject("organisation","Organisation");
        /*
        List<ObjectField> fields = new List<ObjectField>(){
            ObjectField.Lookup("ownerId","Owner Id",true,(string)(""),"individual","myOrgs","My Organisations")
        };
        dataObject.AddFields(fields);*/
        return dataObject;
    }

    private static DataObject Affiliation() {
        Debug.Log("Build Affiliation Object");
        DataObject dataObject = new DataObject("affiliation","Affiliation");
        List<ObjectField> fields = new List<ObjectField>(){
            ObjectField.Lookup("individualId","Individual Id",true,(string)(""),"individual","affiliations","Affiliated Organisations"),
            ObjectField.Lookup("organisationId","Organisation Id",true,(string)(""),"organisation","affiliations","Affiliated Individuals")
        };
        dataObject.AddFields(fields);
        return dataObject;
    }
}