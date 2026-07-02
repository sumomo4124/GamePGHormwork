/*
	■5/18
	１．bullet1かbullet2をSceneに配置
	２．名前をPlayerBulletに変更（Hierarchy配置のGameObject）
	３．PlayerBulletControllerを作成
	４．右に移動させる（速度は任意）
	５．当たり判定を付ける
		Gravity Scale 1 => 0
	６．「PlayerBullet」tagを追加する
	７．PlayerBulletオブジェクトをプレハブ化する
	８．Spaceを押した瞬間にRobotの位置からPlayerBulletを発射する
	９．EA1～EA4でアニメーション作成
	１０．Hierachy配置のEnemyの名前をEnemy01に変更
	１１．Enemy01Controllerを作成
	１２．Enemy01を左に移動する（速度は任意）
	１３．「Enemy」tagを追加する
	１４．当たり判定を付ける
	１５．PlayerBulletとEnemyが重なった瞬間
		PlayerBullet => 削除
		Enemy01 => 削除
	１６．Enemy01のプレハブ化
	１７．EnemyFactory作成
	１８．EnemyFactoryの位置からY軸に-4～4のランダム幅でEnemy01を作成
		　生成間隔は1.5秒
	１９．EffectControllerを作成
	２０．Explosionフォルダの中身でアニメーションを作成
	２１．エフェクトは一秒で削除する
	２２．Enemy01が死んだ位置にEffectを作成する

	■5/22
	２３．EA2 1 ～ EA2 4でアニメーションを作成する（Enemy02）
	２４．Enemy02に当たり判定の設定をする
	２５．スクリプトの作成と設定
	２６．Enemy02のタグをEnemyタグに変更
	２７．Enemy02の移動（上下に移動しながら、左に移動する）
			Ex:cosやsinを使って上下移動を行う
				Mathf.cosf(ラジアン)
				Mahtf.sinf(ラジアン)

	２８．PlayerBulletに当たったら消える
	２９．消える際に爆発エフェクトを表示する
	３０．プレハブ化する
	３１．Enemy02もFactoryから生成できるようにする
			Enemy01とEnemy02の生成確立は50%
	３２．Enemy01のX座標が-10以下になったら削除する
			transform.position.x でObjectのx座標が分かる
	３３．Enemy02のX座標が-10以下になったら削除する
	３４．PlayerBulletが画面から見えなくなったら消す
	３５．Player(Robot)と敵が当たったら消す
		　（エフェクトも表示する）
	３６．背景の実装
	３７．Engine_fire 1～4を使ってアニメーションを作成
	３８．HierarchyでEngineFireをRobotの子供に設定
	３９．EngineFireの座標を(0, 0, 0)に設定
	４０．EngineFireの位置調整

	４１．EngineFireObjectを保存するメンバ変数を宣言
	４２．InspectorでEngineFireObject変数に設定
	４３．Startで非表示設定
	４４．Boost機能の実装
			Boostボタンを押したら起動
			発動時間は5秒
			速度が2倍になる
			EngineFireを表示する

			終了条件：
				・前提
					Boost中
				・条件（どちらか成立で終了）
					5秒経過
					Aボタンを押す
			ヒント：
				起動中かどうかの判断はどうする？
				発動時間はどうやって測る？
	４５．配列の説明
	■5/29
	４６．ゲーム本編からタイトルシーンへの切り替え
	４７．タイトルシーンからゲーム本編への切り替え
			キーを押した瞬間に切り替える
			（切り替わりのキーはどれでもよい）
	４８．Debug.Logの説明
	４９．ブレークポイントの説明
	５０．Robotの移動制限
	５１．斜め移動の移動量調整

	■6/1
	５２．TMPを追加する
	５３．表示されたImporterでTMPをインポートする
	５３．初期フォントは全角対応がないので、日本語対応を行う（方法は下記のURL参照）
		https://zenn.dev/kametani256/articles/63c083ab318136
	５４．Canvasの説明
	５５．Life画像追加
	５６．Canvas内にCreateEmptyでUILife(Life管理用)を追加
	５７．UILifeの中にImageでLifeを追加
		　位置を調整
	５８．UILifeの位置を移動（プロジェクトでは左上隅）
	５９．LifeControllerを作成
	６０．LifeImageを保存するための変数lifesを宣言（配列）
	６１．inspector上で、lifesにLifeImageを設定
	６２．Robotにlife(残機)を追加
	６３．敵に当たったらlifeを1減らし、0になったらSceneを切り替える
			インクリメントとデクリメントについて簡単に説明
	６４．UILifeにRobotObjectの値を保存する（Inspectorを使用）
	６５．UILifeでRobotObjectのRobotControllerからlifeの値を取得する
			publicの説明
	６６．lifeに合わせて描画する残機の数を調整
	６７．forの説明
	■6/5
	６８．MaxLifeの追加
	６９．LifeのOn/Offをforでまとめる
	７０．Sliderを作る
			名前をUIBoostに変更する
	７１．簡単な操作説明
			Background => ゲージの下地の部分
			FillArea => ゲージ本体
			HandleSideArea => ハンドル部分
	７２．ハンドル削除時の注意点
			Handleが邪魔なら消せるが、Fillの範囲がハンドル分小さく作られている
	７３．ハンドルを消す
	７４．Sliderを最小と最大にする
	７５．FillAreaのRectTransformのLeftとRightを0にする
		  FillのWidthを0にする
	７６．BoostGaugeControllerを作成する
	７７．StartでSliderComponentを取得して、maxValueなどを変更する
	７８．ゲームループとGameObjectのライフサイクルの説明
	７９．UIBoostでRobotの情報を取得できるように変数追加
	８０．RobotControllerにboostの制限時間を追加
	８１．BoostGaugeControllerでRobotControllerからBoost情報を取得し、minValueに反映する
	８２．BoostGaugeControllerのUpdateでRobotControllerからboostTimerを取得し、valueに反映する
	８３．ゲージを最大から最小に変化するように変更
	８４．HierarchyにあるTMPの名前を UITimer に変更
	８５．GameTimerControllerを作成
	８６．10秒経過でTitleSceneに遷移する

	■6/8
	８７．TMPに残り時間を反映させる
	８８．残り時間が0から増えていっていたので、残り時間から0になるように変更
	８９．敵とRobotが当たったら、敵を消す
	９０．PlayerBulletを生成したときにRobot情報(GameObject)を渡す 
	９１．PlayerBullet側でEnemyを倒したときにRobotの情報からRobotControllerを取得して倒した数を増やす
			フリーズする可能性が高いため切り替えは一旦保留
	９２．GameSceneManagerとGameSceneControllerを作成
	９３．GameSceneControllerゲームクリアとゲームオーバーの対応を実装
	９４．クリアと失敗処理を書いている場所をGameSceneControllerを使うやり方に変更

	■6/12
	９５．VisualStudioでC++のプロジェクトを作り、「関数」について説明
	９６．OnCollsionやOnTrigger系の中でシーンを切り替えるとフリーズする可能性を説明
	９７．クリア、失敗によるシーン切り替えをGameSceneControllerのUpdateで対応するように変更
	９８．GameStart、GameClear、GameOver画像の設定がMultipleになっていたのでSingleに変更
	９９．「GameStart」が5秒で消えるGameObjectを作り、プレハブ化
	１００．Game開始直後にGameStartと表示する

	■6/15
	１０１．GameStartの文字が出ている間は敵を生成しないようにする
	１０２．GameOverの文字を表示して、5秒で削除するObjectを作成
	１０３．GameOverObjectをプレハブ化
	１０４．Gameが失敗したらGameOverの文字を表示する
	１０５．GameOverから5秒経過でシーン切り替え
	１０６．GameClearの文字を表示して、5秒で削除するObjectを作成
	１０７．GameClearObjectをプレハブ化
	１０８．GameをクリアしたらGameClearの文字を表示する
	１０９．BossesからBossを作成する
	１１０．BossCotrollerスクリプトを作る
	１１１．Bossタグを作成し、設定する
	１１２．当たり判定（Trigger）を設定する
	１１３．Playerの弾を当てて消す（Playerの弾も消すこと）
	１１４．Bossをプレハブ化する
	１１５．GameStartなどの文字をRobotよりも手前に描画する

	■6/19
	１１６．EnemyFacotryのStartでCreateBossを使ってBossを生成する
	１１７．GameTimerControllerで時間が0になったらCreateBossを使う
	１１８．Boss生成を一回で終わるようにする
	１２０．Bossを左に移動する（ゆっくり）
	１２１．特定の位置に到達したら止まる
	１２２．enumでボスの状態を作成
	１２３．Updateの処理を登場状態だった場合に実行するように変更
	１２４．BossControllerに、以下の関数を定義
			1
				戻り値、引数なし
				関数名：Apear

			2
				戻り値、引数なし
				関数名：Battle

			3
				戻り値、引数なし
				関数名：Dead
	１２５．Updateでswitchを作りStateの分岐の作り、各分岐で適切な関数を呼び出す
	１２６．Apearが正常に動作していることを確認する
	１２７．Battle状態中にPlayerBulletが当たったら状態をDeadに変更する
	１２８．Bossが生成されたら敵生成をやめる
	１２９．Bossにlifeを設定する（とりえず初期値は1で）
	１３０．BossにPlayerBulletがlifeを1減らし、0になったら状態をDeadにする
	
	１３１．BossのDead状態の挙動
				10秒経過でDestroy
				10秒の間に爆発エフェクトを一定間隔で生成し続ける
				生成位置はボスの周囲にランダム
				
 */
using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotController : MonoBehaviour
{
	public GameObject bulletPrefab = null;
	public GameObject effectPrefab = null;
	public GameObject engineFireObj = null;

	public float boostTimer = 0.0f;
	public float boostTime = 5.0f;

	bool isBoost = false;
	/*
		public
			メンバ変数に設定することで、以下の効果を得られる
				・Inspectorに項目が表示される
				・外部（別のスクリプト）からアクセスできる
	*/
	public int life = 3;
	public int maxLife = 3;


	public int defeatedCounter = 0;	// 倒した数

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        //if (isBoost) // isBoost == true
        //{
        //}

        //if (!isBoost) // isBoost == false
        //{
        //}



        /*console上に変数に何が入っているかなどを表示できる 
          
                    PythonのPrintと似ている          */
        Debug.Log(boostTimer);
		Debug.Log(123);
		Debug.Log(3.14);
		Debug.Log(engineFireObj);

		Debug.Log(Screen.width);
		Debug.Log(Screen.height);

		engineFireObj.GetComponent<Renderer>().enabled = false;
    }

	// Update is called once per frame
	//void Update()
	//{
	//	float speed = 1.0f;
	//	float move = speed /* 秒速 */ * Time.deltaTime;

	//	if (isBoost == true)
	//	{
	//		move *= 2.0f;
	//	}

	//	if (Input.GetKey(KeyCode.UpArrow))
	//	{
	//		transform.Translate(0.0f, move, 0.0f);
	//	}

	//	if (Input.GetKey(KeyCode.DownArrow))
	//	{
	//		transform.Translate(0.0f, -move, 0.0f);
	//	}

	//	if (Input.GetKey(KeyCode.LeftArrow))
	//	{
	//		transform.Translate(-move, 0.0f, 0.0f);
	//	}

	//	if (Input.GetKey(KeyCode.RightArrow))
	//	{
	//		transform.Translate(move, 0.0f, 0.0f);
	//	}

	//	if (Input.GetKeyDown(KeyCode.Space))
	//	{
	//		Instantiate(bulletPrefab, transform.position, Quaternion.identity);
	//	}

	//	// Boostチェック
	//	if (!isBoost)
	//	{
	//		// Boost発動
	//		if (Input.GetKeyDown(KeyCode.Return))
	//		{
	//			isBoost = true;
	//			boostTimer = 0.0f;
	//			engineFireObj.GetComponent<Renderer>().enabled = true;
	//		}
	//	}
	//	else
	//	{
	//		// 時間加算
	//		boostTimer += Time.deltaTime;

	//		// 時間のチェック
	//		if (boostTimer >= 5.0f ||
	//			Input.GetKeyDown(KeyCode.Return))
	//		{
	//			// ブースト終了
	//			isBoost = false;
	//			engineFireObj.GetComponent<Renderer>().enabled = false;
	//		}
	//	}
	//}

	void Update()
	{
		float speed = 1.0f;
		float move = speed * Time.deltaTime;
		float move_x = 0.0f;
		float move_y = 0.0f;

		if (isBoost == true)
		{
			move *= 2.0f;
		}

		if (Input.GetKey(KeyCode.UpArrow))//上に進む
		{
			move_y = 1.0f;
		}

		if (Input.GetKey(KeyCode.DownArrow))//下に進む
        {
			move_y = -1.0f;
		}

		if (Input.GetKey(KeyCode.LeftArrow))//左に進む
        {
			move_x = -1.0f;
		}

		if (Input.GetKey(KeyCode.RightArrow))//右に進む
        {
			move_x = 1.0f;
		}

		// 平方根を求める関数 
		// Mathf.Sqrt(求めしたい値)
		// Mathf.Sart(10); // √10が返る

		float length = Mathf.Sqrt(move_x * move_x + move_y * move_y);

		// 0割り対策
		if (length > 0.0f)
		{
			move_x /= length;
			move_y /= length;

			move_x *= speed * Time.deltaTime;
			move_y *= speed * Time.deltaTime;

			transform.Translate(move_x, move_y, 0.0f);
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			/*
				目的：PlayerBulletControllerでdefeatedCounterを増やす
			  
				・PlayerBulletを生成したときにRobot情報(GameObject)を渡す 
				・PlayerBullet側でEnemyを倒したときにRobotの情報からRobotControllerを取得して倒した数を増やす

				・Robot側でもEnemyと当たったら倒した数を増やす
				・倒した数が3以上になったらTitleSceneに遷移する
			*/
			// Instantiateは複製した物の情報を教えてくれる
			GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
			bullet.GetComponent<PlayerBulletController>().robotObject = gameObject;
		}

		// Boost発動
		/*
			if (条件A && 条件B)
			{
				条件Aと条件Bが両方とも成立している場合に実行する
			}

			&& => And かつ 論理積

			if (条件A || 条件B)
			{
				条件Aか条件Bのどちらかが成立している場合に実行する
			}

			|| => Or または 論理和
		*/
		if (Input.GetKeyDown(KeyCode.Return) &&
			boostTimer == 0.0f)
		{
			engineFireObj.GetComponent<Renderer>().enabled = true;          // 時間加算
			boostTimer += Time.deltaTime;
		}
		else
		{
			// Boost中かチェック
			if (boostTimer > 0.0f)
			{
				boostTimer += Time.deltaTime;

				// 時間とボタンのチェック
				if (boostTimer >= boostTime ||
					Input.GetKeyDown(KeyCode.Return))
				{
					// ブースト終了
					boostTimer = 0.0f;
					engineFireObj.GetComponent<Renderer>().enabled = false;
				}
			}
		}
	}


	//Updateの次に実行されるメソッド
	void LateUpdate()
	{
		Vector3 position = transform.position;

		// 画面外に出ないように制限処理を書く

		float screen_width = Screen.width / 100.0f;//UnityでPlayerが動く座標１は100pxだから、横幅が1920pxであった場合、÷100して19.2に変換することでプレイヤーのを画面外まで行かなくすることができる
		float screen_height = Screen.height / 100.0f;
		float half_screen_width = screen_width / 2.0f;
		float half_screen_height = screen_height / 2.0f;

		if (position.x > half_screen_width)
		{
			position.x = half_screen_width;
		}
		else if (position.x < -half_screen_width)
		{
			position.x = -half_screen_width;
		}

		if (position.y > half_screen_height)
		{
			position.y = half_screen_height;
		}
		else if (position.y < -half_screen_height)
		{
			position.y = -half_screen_height;
		}

		transform.position = position;
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Enemy")
		{
			// ++：インクリメント
			// 　変数を1増やす
			// --：デクリメント
			// 　変数を1減らす

			//	life++;	// life += 1と同じ
			life--; // life -= 1　と同じ
			if (life <= 0)
			{
				//Destroy(gameObject);
				Instantiate(effectPrefab, transform.position, Quaternion.identity);
				// SceneManager.LoadScene("TitleScene");

				GameObject scene_manager = GameObject.Find("GameSceneManager");

				if (scene_manager != null)
				{
					// OnTriggerやOnCollision内でSceneを切り替えない方が良い
					scene_manager.GetComponent<GameSceneController>().FailedGame();
				}

			}
		}
	}
}
