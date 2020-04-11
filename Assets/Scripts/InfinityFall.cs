using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class InfinityFall : MonoBehaviour
{
    [SerializeField] private float maxTopY = 10.0f;
    [SerializeField] private float minTopY = 7.0f;

    [SerializeField] private float bottomY = -7.0f;

    [SerializeField] private float minX = -9.0f;
    [SerializeField] private float maxX = 9.0f;

    [SerializeField] private GameObject myPrefab;
    [SerializeField] private float period = 1.0f;

    private float nextPopTime = 0.0f;
    void Update()
    {
        foreach (Transform child in transform)
            if (child.position.y < bottomY)
                child.position = new Vector3(Random.Range(minX, maxX), Random.Range(minTopY, maxTopY), 0);
        
        if (Time.time > nextPopTime ) {
            nextPopTime += period;
            Debug.Log("Now");
            Instantiate(myPrefab, new Vector3(Random.Range(minX, maxX), Random.Range(minTopY, maxTopY), -2.0f), Quaternion.identity, transform);
        }
    }
}