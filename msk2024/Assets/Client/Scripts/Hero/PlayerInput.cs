using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
namespace Surv
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private HeroMover _hero;

        public void FrontBackMovement(InputAction.CallbackContext context)
        {
            _hero.directionZ = context.ReadValue<float>();
        }

        public void RightLeftMovement(InputAction.CallbackContext context)
        {
            _hero.directionX = context.ReadValue<float>();
        }

        public void Fire(InputAction.CallbackContext context)
        {
            Debug.Log("GUN!");
        }

        public void Rotation(InputAction.CallbackContext context)
        {
            // TODO
        }
    }
}
