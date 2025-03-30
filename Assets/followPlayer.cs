using UnityEngine;

public class Follow_player : MonoBehaviour {

    public Transform player;
    public float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update () {
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}