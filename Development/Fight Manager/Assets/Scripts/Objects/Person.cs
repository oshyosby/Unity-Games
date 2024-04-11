using System;

public class Person : Record {
    public string firstName;
    public string lastName;
    public string FullName() {
        return firstName+ " "+lastName;
    }

    public Person(string firstName, string lastName) 
    : base(firstName+" "+lastName,"Person","person") {
        this.firstName = firstName;
        this.lastName = lastName;
        GameManager.Instance().data.people.Add(this);
    }
}