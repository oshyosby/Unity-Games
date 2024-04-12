using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NewGameController : MonoBehaviour
{
    public GameObject statInputPrefab;
    private GameObject availablePoints;
    private Transform statsContainer; 

    public List<InputController> inputs;
    public ScreenManager screenManager;

    private int StatPoints() {
        int total = statsContainer.childCount * 10;
        Debug.Log("Total:"+total);
        int used = 0;
        for(int i=0; i<statsContainer.childCount; i++) {
            int statInput;
            if(!int.TryParse(statsContainer.GetChild(i).Find("Value").Find("Input").GetComponent<Text>().text, out statInput)) {
                statInput = 0;
            }
            Debug.Log("Input:"+statInput);
            used += statInput;
        }
        Debug.Log("Used:"+used);
        int value = total - used;
        Debug.Log("Value:"+value);
        return value;
    }

    private void UpdateAvailablePoints() {
        availablePoints.SetActive(true);
        int value = StatPoints();
        availablePoints.transform.Find("Value").GetComponent<Text>().text = value.ToString();
    }

    private void PopulateStats() {
        Role role = Roles.GetRoleByName("Coach");
        foreach(string stat in role.Stats()) {
            GameObject statInput = Instantiate(statInputPrefab, statsContainer);
            statInput.name = stat;
            statInput.transform.Find("Label").GetComponent<Text>().text = stat;
            InputField inputField = statInput.transform.Find("Value").GetComponent<InputField>();
            if(inputField != null) {
                Debug.Log("InputField component found.");
                inputField.onEndEdit.AddListener(delegate { UpdateAvailablePoints(); });
                Debug.Log("Event listener added to InputField.");
            } else {
                Debug.Log("Input not Found");
            } 
        }
    }

    public void Awake() {
        availablePoints = GameObject.Find("StatPoints");
        statsContainer = GameObject.Find("Stats").GetComponent<Transform>();
        inputs = gameObject.GetComponentsInChildren<InputController>().ToList();
        PopulateStats();
        UpdateAvailablePoints();
    }
}
