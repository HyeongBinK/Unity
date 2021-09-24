using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour, IItem
{
    public int ammo = 0;

    public void Use(GameObject target)
    {
        Debug.Log("탄알이 증가했다.");
    }
}
