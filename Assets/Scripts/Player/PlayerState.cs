using System;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private bool canAct;

    void Awake()
    {
        canAct = true;
    }

    public bool GetCanAct()
    {
        return canAct;
    }

    public void SetCanAct(bool val)
    {
        canAct = val;
    }
}
