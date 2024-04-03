using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Canvas _canvas;

    public GameObject player;

    private Items items;

    public Transform inventorySlots;

    public Slot[] slots;



    void Start()
    {
        items = player.GetComponent<Items>();
        slots = inventorySlots.GetComponentsInChildren<Slot>(); 
        canvas.enabled = false;
    }

    public void OpenInventory()
    {
        UpdateUI();
        _canvas.enabled = false;
        canvas.enabled = true;
    }
    public void CloseInventory()
    {
        _canvas.enabled = true;
        canvas.enabled=false;
    }
    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++) 
        {
            bool active = false;
            if (items.hasItems[i]) 
            {
                active = true;
            }
            if(i<items.sprites.Count)
            slots[i].UpdateSlot(active, items.sprites[i], items.items[i]);
        }
    }
}
