using UnityEngine;

public class NPCFinder : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private ChoiceManager choiceManager;
    [SerializeField] private NPCName npcName;
    [SerializeField] private AllDialogue allDialogue;

    [Header("Player Settings")]
    [SerializeField] private Vector3 radius;

    public readonly int firstNPCDialogue = 0;

    private bool _hasNpcInRange;

    public NPCName GetNpcName => npcName;
    
    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        npcName = FindObjectOfType<NPCName>();
    }

    private void Update()
    {
        FindNpcInRange();
        OnNPCInRange();
    } 

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawWireCube(transform.position, new Vector3(3,2,3));
    }

    private void FindNpcInRange()
    {
        var npcInRange = Physics.OverlapBox(transform.position, radius);

        if (npcInRange.Length == 0) _hasNpcInRange = false; 
        
        foreach (var aNPC in npcInRange)
        {
            if (aNPC.transform.CompareTag("NPC"))
            {
                _hasNpcInRange = true;
                npcName = aNPC.GetComponent<NPCName>();
                break;
            }
            _hasNpcInRange = false;
        }
    }

    private void OnNPCInRange() 
    {
        if (_hasNpcInRange)
        {
            allDialogue = npcName.npc.AllDialogue[0];
            dialogueManager.isWithinRadius = true;
            if(dialogueManager.isTalking) dialogueManager.inputIndication.SetActive(false);
            if (!dialogueManager.isTalking) dialogueManager.inputIndication.SetActive(true);
        }
        else
        {
            if (!dialogueManager.isTalking || dialogueManager.dialogueOrder >= allDialogue.NpcDialogue.Count)
            {
                dialogueManager.OnEndConversation();
                dialogueManager.inputIndication.SetActive(false);
                choiceManager.isPlayerResponse = false;
            }
        }
    }
}
