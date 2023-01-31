using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScrip : MonoBehaviour
{
    public void OpenMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OpenGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OpenAward()
    {
        SceneManager.LoadScene("GameScene");
    }
}
