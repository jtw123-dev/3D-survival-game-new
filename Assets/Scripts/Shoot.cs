using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [SerializeField] private GameObject _bloodPrefab;
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
                IDamagable damage = hit.collider.GetComponent<IDamagable>();

                if (damage != null)
                {
                    damage.Damage();
                    var bloodPrefabCopy = Instantiate(_bloodPrefab, hit.point, Quaternion.LookRotation( hit.normal));

                    Destroy(bloodPrefabCopy,1f);
                }
                Debug.Log("You hit object " + hit.collider.name);
            }

        }
    }
}
