using UnityEngine;

public class GameOverController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 5.0f);//5秒後に削除
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
