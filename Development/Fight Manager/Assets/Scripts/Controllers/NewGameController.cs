using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NewGameController : MonoBehaviour
{
    public GameObject statInputPrefab;
    private GameObject availablePoints;
    private Transform statsContainer; 

    public List<InputField> inputComponents;
    private Dictionary<string,string> fieldInputs = new Dictionary<string, string>
    {{"FirstName",null},{"LastName",null},{"Role",null}};

    
    public List<GameObject> screens;

    private GameObject GetScreen(string name) {
        return screens.First(x => x.gameObject.name == name);
    }
    private Dictionary<string,Dictionary<string,string>> navigationMap = new Dictionary<string,Dictionary<string,string>>
    {
        {
            "Details", new Dictionary<string,string>
            {
                {"Back","Home"},
                {"Next","Location"}
            }
        },
        {
            "Location", new Dictionary<string,string>
            {
                {"Back","Details"},
                {"Next","Avatar"}
            }
        },
        {
            "Avatar", new Dictionary<string,string>
            {
                {"Back","Location"},
                {"Next","Preview"}
            }
        }
    };
    

    public void Awake() {
        availablePoints = GameObject.Find("StatPoints");
        availablePoints.SetActive(false);
        statsContainer = GameObject.Find("Stats").GetComponent<Transform>();
        foreach (InputField inputComponent in inputComponents)
        {
            inputComponent.onEndEdit.AddListener(delegate { Input(inputComponent); });
        }
    }

    public void Input(InputField inputField) {
        string field = inputField.gameObject.name; 
        string value = inputField.text;
        Debug.Log(field + ": " + value);
        fieldInputs[field] = value;
        ValidateInput();
    }

    private void ClearStats() {
        if(statsContainer.childCount > 0) {
            for (int i = statsContainer.childCount - 1; i >= 0; i--) {
                DestroyImmediate(statsContainer.GetChild(i).gameObject);
            }
        }
    }
    private void PopulateStats(List<string> stats) {
        foreach(string stat in stats) {
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

    private void ValidateInput() {
        if(fieldInputs.Values.Any(x => x == null)) {
            Debug.Log("Details Still Required");
            return;
        }
        if(StatPoints() > 0) {
            Debug.Log("Points Require Allocation");
            return;
        }
        GameObject.Find("Next").GetComponent<Button>().interactable = true;
    }

    private void UpdateAvailablePoints() {
        availablePoints.SetActive(true);
        int value = StatPoints();
        availablePoints.transform.Find("Value").GetComponent<Text>().text = value.ToString();
        ValidateInput();
    }

    public void SelectRole(string roleName) {
        Role role = Roles.GetRoleByName(roleName);
        ClearStats();
        PopulateStats(role.Stats());
        UpdateAvailablePoints();
        fieldInputs["Role"] = roleName;
    }
    
    public void Back(string section) {
        string screen = navigationMap[section]["Back"];
        Debug.Log("Back: "+screen);
        GetScreen(section).SetActive(false);
        GetScreen(screen).SetActive(true);
    }
    public void Next(string section) {
        string screen = navigationMap[section]["Next"];
        Debug.Log("Next: "+screen);
        GetScreen(section).SetActive(false);
        GetScreen(screen).SetActive(true);
    }
}
