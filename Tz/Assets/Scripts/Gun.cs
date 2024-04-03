using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Gun : MonoBehaviour
{
    private int CurrenAmmo;
    private int MaxAmmo;
    private float FireRate=0.1f;
    private string AmmoType= "5.45x39";
    private int Damage;
    private bool canShoot=false;
    public GameObject bullet;
    public GameObject spawn;
    private float angle;
    private bool isfasing;
    private bool pressed=false;
    private float lastShotTime;
    public Items items;
    private void Update()
    {
        if (pressed)
        {
            if (Time.time > (lastShotTime + FireRate))
            {
                Shoot();
                lastShotTime = Time.time;
            }

        }
    }
    public void Aim(Vector3 point,bool fasing)
    {
        canShoot = true;
        isfasing = fasing;
        point.y += 2f;
        Vector3 direction = point - transform.position;
        angle = Mathf.Atan2(direction.y , direction.x) * Mathf.Rad2Deg;
        if ((angle > -60 && angle < 60 && fasing) || ((angle > 120 || angle < -120) && !fasing)) transform.rotation = Quaternion.Euler(0, 0, angle);
        else ResetAim(fasing);
    }
    public void ResetAim(bool fasing)
    {
        canShoot=false;
        transform.rotation = Quaternion.Euler(0, 0, fasing?0:180);
    }
    public void OnDown()
    {
        pressed = true;
    }
    public void OnUp()
    {
        pressed=false;
    }
    public void Shoot()
    {
        if (canShoot)
        {
            int ammoIndex=-1;
            foreach(string s in items.items_name)
            {
                if (s == AmmoType)
                {
                    ammoIndex=items.items_name.IndexOf(s);
                }
            }
            if (ammoIndex != -1)
            {
                if (items.items[ammoIndex] != 0)
                {
                    GameObject temp = Instantiate(bullet, spawn.transform.position, Quaternion.identity);
                    Bullet b = temp.GetComponent<Bullet>();
                    b.setAngle(angle + (!isfasing ? -90 : 270));
                    items.items[ammoIndex] -= 1;
                    
                }
                   if(items.items[ammoIndex] == 0) items.RemoveItem(ammoIndex);
                }
        }
    }

}
