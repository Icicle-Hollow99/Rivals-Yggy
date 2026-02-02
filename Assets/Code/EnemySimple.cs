using UnityEngine;

public class EnemySimple : MonoBehaviour
{
    public float speed = 3f;
    public float health = 50f;
    public float damage = 10f;
    public float attackCooldown = 1f;

    Transform player;
    float lastAttackTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (!player) return;

        Vector3 dir = (player.position - transform.position).normalized;
        dir.y = 0;

        transform.position += dir * speed * Time.deltaTime;
        transform.LookAt(player);
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                lastAttackTime = Time.time;

                PlayerHealth hp = collision.gameObject.GetComponent<PlayerHealth>();
                if (hp)
                {
                    hp.TakeDamage(damage);
                }
            }
        }
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
            Destroy(gameObject);
    }
}
