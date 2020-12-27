using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;


public class touchpadInput : MonoBehaviour
{
    public int touchpadCounter;

    public void pressedDown()
    {
        touchpadCounter = 1;
        print("touch down");
    }

    public void pressedUp()
    {
        touchpadCounter = 0;
        print("touch up");
    }



    /*
    private MLInputController _controller;
    public int touchCounter;

    // Start is called before the first frame update
    void Start()
    {
        MLInput.Start();
        _controller = MLInput.GetController(MLInput.Hand.Right);
        touchCounter = 0;
    }
    /*
    bool getTouch(MLInputController controller, MagicLeapInputControllerTouchpadGestureType action)
    {
        if (controller != null)
        {

            if()

            if (action == MagicLeapInputControllerTouchpadGestureType.ForceTapDown)
                return true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        string gestureType = _controller.TouchpadGesture.Type.ToString();
        string gestureState = _controller.TouchpadGestureState.ToString();
        //string gestureDirection = _controller.TouchpadGesture.Direction.ToString();

        print("Type: " + gestureType);
        print("\n State: " + gestureState);
        
    }*/
    
}
