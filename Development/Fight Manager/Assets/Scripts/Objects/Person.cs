using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Person : Record {

    [SerializeField]
    public string id {get; set;}
    [SerializeField]
    public string name {get; set;}
    [SerializeField]
    public string firstName;
    [SerializeField]
    public string lastName;
    public string FullName() {
        return firstName+ " "+lastName;
    }
    [SerializeField]
    public string location;
    [SerializeField]
    public List<string> roles;
    [SerializeField]
    public List<Stat> stats;

    public Person(string firstName, string lastName, string location, string role, List<Stat> stats) {
        id = GameManager.Instance().data.GetUniqueId("person",new List<Record>(GameManager.Instance().data.people));
        name = firstName+" "+lastName;
        this.firstName = firstName;
        this.lastName = lastName;
        this.location = location;
        roles = new List<string>{role};
        this.stats = stats;
        GameManager.Instance().data.people.Add(this);
    }
}