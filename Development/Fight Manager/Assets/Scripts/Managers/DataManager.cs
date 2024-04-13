using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DataManager {
    [SerializeField]
    public List<Record> records = new List<Record>();
    [SerializeField]
    public List<Person> people = new List<Person>();
}