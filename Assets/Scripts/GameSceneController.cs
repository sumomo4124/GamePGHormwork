using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour
{
    public GameObject gameStartPrefab = null;
	public GameObject gameOverPrefab = null;
	public GameObject gameClearPrefab = null;

	// 開始演出の時間
	//      GameStartの文字は演出時間の間表示する
	//      敵の生成は演出時間の間行わない
	public float startDirectionTime = 5.0f;
	bool isFinished = false;
    float timer = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // プレハブだけ指定すると座標などはプレハブの情報がそのまま使われる
        Instantiate(gameStartPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        //クリアか失敗したら5秒後にTitleSceneに移動
        if (isFinished == true)
        {
            timer += Time.deltaTime;
            if (timer >= 5.0f)
            {
				SceneManager.LoadScene("TitleScene");
			}
		}
    }

    public void ClearedGame()
    {
        Debug.Log("クリアしたはず");
        isFinished = true;

		Instantiate(gameClearPrefab);
	}

	public void FailedGame()
    {
		Debug.Log("失敗したはず");
		isFinished = true;

        Instantiate(gameOverPrefab);
	}

}
