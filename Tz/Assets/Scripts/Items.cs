using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public sealed class Items : MonoBehaviour
{
    public static Items Instance;
    public List<string> items_name = new List<string>(21) {" "};
    public List<int> items = new List<int>(21) { 0 };
    public List<bool> hasItems = new List<bool>(21) { false };
    bool hasAdd = false;
    int index = 0;
    public List<Sprite> sprites=new List<Sprite>(21);
    private void Start()
    {
        Instance = this;
    }
    public List<string> GetInventoryDataNames()
    {
        return items_name;
    }
    public List<int> GetInventoryDataCount()
    {
        return items;
    }
    public List<bool> GetInventoryDataBool()
    {
        return hasItems;
    }
    public List<Sprite> GetInventoryDataImage()
    {
        return sprites;
    }

    public void SetupNames(List<string> s)
    {
        items_name = s;

    }
    public void SetupCount(List<int> count)
    {
        items = count;
    }
    public void SetupBool(List<bool> bools)
    {
        hasItems = bools;
    }
    public void SetupImages(List<Sprite> images)
    {
        sprites = images;
    }
    public void AddItem(int count, Sprite sprite,string name)
    {
        for(int i=0;i<items_name.Count;i++)
        {
            if (name == items_name[i])
            {
                items[i] += count;
                hasAdd = true;
                break;
            }
        }
        if (!hasAdd)
        {
            items_name[index] = name;
            items[index] = count;
            hasItems[index] = true;
            sprites[index] = sprite;
            index++;
        }
        hasAdd = false;
    }
    public void RemoveItem(int index)
    {
        items_name.RemoveAt(index);
        items.RemoveAt(index);
        hasItems.RemoveAt(index);
        sprites.RemoveAt(index);
        items_name.Add("");
        items.Add(0);
        hasItems.Add(false);
        sprites.Add(null);
    }
}
