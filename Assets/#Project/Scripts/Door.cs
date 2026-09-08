using System;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Collider))]
public class Door : MonoBehaviour
{
    private NavMeshObstacle obstacle;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float chrono;
    private bool isOpening;

    [SerializeField] private float distance = 3f;
    [SerializeField] private float time = 1f;
    void Start()
    {
        obstacle = GetComponentInChildren<NavMeshObstacle>();
        if (obstacle == null) Debug.LogError("This component need an NavmeshObstace in one of its children.", gameObject);
        if (!GetComponent<Collider>().isTrigger) Debug.LogError("This component need to have a trigger as collider.", gameObject);

        startPosition = transform.position;
        endPosition = startPosition + transform.forward * -distance; //We use a negative number to go to left instead of right.
    }

    void Update()
    {
        MoveDoor();
    }

    private void MoveDoor()
    {
        if (isOpening)
        {
            chrono += Time.deltaTime;
            float progression = chrono / time;
            transform.position = Vector3.Lerp(startPosition, endPosition, progression);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        isOpening = true;
    }

}
