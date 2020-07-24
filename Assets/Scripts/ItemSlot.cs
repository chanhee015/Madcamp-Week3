using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Image Image;
    private Items _item;
    public Items Items{
        get {return _item; }
        set{
            _item = value;

            if(_item == null){
                Image.enabled = false;
            } else {
                Image.sprite = _item.Icon;
                Image.enabled = true;
            }
        }
    }

}