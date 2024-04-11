using System;
using System.Collections.Generic;
using System.Linq;

public static class Roles{
    private static List<Role> availableRoles = new List<Role>{
        new Role("Coach", new List<string>{
            "attack","defense",
            "agility","durability","intelligence","speed","strength"
        }),
        new Role("Fighter", new List<string>{
            "attack","defense",
            "agility","durability","intelligence","speed","strength"
        }),
        new Role("Promoter", new List<string>{
            "charisma","intelligence","negotiation"
        }),
    }; 
    public static Role GetRoleByName(string roleName){
        return availableRoles.First(x => x.Name() == roleName);
    }
}

public class Role {
    private string name;
    public string Name(){
        return name;
    }
    private List<string> stats;
    public List<string> Stats(){
        return stats;
    }

    public Role(string name, List<string> stats) {
        this.name = name;
        this.stats = stats;
    }
}