using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInstance : MonoBehaviour
{
    public GameObject Partical;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            var game = Instantiate(Partical, transform.position, transform.rotation);
            Destroy(game, 0.75f);
        }
    }
}
