using UnityEngine;
using Util.Variables;

namespace Defender
{
    public class MovementOrientation : MonoBehaviour
    {
        [SerializeField] private Vector2Reference input = null;

        [SerializeField] private float faceRightRotation = -90f;
        [SerializeField] private float faceLeftRotation = 90f;

        private void Update()
        {
            FaceDirection();
        }

        private void FaceDirection()
        {
            Vector3 rot = transform.localRotation.eulerAngles;

            if (input.Value.x > 0f)
                rot.z = faceRightRotation;
            
            if (input.Value.x < 0f)
                rot.z = faceLeftRotation;

            transform.localRotation = Quaternion.Euler(rot);
        }
    }
}
