using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBased : MonoBehaviour
{
    public virtual void Start()
    {
        transform.position = GridManager.Instance.FitToWorld(transform.position);
    }
}
