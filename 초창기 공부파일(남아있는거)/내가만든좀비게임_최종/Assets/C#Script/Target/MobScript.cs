using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//몬스터스킯트
public class MobScript : MonoBehaviour
{
    public GameObject target;
    public int Score; //게임점수
    public int HP; //총알을 몇발맞으면 죽는지
    public int Dammage; //몬스터데미지
    float MemoTimer = 0;
    float ZombieMoveCoolTime = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("HumanSmell");
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.GetComponent<UserInterFace>().time - MemoTimer > ZombieMoveCoolTime)
        {
            MoveToTarget();
            MemoTimer = Camera.main.GetComponent<UserInterFace>().time;
        }
    }
    void MoveToTarget()
    {
        if (target.transform.position != Vector3.MoveTowards(transform.position, target.transform.position, 1f))
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.2f); // 현위치, 도착점, 속도

            transform.LookAt(target.transform);
            //Debug.Log(Vector3.MoveTowards(transform.position, target.transform.position, 1f));

        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            HP--;
            if (HP == 0)
            {
                //체력이 0이되면 스코어오르고 몹파괴
                Camera.main.GetComponent<UserInterFace>().CurrentScore += Score;
                Destroy(gameObject); //
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            print("좀비로부터데미지를입었다!");
            Camera.main.GetComponent<UserInterFace>().HealthBar.value -= Dammage;
        }
    }

}
