using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevCraftingSystem : MonoBehaviour
{

    public bool IsCrafting;

    public string CurrentCraftID;
    public int currentID;

    public List<Item> items = new List<Item>();
    public List<CraftableItem> CraftableItems = new List<CraftableItem>();

    public List<InputField> Craftslots = new List<InputField>();
    public List<Image> CraftslotsIMG = new List<Image>();

    public Image Result;
    public Sprite EmptySlot;


    // Update is called once per frame
    void Update()
    {
        if(IsCrafting)
        {
            GetCraftID();
        }
    }

    public void GetCraftID()
    {
        CurrentCraftID = "";
        for(int i = 0 ; i < 2; i++)
        {
            if(Craftslots[i].text != "")
            {
                CurrentCraftID += Craftslots[i].text;
                CraftslotsIMG[i].sprite = items[int.Parse(Craftslots[i].text)].img;
            }
            else
            {
                CurrentCraftID += "E";
                CraftslotsIMG[i].sprite = EmptySlot;

            }
        }
        GetItemID(CurrentCraftID);
    }

    public void GetItemID(string CraftID)
    {
        for(int i = 0; i < CraftableItems.Count; i++){
            if(CraftableItems[i].CraftID == CraftID)
            {
                currentID = CraftableItems[i].itemID;
                i = CraftableItems.Count;
                Result.sprite = items[currentID].img;
            }
            else{
                currentID = -1;
                Result.sprite = EmptySlot;
            }
        }
    }

}

[System.Serializable]
public class Item
{
    public string name;
    public Sprite img;
}
[System.Serializable]

public class CraftableItem
{
    public string name;
    public int itemID;
    public string CraftID;
}