using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerTackle : NetworkBehaviour
{
    [SerializeField] private GameObject flagHolder;

    PlayerMovement playerMovement;
    public void Start()
    {
        playerMovement = transform.parent.gameObject.GetComponent<PlayerMovement>();
    }
    public void CollideWithObject(Collider other)
    {
        if (!base.IsOwner) return;
        if (other.gameObject.tag == "Flag" && playerMovement.CanTackle())
        {
            Flag flag = other.gameObject.GetComponent<Flag>();

            flag.AttachToPlayer(flagHolder);
            flag.AttachToPlayerServer(flagHolder);
        }
    }
}
