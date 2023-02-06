using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject shop;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
        SceneManager.LoadScene("AwardScene");
    }
}
