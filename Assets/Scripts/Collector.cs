using System;
using UnityEngine;

public class Collector : MonoBehaviour
{
    
    private int collectedBoxesCount = 0;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Box box))
        {
            Destroy(box.gameObject);
            collectedBoxesCount++;
        }
    }
}
