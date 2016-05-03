using UnityEngine;
using System.Collections;

public class KeybindingsManager : MonoBehaviour
{
    private GameManager gMngr;

    void Awake()
    {
        gMngr = gameObject.transform.parent.GetComponent<GameManager>();
    }
}
