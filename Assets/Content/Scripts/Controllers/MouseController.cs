using UnityEngine;

public class MouseController : MonoBehaviour, InputController
{
    private Vector2? _inputDirection;

    public Vector2? GetInputDirection()
    {
        _inputDirection = null;
        if (Input.GetMouseButton(0))
        {
            _inputDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        return _inputDirection;
    }

    public bool GetButtonBack()
    {
        return Input.GetKeyDown(KeyCode.Escape);
    }
}