using System;
using UnityEngine;

[Serializable]
public class ColorBlue
{
    public Color _blue;
    public Enums.Types _blueType = Enums.Types.Water;
    public GameObject colorBlue;
    public ColorManager _colorManager;

    void Update()
    {
        if (_blueType == _colorManager.actualType)
        {
            //_colorManager.UseColor();
        }
    }
}
