﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

    private void OnTriggerExit2D(Collider2D Other)
    {
        Destroy(Other.gameObject);
    }
}
