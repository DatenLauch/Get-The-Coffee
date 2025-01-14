    using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;
    public float rotationSpeed = 1f;

    // Neue Variablen für die Kameraführung
    public bool followPlayer = true; // Flag, ob die Kamera dem Spieler folgen soll
    public GameObject puzzleGameObject;
    public float moveSpeed = 5f;     // Geschwindigkeit für die Kamerabewegung

    private bool isMovingSmoothly = false;
    void Update()
    {
        if (isMovingSmoothly)
        {
            // Keine direkte Bewegung, wenn eine sanfte Bewegung läuft
            return;
        }
        if (followPlayer)
        {
            // Aktueller Code zum Folgen des Spielers
            Quaternion playerRotation = playerTransform.rotation;
            Vector3 offsetRotated = playerRotation * offset;
            transform.position = playerTransform.position + offsetRotated;
            transform.position = Vector3.Lerp(transform.position, playerTransform.position + offsetRotated, moveSpeed * Time.deltaTime);
            Quaternion targetRotation = Quaternion.Slerp(transform.rotation, playerRotation, rotationSpeed * Time.deltaTime);
            transform.rotation = targetRotation;
        }
        else
        {
            // Bewege die Kamera zur Zielposition
            transform.position = Vector3.Lerp(transform.position, puzzleGameObject.transform.position, moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, puzzleGameObject.transform.rotation, rotationSpeed * Time.deltaTime);
        }
    }
    
    public void ToggleCameraFollow()
    {
        // Starte eine Coroutine für die sanfte Bewegung zurück zum Spieler
        StartCoroutine(ToggleFollowCameraCoroutine());

    }

    private IEnumerator ToggleFollowCameraCoroutine()
    {
        if (followPlayer == false)
        {
            isMovingSmoothly = true;
            yield return StartCoroutine(SmoothMoveToPlayer());
        }
        
        followPlayer = !followPlayer;
    }
    // Coroutine für die sanfte Bewegung zurück zum Spieler
    private IEnumerator SmoothMoveToPlayer()
    {
        
        // Berechne die Zielposition und -rotation basierend auf dem Spieler und dem Offset
        Quaternion playerRotation = playerTransform.rotation;
        Vector3 targetPosition = playerTransform.position + playerRotation * offset;
        Quaternion targetRotation = playerRotation;
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            yield return null;
        }
        isMovingSmoothly = false;
        
        //Debug.Log("Player is following");
    }
}
