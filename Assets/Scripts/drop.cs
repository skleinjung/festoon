using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop : MonoBehaviour
{
    public float Speed = 25;

    private Transform _myTransform;

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        var moveAmount = Speed * Time.deltaTime;
        _myTransform.position = _myTransform.position + new Vector3(0, -moveAmount, 0);
    }
}
