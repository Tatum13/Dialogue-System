using UnityEngine;

public class NPCFinder : MonoBehaviour
{
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private NPC _npc;
    
    [SerializeField] private Vector3 radius;
    
    private void Start() => _dialogueManager = FindObjectOfType<DialogueManager>();

    private void Update() => FindNPCInRange();

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawWireCube(transform.position, new Vector3(3,2,3));
    }

    private void FindNPCInRange()
    {
        var npcInRange = Physics.OverlapBox(transform.position, radius);
        foreach (Collider anNPC in npcInRange)
        {
            if(anNPC.transform.CompareTag("Player")) continue;
            if(anNPC.transform.CompareTag("NPC"))
            {
                _dialogueManager._isTest = true;
                if(_dialogueManager._dialogueOrder >= _npc.Dialogue.Length) Debug.Log("text test3");
                if (!_dialogueManager._isTalking) _dialogueManager.inputIndication.SetActive(true);
            }
            if(!anNPC.CompareTag("NPC")) _dialogueManager.inputIndication.SetActive(false);
        }
    }
}
