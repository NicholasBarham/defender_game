using System;
using UnityEngine;
using Util.Variables;

namespace Defender
{
    public class MovementReceiver : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb = null;
        
        [SerializeField] private Vector2Reference input = null;

        [SerializeField] private float acceleration = 1f;
        [SerializeField] private float maxSpeed = 5f;

        private void Awake()
        {
            if (rb.Equals(null))
                rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            UpdateMovement();
        }

        private void UpdateMovement()
        {
            if (input.Equals(null) || rb.Equals(null))
                return;
            
            rb.AddForce(input.Value * acceleration, ForceMode2D.Impulse);

            CheckSpeedLimit();
        }

        private void CheckSpeedLimit()
        {
            Vector2 velocity = rb.velocity;
            
            if (Mathf.Abs(velocity.x) <= maxSpeed && Mathf.Abs(velocity.y) <= maxSpeed)
                return;
            
            Vector2 combatForce = Vector2.zero;
            
            if (Mathf.Abs(velocity.x) > maxSpeed) 
                combatForce.x = GetReactiveForce(velocity.x);

            if (Mathf.Abs(velocity.y) > maxSpeed) 
                combatForce.y = GetReactiveForce(velocity.y);

            rb.AddForce(combatForce, ForceMode2D.Impulse);
        }

        private float GetReactiveForce(float velocity)
        {
            float combatForce = Mathf.Abs(velocity) - maxSpeed;

            return velocity > 0f ? -combatForce : combatForce;
        }
    }
}