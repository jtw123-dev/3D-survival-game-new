using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 center = new Vector3(0.5f, 0.5f, 0);
            Ray ray = Camera.main.ViewportPointToRay(center);
            RaycastHit hit;
          if (  Physics.Raycast(ray,out hit,Mathf.Infinity))
            {
                Debug.Log("You hit object " + hit.collider.name);
            }

        }
    }
}
