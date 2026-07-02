using UnityEngine;

public class EffectController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 1.0f);//1秒たったら削除
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
