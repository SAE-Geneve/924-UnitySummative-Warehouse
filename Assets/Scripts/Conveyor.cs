using System.Collections;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    
    [SerializeField] private Box[] boxes;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnTime;
    [SerializeField] private float forceFactor = 2;

    
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
