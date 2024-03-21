using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    bool hadEnded = false;

    public float restartDelay = 2.0f;

    public GameObject EndGameUI;

    public GameObject HP;

    public GameObject Minimap;

    public DayNight timeControl;

    public PlayerHealth playerManager;

    // public AudioSource winSource;

    public void EndGame () 
    {
        if (hadEnded == false)
        {
            hadEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
        }
    }

 

    void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameWon()
    {
        EndGameUI.SetActive(true);
        HP.SetActive(false);
        Minimap.SetActive(false);

        TimeStop();
        StopPlayer();

        // winSource.Play();
        
        Debug.Log("U WON");
        replaygame();
    }

    void TimeStop()
    {   
        timeControl = timeControl.GetComponent<DayNight>();
        timeControl.ppv.weight = 0;
        timeControl.tick = 1;
        
    }

    void StopPlayer()
    {
        playerManager.GetComponent<PlayerHealth>().DPS = 0;
    }

    public void replaygame()
    {
        
        if (Input.anyKey)
            {
                SceneManager.LoadScene("SCENE");
            }
        
    }
}
