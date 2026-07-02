using UnityEngine;

public class Enemy02Controller : MonoBehaviour
{
	public GameObject effectPrefab = null;
	float timer = 0;

    void Start()
    {
        
    }

    void Update()
    {
        // ŽžŠÔŒv‘ª
        timer += Time.deltaTime;
        if (timer >= 2.0f)
        {
            timer = 0.0f;
        }

        // ˆÚ“®
        float speed_x = -1.0f;
        float speed_y = 1.0f;

        if (timer < 1.0f)
        {
            speed_y *= -1.0f;
        }

        float move_x = speed_x * Time.deltaTime;
        float move_y = speed_y * Time.deltaTime;

        transform.Translate(move_x, move_y, 0.0f);

        //‰æ–ÊŠO‚Ì‚ ‚éêŠ‚Ü‚Ås‚Á‚½‚çEnemy02‚ðíœ‚·‚é
        if (transform.position.x <= -10.0f)
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
        // &&
        // ||
        //“–‚½‚Á‚½tag‚ªPlayerBullet‚©Player‚È‚çEnemy02‚ðíœ
        if (collision.tag == "PlayerBullet" || collision.tag == "Player")
		{
			Instantiate(effectPrefab, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}

}
