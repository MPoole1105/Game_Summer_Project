using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrid : GridBased
{
    [SerializeField] LayerMask m_collisionLayerMask;

    public override void Start()
    {
        base.Start();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            TryMovePosition(0, 1);
        if (Input.GetKeyDown(KeyCode.A))
            TryMovePosition(-1, 0);
        if (Input.GetKeyDown(KeyCode.S))
            TryMovePosition(0, -1);
        if (Input.GetKeyDown(KeyCode.D))
            TryMovePosition(1, 0);
    }

    void TryMovePosition(int dx, int dy)
    {
        Vector2 newPos = new Vector3(dx, dy) + transform.position;

        RaycastHit2D hit = Physics2D.Raycast(newPos, Vector3.forward, 1, m_collisionLayerMask);
        if (hit.collider == null)
            transform.position = newPos;
    }
}
