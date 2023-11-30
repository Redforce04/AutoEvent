/*// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         AutoEvent
//    Project:          AutoEvent
//    FileName:         RockEffectGrenade.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/29/2023 7:13 PM
//    Created Date:     10/29/2023 7:13 PM
// -----------------------------------------

using System.Diagnostics;
using InventorySystem.Items.ThrowableProjectiles;
using Mirror;
using UnityEngine;

namespace AutoEvent.API;

public class RockEffectGrenade : EffectGrenade
{
    private static readonly CachedLayerMask HitboxLayer = new CachedLayerMask("Hitbox");

    private static readonly Collider[] Detections = new Collider[8];

    private const float MinSelfDamageDelay = 0.1f;

    private const float DetectorThickness = 0.07f;

    private readonly Stopwatch _selfDamageStopwatch = Stopwatch.StartNew();

    [SerializeField] private Transform _centerTransform;

    private Vector3 _prevPosition;

    override void Awake()
    {
        base.Awake();
        _prevPosition = _centerTransform.position;
    }

    override void FixedUpdate()
    {
        FixedUpdate(); ;
        if (NetworkServer.active)
        {
            DetectPlayers();
        }
    }

    public override void ProcessCollision(Collision collision)
    {
        if (NetworkServer.active)
        {
            DestroyProjectile();
        }
    }

    protected virtual void OnCollision(ReferenceHub hub)
    {
        if (NetworkServer.active)
        {
            DestroyProjectile();
        }
    }

    protected void DestroyProjectile()
    {
        if (NetworkServer.active)
        {
            ServerFuseEnd();
        }
    }

    private void DetectPlayers()
    {
        Vector3 prevPosition = _prevPosition;
        _prevPosition = _centerTransform.position;
        int num = Physics.OverlapCapsuleNonAlloc(prevPosition, _prevPosition, 0.07f, Detections, HitboxLayer);
        for (int i = 0; i < num; i++)
        {
            if (Detections[i].TryGetComponent<HitboxIdentity>(out var component))
            {
                ReferenceHub targetHub = component.TargetHub;
                if (!(targetHub == PreviousOwner.Hub) ||
                    !(_selfDamageStopwatch.Elapsed.TotalSeconds < 0.10000000149011612))
                {
                    OnCollision(targetHub);
                }
            }
        }
    }

    private void MirrorProcessed()
    {
    }
}*/