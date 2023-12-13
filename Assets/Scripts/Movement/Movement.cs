using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private float currentMovementSpeed;
    
    private Vector3 _moveDirection;
    private Vector3 _velocity;
    private float _horizontal;
    private float _vertical;


    private void Update()
    {
        SetInput();
        SetMoveDirection();
        StopMoving();
    }

    private void SetInput()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
    }

    private void SetMoveDirection()
    {
        _moveDirection = (transform.right * _horizontal + transform.forward * _vertical) * currentMovementSpeed;
        _moveDirection.y = _velocity.y;
        
        characterController.Move(_moveDirection * Time.deltaTime);
    }

    private void StopMoving()
    {
        if (dialogueManager._isTalking) currentMovementSpeed = 0;
        if (!dialogueManager._isTalking) currentMovementSpeed = 5;
    }
}
