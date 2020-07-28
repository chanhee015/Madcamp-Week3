using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DevCraftingSystem : MonoBehaviour
{
    /* Check if the game is crafting */
    public bool IsCrafting;


    public static bool IsChanging = false;
    public string CurrentCraftID1;
    public string CurrentCraftID2;
    public int currentID;

    /* List of Input Items*/
    public List<Item> items = new List<Item>();
    /* List of Craftable Items */
    public List<CraftableItem> CraftableItems = new List<CraftableItem>();
    /* List of Input Fields for Elements */
    public List<InputField> Craftslots = new List<InputField>();
    /* List of Images shown in the slots */
    public List<Image> CraftslotsIMG = new List<Image>();
    /* Run Button */
    public Button Run_button;
    /* ID for input in GetItemID() */
    public string ID = "";
    /* Result Image after crafting */
    public Image Result;
    public Sprite EmptySlot;
    public Image CraftedElements;

    public Text description;

    public List<Image> CraftedImages = new List<Image>();

    /* Counter for carafted image slots */
    public int cnt = 0;

    /* Set onClick Listener for Run_button */
    void TaskOnClick()
    {
        GetItemID(ID);
    }

    /* on Start */
    void Start () 
    {   
        //DontDestroyOnLoad (this.gameObject);
		Run_button.onClick.AddListener(TaskOnClick);
	}


    // Update is called once per frame
    void Update()
    {
        if(IsCrafting)
        {
            ID = GetCraftID();
        }
        else
        {
            GetItemID("EE");
        }
    }

    public string GetCraftID()
    {
        CurrentCraftID1 = "";
        CurrentCraftID2 = "";

        /* Craft Slot 1 */
        if(Craftslots[0].text != "")
        {   
            for (int j = 0 ; j < items.Count ; j++)
            {
                if(items[j].name == Craftslots[0].text)
                {
                    CurrentCraftID1 += items[j].itemID;
                }
            }
            CraftslotsIMG[0].sprite = items[int.Parse(CurrentCraftID1)].img;
        }
        else
        {
            CurrentCraftID1 += "E";
            CraftslotsIMG[0].sprite = EmptySlot;

        }

        /* Craft Slot 2 */
        if(Craftslots[1].text != "")
        {   
            for (int j = 0 ; j < items.Count ; j++)
            {
                if(items[j].name == Craftslots[1].text)
                {
                    CurrentCraftID2 += items[j].itemID;
                }
            }
            CraftslotsIMG[1].sprite = items[int.Parse(CurrentCraftID2)].img;
        }
        else
        {
            CurrentCraftID2 += "E";
            CraftslotsIMG[1].sprite = EmptySlot;

        }
        
        return CurrentCraftID1 + CurrentCraftID2;
    }

    public void GetItemID(string CraftID)
    {
        for(int i = 0; i < CraftableItems.Count; i++){
            if(CraftableItems[i].CraftID == CraftID || CraftableItems[i].rev_CraftID == CraftID )
            {
                currentID = CraftableItems[i].itemID;
                i = CraftableItems.Count;
                Result.sprite = items[currentID].img;
                CraftedElements.sprite = items[currentID].img;
                CraftedImages[cnt].sprite = items[currentID].img;
                description.text = items[currentID].description;
                cnt++;
                IsChanging = true;
            }
            else
            {
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
    public string itemID;
    public Sprite img;
    public string description;
}

[System.Serializable]
public class CraftableItem
{
    public string name;
    public int itemID;
    public string CraftID;
    public string rev_CraftID;
}
