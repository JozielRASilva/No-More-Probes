﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{

    public int bestPoint;

    public PlayerData()
    {
        bestPoint = PlayerInfo.bestPoint;
    }


}
