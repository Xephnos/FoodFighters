using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class KeybindingsManager : MonoBehaviour
{
    public Dictionary<string, KeyCode> keybindings = new Dictionary<string, KeyCode>();

    public Text forward, left, backward, right, jump;

    private GameObject keyPressed;

    void Start()
    {
        keybindings.Add("Forward", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Forward", "W")));
        keybindings.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A")));
        keybindings.Add("Backward", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Backward", "S")));
        keybindings.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D")));
        keybindings.Add("Jump", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space")));

        forward.text = keybindings["Forward"].ToString();
        left.text = keybindings["Left"].ToString();
        backward.text = keybindings["Backward"].ToString();
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
        keybindings["Forward"] = KeyCode.W;
        keybindings["Left"] = KeyCode.A;
        keybindings["Backward"] = KeyCode.S;
        keybindings["Right"] = KeyCode.D;
        keybindings["Jump"] = KeyCode.Space;

        forward.text = keybindings["Forward"].ToString();
        left.text = keybindings["Left"].ToString();
        backward.text = keybindings["Backward"].ToString();
        right.text = keybindings["Right"].ToString();
        jump.text = keybindings["Jump"].ToString();
    }
}
