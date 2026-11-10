using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, (1 * speed)); 
    }
}
