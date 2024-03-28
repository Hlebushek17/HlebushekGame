using UnityEngine;

public class MiddleCube : MonoBehaviour
{

    public Transform Point1;
    public Transform Point2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(Point1.position, Point2.position, 0.5f);
    }
}
