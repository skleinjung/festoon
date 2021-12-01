using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{
    new public string name = "Cake";

    // how fast this cake moves
    public float Speed = 5;

    // indicates if we got a decoration or not
    private bool _decorated = false;

    // our game object's transformation
    private Transform _transform;

    public bool Decorated
    {
        get { return _decorated; }
    }

    // Start is called before the first frame update
    void Start()
    {
        _transform = this.transform;

        // hide the decoration frosting by default
        var child = gameObject.transform.Find("AppliedDecoration");
        child.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // move right
        var moveAmount = Speed * Time.deltaTime;
        _transform.position = _transform.position + new Vector3(moveAmount, 0, 0);

        // remove if offscreen 
        if (this.transform.position.x >= 10.3f)
        {
            if (_decorated) 
            {
                Debug.Log("Decorated!");
            }
            else
            {
                Debug.Log("Missed!");
            }

            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Decoration") 
        {
            _decorated = true;
            
            var child = gameObject.transform.Find("AppliedDecoration");
            child.GetComponent<Renderer>().enabled = true;
        }
    }
}
