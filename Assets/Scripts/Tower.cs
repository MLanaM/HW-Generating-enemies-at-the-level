using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Tower : MonoBehaviour
{
    private static Vector3 s_pointScale = new Vector3(3, 4, 3);

    public void Init(Vector3 position)
    {
        transform.position = position;
        transform.localScale = s_pointScale;

        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = Color.cyan;
    }
}