using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    [Header("Rooms")]
    public GameObject[] upenter;
    public GameObject[] downenter;
    public GameObject[] leftenter;
    public GameObject[] rightenter;
    public GameObject end;
    public GameObject start;

    [Header("Generation properties")]
    public int size;
    public float precision;

    [Header("Loading Screen")]
    public Text progress;
    public Slider progressbar;
    public GameObject loadpan;

    int _total;
    int _dir;

    List<GameObject> _rooms;
    List<Bounds> _roombounds;
    GameObject _prev;


    void Start()
    {
        _rooms = new List<GameObject>();
        _roombounds = new List<Bounds>();
        //InvokeRepeating( "Generate", 0.2f, 0.2f );
        StartCoroutine(Generate());
    }


    IEnumerator Generate()
    {
        do
        {
            yield return new WaitForSeconds(0.2f);
            GenerateOneRoom();
        } while (_total != size);
    }


    void GenerateOneRoom()
    {
        if (_total == 0)
        {
            GenerateFirstRoom();
            return;
        }

        List<GameObject> prefabs = GetPrefabs(_dir);

        GameObject newroom = Instantiate(prefabs[Random.Range(0, prefabs.Count)], Vector3.zero, transform.rotation);
        Vector3 spawnpos = _prev.GetComponent<room>().end.position - newroom.GetComponent<room>().dis;
        newroom.transform.position = spawnpos;
        var ccollider = newroom.GetComponent<CompositeCollider2D>();
        var newbounds = ccollider.bounds;
        newbounds.Expand(-precision);
        newbounds.center = ccollider.bounds.center;
        var intersects = false;
        foreach (var bounds in _roombounds)
        {
            if (bounds.Intersects(newbounds))
                intersects = true;
        }
        if (intersects)
        {
            print("Intersection detected!");
            Destroy(newroom);
            return;
        }
        _rooms.Add(newroom);
        _roombounds.Add(newbounds);
        _prev = newroom;
        _dir = newroom.GetComponent<room>().exitdir;
        _total++;
    }


    void GenerateFirstRoom()
    {
        GameObject room = Instantiate(start, Vector3.zero, transform.rotation);
        _rooms.Add(room);
        var ccollider = room.GetComponent<CompositeCollider2D>();
        var bounds = ccollider.bounds;
        bounds.Expand(-precision);
        bounds.center = ccollider.bounds.center;
        _roombounds.Add(bounds);
        _dir = room.GetComponent<room>().exitdir;
        _prev = room;
        _total++;
    }


    List<GameObject> GetPrefabs(int dir)
    {
        switch (dir)
        {
            case 0:
                return downenter.ToList();

            case 1:
                return rightenter.ToList();

            case 2:
                return leftenter.ToList();

            case 3:
                return upenter.ToList();

            default:
                return new List<GameObject>();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        foreach (Bounds bound in _roombounds)
        {
            Gizmos.DrawWireCube(bound.center,bound.size);
        }
    }
}