using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//총알관리스크립트
public class BulletManager : MonoBehaviour
{
    public Rigidbody Bullet; //총
    public float BulletSpeed; //총속도
    public AudioClip BulletAudioClip; //총소리
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody cb = (Rigidbody)Instantiate(Bullet, transform.position, transform.rotation);
            cb.velocity = transform.TransformDirection(new Vector3(0, 0, BulletSpeed));
            AudioSource.PlayClipAtPoint(BulletAudioClip, transform.position);
        }
    }
}
