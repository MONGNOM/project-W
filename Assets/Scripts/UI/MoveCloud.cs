using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloud : MonoBehaviour
{
    public float cloudSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * cloudSpeed * Time.deltaTime);

        if (transform.position.x > 8)
            transform.position = new Vector2(-8, transform.position.y);
    }
}
