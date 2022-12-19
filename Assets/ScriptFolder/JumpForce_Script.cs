using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpForce_Script : MonoBehaviour
{
    [SerializeField] Image color;
    [SerializeField] Image CorrectPoint;
    float Correctjumpforce;
    float JoystickCorrectjumpforce;
    float MaxJumpeforce;
    CharacterMove _CharacterController;
    JoystickCharacterMove _JoystickCharacterMove;
    GameObject _GameObject;
    // Start is called before the first frame update
    void Start()
    {
        _GameObject = GameObject.Find("Bubo");
        color = GetComponent<Image>();
        CorrectPoint = GetComponent<Image>();
        _CharacterController = GameObject.Find("Bubo").GetComponent<CharacterMove>();
        _JoystickCharacterMove = GameObject.Find("Bubo").GetComponent<JoystickCharacterMove>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_GameObject.GetComponent<CharacterMove>() == true)
        {
            color.fillAmount = CorrectJumpforceMethod(_CharacterController.JumpeForce, _CharacterController.Chargejump,
                MaxJumpeforceReturn(_CharacterController.MaxJump, _CharacterController.JumpeForce));
        }
        if (_GameObject.GetComponent<JoystickCharacterMove>() == true)
        {
            color.fillAmount = CorrectJumpforceMethod(_JoystickCharacterMove.JoyStickJumpeForce, _JoystickCharacterMove.JoysickChargejump,
                MaxJumpeforceReturn(_JoystickCharacterMove.JoystickMaxJump, _JoystickCharacterMove.JoyStickJumpeForce));
        }
    }

    float CorrectJumpforceMethod(float JumpeForce, float Chargejump, float division)
    {
        return Correctjumpforce = (JumpeForce * Chargejump) / division;
    }

    float MaxJumpeforceReturn(float MaxJump, float JumpeForce)
    {
        return MaxJumpeforce = (MaxJump * JumpeForce);
    }
}
