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
        keybindings.Add("Up", KeyCode.W);
        keybindings.Add("Left", KeyCode.A);
        keybindings.Add("Down", KeyCode.S);
        keybindings.Add("Right", KeyCode.D);
        keybindings.Add("Jump", KeyCode.Space);

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

    public void UpdateKeybind(GameObject _keybind)
    {
        keyPressed = _keybind;
    }
}
