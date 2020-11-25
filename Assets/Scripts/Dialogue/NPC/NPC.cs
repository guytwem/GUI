﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour
{
    [SerializeField] protected private string name;

    public abstract void Interact();
    
}
