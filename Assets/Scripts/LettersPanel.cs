using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Core.Classes;
using UnityEditor;
using Assets.Scripts;
using System.Threading.Tasks;

public class LettersPanel : MonoBehaviour
{
    [SerializeField] private Transform _lettersPanel;
    [SerializeField] private GameObject _lettersBtnPrefab;
    [SerializeField] private Transform _answerPanel;
    public GameCreation gameCreation;
   
    // Start is called before the first frame update
    void Start()
    {
        FillPanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FillPanel()
    {
        foreach(Transform button in _lettersPanel.transform)
        {
            Destroy(button.gameObject);
        }
       
        Question question = gameCreation.Game.CurrentQuestion;

        int countLetters = 0;
        var array = GetRandomIntArray(question.AnswerText.Length);
        for (int i = 0; i < 30; i++)
        {
            var btn = Instantiate(_lettersBtnPrefab, _lettersPanel);
            if (!ArrayUtility.Contains(array, i))
            {
                btn.GetComponentInChildren<Text>().text = ((char)Random.Range('?', '?')).ToString();
            }
            else
            {
                btn.GetComponentInChildren<Text>().text = question.AnswerText[countLetters].ToString().ToUpper();
                countLetters++;
            }
            btn.GetComponent<Button>().onClick.AddListener(() => ChooseLetterButton(btn.GetComponent<Button>()));
        }
    }

    private int[] GetRandomIntArray(int length)
    {
        var array = new int[length];
        int number;

        for (int i = 0; i < length; i++)
        {
            number = Random.Range(0, 31);
            if (!ArrayUtility.Contains(array, number))
            {
                array[i] = number;
            }
            else
            {
                i--;
            }
        }

        return array;
    }

    public void ChooseLetterButton(Button btn)
    {
        foreach (Button b in _answerPanel.GetComponentsInChildren<Button>())
        {
            if (b.GetComponentInChildren<Text>().text == "")
            {
                b.GetComponentInChildren<Text>().text = btn.GetComponentInChildren<Text>().text;
                btn.interactable = false;
                btn.transform.Translate(0, 10000, 0);
                gameCreation.Game.CountLetters++;
                
                return;
            }
        }
    }
}
