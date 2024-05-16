using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ColorWhite
{
    public Color _white;
    public Enums.Types _whiteType = Enums.Types.Water;
    private Rigidbody2D theRB;
    public GameObject colorWhite;
    public ColorManager _colorManager;

    void Update()
    {
        if (_whiteType == _colorManager.actualType)
        {
            //_colorManager.UseColor();
        }
    }
}
