using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputNames
{
    public const string HORIZONTAL_INPUT_NAME = "Horizontal";
    public const string VERTICAL_INPUT_NAME = "Vertical";
    public const string SHOOT_INPUT_NAME = "Fire1";
}
public class InputManager : MonoBehaviour
{

private float _horizontalInput, _verticalInput;
private bool _shootInput;

public float HorizontalInput {get {return _horizontalInput;}}

public float VerticalInput {get {return _verticalInput;}}

public bool ShootInput {get{return _shootInput;}}

private void Update()
{
GetInput();
}

private void GetInput()
    {

    _horizontalInput = Input.GetAxisRaw(InputNames.HORIZONTAL_INPUT_NAME);
    _verticalInput = Input.GetAxisRaw(InputNames.VERTICAL_INPUT_NAME);
    _shootInput = Input.GetButtonDown(InputNames.SHOOT_INPUT_NAME);

    if(_shootInput)
    {
        Debug.Log("shoot");
    }
    }
}
