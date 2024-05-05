using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float m_speed;

    void Start()
    {
        
    }

    void Update()
    {
        float dx = Input.GetAxisRaw("Horizontal");
        float dy = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(dx, dy) * m_speed * Time.deltaTime;
    }
}
