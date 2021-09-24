using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;

    [SerializeField] float jumpForce = 300f;
    readonly int limitJumpCount = 2;
    int jumpCount = 0;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameMgr.Instance.isDead || !rigid) return;
        if(Input.GetKeyDown(KeyCode.Space) && limitJumpCount > jumpCount)
        {
            jumpCount++;

            rigid.velocity = Vector2.zero;
            rigid.AddForce(Vector2.up * jumpForce);
            SoundMgr.Instance.PlaySFX("jump");
        }
        else if(Input.GetKeyUp(KeyCode.Space) && 0 < rigid.velocity.y)
        {
            rigid.velocity *= 0.5f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.contacts[0].normal.y > 0.8f)
        {
            if (anim) anim.SetBool("isGround", true);
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (anim) anim.SetBool("isGround", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("DeadZone"))
        {
            if (rigid) rigid.simulated = false;
            if(anim) anim.SetTrigger("isDie");
            GameMgr.Instance.OnDie();
            SoundMgr.Instance.PlaySFX("die");
        }
    }

    private void GameOver()
    {
        GameMgr.Instance.GameOver();
    }

}
