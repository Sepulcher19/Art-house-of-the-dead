using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner3D : MonoBehaviour
{
    public float Max;
    public float Min;
    public int E;
    [SerializeField] GameObject prefab;
    [SerializeField] BoxCollider bc;

    Vector2 cubeSize;
    Vector2 cubeCenter;

    void Awake()
    {
        Transform cubeTrans = bc.GetComponent<Transform>();
        cubeCenter = cubeTrans.position;

        // Multiply by scale because it does affect the size of the collider
        cubeSize.x = cubeTrans.localScale.x * bc.size.x;
        cubeSize.y = cubeTrans.localScale.y * bc.size.y;
    }

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        E = GameObject.FindGameObjectsWithTag("Enemie").Length;

        if(E <= Max)
        {
            GameObject go = Instantiate(prefab, GetRandomPosition(), Quaternion.identity);
        }
        
    }
    private Vector2 GetRandomPosition()
    {
        // You can also take off half the bounds of the thing you want in the box, so it doesn't extend outside.
        // Right now, the center of the prefab could be right on the extents of the box
        Vector2 randomPosition = new Vector2(Random.Range(-cubeSize.x / 2, cubeSize.x / 2), Random.Range(-cubeSize.y / 2, cubeSize.y / 2));

        return cubeCenter + randomPosition;
    }
 
}
