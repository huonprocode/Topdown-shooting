using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] float healthEnemy = 10f;

    public GameObject pfDeadEff;
    public Transform _player;
    public SpriteRenderer enemySR;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            TakeDamage();
        }
    }
    void Start()
    {

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject == null)
        {
            playerObject = FindObjectOfType<GameObject>();
        }

        if (playerObject != null)
        {
            _player = playerObject.transform;
        }
    }

    void Update()
    {
        if (_player != null)
        {
            Vector2 dir = (_player.position - transform.position).normalized;
            Vector3 faceEnemy = dir * moveSpeed * Time.deltaTime;
            transform.Translate(faceEnemy);
            if (faceEnemy.x != 0)
            {
                if (faceEnemy.x < 0)
                {
                    enemySR.transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    enemySR.transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }

        OnDie(healthEnemy);
    }

    void OnDie(float health)
    {
        if (health == 0)
        {
            Destroy(this.gameObject);
            Instantiate(pfDeadEff, transform.position, Quaternion.identity);

            FindObjectOfType<Score>().AddScore();
        }
    }
    void TakeDamage()
    {

        healthEnemy--;
    }
}
