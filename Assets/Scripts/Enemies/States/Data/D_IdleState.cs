﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newIdleStateData", menuName = "Data/State Data/Idle State")]
public class D_IdleState : ScriptableObject
{
    public float minIdleTime;
    public float maxIdleTime;
}
