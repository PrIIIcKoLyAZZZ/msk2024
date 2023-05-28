using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
namespace Surv
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private HeroMover _hero;
        [SerializeField] private CameraMover _camera;

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
            //Debug.Log(context.phase);
            if(context.phase == InputActionPhase.Performed)
            {
                _hero.Shooting();
            }
        }

        public void Rotation(InputAction.CallbackContext context)
        {
            _hero.mousePosition = context.ReadValue<float>();
        }

        public void CameraRotation(InputAction.CallbackContext context)
        {
            //_camera.rotateDirection = context.ReadValue<float>();
        }
    }
}
