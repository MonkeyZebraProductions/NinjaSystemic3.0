using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
   

    public TMP_Text TimerText,ResultText;
    public GameObject ResultScreen,ControlScreen;
    public float timeSpent, minutes, seconds;
    private bool _controlScreen;

    private PlayerMovement pm;

    public UnityEvent Reload, Back;

    void Start()
    {
        Time.timeScale = 1;
        pm = FindObjectOfType<PlayerMovement>();
    }
    private void Update()
    {
        timeSpent+= Time.deltaTime;
        minutes = Mathf.FloorToInt(timeSpent / 60);
        seconds = Mathf.FloorToInt(timeSpent % 60);
        
        if((timeSpent*minutes)+timeSpent<10)
        {
            TimerText.text = "Time: " + minutes + ":0" + seconds;
        }
        else
        {
            TimerText.text = "Time: " + minutes + ":" + seconds;
        }

        //ControlScreen.SetActive(_controlScreen);

        //if(Input.GetKeyDown(KeyCode.R))
        //{
        //    Time.timeScale = 1;
        //    ResultScreen.SetActive(false);
        //    Reload.Invoke();
        //}

        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    _controlScreen = !_controlScreen;
        //}

        //if(Input.GetKeyDown(KeyCode.Return))
        //{
        //    SceneManager.LoadScene(0);
        //}


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer==11)
        {
            Time.timeScale = 0;
            if ((timeSpent * minutes) + timeSpent < 10)
            {
                ResultText.text = "Congrats! You beat the level in " + minutes + ":0" + seconds;
            }
            else
            {
                ResultText.text = "Congrats! You beat the level in " + minutes + ":" + seconds;
            }
            ResultScreen.SetActive(true);
        }
        
    }
}
