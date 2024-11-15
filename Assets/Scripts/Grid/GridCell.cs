using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class GridCell : MonoBehaviour
{
    [SerializeField] GridColorManagerSO _gridManagerSO;
    SpriteRenderer _spriteRenderer;


    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public Color OnColorChange(Color c)
    {
        var prevColor = _spriteRenderer.color;
        _spriteRenderer.color = c;
        return prevColor;
    }
}
