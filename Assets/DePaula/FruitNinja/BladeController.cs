using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BladeController : MonoBehaviour
{
    bool isCutting = false;

    Rigidbody2D rb;
    Camera cam;

    [SerializeField] GameObject bladeTrail;
    GameObject trail;

    CircleCollider2D circleCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if (isCutting)
        {
            UpdateCut();
        }
    }

    void StartCutting()
    {
        isCutting = true;
        trail = Instantiate(bladeTrail, transform);
        circleCollider.enabled = true;
    }

    void StopCutting()
    {
        isCutting = false;
        trail.transform.SetParent(null, true);
        Destroy(trail, 1f);
        circleCollider.enabled = false;
    }

    void UpdateCut()
    {
        rb.position = cam.ScreenToWorldPoint(Input.mousePosition);
    }
}
