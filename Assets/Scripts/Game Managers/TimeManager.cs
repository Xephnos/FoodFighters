using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeManager : MonoBehaviour
{
    [HideInInspector]public int totalApplicationGameTime;

    public Text gameTimer;

    public int playTimeLimiter;
    public int playTimer;

    [HideInInspector] public int seconds;
    [HideInInspector] public int minutes;

    private bool countingDown;

    private GameManager gMngr;
   
    void Awake()
    {
        gMngr = gameObject.transform.parent.GetComponent<GameManager>();
    }

    // Use this for initialization
    void Start ()
    {
	    if (gMngr.gameMode == GameMode.CaptureTheTest)
        {
            StartCoroutine(StartGameTimer(gMngr.gameMode));
        }
	}

    IEnumerator StartGameTimer(GameMode _gameMode)
    {
        switch (_gameMode)
        {
            case GameMode.None:
                yield return new WaitForEndOfFrame();
                StopCoroutine("StartGameTimer");
                break;
            case GameMode.CaptureTheTest:

                minutes = playTimeLimiter;
                seconds = 0;
                gameTimer.text = string.Format("{0} : {1}", minutes, seconds);
                playTimeLimiter *= 60;
                countingDown = true;
                while (countingDown)
                {
                    yield return new WaitForSeconds(1);
                    playTimeLimiter -= 1;
                    seconds = (playTimeLimiter % 60);
                    minutes = ((playTimeLimiter / 60) % 60);
                    gameTimer.text = string.Format("{0} : {1}", minutes, seconds);
                    if (playTimeLimiter == 0)
                    {
                        print("The Game Has Ended");
                        countingDown = false;
                    }
                }
                break;
            case GameMode.FoodWars:
                break;
            default:
                break;
        }
    }
}
