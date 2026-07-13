using UnityEngine;

public class BGController : MonoBehaviour
{
    public GameObject BGPrefab;
    float speed = 5f;

    GameObject bg1;
    GameObject bg2;

    void Start()
    {
        // 1枚目
        bg1 = Instantiate(BGPrefab, new Vector3(0f, 0f, 120f), Quaternion.identity);

        // 2枚目を右側に生成
        bg2 = Instantiate(BGPrefab, new Vector3(19.19f, 0f, 120f), Quaternion.identity);
    }

    void Update()
    {
        // 両方の背景を左へ移動
        bg1.transform.Translate(-speed * Time.deltaTime,0f,0f);
        bg2.transform.Translate(-speed * Time.deltaTime,0f,0f);

        // bg1が画面外へ行ったらbg2の右へ移動
        if (bg1.transform.position.x <= -19.19f)
        {
            bg1.transform.position =new Vector3(19.19f,0f,120f);
        }

        // bg2が画面外へ行ったらbg1の右へ移動
        if (bg2.transform.position.x <= -19.19f)
        {
            bg2.transform.position = new Vector3(19.19f, 0f, 120f);
        }
    }
}