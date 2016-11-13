using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    public Transform target;
    public float speed;

    private Transform _transform;

    // Use this for initialization
    void Start() {

        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() {

        float step = speed * Time.deltaTime;
        _transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
