using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyF : MonoBehaviour {

    public float speed;
    public float cooldown;
    public float movetime;
    public float radius;
    Rigidbody2D rb;
    GameObject player;
    float timer,timer2 = 0;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        timer = cooldown;
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        rb.velocity = Vector2.zero;
        if (timer2 <= 0)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            if (timer <= 0)
            {
                timer2 = movetime;
            }
        }
        if(timer <= 0)
        {
            if (timer2 > 0)
            {
                move();
                timer2 -= Time.deltaTime;
            }
            if (timer2 <= 0)
            {
                timer = cooldown;
            }
        }




	}
    void move()
    {
        Vector3 dis = player.transform.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(player.transform.position, dis.normalized, dis.magnitude);
        if (dis.magnitude <= radius && hit.collider.tag != "wall")
        {
            transform.Translate(dis.normalized * speed * 0.01f);
            Debug.DrawLine(player.transform.position, transform.position, Color.red);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
