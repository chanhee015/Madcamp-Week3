using System.Collections.Generic;
using UnityEngine;

public class MyInventory : MonoBehaviour
{
    [SerializeField] List<Items> items;
    [SerializeField] Transform itemsParent;
    [SerializeField] ItemSlot[] itemSlots;
    
}
