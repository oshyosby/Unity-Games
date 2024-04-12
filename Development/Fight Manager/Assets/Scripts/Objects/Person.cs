using System;

public class Person : Record {
    public string firstName;
    public string lastName;
    public string FullName() {
        return firstName+ " "+lastName;
    }
    public string location;

    public Person(string firstName, string lastName, string location) 
    : base(firstName+" "+lastName,"Person","person") {
        this.firstName = firstName;
        this.lastName = lastName;
        this.location = location;
        GameManager.Instance().data.people.Add(this);
    }
}