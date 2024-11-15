using UnityEngine;
using UnityEngine.UI;

public static class ColorBlockExt
{
    public static ColorBlock ColorToColorBlock(this Color color, ColorBlock colorBlock)
    {
        colorBlock.normalColor = color;
        colorBlock.selectedColor = color;
        colorBlock.pressedColor = color;
        colorBlock.highlightedColor = color;
        return colorBlock;
    }
}
