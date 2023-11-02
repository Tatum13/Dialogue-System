using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private NPC npc;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject dialogueUI;

    [Header("Settings")]
    [SerializeField] private float currentResponseTracker = 0;

    [Header("I don't know how to call this yet")]
    [SerializeField] private TMP_Text npcName;
    [SerializeField] private TMP_Text dialogueBox;
    [SerializeField] private string playerResponse;
    
    [TextArea (0,15), SerializeField] private string response;

    public GameObject inputIndication;
    public int _dialogueOrder = -1;
    public bool _isTalking;
    public bool _isTest;

    private void Start() => dialogueUI.SetActive(false);

    /*
    private void OnTriggerEnter(Collider other)//Look if an npc is within the collider (with npc tag)
    {
        //This doesn't look clean 
        _isTest = true;
        if(_dialogueOrder >= npc.Dialogue.Length) Debug.Log("text test3");
        if (other.gameObject != player) return;
        if (!_isTalking) inputIndication.SetActive(true);
    }
    */

    public void OnStartConversation()
    {
        _isTalking = true;
        if(_isTalking) inputIndication.SetActive(false);
        currentResponseTracker = 0;
        dialogueUI.SetActive(true);
        npcName.text = npc.name;
        Next();
    }

    public void Next()
    {
        _dialogueOrder++;
        if (_dialogueOrder >= npc.Dialogue.Length)
        {
            OnEndConversation();
            return;
        }
        UpdateText();
    }

    public void Previous()
    {
        _dialogueOrder--;
        if (_dialogueOrder < 0) _dialogueOrder = 0; 
        UpdateText();
    }
    
    private void UpdateText() => dialogueBox.text = npc.Dialogue[_dialogueOrder];
    
    public void OnEndConversation()
    {
        _isTalking = false;
        dialogueUI.SetActive(false);
    }

    /*
    private void OnTriggerExit(Collider other)
    {
        inputIndication.SetActive(false);
        _isTest = false;
        OnEndConversation();
    }
    */

    public void ChoiceTest()
    {
        dialogueBox.text = response;
        Debug.Log("test");
    }

    /*
    private void OnSelectOption()
    {
        
    }
    */
}
