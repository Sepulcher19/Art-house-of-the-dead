using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    private ArtProperties art;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform != null)
                {
                    art = hit.transform.GetComponent<ArtProperties>();
                    print(art.url);
                    Application.OpenURL(art.url);
                }
            }
        }
    }
}
