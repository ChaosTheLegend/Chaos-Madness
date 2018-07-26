using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControll : MonoBehaviour {

    public int MaxHealth;
    public int Health;
    public float cooldown;
    float Timer;


    // Use this for initialization
	void Start () {
        Timer = 0;
        Health = MaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
	}
    private void OnCollisionStay2D(Collision2D other)
    {
        if (Timer <= 0 && other.transform.tag == "Enemy")
        {
            Health -= other.transform.GetComponent<EnemyBase>().dmg;
            Timer = cooldown;
        }
    } 
}
