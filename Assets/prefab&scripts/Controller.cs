using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private float _minGroundNormalY = .65f;
    private float _gravityModifier = 1f;
    private Vector2 _velocity;
    private LayerMask _layerMask = 1;

    protected Vector2 TargetVelocity;
    protected bool Grounded;
    protected Vector2 GroundNormal;
    protected Rigidbody2D Rb2d;
    protected ContactFilter2D ContactFilter;
    protected RaycastHit2D[] HitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> HitBufferList = new List<RaycastHit2D>(16);

    protected const float MinMoveDistance = 0.001f;
    protected const float ShellRadius = 0.01f;

    private void OnEnable()
    {
        Rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ContactFilter.useTriggers = false;
        ContactFilter.SetLayerMask(_layerMask);
        ContactFilter.useLayerMask = true;
    }

    private void Update()
    {
        TargetVelocity = new Vector2(Input.GetAxis("Horizontal"), 0);

        if (Input.GetKey(KeyCode.Space) && Grounded)
            _velocity.y = 5;
    }

    private void FixedUpdate()
    {
        _velocity += _gravityModifier * Physics2D.gravity * Time.deltaTime;
        _velocity.x = TargetVelocity.x;

        Grounded = false;

        Vector2 deltaPosition = _velocity * Time.deltaTime;
        Vector2 moveAlongGround = new Vector2(GroundNormal.y, -GroundNormal.x);
        Vector2 move = moveAlongGround * deltaPosition.x;

        MovePlayer(move, false);

        move = Vector2.up * deltaPosition.y;

        MovePlayer(move, true);
    }

    private void MovePlayer(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;

        if (distance > MinMoveDistance)
        {
            int count = Rb2d.Cast(move, ContactFilter, HitBuffer, distance + ShellRadius);

            HitBufferList.Clear();

            for (int i = 0; i < count; i++)
            {
                HitBufferList.Add(HitBuffer[i]);
            }

            for (int i = 0; i < HitBufferList.Count; i++)
            {
                Vector2 currentNormal = HitBufferList[i].normal;
                if (currentNormal.y > _minGroundNormalY)
                {
                    Grounded = true;
                    if (yMovement)
                    {
                        GroundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }

                float projection = Vector2.Dot(_velocity, currentNormal);
                if (projection < 0)
                {
                    _velocity = _velocity - projection * currentNormal;
                }

                float modifiedDistance = HitBufferList[i].distance - ShellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }
        }

        Rb2d.position = Rb2d.position + move.normalized * distance;
    }
}