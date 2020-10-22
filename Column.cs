﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Birds>() != null)
        {
            GameController.instance.BirdScored();
        }
    }
}
