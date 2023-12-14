using UnityEngine;

public class InputManager : MonoBehaviour
{
    private DialogueManager _dialogueManager;
    private ChoiceManager _choiceManager;

    private void Start()
    {
        _dialogueManager = FindObjectOfType<DialogueManager>();
        _choiceManager = FindObjectOfType<ChoiceManager>();
    }

    private void Update()
    {
        if(!_dialogueManager.isWithinRadius) return;
        InteractionInput();
    }
    
    private void InteractionInput()
    {
        if (Input.GetKeyDown(KeyCode.E) && !_dialogueManager.isTalking)
        {
            _choiceManager.choiceButtons.SetActive(true);
            _dialogueManager.OnStartConversation();
        }
        else if (Input.GetKeyDown(KeyCode.E) && _dialogueManager.isTalking)
        {
            _choiceManager.GoToNpcResponse();
        }
    }
}
