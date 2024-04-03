using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public sealed  class InventorySaveLoader :  ISaveLoader
{
    public class SerializeTexture
    {
        [SerializeField]
        public string name;
        [SerializeField]
        public int x;
        [SerializeField]
        public int y;
        [SerializeField]
        public byte[] bytes;
    }
    public struct InventoryData
    {
        public InventoryData(bool Zero){
            items_name = new List<string>();
            items=new List<int> ();
            hasItems=new List<bool> ();
            sprites = new List<SerializeTexture>();
        }
        public List<string> items_name;
        public List<int> items;
        public List<bool> hasItems;
        public List<SerializeTexture> sprites;
        public void SerializeTest(Sprite mySprite)
        {
            SerializeTexture exportObj = new SerializeTexture();
            Texture2D tex = mySprite.texture;
            exportObj.x = tex.width;
            exportObj.y = tex.height;
            exportObj.bytes = ImageConversion.EncodeToPNG(tex);
            exportObj.name = mySprite.name;
            sprites.Add(exportObj);
            
        }
        public Sprite DeSerializeTest(int index)
        {
            Texture2D tex = new Texture2D(sprites[index].x, sprites[index].y);
            ImageConversion.LoadImage(tex, sprites[index].bytes);
            Sprite mySprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), Vector2.one);
            mySprite.name = sprites[index].name;
            return mySprite;
        }
    }
    public InventoryData data=new InventoryData(true);

    void ISaveLoader.LoadData()
    {
        data = Repository.GetData<InventoryData>();
        Items.Instance.SetupNames(data.items_name);
        Items.Instance.SetupCount(data.items);
        List<Sprite> sprites = new List<Sprite>();
        for(int i = 0; i < data.sprites.Count; i++)
        {
            sprites.Add(data.DeSerializeTest(i));
        }
        Items.Instance.SetupImages(sprites);
        Items.Instance.SetupBool(data.hasItems);
    }


    void ISaveLoader.SaveData()
    {
        data.items_name = Items.Instance.GetInventoryDataNames();
        data.items=Items.Instance.GetInventoryDataCount();
        List<Sprite> s = new List<Sprite>();
        s=Items.Instance.GetInventoryDataImage();
        foreach (Sprite sprite in s)
        {
            if(sprite!=null)
            data.SerializeTest(sprite);
        }
        data.hasItems = Items.Instance.GetInventoryDataBool();
        Repository.SetData(data);
    }


}
