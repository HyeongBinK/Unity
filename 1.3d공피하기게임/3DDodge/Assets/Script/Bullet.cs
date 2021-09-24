using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private Rigidbody rigid;
    public event Action EventHandleOnCollisionPlayer;
    // Start is called before the first frame update
    private void Start()
    {
        if (!rigid) rigid = GetComponent<Rigidbody>();
        gameObject.SetActive(false);
    }
    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
    }

    public void OnFire(Vector3 dir, float force)
    {
        gameObject.SetActive(true);

        rigid.velocity = Vector3.zero;
        rigid.AddForce(dir.normalized * force);
    }

    private void OnTriggerEnter(Collider other)
    {
        var tag = other.tag;
        if(tag.Equals("Player"))

        {
            if (null != EventHandleOnCollisionPlayer) EventHandleOnCollisionPlayer();
        }
        else if(tag.Equals("Respawn") || other.name.Equals(name)) return;

        gameObject.SetActive(false);
    }
}
