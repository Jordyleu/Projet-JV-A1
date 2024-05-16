using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ColorRed
{
    public Color _red;
    public Enums.Types _redType = Enums.Types.Fire;
    private Rigidbody2D theRB;
    public GameObject colorRed;
    public ColorManager _colorManager;

    void Update()
    {
        if (_redType == _colorManager.actualType)
        {
            //_colorManager.UseColor();
        }
    }
}
