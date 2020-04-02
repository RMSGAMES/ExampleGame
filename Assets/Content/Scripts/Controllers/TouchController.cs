using UnityEngine;

public class TouchController : MonoBehaviour, InputController
{
	private Vector2? _inputDirection;

	public Vector2? GetInputDirection()
	{
        _inputDirection = null;
        if (Input.touchCount > 0)
        {
            _inputDirection = Input.GetTouch(0).position;
        }
        return _inputDirection;
	}

	public bool GetButtonBack()
	{
		return Input.GetButtonDown("Cancel");
	}
}