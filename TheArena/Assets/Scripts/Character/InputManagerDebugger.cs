using UnityEngine;
using System.Collections;

public class InputManagerDebugger : MonoBehaviour
{
    public InputManager inputManager;

    void Update()
    {
        if (inputManager.GetInput(InputManager.InputActions.PRIMARY_ATTACK))
        {
            Debug.Log("<INPUT MANAGER>: Performing [PRIMARY_ATTACK]");
        }

        if (inputManager.GetInput(InputManager.InputActions.SECONDARY_ATTACK))
        {
            Debug.Log("<INPUT MANAGER>: Performing [SECONDARY_ATTACK]");
        }

        if (inputManager.GetInput(InputManager.InputActions.UP, true))
        {
            Debug.Log("<INPUT MANAGER>: Performing [UP]");
        }

        if (inputManager.GetInput(InputManager.InputActions.LEFT, true))
        {
            Debug.Log("<INPUT MANAGER>: Performing [LEFT]");
        }

        if (inputManager.GetInput(InputManager.InputActions.DOWN, true))
        {
            Debug.Log("<INPUT MANAGER>: Performing [DOWN]");
        }

        if (inputManager.GetInput(InputManager.InputActions.RIGHT, true))
        {
            Debug.Log("<INPUT MANAGER>: Performing [RIGHT]");
        }

        if (inputManager.GetInput(InputManager.InputActions.BLOCK, true))
        {
            Debug.Log("<INPUT MANAGER>: Performing [BLOCK]");
        }

        if (inputManager.GetInput(InputManager.InputActions.DODGE))
        {
            Debug.Log("<INPUT MANAGER>: Performing [DODGE]");
        }

        if (inputManager.GetInput(InputManager.InputActions.SWAP_WEAPON))
        {
            Debug.Log("<INPUT MANAGER>: Performing [SWAP_WEAPON]");
        }

        if (inputManager.GetInput(InputManager.InputActions.ABILITY_1))
        {
            Debug.Log("<INPUT MANAGER>: Performing [ABILITY_1]");
        }

        if (inputManager.GetInput(InputManager.InputActions.ABILITY_2))
        {
            Debug.Log("<INPUT MANAGER>: Performing [ABILITY_2]");
        }

        if (inputManager.GetInput(InputManager.InputActions.ABILITY_3))
        {
            Debug.Log("<INPUT MANAGER>: Performing [ABILITY_3]");
        }

        if (inputManager.GetInput(InputManager.InputActions.ABILITY_4))
        {
            Debug.Log("<INPUT MANAGER>: Performing [ABILITY_4]");
        }

        if (inputManager.GetInput(InputManager.InputActions.ABILITY_5))
        {
            Debug.Log("<INPUT MANAGER>: Performing [ABILITY_5]");
        }

        if (inputManager.GetInput(InputManager.InputActions.CONSUMABLE_1))
        {
            Debug.Log("<INPUT MANAGER>: Performing [CONSUMABLE_1]");
        }

        if (inputManager.GetInput(InputManager.InputActions.CONSUMABLE_2))
        {
            Debug.Log("<INPUT MANAGER>: Performing [CONSUMABLE_2]");
        }
    }
}
