using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBulletController : MonoBehaviour
{
    public GameObject robotObject = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 9.0f;

        transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);

        // Renderer => 描画関連の機能を持つコンポーネント
        Renderer renderer = GetComponent<Renderer>();

        if (renderer.isVisible == false)
        {
            Destroy(gameObject);
        }
    }

	void OnTriggerEnter2D(Collider2D collision)
	{
	    if (collision.tag == "Enemy")
        {
            RobotController controller = robotObject.GetComponent<RobotController>();

            controller.defeatedCounter++;
            if (controller.defeatedCounter >= 3)
            {
				GameObject scene_manager = GameObject.Find("GameSceneManager");

				if (scene_manager != null)
				{
					//scene_manager.GetComponent<GameSceneController>().ClearedGame();
				}
				//SceneManager.LoadScene("TitleScene");
			}
			else
            {
				Destroy(gameObject);
			}
		}
        else if (collision.tag == "Boss")
        {
            Destroy(gameObject);
        }
	}
}
