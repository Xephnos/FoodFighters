using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class KeybindingsManager : MonoBehaviour
{
    public Dictionary<string, KeyCode> keybindings = new Dictionary<string, KeyCode>();

    public Text up, left, down, right, jump;

    private GameManager gMngr;
    private GameObject keyPressed;

    void Awake()
    {
        gMngr = gameObject.transform.parent.GetComponent<GameManager>();
    }

    void Start()
    {
        keybindings.Add("Up", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "W")));
        keybindings.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A")));
        keybindings.Add("Down", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Down", "S")));
        keybindings.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D")));
        keybindings.Add("Jump", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space")));

        up.text = keybindings["Up"].ToString();
        left.text = keybindings["Left"].ToString();
        down.text = keybindings["Down"].ToString();
        right.text = keybindings["Right"].ToString();
        jump.text = keybindings["Jump"].ToString();
    }

    void OnGUI()
    {
        if (keyPressed != null)
        {
            Event e = Event.current;

            if (e.isKey)
            {
                keybindings[keyPressed.name] = e.keyCode;
                keyPressed.transform.FindChild("Text").GetComponent<Text>().text = e.keyCode.ToString();
                keyPressed = null;
            }
        }
    }

    public void UpdateKeybind(GameObject _clicked)
    {
        keyPressed = _clicked;
    }

    public void SaveKeybindings()
    {
        foreach (var key in keybindings)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }

        PlayerPrefs.Save();
    }

    public void ResetKeybindings()
    {
        keybindings["Up"] = KeyCode.W;
        keybindings["Left"] = KeyCode.A;
        keybindings["Down"] = KeyCode.S;
        keybindings["Right"] = KeyCode.D;
        keybindings["Jump"] = KeyCode.Space;

        up.text = keybindings["Up"].ToString();
        left.text = keybindings["Left"].ToString();
        down.text = keybindings["Down"].ToString();
        right.text = keybindings["Right"].ToString();
        jump.text = keybindings["Jump"].ToString();
    }
}
