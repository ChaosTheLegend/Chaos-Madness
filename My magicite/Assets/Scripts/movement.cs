using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    Rigidbody2D rb;
    public float Speed;
    public float JumpHight;
    public int jumps;
    int totaljumps;
    bool grd;
    public float dash;
    int move;

    Renderer renderer;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        totaljumps = 0;
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CollisionLeft())
        {
            rb.velocity = new Vector2(Mathf.Clamp(Input.GetAxis("Horizontal"),0,10) * Speed, rb.velocity.y);
        }
        if (CollisionRight())
        {
            rb.velocity = new Vector2(Mathf.Clamp(Input.GetAxis("Horizontal"),-10,0) * Speed, rb.velocity.y);
        }
        if (!CollisionRight() && !CollisionLeft())
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, rb.velocity.y);
        }

        grd = CollisionBottom();
        if (grd)
        {
            totaljumps = jumps;
        }
        if (Input.GetKeyDown("space"))
        {
            if (grd)
            {
                rb.velocity += new Vector2(0, JumpHight);
            }
            else if (totaljumps > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpHight);
                totaljumps--;
            }
        }
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
    public bool CollisionRight()
    {
        float raylengh = 0.05f;
        float gap = 0.001f;

        Vector2 linestart = new Vector2(transform.position.x + renderer.bounds.extents.x + gap + raylengh, transform.position.y + renderer.bounds.extents.y);
        Vector2 search = new Vector2(linestart.x, transform.position.y - renderer.bounds.extents.y);
        RaycastHit2D hit = Physics2D.Linecast(linestart, search);

        Debug.DrawLine(linestart, search, Color.red);
        
        return hit;
    }
    public bool CollisionLeft()
    {
        float raylengh = 0.05f;
        float gap = 0.001f;

        Vector2 linestart = new Vector2(transform.position.x - renderer.bounds.extents.x - gap - raylengh, transform.position.y + renderer.bounds.extents.y);
        Vector2 search = new Vector2(linestart.x, transform.position.y - renderer.bounds.extents.y);
        RaycastHit2D hit = Physics2D.Linecast(linestart, search);

        Debug.DrawLine(linestart, search, Color.red);

        return hit;
    }
}
