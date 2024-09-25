using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class PatrolIA : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField]  private float Speed;
    [SerializeField] private float waitTime;

    private int currentWaypoint;
    private bool isWaiting;

    void Update()
    {
        if(transform.position != waypoints[currentWaypoint].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, Speed * Time.deltaTime);
        }
        else if(!isWaiting)
        {
            StartCoroutine(Wait());
        }

    }

    IEnumerator Wait()
    {
        isWaiting = true;

        yield return new WaitForSeconds(waitTime);
        currentWaypoint++;

        if(currentWaypoint == waypoints.Length)
        {
            currentWaypoint = 0;
        }
        isWaiting = false;

        Flip();
    }

    private void Flip()
    {
        if (transform.position.x > waypoints[currentWaypoint].position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0);

        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0);
        }
    }
}
