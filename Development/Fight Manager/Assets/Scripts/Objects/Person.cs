using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Person {

    [SerializeField]
    public string id;
    [SerializeField]
    public string firstName;
    [SerializeField]
    public string lastName;
    public string FullName() {
        return firstName + " " + lastName;
    }
    [SerializeField]
    public string location;
    [SerializeField]
    public List<string> roles;
    [SerializeField]
    public List<Stat> stats;
    public Record recordVersion;

    public void PrepareRecord() {
        Dictionary<string,object> data = new Dictionary<string,object>{
            {"firstName",firstName},{"lastName",lastName},{"location",location},
            {"roles",roles},{"stats",stats}
        };
        Record record = new Record(FullName(),"person",data);
        record.id = id;
        recordVersion = record;
    }

    public Person(string firstName, string lastName, string location, string role, List<Stat> stats) {
        id = "undefined";
        this.firstName = firstName;
        this.lastName = lastName;
        this.location = location;
        roles = new List<string>{role};
        this.stats = stats;   
        PrepareRecord();
    }

    public void Push() {
        GameManager.Instance().DataManager().Add(recordVersion);
    }
}