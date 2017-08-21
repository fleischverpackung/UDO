using UnityEngine;
#if UNITY_5_3_OR_NEWER
using UnityEngine.SceneManagement;
#endif

namespace Invector.CharacterController
{
    public class vThirdPersonInput : MonoBehaviour
    {
        #region variables


        private float camRotateSpeed = 0.1f;

        [Header("Default Inputs")]
        public string horizontalInput = "Horizontal";
        public string verticallInput = "Vertical";
        public bool enableMovement = true;
        public KeyCode jumpInput = KeyCode.Space;
        public KeyCode strafeInput = KeyCode.Tab;
        public KeyCode sprintInput = KeyCode.LeftShift;
        public KeyCode danceMode1 = KeyCode.D;

        [Header("Camera Settings")]
        public string rotateCameraXInput ="Mouse X";
        public string rotateCameraYInput = "Mouse Y";
        public bool enableCamRotate = true;
        public bool freezeCam = false;
        public float orbitSpeed = 1;

        protected vThirdPersonCamera tpCamera;                // acess camera info        
        [HideInInspector]
        public string customCameraState;                    // generic string to change the CameraState        
        [HideInInspector]
        public string customlookAtPoint;                    // generic string to change the CameraPoint of the Fixed Point Mode        
        [HideInInspector]
        public bool changeCameraState;                      // generic bool to change the CameraState        
        [HideInInspector]
        public bool smoothCameraState;                      // generic bool to know if the state will change with or without lerp  
        [HideInInspector]
        public bool keepDirection;                          // keep the current direction in case you change the cameraState

        protected vThirdPersonController cc;                // access the ThirdPersonController component                

        #endregion

        protected virtual void Start()
        {
            CharacterInit();
        }

        protected virtual void CharacterInit()
        {
            cc = GetComponent<vThirdPersonController>();
            if (cc != null)
                cc.Init();

            tpCamera = FindObjectOfType<vThirdPersonCamera>();
            if (tpCamera) tpCamera.SetMainTarget(this.transform);

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        protected virtual void LateUpdate()
        {
            if (cc == null) return;             // returns if didn't find the controller		    
            InputHandle();                      // update input methods
            UpdateCameraStates();               // update camera states
        }

        protected virtual void FixedUpdate()
        {
            cc.AirControl();
            CameraInput();
        }

        protected virtual void Update()
        {
            cc.UpdateMotor();                   // call ThirdPersonMotor methods               
            cc.UpdateAnimator();                // call ThirdPersonAnimator methods		               
        }

        protected virtual void InputHandle()
        {
            ExitGameInput();
            CameraInput();

            if (!cc.lockMovement)
            {
                MoveCharacter();
                SprintInput();
                StrafeInput();
                JumpInput();
                DanceMode1();
                //danceInput();
            }
        }

        #region Basic Locomotion Inputs      

        protected virtual void MoveCharacter()
        {   
            if (enableMovement)
            {
                cc.input.x = Input.GetAxis(horizontalInput);
                cc.input.y = Input.GetAxis(verticallInput);
            }
            else
            {
                cc.input.x = 0;
                cc.input.y = 0;
            }
        }

        protected virtual void StrafeInput()
        {
            if (Input.GetKeyDown(strafeInput))
                cc.Strafe();
        }

        protected virtual void SprintInput()
        {
            if (Input.GetKeyDown(sprintInput))
                cc.Sprint(true);
            else if(Input.GetKeyUp(sprintInput))
                cc.Sprint(false);
        }

        protected virtual void DanceMode1()
        {
            if (Input.GetKeyDown(danceMode1))
                cc.Strafe();
        }

        protected virtual void DanceMode2()
        {
            if (Input.GetKeyDown(danceMode2))
                cc.Strafe();
        }

        protected virtual void DanceMode3()
        {
            if (Input.GetKeyDown(danceMode3))
                cc.Strafe();
        }

        protected virtual void JumpInput()
        {
            if (Input.GetKeyDown(jumpInput))
                cc.Jump();
        }

        protected virtual void ExitGameInput()
        {
            // just a example to quit the application 
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!Cursor.visible)
                    Cursor.visible = true;
                else
                    Application.Quit();
            }
        }

        #endregion

        #region Camera Methods

        protected virtual void CameraInput()
        {
            if (tpCamera == null)
                return;
            
            var Y = Input.GetAxis(rotateCameraYInput);
            var X = Input.GetAxis(rotateCameraXInput);
            

            // DISABLE CAMERA MOVEMENT
            if (enableCamRotate)
                tpCamera.RotateCamera(X += camRotateSpeed, Y);                
            else
                tpCamera.RotateCamera(X, Y);
            
            if (freezeCam)
                tpCamera.RotateCamera(X, Y);
            else
                tpCamera.RotateCamera(X, Y);
                


            // tranform Character direction from camera if not KeepDirection
            if (!keepDirection)
                cc.UpdateTargetDirection(tpCamera != null ? tpCamera.transform : null);
            // rotate the character with the camera while strafing        
            RotateWithCamera(tpCamera != null ? tpCamera.transform : null);            
        }

        protected virtual void UpdateCameraStates()
        {
            // CAMERA STATE - you can change the CameraState here, the bool means if you want lerp of not, make sure to use the same CameraState String that you named on TPCameraListData
            if (tpCamera == null)
            {
                tpCamera = FindObjectOfType<vThirdPersonCamera>();
                if (tpCamera == null)
                    return;
                if (tpCamera)
                {
                    tpCamera.SetMainTarget(this.transform);
                    tpCamera.Init();
                }
            }            
        }

        protected virtual void RotateWithCamera(Transform cameraTransform)
        {
            if (cc.isStrafing && !cc.lockMovement && !cc.lockMovement)
            {                
                cc.RotateWithAnotherTransform(cameraTransform);                
            }
        }

        #endregion     
    }
}