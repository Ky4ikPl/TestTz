using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public TextMeshProUGUI amount;
    public Image icon; 
    private void Start()
    {
        amount=GetComponentInChildren<TextMeshProUGUI>();
        amount.text = "";
        icon.enabled = false;
    }
    public void UpdateSlot(bool active,Sprite _sprite,int count) 
    {
        if (active)
        {
            amount.text=count==1?"":count.ToString();
            icon.enabled = true;
            icon.sprite = _sprite;
        }
        else
        {
            amount.text = "";
            icon.enabled = false;
            icon.sprite = null;
        }
    }
}
