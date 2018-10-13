// auther: Lingjie Kong
// revision: x1
// data: 10/12/2018

using UnityEngine;

public class RanchScript : MonoBehaviour
{
    public GameObject ranchObj; // ranch object
    public GameObject nutOjb;   // nut object
    public float scale = 20.0f; // move step size scale
    Vector3 posZ = new Vector3(0.0f, 0.0f, 1.0f);   // positive z vector
    Vector3 negZ = new Vector3(0.0f, 0.0f, -1.0f);  // negative z vector 
    Vector3 posX = new Vector3(1.0f, 0.0f, 0.0f);   // postive x vector
    Vector3 negX = new Vector3(-1.0f, 0.0f, 0.0f);  // negative x vector 
    Vector3 posY = new Vector3(0.0f, 1.0f, 0.0f);   // positive y vector
    Vector3 negY = new Vector3(0.0f, -1.0f, 0.0f);  // negative y vector
    Vector3 offset = new Vector3(0.0f, 8.0f, 0.0f); // offset vector
    public bool findNut = false;    // bool to check whether nut is found or not

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        // allow ranch to move to search for nut if nut is not found
        if (!findNut)
        {
            // use key to move ranch around in x, y, and z direction
            if (Input.GetKey("s"))  
            {
                transform.position += scale * posZ * Time.fixedDeltaTime;
            }
            if (Input.GetKey("w"))
            {
                transform.position += scale * negZ * Time.fixedDeltaTime;
            }
            if (Input.GetKey("a"))
            {
                transform.position += scale * posX * Time.fixedDeltaTime;
            }
            if (Input.GetKey("d"))
            {
                transform.position += scale * negX * Time.fixedDeltaTime;
            }
            if (Input.GetKey("z"))
            {
                transform.position += scale * posY * Time.fixedDeltaTime;
            }
            if (Input.GetKey("x"))
            {
                transform.position += scale * negY * Time.fixedDeltaTime;
            }
            // check whether ranch and nut are close enough to snap them 
            if (Vector3.Distance(transform.position, nutOjb.transform.position) < 10)
            {
                transform.position = nutOjb.transform.position + offset;    // set ranch and nut at same pivot point
                findNut = true; // disable ranch search and enable rotate
            }
        }
        // ranch find nut and rotate
        if (findNut)
        {   
            // rotate clockwise to move nut down
            if (Input.GetKey("r"))
            {
                transform.Rotate(scale * posZ * Time.deltaTime);
                nutOjb.transform.Rotate(scale * posX * Time.deltaTime);
                transform.position += negY * 0.1f;
                nutOjb.transform.position += negY * 0.1f;
            } 
            // rotate counterclockwise to move nut up
            if (Input.GetKey("t"))
            {
                transform.Rotate(scale* negZ * Time.deltaTime);
                nutOjb.transform.Rotate(scale* negX * Time.deltaTime);
                transform.position += posY * 0.1f;
                nutOjb.transform.position += posY * 0.1f;
            }
        }
    }

}
