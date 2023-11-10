using UnityEngine;

public class NPCFinder : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private NPCName npcName;
    [SerializeField] private AllDialogue _allDialogue;

    [Header("Player Settings")]
    [SerializeField] private Vector3 radius;

    public readonly int firstNPCDialogue = 0;
    
    private bool _hasNPCInRange;

    public NPCName GetNPCName => npcName;
    
    private void Start()
    {
        _dialogueManager = FindObjectOfType<DialogueManager>();
        npcName = FindObjectOfType<NPCName>();
    }

    private void Update()
    {
        FindNPCInRange();
        OnNPCInRange();
    } 

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawWireCube(transform.position, new Vector3(3,2,3));
    }

    private void FindNPCInRange()
    {
        var npcInRange = Physics.OverlapBox(transform.position, radius);

        if (npcInRange.Length == 0) _hasNPCInRange = false; 
        
        foreach (var aNPC in npcInRange)
        {
            if (aNPC.transform.CompareTag("NPC"))
            {
                _hasNPCInRange = true;
                npcName = aNPC.GetComponent<NPCName>();
                break;
            }
            _hasNPCInRange = false;
        }
    }

    private void OnNPCInRange() 
    {
        if (_hasNPCInRange)
        {
            _allDialogue = npcName._npc.AllDialogue[0];
            _dialogueManager._isWithinRadius = true;
            if (!_dialogueManager._isTalking) _dialogueManager.inputIndication.SetActive(true);
        }
        else
        {
            if (!_dialogueManager._isTalking || _dialogueManager._dialogueOrder >= _allDialogue.NPCDialogue.Length) _dialogueManager.inputIndication.SetActive(false);
        }
    }
}
