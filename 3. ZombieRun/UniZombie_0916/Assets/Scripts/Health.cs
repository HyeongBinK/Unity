using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IItem
{
    public int health = 50;

    public void Use(GameObject target)
    {
        LivingEntity life = target.GetComponent<LivingEntity>();
        if(null != life)
        {
            life.RestoreHealth(health);
            Debug.Log("체력이 증가했다.");
        }

        Destroy(gameObject);
    }
}
