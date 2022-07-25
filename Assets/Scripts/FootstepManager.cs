
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepManager : MonoBehaviour
{
    public Player player;
    public Camera mainCamera;
    public LayerMask groundLayerMask;
    public List<AudioClip> gravelSteps = new List<AudioClip>();
    public List<AudioClip> woodSteps = new List<AudioClip>();
    public List<AudioClip> stoneSteps = new List<AudioClip>();
    public List<AudioClip> wataSteps = new List<AudioClip>();

    public AudioSource source;
    public float baseStepSpeed = 0.35f;
    private float footstepTimer;

    private void Start()
    {
        footstepTimer = baseStepSpeed;
    }
    public void Update()
    {
        if (!player.isGrounded) { return; }

        if (player.move == Vector3.zero) { return; }

        footstepTimer -= Time.deltaTime;

        if (footstepTimer <= 0)
        {
            if (Physics.Raycast(mainCamera.transform.position, Vector3.down, out RaycastHit hit, 25, groundLayerMask))
            {
                switch (hit.collider.tag)
                {
                    case "GravelFloor":
                        {
                            source.PlayOneShot(gravelSteps[(Random.Range(0, gravelSteps.Count))]);
                            break;
                        }
                    case "WoodFloor":
                        {
                            source.PlayOneShot(woodSteps[(Random.Range(0, woodSteps.Count))]);
                            break;
                        }
                    case "StoneFloor":
                        {
                            source.PlayOneShot(stoneSteps[(Random.Range(0, stoneSteps.Count))]);
                            break;
                        }
                    case "WaterFloor":
                        {
                            source.PlayOneShot(wataSteps[(Random.Range(0, wataSteps.Count))]);
                            break;
                        }
                    default:
                        {
                            source.PlayOneShot(gravelSteps[(Random.Range(0, gravelSteps.Count))]);
                            break;
                        }
                }
            }
            footstepTimer = baseStepSpeed;
        }
    }
}

