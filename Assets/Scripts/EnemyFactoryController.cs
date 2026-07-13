using TMPro;
using UnityEngine;

public class EnemyFactoryController : MonoBehaviour
{
	public GameObject gameSceneManagerObject = null;

    public GameObject enemy01Prefab = null;
	public GameObject enemy02Prefab = null;
	/*
        配列の用語
            要素：
                配列に保存されている1つ1つの値

            要素数：
                配列に保存されている要素の数

            要素番号（インデックス、そえ字）：
                配列の内の要素を識別するために設定された番号
                
                要素番号の特徴：
                    0から始まる
                    連番になっている
    */
	/*
	   プログラム中に配列を作る場合(C#バージョン)
		   変数名 = new 型[要素数]
   */
    public GameObject[] enemyPrefabs = new GameObject[10];//Inspector内にenemyPrefabsを格納できる部屋を10個作成(配列)
	public GameObject bossPrefab = null;
	//    GameObject enemies[];
	float timer = 0.0f;
    float startTimer = 0.0f;

	bool isCreatedBoss = false;//Bossが生成されたか判断

	public void CreateBoss()
	{
        TextMeshProUGUI tmpro = GetComponent<TextMeshProUGUI>();

        if (isCreatedBoss == false)
		{
			// Bossを作る
			// Instatiateを使う
			// 複製元のデータが必要 => BossのPrefab
			// Bossプレハブがないからメンバ変数に追加する
			Instantiate(bossPrefab, transform.position, Quaternion.identity);

            //Bossの生成は一度でいいためここでIsCreatedBossをtrueにする
            isCreatedBoss = true;

		}
	}

	void Start()
	{

	}

	void Update()
    {
		if (isCreatedBoss == true)
		{
            // returnに到達するとそこで関数（メソッド）は終わり
            return;
		}

        startTimer += Time.deltaTime;

		float wait_time = 0.0f;
        //wait_timeはGameSceneControllerのスクリプト内にあるstartDirectionTime変数の値を代入
        wait_time = gameSceneManagerObject.GetComponent<GameSceneController>().startDirectionTime;
        if (startTimer < wait_time)
		{
			// returnに到達するとそこで関数（メソッド）は終わり
			return;
		}

		/*
			Random.Range(最小整数, 最大整数)
				最小整数～最大整数-1までの範囲
				Random.Range(0, 100) => 0 ～ 99

			Random.Range(最小実数, 最大実数)
				最小実数～最大実数までの範囲
				Random.Range(0.0f, 100.0f) => 0.0f ～ 100.0f
		*/
		float interval = 1.5f;

		timer += Time.deltaTime;
		if (timer >= interval)
		{
			Vector3 pos = transform.position;

			pos.y += Random.Range(-4.0f, 4.0f);

			int random = Random.Range(0, 2); // 0 ～ 1

			//random変数に0か1を代入し、0ならEnemy01を、1ならEnemy02を生成する
			if (random == 0)
			{
				Instantiate(enemyPrefabs[0], pos, Quaternion.identity);
			}
			else
			{
				Instantiate(enemyPrefabs[1], pos, Quaternion.identity);
			}

			timer = 0.0f;
		}
	}
}
