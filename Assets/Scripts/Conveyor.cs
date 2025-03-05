using System.Collections;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    
    [SerializeField] private Box[] boxes;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnTime;
    [SerializeField] private float forceFactor = 2;
    
    [SerializeField] private UIManager uIManager;
    
    public static int collectibleBoxCount = 0;
    public static void AddCollectibleBoxCount()
    {
        collectibleBoxCount++;
    }
    public static void SubstractCollectibleBoxCount()
    {
        collectibleBoxCount--;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        StartCoroutine(SpawnBox());
    }
    void OnDisable()
    {
       StopAllCoroutines();
    }

    IEnumerator SpawnBox()
    {
        if(boxes.Length > 0)
        {
            do
            {
                Box box = boxes[Random.Range(0, boxes.Length)];
                Instantiate(box, spawnPoint.position, spawnPoint.rotation);
                
                Conveyor.AddCollectibleBoxCount();
                uIManager.SetCollectibleBoxesCount(Conveyor.collectibleBoxCount);
                
                yield return new WaitForSeconds(spawnTime);
                
            } while (true);
        }
    }
    
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Box box))
        {
            box.GetComponent<Rigidbody>().AddForce(transform.forward * forceFactor, ForceMode.Force);
        }
    }

}
