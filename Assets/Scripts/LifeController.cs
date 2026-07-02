using UnityEngine;

public class LifeController : MonoBehaviour
{
	// GameObjectの配列を用意 名前：lifes
	public GameObject[] lifes;
	public GameObject playerObject;

	// Inspector上で要素数3で設定して、各要素番号には以下の画像を設定
	// element0:Image
	// element1:Image(1)
	// element2:Image(2)

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		//lifes[0].SetActive(false);
		/*
			for (カウンター変数の宣言と初期化; 繰り返し条件チェック; カウンター変数の増減)
			{
				繰り返し処理
			}

			流れ
				① カウンター変数の宣言と初期化が行われる
					インデックス変数とも呼ばれている
				② 繰り返し条件チェックを行う
					条件が成立していたら繰り返し処理実行
				③ 繰り返し処理を実行する
				④ カウンター変数の増減処理を行う
				⑤ ②に戻る
		 */
		for (int i = 0; i < 3; i++)
		{
			Debug.Log("繰り返し中");
		}

    }

    // Update is called once per frame
    void Update()
    {
		// 1. gameObject => UILifeの指すので違う
		// 2. GameObject => 型名なので違う
		// 3. playerObject => RobotのGameObjectであり、RobotControllerを保持しているので正解
		// 4. すべて違う => 違う
		// 5. どれでも良い => 違う
		RobotController robot_controller = null;
		robot_controller = playerObject.GetComponent<RobotController>();

        //RobotControllerのscriptの変数と同期
        int life = robot_controller.life;
        int max_life = robot_controller.maxLife;

		/*
			for (カウンター変数の宣言と初期化; 繰り返し条件チェック; カウンター変数の増減)
			{
				繰り返し処理
			}

			流れ
				① カウンター変数の宣言と初期化が行われる
					インデックス変数とも呼ばれている
				② 繰り返し条件チェックを行う
					条件が成立していたら繰り返し処理実行
				③ 繰り返し処理を実行する
				④ カウンター変数の増減処理を行う
				⑤ ②に戻る
		*/
		for (int i = 0; i < max_life; i++)
		{
			if (life > i)
			{
				lifes[i].SetActive(true);
			}
			else
			{
				lifes[i].SetActive(false);
			}
		}

		//if (life > 0)
		//{
		//	lifes[0].SetActive(true);
		//}
		//else
		//{
		//	lifes[0].SetActive(false);
		//}

		//if (life > 1)
		//{
		//	lifes[1].SetActive(true);
		//}
		//else
		//{
		//	lifes[1].SetActive(false);
		//}

		//if (life > 2)
		//{
		//	lifes[2].SetActive(true);
		//}
		//else
		//{
		//	lifes[2].SetActive(false);
		//}
    }
}
