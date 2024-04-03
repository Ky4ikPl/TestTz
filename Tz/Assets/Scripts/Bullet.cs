using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timeDestroy = 3f;
    public float speed = 10f;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
        Invoke("DestroyBullet", timeDestroy);
    }
    public void setAngle(float angle)
    {
        Debug.Log(angle);
        transform.rotation=Quaternion.Euler(0f,0f,angle);
    }
    void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            DestroyBullet();
    }
}
