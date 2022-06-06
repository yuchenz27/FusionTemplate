using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class CharacterMovementHandler : NetworkBehaviour
{
    private Vector2 _viewInput;

    //

    private NetworkCharacterControllerPrototypeCustom _networkCharacterControllerPrototypeCustom;

    private void Awake()
    {
        _networkCharacterControllerPrototypeCustom = GetComponent<NetworkCharacterControllerPrototypeCustom>();
    }

    public override void FixedUpdateNetwork()
    {
         // Get the input from the network
         if (GetInput(out NetworkInputData networkInputData))
        {
            // Rotate
            _networkCharacterControllerPrototypeCustom.Rotate(networkInputData.rotationInput);

            // Move
            Vector3 moveDirection = transform.forward * networkInputData.movementInput.y + transform.right * networkInputData.movementInput.x;
            moveDirection.Normalize();
            _networkCharacterControllerPrototypeCustom.Move(moveDirection);
        }
    }

    public void SetViewInputVector(Vector2 viewInput)
    {
        _viewInput = viewInput;
    }
}
