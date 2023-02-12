using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Core.Classes;
using Assets.Scripts;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

public class AnswerPanel : MonoBehaviour
{

    [SerializeField] private Transform _answerPanel;
    [SerializeField] private GameObject _lettersBtnPrefab;
    [SerializeField] private GameObject _question;
    [SerializeField] private Transform _lettersPanel;
    [SerializeField] private GameObject _questionPanel;
    [SerializeField] private GameObject _rightAnswerPanel;
    [SerializeField] private GameObject _wrongAnswerPanel;
    [SerializeField] private GameObject _timer;
    public GameCreation gameCreation;
    public GameManager gameManager;
    public LettersPanel lettersPanel;
    private int _seconds;
    private bool isTimerStopped;
    private bool isAnswerPanelOpen;


    // Start is called before the first frame update
    void Start()
    {
        _seconds = 30;
        StartTimer();
        FillField();
    }

    // Update is called once per frame
    void Update()
    {
        CheckAnswer();
    }

    public void ReturnButton(Button btn)
    {
        try
        {
            Button button = _lettersPanel.GetComponentsInChildren<Button>()
                .Where(x => x.interactable == false && x.GetComponentInChildren<Text>().text == btn.GetComponentInChildren<Text>().text).FirstOrDefault();

            btn.GetComponentInChildren<Text>().text = "";
            button.interactable = true;
            button.transform.Translate(0, -10000, 0);
            gameCreation.Game.CountLetters--;
        }
        catch { }
    }

    private async Task CheckAnswer()
    {
        await Task.Delay(1000);
        if (gameCreation.Game.CheckAnswer())
        {
            string answer = "";
            foreach(var button in _answerPanel.GetComponentsInChildren<Button>())
            {
                answer += button.GetComponentInChildren<Text>().text;
            }

            if(answer == gameCreation.Game.CurrentQuestion.AnswerText.ToUpper())
            {
                _rightAnswerPanel.SetActive(true);
                isAnswerPanelOpen = true;
            }
            else
            {
                _wrongAnswerPanel.SetActive(true);
                isAnswerPanelOpen = true;
            }
        }
    }

    private void FillField()
    {
        gameCreation.Game.CountLetters = 0;
        foreach (Transform button in _answerPanel.transform)
        {
            Destroy(button.gameObject);
        }
        _rightAnswerPanel.SetActive(false);
        _wrongAnswerPanel.SetActive(false);
        if (gameManager.TypeQuestion != null)
        {
            gameCreation.Game.SetType(gameManager.TypeQuestion);
            gameCreation.Game.ChangeQuestion();
        }
        Question question = gameCreation.Game.CurrentQuestion;
        _question.GetComponent<Text>().text = question.QuestionText;

        for (int i = 0; i < question.AnswerText.Length; i++)
        {
            var btn = Instantiate(_lettersBtnPrefab, _answerPanel);
            btn.GetComponentInChildren<Text>().text = "";
            btn.GetComponent<Button>().onClick.AddListener(() => ReturnButton(btn.GetComponent<Button>()));
        }
    }

    public void Continue()
    {
        gameCreation.Game.ChangeQuestion();
        _seconds = 30;
        isAnswerPanelOpen = false;
        if (isTimerStopped)
        {
            StartTimer();
            isTimerStopped = false;
        }
        FillField();
        lettersPanel.FillPanel();
    }

    private async Task StartTimer()
    {
        while(_seconds != 0)
        {
            if (!isAnswerPanelOpen)
            {
                await Task.Delay(1000);
                _seconds--;
                _timer.GetComponent<Text>().text = "0:" + _seconds;
            }
            else
            {
                isTimerStopped = true;
                return;
            }
        }

        if (_seconds == 0)
        {
            isTimerStopped = true;
            _wrongAnswerPanel.SetActive(true);
            isAnswerPanelOpen = true;
        }
    }
}
