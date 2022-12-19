using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoyStickPlayerJumpScript : MonoBehaviour,Hello
{
    GameObject Player;
    JoystickCharacterMove _JoystickCharacterMove;
    public bool readyToJumpJoyStick = false;
    public bool ToJumpJoyStick = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Bubo");
        _JoystickCharacterMove = Player.GetComponent<JoystickCharacterMove>();
    }

    // Update is called once per frame
    void Update()
    {

        if (readyToJumpJoyStick == true && !ToJumpJoyStick == true && _JoystickCharacterMove.IsGrounded())
        {
            //_JoystickCharacterMove._animator.SetBool("IsReadyToJumpe", true);
            //_JoystickCharacterMove._animator.SetBool("IsJumpe", false);
            _JoystickCharacterMove.jumpBtnGetDown();
        }
        else if (!readyToJumpJoyStick == true && ToJumpJoyStick == true)
        {
            //_JoystickCharacterMove._animator.SetBool("IsJumpe", true);
            //_JoystickCharacterMove._animator.SetBool("IsReadyToJumpe", false);
            _JoystickCharacterMove.JumpKeyup();

            readyToJumpJoyStick = false;
            ToJumpJoyStick = false;
        }

    }

    public void jumpBtndown()
    {
        readyToJumpJoyStick = true;
        ToJumpJoyStick = false;
    }

    public void JumpBtnUp()
    {
        readyToJumpJoyStick = false;
        ToJumpJoyStick = true;
    }
}

public interface Hello
{

}