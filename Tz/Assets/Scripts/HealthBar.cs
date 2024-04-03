using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public int maxValue = 60;
    public bool isRight;
    public Canvas canvas;
    public GameObject Bar;
    public GameObject barsHendler;
    public int current;
    public List<GameObject> bars = new List<GameObject>();

    void Start()
    { 

        current = maxValue;

        UpdateUI();
    }


    void Update()
    {

        if (current < 0) current = 0;
        if (current > maxValue) current = maxValue;

    }

    void UpdateUI()
    {
        foreach (var bar in bars)
        {
            Destroy(bar);
        }
        bars.Clear();
        for (int i = 0; i < Mathf.Round(current / 10); i++)
        {
            bars.Add(Instantiate(Bar, barsHendler.transform.position, Quaternion.identity,barsHendler.transform));
            bars[i].transform.position = new Vector3(-0.7f +0.2f * bars.Count+ bars[i].transform.position.x, bars[i].transform.position.y, 0f);
        }
    }

    public void AdjustCurrentValue(int adjust)
    {
        UpdateUI();
        current += adjust;
    }
}
