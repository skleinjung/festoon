using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dispense : MonoBehaviour
{
    private Transform _nozzleTransform;

    // frosting object to appear when dispensing
    public GameObject FrostingPrefab;

    // initial downward speed
    public float InitialSpeed = 0F;

    // Start is called before the first frame update
    void Start()
    {
        _nozzleTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            GameObject spawned = Instantiate(FrostingPrefab);
            spawned.transform.position = new Vector3(_nozzleTransform.position.x, 0, 0);
            spawned.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -InitialSpeed, 0);
        }
    }

    void OnMouseDrag()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _nozzleTransform.position = new Vector3(mouseWorldPosition.x, _nozzleTransform.position.y, 0);
    }
}
