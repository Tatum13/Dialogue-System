using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [Header("References")]
    public NPCFinder npcFinder;
    public TMP_Text dialogueBox;
    public GameObject inputIndication;
    public TMP_Text npcName;
    [SerializeField] private GameObject dialogueUI;

    [HideInInspector] public int dialogueOrder = -1;
    
    [Header("Checks")]
    public bool isWithinRadius;
    public bool isTalking;

    private void Start() => dialogueUI.SetActive(false);

    private void UpdateText() => dialogueBox.text = npcFinder.GetNpcName.npc.AllDialogue[npcFinder.firstNPCDialogue].NpcDialogue[dialogueOrder].NpcDialogue;
    
    public void OnStartConversation()
    {
        isTalking = true;
        dialogueUI.SetActive(true);
        npcName.text = npcFinder.GetNpcName.npc.name;
        Next();
    }

    private void Next()
    {
        dialogueOrder++;
        
        if(dialogueOrder >= npcFinder.GetNpcName.npc.AllDialogue[npcFinder.firstNPCDialogue].NpcDialogue.Count)
        {
            OnEndConversation();
            return;
        }
        UpdateText();
    }

    public void Previous()
    {
        dialogueOrder--;
        if(dialogueOrder < 0) dialogueOrder = 0; 
        UpdateText();
    }

    public void OnEndConversation()
    {
        isTalking = false;
        dialogueUI.SetActive(false);
        Reset();
    }

    private void Reset() => dialogueOrder = -1;
}
