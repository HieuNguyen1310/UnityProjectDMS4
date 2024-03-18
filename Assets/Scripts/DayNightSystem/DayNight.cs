using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class DayNight : MonoBehaviour
{
//    public TextMeshProUGUI timeDisplay; //Display Time
   public TextMeshProUGUI dayDispaly; //Display Day
   public Volume ppv; //Post Processing

   public float tick; //Increase the tick => increase second rate
   public float seconds;
   public int mins;
   public int hours;
   public int days = 0;

   public float weightChangeSpeed = 0.1f; // Adjust this value to control transition speed



   // Random Check
   [SerializeField] private bool isDay; // Track current state

//    public float dayCheck;
   [SerializeField] private float nextChangeChance; //init chance of change

//    public bool activeLight; // check if lights on
   public GameObject lights; // the light we want to turn on when night
   

   void Start()
   {
    // ppv = GameObject.GetComponent<Volume>();
    hours = 8;
    ppv.weight = 0;
    lights.SetActive(false);
    isDay = true;
    // dayCheck = 1;
    // activeLight = false;
   }

   void Update()
   {
    CalcTime();
    DisplayTime();
    ControlPPV();
   }

    public void CalcTime() // calc secs, mins, hours
    {
        seconds += Time.fixedDeltaTime * tick; //multiply time between fixed update by tick

        if (seconds >= 60) // 60s = 1m
        {
            seconds = 0;
            mins += 1;
        }
        if (mins >= 60) //60m = 1h
        {
            mins = 0;
            hours += 1;
            if (hours % 12==0)
            {
                ChangeCheck();
            }
        }
        if (hours >= 24) //24h = 1day
        {
            hours = 0;
            days += 1;
            // ChangeCheck();
            // ControlPPV();
        }
       
        
        
    }

        

    public void ChangeCheck() // 
    {
        nextChangeChance = Random.Range(0.1f, 0.9f);
         if (nextChangeChance < 0.5f)
        {
            // Trigger a change
            isDay = false;
            ControlPPV(); // Update post-processing immediately

            // Adjust next change chance for more variability
            // nextChangeChance = Random.Range(0.1f, 0.9f); // Randomize between 10% and 90%
        }
         
        else if (nextChangeChance >= 0.5f)
        {
            // Trigger a change
            isDay = true;
            ControlPPV(); // Update post-processing immediately

            // Adjust next change chance for more variability
            // nextChangeChance = Random.Range(0.1f, 0.9f); // Randomize between 10% and 90%
        }

        // Gradually increase chance over time to ensure eventual change
        // nextChangeChance += Time.deltaTime * 0.1f; // Adjust this rate as needed
    }

    public void ControlPPV() //Adjust post processing slider
    {   
        // ChangeCheck();
        if (isDay == false) // Change to Night
        {
            ppv.weight = Mathf.Lerp(ppv.weight, 1f, weightChangeSpeed * Time.deltaTime);
            lights.SetActive(true);
            // dayCheck = 0;
            // Debug.Log("Night");
            // Debug.Log("Night, ppv.weight: " + ppv.weight);
        }

        else if (isDay == true) // Change to Day
        {
            ppv.weight = Mathf.Lerp(ppv.weight, 0f, weightChangeSpeed * Time.deltaTime);
            lights.SetActive(false);
            // dayCheck = 1;
            // Debug.Log("Day");
            // Debug.Log("Day, ppv.weight: " + ppv.weight);
        }


        // //ppv.weight = 0;
        // if (hours >= 21 && hours < 22) //dusk at 2100pm
        // {
        //     ppv.weight = (float)mins / 60; // since dusk is 1 hour, divide the mins by 60 will slowly increase from 0 -> 1
            
        //     // if (activeLight == false)
        //     // {
        //         if (mins <45)
        //         {
        //             lights.SetActive(true);
                    
        //         }
        //         // activeLight = true;
        //     // }
        // }

        // if (hours >= 6 && hours < 7) // dawn at 6am to 7am
        // {
        //     ppv.weight = 1 - (float)mins / 60; // since dawn is 1 hour, 1 minus divide the mins by 60 will slowly dencrease from 1 -> 0
            
        //     // if (activeLight == true)
        //     // {
        //         if (mins > 45)
        //         {
        //             lights.SetActive(false);
                    
        //         }
        //         // activeLight = false;
        //     // }
        // }
        // // Debug.Log(ppv.weight);
    }

    public void DisplayTime() // Show day and time
    {
        dayDispaly.text = "Day: " + days;
    }

}
