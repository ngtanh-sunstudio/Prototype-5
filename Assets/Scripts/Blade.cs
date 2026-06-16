using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Blade : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private TrailRenderer trailRenderer;
    [SerializeField] private BoxCollider boxCollider;
    [SerializeField] private float distanceFromCamera = 10f;

    private bool isSlicing;

    void Awake()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        if (trailRenderer == null)
        {
            trailRenderer = GetComponent<TrailRenderer>();
        }
        if (boxCollider == null)
        {
            boxCollider = GetComponent<BoxCollider>();
        }

        trailRenderer.enabled = false;
        boxCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
          {
              StartSlice();
          }

          if (Mouse.current.leftButton.isPressed)
          {
              ContinueSlice();
          }

          if (Mouse.current.leftButton.wasReleasedThisFrame)
          {
              EndSlice();
          }
    }

    private void StartSlice()
    {
        isSlicing = true;

        MoveBladeToMouse();

        trailRenderer.enabled = true;
        boxCollider.enabled = true;
        trailRenderer.Clear();
    }

    private void ContinueSlice()
    {
        if (!isSlicing)
        {
            return;
        }

        MoveBladeToMouse();
    }

    private void MoveBladeToMouse()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector3 screenPos = new Vector3(
            mousePos.x,
            mousePos.y,
            distanceFromCamera
        );

        Vector3 worldPos = mainCamera.ScreenToWorldPoint(screenPos);
        transform.position = worldPos;
    }

    private void EndSlice()
    {
        isSlicing = false;
        trailRenderer.enabled = false;
        boxCollider.enabled = false;
        trailRenderer.Clear();
    }
}
