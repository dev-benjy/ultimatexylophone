using UnityEngine;

public class rotate : MonoBehaviour
{
    private RectTransform rectComponent;
    public float rotateSpeed = 800f;

    private void Start()
    {
        rectComponent = GetComponent<RectTransform>();
    }

    private void Update()
    {
        rectComponent.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
    }
}
