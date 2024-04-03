using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeleteTab : MonoBehaviour
{
    [SerializeField] private Player player;
    private Items items;
    public TextMeshProUGUI text;
    [SerializeField] private Canvas canvas;
    private int index;
    [SerializeField] private Inventory inv;
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        items =player.GetComponent<Items>();
        canvas.enabled = false;
    }
    public void openDeleteTab(int i)
    {
        index = i;
        if (items.hasItems[i])
        {
            text.text = "Вы хотите удалить " + items.items_name[index].ToString() + "?";
            canvas.enabled = true;
        }
        else
        {
            closeDeleteTab();
        }
    }
    public void closeDeleteTab()
    {
        index = 0;
        canvas.enabled=false;
    }
    public void deleteItem()
    {
        items.RemoveItem(index);
        inv.UpdateUI();
        closeDeleteTab();
    }
}
