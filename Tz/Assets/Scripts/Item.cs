using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string name;
    public SpriteRenderer spriteRenderer;
    int count;
    private void Start()
    {
        name = gameObject.name;
        count = Random.Range(1, 10);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.transform.tag == "Player")
        {
            obj.GetComponent<Items>().AddItem(count,spriteRenderer.sprite,name);
            Destroy(gameObject); 
        }
    }
}
