using UnityEngine;

public class CharacterInputHandler : MonoBehaviour
{
    Vector2 _moveInputVector = Vector2.zero;

    Vector2 _viewInputVector = Vector2.zero;

    private ScreenButton _upButton;

    private ScreenButton _downButton;

    private ScreenButton _leftButton;

    private ScreenButton _rightButton;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

        var canvas = FindObjectOfType<UnityEngine.UI.CanvasScaler>();
        _upButton = canvas.transform.Find("Up Button").GetComponent<ScreenButton>();
        _downButton = canvas.transform.Find("Down Button").GetComponent<ScreenButton>();
        _leftButton = canvas.transform.Find("Left Button").GetComponent<ScreenButton>();
        _rightButton = canvas.transform.Find("Right Button").GetComponent<ScreenButton>();
    }

    private void Update()
    {
        // View input
        //_viewInputVector.x = Input.GetAxis("Mouse X");
        //_viewInputVector.y = Input.GetAxis("Mouse Y") * -1f;

        // Move input
        //_moveInputVector.x = Input.GetAxis("Horizontal");
        //_moveInputVector.y = Input.GetAxis("Vertical");

        if ((!_upButton.IsPressed && !_downButton.IsPressed) || (_upButton.IsPressed && _downButton.IsPressed))
        {
            _moveInputVector.y = 0f;
        }
        else
        {
            if (_upButton.IsPressed)
            {
                _moveInputVector.y = 1f;
            }
            else
            {
                _moveInputVector.y = -1f;
            }
        }

        if ((!_leftButton.IsPressed && !_rightButton.IsPressed) || (_leftButton.IsPressed && _rightButton.IsPressed))
        {
            _moveInputVector.x = 0f;
        }
        else
        {
            if (_leftButton.IsPressed)
            {
                _moveInputVector.x = -1f;
            }
            else
            {
                _moveInputVector.x = 1f;
            }
        }
    }

    public NetworkInputData GetNetworkInput()
    {
        NetworkInputData networkInputData = new NetworkInputData();

        // View data
        networkInputData.rotationInput = _viewInputVector.x;

        // Move data
        networkInputData.movementInput = _moveInputVector;

        return networkInputData;
    }
}
