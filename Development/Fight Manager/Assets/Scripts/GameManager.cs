using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance() {
        if (instance == null) {
        }
        return instance;
    }

    private void Awake() {
        instance = this; 
    }

    public DataManager data;

    public GameManager() {
        data = new DataManager();
    }
}
