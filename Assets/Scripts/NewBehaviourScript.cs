using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    int n = 0;
    private void Start() {
        n = 0;
    }
    public void DebugLog() {
        Debug.Log($"Clicked {n}");
        n += 1;
    }
}
