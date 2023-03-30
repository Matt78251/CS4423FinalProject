using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public GameObject point_a;
    public GameObject point_b;
    private Rigidbody2D rb;
    private Transform current_point;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        current_point = point_b.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 point = current_point.position - transform.position;
        if(Vector2.Distance(transform.position, current_point.position) < 0.5f && current_point == point_b.transform)
        {
            current_point = point_a.transform;
        }

        if(Vector2.Distance(transform.position, current_point.position) < 0.5f && current_point == point_a.transform)
        {
            current_point = point_b.transform;
        }


        if(current_point == point_b.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);

        }
        
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(point_a.transform.position, 0.5f);
        Gizmos.DrawWireSphere(point_b.transform.position, 0.5f);
        Gizmos.DrawLine(point_a.transform.position, point_b.transform.position);
    } */
}
