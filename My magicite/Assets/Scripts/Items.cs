using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Items : ScriptableObject {

    public new string name;
    public Sprite vis;
    public int stack;
}
