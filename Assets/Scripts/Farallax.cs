using UnityEngine;

public class Fara : MonoBehaviour
{
    public float speed = 1f;

    public MeshRenderer mr;

    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        if(!GameManager.Instance.isDie)
        {
            mr.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0f);
        }
    }
}
