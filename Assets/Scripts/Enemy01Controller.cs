using UnityEngine;

public class Enemy01Controller : MonoBehaviour
{
	public float speed = 2.0f;
	public GameObject effectPrefab = null;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		// Inspector設定項目をStartで更新するとStartの設定が優先される
		// speed = 0.0f;
	}

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0.0f, 0.0f);

		//画面外のある場所まで行ったらEnemy01を削除する
		if (transform.position.x <= -10.0f)
		{
			Destroy(gameObject);
		}
    }

	void OnTriggerEnter2D(Collider2D collision)
	{
        //当たったtagがPlayerBulletかPlayerならEnemy01を削除
        if (collision.tag == "PlayerBullet" || collision.tag == "Player")
		{
			Instantiate(effectPrefab, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}

//敵を倒した数を数える

//	誰が？
		
//	どこで？
//		OnTriggerEnter2D
//			Enemy
//			PlayerBullet
//			Player
//	いつ？
//		敵倒されたとき
