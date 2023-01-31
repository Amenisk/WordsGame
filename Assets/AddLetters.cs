using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Transform _lettersPanel;
    [SerializeField] private GameObject _lettersBtnPrefab;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            var btn = Instantiate(_lettersBtnPrefab, _lettersPanel);
            btn.GetComponentInChildren<Text>().text = Random.RandomRange(10, 100).ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}