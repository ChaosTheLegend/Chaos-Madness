using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyG : MonoBehaviour {

    public float speed;
    public float JumpHight;
    public float radius;
    GameObject player;
    Rigidbody2D rb;
    Renderer renderer;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 dis = player.transform.position - transform.position;
        if (dis.magnitude <= radius && new Vector2(dis.x, 0).magnitude >= 0.4f)
        {
            if (transform.position.x < player.transform.position.x)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            if (transform.position.x > player.transform.position.x)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    public bool CollisionBottom()
    {
        float raylengh = 0.1f;
        float gap = 0.001f;

        Vector2 linestart = new Vector2(transform.position.x - renderer.bounds.extents.x, transform.position.y - renderer.bounds.extents.y - gap - raylengh);
        Vector2 search = new Vector2(transform.position.x + renderer.bounds.extents.x, linestart.y);

        RaycastHit2D hit = Physics2D.Linecast(linestart, search);

        Debug.DrawLine(linestart, search, Color.red);
        return hit;
    }
}
