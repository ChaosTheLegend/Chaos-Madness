using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public GameObject inv;
    bool open = false;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("tab"))
        {
            open = !open;
        }
        //inv.GetComponent<Animator>().SetBool("open",open);
        




	}
}
