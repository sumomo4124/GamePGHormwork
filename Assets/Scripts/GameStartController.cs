using UnityEngine;

public class GameStartController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //5ïbå„Ç…çÌèú
        GameObject scene_manager = GameObject.Find("GameSceneManager");

        Destroy(gameObject, scene_manager.GetComponent<GameSceneController>().startDirectionTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
