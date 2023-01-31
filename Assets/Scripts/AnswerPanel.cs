using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Core.Classes;

public class AnswerPanel : MonoBehaviour
{
    private QuestionsList list = new QuestionsList();
    public Question question;

    [SerializeField] private Transform _lettersPanel;
    [SerializeField] private GameObject _lettersBtnPrefab;
    [SerializeField] private GameObject _question;

    private void Awake()
    {
        question = list.GetRandomQuestion();
    }
    // Start is called before the first frame update
    void Start()
    {
        _question.GetComponent<Text>().text = question.QuestionText;

        for (int i = 0; i < question.AnswerText.Length; i++)
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
