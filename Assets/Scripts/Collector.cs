using System;
using UnityEngine;

public class Collector : MonoBehaviour
{
    
    private int collectedBoxesCount = 0;

    [SerializeField] private UIManager uIManager;
    
    void Start()
    {
        
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Box box))
        {
            Destroy(box.gameObject);
            collectedBoxesCount++;
            Conveyor.SubstractCollectibleBoxCount();
            
            uIManager.SetCollectedBoxesCount(collectedBoxesCount);
            uIManager.SetCollectibleBoxesCount(Conveyor.collectibleBoxCount);
            
        }
    }
}
