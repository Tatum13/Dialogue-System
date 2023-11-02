using UnityEngine;

public class NPCFinder : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private NPC _npc;
    
    [Header("Player Settings")]
    [SerializeField] private Vector3 radius;

    private bool _hasNPCInRange;
    
    private void Start() => _dialogueManager = FindObjectOfType<DialogueManager>();

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

        foreach (var aNPC in npcInRange)
        {
            if (aNPC.transform.CompareTag("NPC"))
            {
                _hasNPCInRange = true;
                break;
            }
            _hasNPCInRange = false;
        }
    }

    private void OnNPCInRange()
    {
        if (_hasNPCInRange)
        {
            _dialogueManager._isWithinRadius = true;
            //if(_dialogueManager._dialogueOrder >= _npc.Dialogue.Length) Debug.Log("This works");
            if (!_dialogueManager._isTalking) _dialogueManager.inputIndication.SetActive(true);
        }
        else
        {
            if (!_dialogueManager._isTalking || _dialogueManager._dialogueOrder >= _npc.Dialogue.Length) _dialogueManager.inputIndication.SetActive(false);
        }
    }
}
