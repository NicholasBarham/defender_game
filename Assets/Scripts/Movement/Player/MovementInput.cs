using UnityEngine;
using Util.Variables;

namespace Defender
{
    public class MovementInput : MonoBehaviour
    {
        [SerializeField] private Vector2Variable inputDirection = null;

        void Update()
        {
            UpdateInput();
        }

        private void UpdateInput()
        {
            if(inputDirection.Equals(null)) 
                return;

            var input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            inputDirection.Value = input;
        }

        private void OnDisable() 
        {
            inputDirection.Value = Vector2.zero;
        }
    }

}
