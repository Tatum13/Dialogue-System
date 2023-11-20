using UnityEngine;
using UnityEngine.UI;

public class ChoiceManager : MonoBehaviour
{
    [SerializeField] private GameObject textBox;
    [SerializeField] private string choicePlayer;

    private AllDialogue _allDialogue;   

    public void OnChoiceButtonOne()
    {
        Debug.Log("button1");
    }
    public void OnChoiceButtonTwo()
    {
        Debug.Log("button2");
    }
}
