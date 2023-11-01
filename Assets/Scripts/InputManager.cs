using UnityEngine;

public class InputManager : MonoBehaviour
{
    private DialogueManager _dialogueManager;

    private void Start() => _dialogueManager = FindObjectOfType<DialogueManager>();

    private void Update()
    {
        if(!_dialogueManager._isTest) return;
        InteractionInput();
    }
    
    private void InteractionInput()
    {
        if(Input.GetKeyDown(KeyCode.E) && _dialogueManager._isTalking == false) _dialogueManager.OnStartConversation();
        else if(Input.GetKeyDown(KeyCode.E)) _dialogueManager.Next();
        else if(Input.GetKeyDown(KeyCode.T)) _dialogueManager.Previous();
        else if (Input.GetKeyDown(KeyCode.E) && _dialogueManager._isTalking) _dialogueManager.OnEndConversation();
    }
}
