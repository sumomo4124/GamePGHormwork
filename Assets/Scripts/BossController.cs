using UnityEngine;

public class BossController : MonoBehaviour
{
    //enumのStateという型のなかにApear,Battle,Deadを作成

    enum State
    {
        Apear,//上から要素番号0
        Battle,//要素番号1
        Dead,//要素番号2
    }

    public GameObject explosionPrefab = null;
    int life = 50;
    State state = State.Apear;  // 現在の状態
    float timer = 0.0f;
    float effectTimer = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //switch(分岐元の変数)で変数の値によって処理を分岐
        //switchにはbreakを必ず含めないとエラーが起きる
        switch (state)
        {
            case State.Apear:
                Apear();
                break;
            case State.Battle:
                Battle();
                break;
            case State.Dead:
                Dead();
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
	{
        /*
            当たる条件
                tagがPlayerBullet
                状態がBattle
         
                上記の条件をどちらも満たしたら当りとする

            当たった場合
                状態をDeadに変更する
                ※１．削除はここでしない
                ※２．確認が必要ならDebug.Logで表示する
        */

		if (collision.tag == "PlayerBullet" &&
            state == State.Battle)
        {
            //当たったらlifeを一ずつ減らす
            life--;

            //lifeが0以下になったら状態をDeadに変える
            if (life <= 0)
            {
				state = State.Dead;
			}
		}
	}

    //Bossが登場し指定した座標まで進むまで
    void Apear()
    {
		float speed = 0.5f;
		float stop_pos = 6.0f;

		if (transform.position.x > stop_pos)
		{
			transform.Translate(-speed * Time.deltaTime, 0.0f, 0.0f);
		}
        else
        {
			// 登場が終わったのでBattleに変更
			state = State.Battle;   
        }
	}

    //戦闘中
	void Battle()
    {

    }

    //Bossが死んだとき
    void Dead()
    {
        float destroy_time = 10.0f;

        timer += Time.deltaTime;
        if (timer >= destroy_time)
        {
			Destroy(gameObject);
            GameObject scene_manager = GameObject.Find("GameSceneManager");

            if (scene_manager != null)
            {
                scene_manager.GetComponent<GameSceneController>().ClearedGame();
            }
        }

        float interval_time = 0.3f;

        effectTimer += Time.deltaTime;
        if (effectTimer >= interval_time)
        {
            Vector3 pos = transform.position;

            pos.x += Random.Range(-3.0f, 3.0f);
            pos.y += Random.Range(-4.0f, 4.0f);
            //Random.Rangeで生成した値を座標に代入し、そのランダムな位置にexplosionPrefabを生成する
            Instantiate(explosionPrefab, pos, Quaternion.identity);

            effectTimer = 0.0f;
        }
	}
}
