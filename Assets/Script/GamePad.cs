using UnityEngine;
using System.Collections;

public class GamePad : MonoBehaviour {

    public ButtonControll btnLeft;
    public ButtonControll btnRight;
    public ButtonControll btnA;

    public bool IsJump()
    {
        return btnA.isPressed();
    }

    public bool IsLeft()
    {
        return btnLeft.isPressed();
    }

    public bool IsRight()
    {
       return btnRight.isPressed();
    }

}
