using System;
using Unity.VisualScripting;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = spawnPoint.transform.position;
        }
    }
}
