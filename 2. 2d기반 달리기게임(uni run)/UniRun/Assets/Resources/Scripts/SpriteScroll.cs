using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct GroundData
{
    public float xPos;
    public float width;
}
public class SpriteScroll : MonoBehaviour
{
    SpriteRenderer background;
    Vector2 offset = Vector2.zero;

    [SerializeField] float scrollSpeed = 5f;
    [SerializeField] SpriteRenderer[] grounds;
    [SerializeField] float bounds = 5f;

    GroundData[] groundDatas;
    float halfWidth = 0;
    float prePosX = 0;

    private void Start()
    {
        var worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        var worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
        background = GetComponent<SpriteRenderer>();
        if(background)
        {
            background.drawMode = SpriteDrawMode.Tiled;
            var size = background.size;
            size.x = worldScreenWidth;
            background.size = size;
        }

        halfWidth = worldScreenWidth * 0.5f;
        var count = grounds.Length;
        if (1 < count)
        {
            groundDatas = new GroundData[count];
            for (int i = 0; count > i; i++)
            {
                groundDatas[i].width = grounds[i].size.x;
                if (0 < i)
                {
                    groundDatas[i].xPos = groundDatas[i - 1].xPos + bounds + groundDatas[i].width;
                    grounds[i].transform.position = Vector3.right * groundDatas[i].xPos + Vector3.down;
                }
                else groundDatas[i].xPos = grounds[i].transform.position.x;
            }

            prePosX = groundDatas[count - 1].xPos;

        }
    }

    void Update()
    {
        if (GameMgr.Instance.isDead) return;
        offset.x = Mathf.Repeat(Time.time * scrollSpeed * 0.01f, 1);
        background.material.mainTextureOffset = offset;

        if(1 < grounds.Length)
        {
            for(int i = 0; grounds.Length > i; i++)
            {
                groundDatas[i].xPos -= Time.deltaTime * scrollSpeed;
                if (-halfWidth >= groundDatas[i].xPos)
                {
                    groundDatas[i].xPos = prePosX + bounds + groundDatas[i].width;
                }
                grounds[i].transform.position = Vector3.right * groundDatas[i].xPos + Vector3.down;
                prePosX = groundDatas[i].xPos;
            }
        }
    }

}
