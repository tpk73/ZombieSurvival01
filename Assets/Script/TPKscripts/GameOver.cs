using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text timer;
    public Text ptsText;
    public Text gameOverPrompt;

    public void Setup(float score)
    {
        gameObject.SetActive(true);
        ptsText.text = score.ToString() + " Points";
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("ZombieRun");
    }
    public void HomeButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
