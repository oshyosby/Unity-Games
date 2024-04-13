using System;
using UnityEngine;

[Serializable]
public class Stat {
    [SerializeField]
    public string name;
    [SerializeField]
    public string type;
    [SerializeField]
    public int value;

    public Stat(string name, string type, int value) {
        this.name = name;
        this.type = type;
        this.value = value;
    }
}