using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //총발사시 폭발효과
    public GameObject OriginalSpark;
    GameObject CloneSpark;

    // Start is called before the first frame update
    void Start()
    {
        CloneSpark = (GameObject)Instantiate(OriginalSpark,OriginalSpark.transform.position, OriginalSpark.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Bullet")
        {
            return;
        }
        CloneSpark.transform.position = transform.position;
        Destroy(transform.gameObject);
    }
}
