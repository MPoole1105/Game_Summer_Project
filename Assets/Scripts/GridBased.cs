using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBased : MonoBehaviour
{
    public virtual void Start()
    {
        Debug.Log(transform.position);
        transform.position = GridManager.Instance.FitToWorld(transform.position);
        Debug.Log(transform.position);
    }
}
