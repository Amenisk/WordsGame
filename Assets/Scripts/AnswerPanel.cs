using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerPanel : MonoBehaviour
{
    List<string> _list = new List<string>();

    [SerializeField] private Transform _lettersPanel;
    [SerializeField] private GameObject _lettersBtnPrefab;
    [SerializeField] private GameObject _question;


    // Start is called before the first frame update
    void Start()
    {
        string word = words[Random.RandomRange(0, words.Length)];
        for (int i = 0; i < word.Length; i++)
        {
            var btn = Instantiate(_lettersBtnPrefab, _lettersPanel);
            btn.GetComponentInChildren<Text>().text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
