using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StartRoomRandomiser : MonoBehaviour {

    int dir;
    int exitpos;
    public GameObject exit;
    public Tilemap t;
    public TilemapCollider2D col;
    public Tile[] Tiles;
    public Transform playerpos;
    private void Awake()
    {
        dir = Random.Range(0,3);
        if (dir == 0)
        {
            exitpos = Random.Range(-5, 5);
            for (int i = 0; i < 5; i++)
            {
                if (t.GetTile(new Vector3Int(exitpos - 2 + i, 4, 0)).name == "dirt0")
                {
                    t.SetTile(new Vector3Int(exitpos - 2 + i, 4, 0), Tiles[0]);
                }
                if (t.GetTile(new Vector3Int(exitpos - 2 + i, 4, 0)).name == "dirt2")
                {
                    t.SetTile(new Vector3Int(exitpos - 2 + i, 4, 0), Tiles[1]);
                }
                if (t.GetTile(new Vector3Int(exitpos - 2 + i, 4, 0)).name == "dirt1")
                {
                    if (i == 0)
                    {
                        t.SetTile(new Vector3Int(exitpos - 2 + i, 4, 0), Tiles[2]);
                    }
                    else if (i == 4)
                    {
                        t.SetTile(new Vector3Int(exitpos - 2 + i, 4, 0), Tiles[3]);
                    }
                    else
                    {
                        t.SetTile(new Vector3Int(exitpos - 2 + i, 4, 0), null);
                    }
                }
            }
            GetComponent<room>().end =  Instantiate(exit, new Vector3(exitpos + 0.5f, 5.5f, 0), transform.rotation).transform;
            //col.enabled = true;
        }
        if (dir == 1)
        {
            exitpos = Random.Range(-4, 3);
            for (int i = 0; i < 5; i++)
            {
                if (t.GetTile(new Vector3Int(-7, exitpos - 2 + i, 0)).name == "dirt6")
                {
                    t.SetTile(new Vector3Int(-7, exitpos - 2 + i, 0), Tiles[4]);
                }
                if (t.GetTile(new Vector3Int(-7, exitpos - 2 + i, 0)).name == "dirt0")
                {
                    t.SetTile(new Vector3Int(-7, exitpos - 2 + i, 0), Tiles[5]);
                }
                if (t.GetTile(new Vector3Int(-7, exitpos - 2 + i, 0)).name == "dirt3")
                {
                    if (i == 0)
                    {
                        t.SetTile(new Vector3Int(-7, exitpos - 2 + i, 0), Tiles[6]);
                    }
                    else if (i == 4)
                    {
                        t.SetTile(new Vector3Int(-7, exitpos - 2 + i, 0), Tiles[2]);
                    }
                    else
                    {
                        t.SetTile(new Vector3Int(-7, exitpos - 2 + i,0), null);
                    }
                }
            }
            GetComponent<room>().end = Instantiate(exit, new Vector3(-7.5f, exitpos + 0.5f, 0), transform.rotation).transform;
            //col.enabled = true;
        }
        if (dir == 2)
        {
            exitpos = Random.Range(-4, 3);
            for (int i = 0; i < 5; i++)
            {
                if (t.GetTile(new Vector3Int(6, exitpos - 2 + i, 0)).name == "dirt8")
                {
                    t.SetTile(new Vector3Int(6, exitpos - 2 + i, 0), Tiles[4]);
                }
                if (t.GetTile(new Vector3Int(6, exitpos - 2 + i, 0)).name == "dirt2")
                {
                    t.SetTile(new Vector3Int(6, exitpos - 2 + i, 0), Tiles[5]);
                }
                if (t.GetTile(new Vector3Int(6, exitpos - 2 + i, 0)).name == "dirt5")
                {
                    if (i == 0)
                    {
                        t.SetTile(new Vector3Int(6, exitpos - 2 + i, 0), Tiles[7]);
                    }
                    else if (i == 4)
                    {
                        t.SetTile(new Vector3Int(6, exitpos - 2 + i, 0), Tiles[3]);
                    }
                    else
                    {
                        t.SetTile(new Vector3Int(6, exitpos - 2 + i, 0), null);
                    }
                }
            }
            GetComponent<room>().end = Instantiate(exit, new Vector3(7.5f, exitpos + 0.5f, 0), transform.rotation).transform;
            //col.enabled = true;
        }
        col.enabled = true;
        
        GetComponent<room>().exitdir = dir;
    }
    // Use this for initialization
    void Start () { 
        

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
