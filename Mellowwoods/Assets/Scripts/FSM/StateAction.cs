﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public abstract class StateAction : MonoBehaviour
    {
        public abstract bool Execute();
    }
}
