using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LineRenderer lr;

    [Header("Attributes")]
    [SerializeField] private float maxPower = 10f;
    [SerializeField] private float power = 2f;
    [SerializeField] private float maxGoalSpeed = 4f;

    private bool isDragging;
    private bool inHole;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();        
    }

    private void PlayerInput()
    {
        Vector2 inputPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector2.Distance(transform.position, inputPosition);

        if(Input.GetMouseButtonDown(0) && distance <= 0.5f) DragStart();
        if(Input.GetMouseButton(0) && isDragging) DragChange();
        if(Input.GetMouseButtonUp(0) && isDragging) DragRelease(inputPosition);
    }

    private void DragStart()
    {
        isDragging = true;
    }

    private void DragChange()
    {

    }

    private void DragRelease( Vector2 position)
    {
        float distance = Vector2.Distance((Vector2)transform.position, position);
        isDragging = false;

        if(distance < 1f)
        {
            return;
        }

        Vector2 direction = (Vector2)transform.position - position;

        rb.velocity = Vector2.ClampMagnitude(direction * power, maxPower);
    }
}