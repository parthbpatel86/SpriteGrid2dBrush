using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    [SerializeField] GridColorManagerSO _gridColorManager;
    ColorCellControls _inputActions;
    InputAction _touchPosAction;
    InputAction _touchPressAction;
    GridCell _prevcell;

    private void Awake()
    {
        _inputActions = new ColorCellControls();
        _touchPosAction = _inputActions.TouchCell.TouchPosition;
        _touchPressAction = _inputActions.TouchCell.TouchPress;
    }

    private void OnEnable()
    {
        _inputActions.Enable();
        _touchPressAction.Enable();
        _touchPosAction.Enable();
        _touchPressAction.performed += TouchStarted;
        _touchPosAction.performed += TouchPos;
    }

    private void OnDisable()
    {
        _inputActions.Disable();
        _touchPressAction.Disable();
        _touchPosAction.Disable();
        _touchPressAction.performed -= TouchStarted;
        _touchPosAction.performed -= TouchPos;
    }

    private void TouchStarted(InputAction.CallbackContext context)
    {
        _gridColorManager.BatchTouchStarted();
    }

    private void TouchPos(InputAction.CallbackContext context)
    {
        var value = _touchPosAction.ReadValue<Vector2>();
        var worldPos = Camera.main.ScreenToWorldPoint(value);
        Vector2 vector2 = new Vector2(worldPos.x, worldPos.y);

        // Cast a ray from the mouse position
        RaycastHit2D hit = Physics2D.Raycast(vector2, Vector2.zero);

        if (hit.collider != null)
        {
            // Check if the ray hit a sprite
            SpriteRenderer spriteRenderer = hit.collider.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                var cell = spriteRenderer.GetComponent<GridCell>();
                if (cell != null && _prevcell != cell)
                {
                    _gridColorManager.OnGridCellColorChange(cell);
                    _prevcell = cell;
                }
            }
        }
    }
}