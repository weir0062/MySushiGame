using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiSpawner : MonoBehaviour
{
    private float m_time;
    public float SushiSpawnTime = 2.5f;
    public float speed = 1;
    public GameObject sushi;
    bool Isleft = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 movementposion = Vector3.left * -speed;
        if (transform.position.x <= -2)
        {
            Isleft = false;

        }
        if (transform.position.x >= 2)
        {
            Isleft = true;
        }
        if (Isleft == false)
        {
             movementposion.x = speed;
        }
        
        if (Isleft == true)
        {
             movementposion.x = -speed;
        }
        transform.Translate(movementposion * Time.deltaTime, Space.World);
        m_time += Time.deltaTime;
        if (m_time >= SushiSpawnTime)
        {
            Instantiate(sushi, transform.position, Quaternion.Euler(90,0,0), null);
            m_time = 0;
        }
    }
}
