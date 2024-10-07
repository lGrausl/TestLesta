using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI headPoint;
    public TextMeshProUGUI timer;


    public GameObject restartText;
    public GameObject FinishText;

    public GameObject startButton;
    public GameObject restartButton;

    public GameObject startTimer;
    public GameObject player;


    void Update()
    {
        headPoint.text = "Hp: " + player.GetComponent<Specifications>().healthPoints;

        if (player.GetComponent<Specifications>().loseGame)
            LoseGame();

        if (player.GetComponent<Specifications>().finGame)
            FinishGameUI();
    }

    public void StarGame()
    {
        startButton.SetActive(false);
        player.GetComponent<Specifications>().startGame = true;
        Time.timeScale = 1;
    }

    public void LoseGame()
    {
        restartButton.SetActive(true);
        restartText.SetActive(true);
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }



    public void FinishGameUI()
    {
        timer.text = startTimer.GetComponent<StartTimer>().timeLeft.ToString("#.##");
        FinishText.SetActive(true);
        restartButton.SetActive(true);
        Time.timeScale = 0;
    }

    public void FinishGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    

}
