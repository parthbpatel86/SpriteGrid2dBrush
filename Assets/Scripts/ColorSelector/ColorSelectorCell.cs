using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ColorSelectorButton : MonoBehaviour
{
    Toggle _toggle;
    List<Action<Color>> _cb;

    private void Start()
    {
        _toggle = GetComponent<Toggle>();
    }
    public void RegisterForCallBack(Action<Color> callback)
    {
        if (_cb == null)
            _cb = new List<Action<Color>>();
        _cb.Add(callback);
    }

    public void CallBackOnSelect(bool enable)
    {
        if (enable == false) return;

        for(int i=0; i< _cb.Count; i++)
        {
            _cb[i](_toggle.colors.normalColor);
        }
    }
}
