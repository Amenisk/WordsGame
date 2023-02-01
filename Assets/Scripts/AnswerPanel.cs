using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Core.Classes;
using Assets.Scripts;
using System.Linq;

public class AnswerPanel : MonoBehaviour
{

    [SerializeField] private Transform _answerPanel;
    [SerializeField] private GameObject _lettersBtnPrefab;
    [SerializeField] private GameObject _question;
    [SerializeField] private Transform _lettersPanel;
    public GameCreation gameCreation;

    // Start is called before the first frame update
    void Start()
    {
        var question = gameCreation.Game.CurrentQuestion;
        _question.GetComponent<Text>().text = question.QuestionText;

        for (int i = 0; i < question.AnswerText.Length; i++)
        {
            var btn = Instantiate(_lettersBtnPrefab, _answerPanel);
            btn.GetComponentInChildren<Text>().text = "";
            btn.GetComponent<Button>().onClick.AddListener(() => ReturnButton(btn.GetComponent<Button>()));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReturnButton(Button btn)
    {
        try
        {
            Button button = _lettersPanel.GetComponentsInChildren<Button>()
                .Where(x => x.interactable == false && x.GetComponentInChildren<Text>().text == btn.GetComponentInChildren<Text>().text).FirstOrDefault();

            btn.GetComponentInChildren<Text>().text = "";
            button.interactable = true;
            button.transform.Translate(0, -1000, 0);
        }
        catch { }
    }
}
