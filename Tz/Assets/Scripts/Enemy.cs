using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float visionRange = 12f;
    public float speed = 0.5f;
    public float attackRange = 1.6f;
    public GameObject Item;
    public GameObject Player;
    private Animator animator;
    private bool faceright = true;
    public HealthBar healthBar;

    void Start()
    {
        animator = GetComponent<Animator>();
        Player=FindObjectOfType<Player>().gameObject;
    }

    void Update()
    {

        if (Vector3.Distance(transform.position, Player.transform.position) < attackRange)
        {
            animator.Play("Attack");
        }
        if (Vector3.Distance(transform.position, Player.transform.position) < visionRange&& Vector3.Distance(transform.position, Player.transform.position)>attackRange)
        {

            animator.Play("Run");
            transform.position =Vector3.MoveTowards(transform.position,Player.transform.position, speed*Time.deltaTime);
        }
        if(Vector3.Distance(transform.position, Player.transform.position) > visionRange)
        {
            animator.Play("Idle");
        }
        if (healthBar.current <=0)
        {
            Death();
        }
        CheckFasing();
    }
    void CheckFasing()
    {
        float angle;
        Vector3 direction = Player.transform.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (angle > -90 && angle < 90) faceright = true;
        else faceright = false;
        if(faceright&&transform.localScale.x<0||!faceright&&transform.localScale.x>0)
        {
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
        }
        healthBar.AdjustCurrentValue(0);
    }
    private void Death()
    {
        Instantiate(Item,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            healthBar.AdjustCurrentValue(-10);
        }
    }
}
