using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class InputManager : MonoBehaviour
{
    //-------------------------------------------------

    public enum InputActions
    { 
        UP,
        LEFT,
        DOWN,
        RIGHT,
        PRIMARY_ATTACK,   // Default Mouse Input
        SECONDARY_ATTACK, // Default Mouse Input
        BLOCK,
        DODGE,
        SWAP_WEAPON,
        ABILITY_1,
        ABILITY_2,
        ABILITY_3,
        ABILITY_4,
        ABILITY_5,
        CONSUMABLE_1,
        CONSUMABLE_2
    };

    private Dictionary<InputActions, KeyCode> KeyMapping;
    private Dictionary<InputActions, int> MouseMapping;

    //-------------------------------------------------

    void Awake()
    {
        KeyMapping = new Dictionary<InputActions, KeyCode>();
        MouseMapping = new Dictionary<InputActions, int>();
        SetDefaultKeybindings();
    }

    //-------------------------------------------------

    #region Key Mapping Functions

    public void SetDefaultKeybindings()
    {
        // Keyboard
        KeyMapping.Add(InputActions.UP, KeyCode.W);
        KeyMapping.Add(InputActions.LEFT, KeyCode.A);
        KeyMapping.Add(InputActions.DOWN, KeyCode.S);
        KeyMapping.Add(InputActions.RIGHT, KeyCode.D);
        KeyMapping.Add(InputActions.BLOCK, KeyCode.LeftShift);
        KeyMapping.Add(InputActions.DODGE, KeyCode.Space);
        KeyMapping.Add(InputActions.SWAP_WEAPON, KeyCode.Tab);
        KeyMapping.Add(InputActions.ABILITY_1, KeyCode.Alpha1);
        KeyMapping.Add(InputActions.ABILITY_2, KeyCode.Alpha2);
        KeyMapping.Add(InputActions.ABILITY_3, KeyCode.Alpha3);
        KeyMapping.Add(InputActions.ABILITY_4, KeyCode.Alpha4);
        KeyMapping.Add(InputActions.ABILITY_5, KeyCode.R);
        KeyMapping.Add(InputActions.CONSUMABLE_1, KeyCode.Q);
        KeyMapping.Add(InputActions.CONSUMABLE_2, KeyCode.E);

        // Mouse
        MouseMapping.Add(InputActions.PRIMARY_ATTACK, 0);
        MouseMapping.Add(InputActions.SECONDARY_ATTACK, 1);
    }

    public void SetPreferenceKeybindings()
    {
        // TO-DO: load player pref and load the specified keybindings
    }

    public void SetKeybinding(KeyCode key, InputActions forAction)
    {

    }

    public void SetKeybinding(string key, InputActions forAction)
    {

    }

    public void SetKeybinding(int mouse, InputActions forAction)
    {

    }

    #endregion

    //-------------------------------------------------

    #region Input Functions

    public bool GetInput(InputActions forAction, bool continuous = false)
    {
        KeyCode keyboardPress = GetKeyboardInput(forAction);
        if (keyboardPress != KeyCode.None)
        {
            if (continuous)
            {
                return Input.GetKey(keyboardPress);
            }
            else
            {
                return Input.GetKeyDown(keyboardPress);
            }
        }
        int mousePress = GetMouseInput(forAction);
        if (mousePress != 3)
        {
            if (continuous)
            {
                return Input.GetMouseButton(mousePress);
            }
            else
            {
                return Input.GetMouseButtonDown(mousePress);
            }
        }
        return false;
    }

    private KeyCode GetKeyboardInput(InputActions forAction)
    {
        if (KeyMapping.ContainsKey(forAction))
        {
            return KeyMapping[forAction];
        }
        else
        {
            return KeyCode.None;
        }
    }

    private int GetMouseInput(InputActions forAction)
    {
        if (MouseMapping.ContainsKey(forAction))
        {
            return MouseMapping[forAction];
        }
        else
        {
            return 3; // Non - Assigned mouse button
        }
    }

    #endregion

    //-------------------------------------------------
}
