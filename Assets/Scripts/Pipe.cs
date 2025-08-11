using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed = 2f;

    private void Update()
    {
        transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
    }
}