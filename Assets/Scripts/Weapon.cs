
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public GameObject fireEff;
    public Transform firePoint;

    EnemyController enemyTarget;

    AudioManager audioManager;

    public float bulletForce;
    public float speedShot;

    private float currentSpeedShot;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Update()
    {

        RotateGun();
        currentSpeedShot -= Time.deltaTime;
        if (enemyTarget != null && currentSpeedShot < 0)
        {
            currentSpeedShot = speedShot;

            audioManager.PlaySFX(audioManager.shoting);

            GameObject bulletTmp = Instantiate(bullet, firePoint.position, UnityEngine.Quaternion.identity);
            Instantiate(fireEff, firePoint.position, this.transform.rotation);

            Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
        }
    }
    void RotateGun()
    {
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = enemyTarget.transform.position;//mousePos - transform.position;

        float angel = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angel);
        transform.rotation = rotation;

        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            transform.localScale = new Vector3(1, -1, 0);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
    }
    public void SetTarget(EnemyController enemyTarget)
    {
        this.enemyTarget = enemyTarget;
    }
}
