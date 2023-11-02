using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private NPC npc;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private TMP_Text npcName;
    [SerializeField] private TMP_Text dialogueBox;
    
    public GameObject inputIndication;

    [Header("Player Settings")]
    [SerializeField] private float currentResponseTracker = 0;
    [SerializeField] private string playerResponse;
    [TextArea (0,15), SerializeField] private string response;

    [HideInInspector] public int _dialogueOrder = -1;
    
    [Header("Checks")]
    public bool _isWithinRadius;
    public bool _isTalking;

    private void Start() => dialogueUI.SetActive(false);
    
    private void UpdateText() => dialogueBox.text = npc.Dialogue[_dialogueOrder];

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
        if(_dialogueOrder >= npc.Dialogue.Length)
        {
            OnEndConversation();
            return;
        }
        UpdateText();
    }

    public void Previous()
    {
        _dialogueOrder--;
        if(_dialogueOrder < 0) _dialogueOrder = 0; 
        UpdateText();
    }

    public void OnEndConversation()
    {
        _isTalking = false;
        dialogueUI.SetActive(false);
    }
}
