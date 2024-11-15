using UnityEngine;
using UnityEngine.InputSystem;

public class HistoryNavInputActionManager : MonoBehaviour
{
    [SerializeField] GridColorManagerSO _colorManagerSO;

    private HistoryNavControls _keyboardControls;
    private InputAction _undoAction;
    private InputAction _redoAction;

    private void OnEnable()
    {
        _keyboardControls = new HistoryNavControls();
        _undoAction = _keyboardControls.HistoryNavigate.Undo;
        _undoAction.Enable();
        _redoAction = _keyboardControls.HistoryNavigate.Redo;
        _redoAction.Enable();
    }

    private void OnDisable()
    {
        _undoAction.Disable();
        _redoAction.Disable();
        _keyboardControls.Disable();
    }

    void Update()
    {
        if (_undoAction != null && _undoAction.WasPressedThisFrame())
            _colorManagerSO.Undo();
        if (_redoAction != null && _redoAction.WasPressedThisFrame())
            _colorManagerSO.Redo();
    }
}
