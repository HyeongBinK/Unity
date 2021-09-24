using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMgr : MonoBehaviour
{
    public static GameMgr instance { get; private set; }

    private Player player;
    GameObject[] turrets;

    private Bullet bulletPrefab;
    private List<Bullet> listBullet;

    [SerializeField] private float spawnRateMin = 0.3f;
    [SerializeField] private float spawnRateMax = 0.8f;
    private float spawnRate = 1f;
    private float checkTIme = 0;
    private float timer = 0;

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += (scene, mode) => { Init(); };
            return;
        }

        Destroy(gameObject);
    }

    void Init()
    {
        UIMgr.instance.OnPlay();
        spawnRate = 1f;
        spawnRateMax = 0.8f;
        timer = 0;

        player = FindObjectOfType<Player>();
        if (!player) player.Init();

        bulletPrefab = Resources.Load<Bullet>("Prefabs/Sphere");

        turrets = GameObject.FindGameObjectsWithTag("Respawn");
        listBullet = new List<Bullet>();
        for (int i = 0; turrets.Length > i; i++)
        {
            var bullet = MakeBullet();
        }
    }

    void SpawnBullet()
    {
        if (0 >= turrets.Length) return;

        var bullet = listBullet.Find(b => !b.gameObject.activeSelf);
        if (!bullet) bullet = MakeBullet();

        if (bullet)
        {
            //ÅºÈ¯¹ß»ç
            var pos_index = Random.Range(0, turrets.Length);
            var pos = turrets[pos_index].transform.position + Vector3.up * 1.5f;
            bullet.SetPosition(pos);

            var dir = (player.position - pos).normalized;
            dir.y = 0.2f;

            var force = Random.Range(3, 8);
            bullet.OnFire(dir, force * 100);

        }
    }

    Bullet MakeBullet()
    {
        if (bulletPrefab)
        {
            var bullet = Instantiate(bulletPrefab);
            if (bullet && player)
            {
                bullet.EventHandleOnCollisionPlayer += player.OnDamaged;
                bullet.EventHandleOnCollisionPlayer += () => { UIMgr.instance.GameOver(timer); };
            }

            if (bullet) listBullet.Add(bullet);
            return bullet;

        }

        return null;
    }

    void Update()
    {
        if (player)
        {

            if (player.isLive)
            {
                timer += Time.deltaTime;
                UIMgr.instance.Timer = timer;

                checkTIme += Time.deltaTime;
                if (spawnRate <= checkTIme)
                {
                    checkTIme = 0;
                    spawnRate = Random.Range(spawnRateMin, spawnRateMax);

                    SpawnBullet();    
                }
            }
            else if(Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene("Dodge");
        }
    }
}
