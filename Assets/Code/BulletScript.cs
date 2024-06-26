using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public ExpBar expBar;
    public float totalTimeAlive;
    public float timeAlive;

    private Player playerStats;
    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerStats = player.GetComponent<Player>();

        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        expBar = FindObjectOfType<ExpBar>();

        StartCoroutine(delete());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
                float damageAmount = playerStats.damage;

                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damageAmount);
                }

                if (expBar != null && enemyHealth.currentHealth <= 0)
                {
                    playerHealth.heal();
                    expBar.AddExp(enemy.expValue);
                }
            }
            Destroy(gameObject);
        }
    }

    private IEnumerator delete()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
