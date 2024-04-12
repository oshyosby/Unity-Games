using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    public string type;
    private InputField inputField;
    private Dropdown dropdown;

    private string value;
    public void Input() {
        switch(type) {
            case "InputField":
                value = inputField.text;
                break;
            case "Dropdown":
                int valueIndex = dropdown.value;
                value = dropdown.options[valueIndex].text;
                break;
            default:
                value = "undefined";
                break;
        }
        Debug.Log("Value: "+value);
    }

    public void Awake() {
        inputField = GetComponent<InputField>();
        dropdown = GetComponent<Dropdown>();

        if(inputField != null) {
            type = "InputField";
            inputField.onEndEdit.AddListener(delegate { Input(); });
        } else if(dropdown != null) {
            type = "Dropdown";
            dropdown.onValueChanged.AddListener(delegate { Input(); });
        } else {
            type = "undefined";
        }
    }    
}
