using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryControll : MonoBehaviour {

    public Items[] slot;
    public int[] amount;
    public Image[] slotimg;
    public Text[] numb;
    Items Selected;
    int SelectedAM;
    public Image mouseCell;
    Vector2 mousepos = Vector2.zero;
    // Use this for initialization
    void Start () {
        slot = new Items[25];
        amount = new int[25];
        numb = new Text[25];
        for (int i = 0; i < 5; i++)
        {
            slotimg[i] = transform.GetChild(0).GetChild(i).GetComponent<Image>();
            numb[i] = slotimg[i].transform.GetChild(0).GetComponent<Text>();
        }
        for (int i = 5; i < 25; i++)
        {
            slotimg[i] = transform.GetChild(1).GetChild(i-5).GetComponent<Image>();
            numb[i] = slotimg[i].transform.GetChild(0).GetComponent<Text>();
        }
    }

	// Update is called once per frame
	void Update ()
    {
        mousepos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        for (int i = 0; i < 25; i++)
        {
            if (slot[i] != null)
            {
                slotimg[i].sprite = slot[i].vis;
                if (amount[i] > 1)
                {
                    numb[i].text = amount[i] + "";
                }
                else
                {
                    numb[i].text = "";
                }
            }
            else
            {
                slotimg[i].sprite = null;
                numb[i].text = "";
            }
        }
        for (int i = 0; i < 25; i++)
        {
            if (mousepos.x >= slotimg[i].GetComponent<RectTransform>().position.x - slotimg[i].GetComponent<RectTransform>().sizeDelta.x / 2 && mousepos.x <= slotimg[i].GetComponent<RectTransform>().position.x + slotimg[i].GetComponent<RectTransform>().sizeDelta.x/2)
            {
                if (mousepos.y >= slotimg[i].GetComponent<RectTransform>().position.y - slotimg[i].GetComponent<RectTransform>().sizeDelta.y / 2 && mousepos.y <= slotimg[i].GetComponent<RectTransform>().position.y + slotimg[i].GetComponent<RectTransform>().sizeDelta.y / 2)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (slot[i] != null && Selected == null)
                        {
                            Selected = slot[i];
                            SelectedAM = amount[i];
                            slot[i] = null;
                            amount[i] = 0;
                        }
                        else if (slot[i] == null && Selected != null)
                        {
                            slot[i] = Selected;
                            amount[i] = SelectedAM;
                            Selected = null;
                            SelectedAM = 0;
                        }
                        else if (Selected != null && slot[i] == Selected)
                        {
                            Stack(i);
                        }
                    }
                }
            }
        }
        if (Selected != null)
        {
            mouseCell.transform.gameObject.SetActive(true);
            mouseCell.GetComponent<RectTransform>().position = mousepos;
            mouseCell.sprite = Selected.vis;
            if (SelectedAM > 1)
            {
                mouseCell.transform.GetChild(0).GetComponent<Text>().text = SelectedAM + "";
            }
            else
            {
                mouseCell.transform.GetChild(0).GetComponent<Text>().text = "";
            }
        }
        else
        {
            mouseCell.transform.gameObject.SetActive(false);
        }
    }

    void Stack(int slotid)
    {
        if (amount[slotid] + SelectedAM > Selected.stack)
        {
            SelectedAM = amount[slotid] + SelectedAM - Selected.stack;
            amount[slotid] = Selected.stack;
        }
        else
        {
            amount[slotid] += SelectedAM;
            SelectedAM = 0;
            Selected = null;
        }
    }
}
