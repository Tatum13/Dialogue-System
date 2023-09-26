using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
    [SerializeField] private GameObject textBox;
    [SerializeField] private GameObject choice01;
    [SerializeField] private GameObject choice02;
    [SerializeField] private GameObject choice03;
    [SerializeField] private int choiceMade;

    public void TestChoice1()
    {
        textBox.GetComponent<Text>().text = "That is good to hear";
        choiceMade = 1;
    }
    
    public void TestChoice2()
    {
        textBox.GetComponent<Text>().text = "Let me know if you change your mind";
        choiceMade = 2;
    }
    public void TestChoice3()
    {
        textBox.GetComponent<Text>().text = "Why no?";
        choiceMade = 3;
    }

    private void Update()
    {
        if (choiceMade >= 1)
        {
            choice01.SetActive(false);
            choice02.SetActive(false);
            choice03.SetActive(false);
        }
    }
}
