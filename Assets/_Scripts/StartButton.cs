using UnityEngine;
using UnityEngine.EventSystems;

public class StartButton : MonoBehaviour
{
    RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnHover(BaseEventData eventData)
    {
        rectTransform.position = new Vector3(
            rectTransform.position.x,
            rectTransform.position.y + 0.3f,
            rectTransform.position.z
        );
    }

    public void OnHoverExit(BaseEventData eventData)
    {
        rectTransform.position = new Vector3(
            rectTransform.position.x,
            rectTransform.position.y - 0.3f,
            rectTransform.position.z
        );
    }
}
