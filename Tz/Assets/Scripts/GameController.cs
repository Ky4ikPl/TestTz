using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Enemy;
    private void Start()
    {
        for (int i = 0; i < 3; i++) Instantiate(Enemy, new Vector3(Random.Range(-30, 30), Random.Range(-30, 30), 0f), Quaternion.identity);    
    }
}
