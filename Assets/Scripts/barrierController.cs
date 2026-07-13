using UnityEngine;

public class barrierController : MonoBehaviour
{

    public GameObject GetItemPrefab=null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //当たったtagがPlayerならEnemy01を削除
        if (collision.tag == "Player")
        {
            Instantiate(GetItemPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
