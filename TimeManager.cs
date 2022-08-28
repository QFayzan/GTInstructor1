using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeManager : MonoBehaviour
{
    bool IsGameStarted = true;   //As required by task 1
    public TextMeshProUGUI elapsedUI;
    public TextMeshProUGUI Countdown;
    public TextMeshProUGUI Paused;
    public float Counter;          //counts time remaining
    public float elapsed;                //counts time pased since scene started
    // Start is called before the first frame update
    void Start()
    {
        Paused.text = "IsGameStarted is " + IsGameStarted.ToString();  //operates isgamestarted logic
        //InvokeRepeating("CounterFunction", 1f, 1f);  //1s delay, repeat every 1s
    }

    // Update is called once per frame
    void Update()
    {
        //Stops the Game when IsGameStarted is false and also displays that in UI
        if (IsGameStarted == false)
        {
            Time.timeScale = 0;
            Paused.text = "IsGameStarted is " + IsGameStarted.ToString();
        }
        //Shows time since game started
        elapsed = Time.realtimeSinceStartup;
        elapsedUI.text = "Time Since Start " + elapsed.ToString();
        //the basic standard for "cycling" a command using a single button
        //if (Input.GetKeyDown(KeyCode.R))
        //   {
        //     IsGameStarted = !IsGameStarted;
          
        //   }

        //to restart the scene if needed
        if (Input.GetKeyDown(KeyCode.F))
        {
            IsGameStarted = true;
            Time.timeScale = 1;
            SceneManager.LoadScene("Solution");
        }
    }
    private void LateUpdate()
    {  
        // Basic logic of timer using late update for accuracy

        if (Counter > 0)
        {
            Counter = Counter - Time.deltaTime;
        }
        if (Counter <= 0)
        {
            IsGameStarted = false;
        }

        //displays countdown since start
        Countdown.text = "Timer Remaining " + Counter.ToString();
    }


 
    
        
}

    


