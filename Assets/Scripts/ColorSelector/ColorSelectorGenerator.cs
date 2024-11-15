using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelectorPopulator : MonoBehaviour
{
    [SerializeField] ColorSelectorButton _colorSelectorButton;
    [SerializeField] List<Color> _colors;
    [SerializeField] GridColorManagerSO _gridManagerSO;

    void Start()
    {
        if (_colors == null)
            return;

        ToggleGroup toggleGp = this.GetComponent<ToggleGroup>();
        for (int i=0; i < _colors.Count; i++)
        {
            ColorSelectorButton go = Instantiate<ColorSelectorButton>(_colorSelectorButton, this.transform);
            go.RegisterForCallBack(OnColorSelected);
            Toggle toggle = go.GetComponent<Toggle>();
            toggle.group = toggleGp;
            toggle.colors = _colors[i].ColorToColorBlock(toggle.colors);
            if (i == _colors.Count - 1)
            {
                toggle.isOn = true;
                OnColorSelected(_colors[i]);
            }
        }
    }

    void OnColorSelected(Color color)
    {
        _gridManagerSO.OnCurrentColorChange(color);
    }
}
