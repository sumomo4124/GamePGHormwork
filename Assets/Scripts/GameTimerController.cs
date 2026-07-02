using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameTimerController : MonoBehaviour
{
    public GameObject enemyFactory = null;

    float timer = 10.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0.0f)
        {
            enemyFactory.GetComponent<EnemyFactoryController>().CreateBoss();//EnemyFactoryに紐づいているEnemyFactoryControllerのScriptにアクセスしその中のCreateBossを実行している

            //SceneManager.LoadScene("TitleScene");

            // GameObject.Find(探しているGameObjectの名前);
            // Hierarchy上にあるGameObjectから該当するGameObjectを探してくれる
            GameObject scene_manager = GameObject.Find("GameSceneManager");

            if (scene_manager != null)
            {
                //scene_manager.GetComponent<GameSceneController>().FailedGame();
            }
        }

        // Clamp(調整値, 下限値, 上限値)
        // 調整値が下限値から上限値までの間で調整される
        timer = Mathf.Clamp(timer, 0.0f, 60.0f);

		TextMeshProUGUI tmpro = GetComponent<TextMeshProUGUI>();
        // toString 変数情報を文字列にする
        // 文字列結合 => A + B
        tmpro.text = "Time:" + timer.ToString("f2");//カッコの中の"f2"は小数点第二位までを表示
	}
}
