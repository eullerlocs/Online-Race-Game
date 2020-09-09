using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Photon.Pun;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]
    public class CarUserControl : MonoBehaviour
    {
        public PhotonView pview;
        private CarController m_Car; // the car controller we want to use


        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
            PlayerPrefs.SetInt("UnitySelectMonitor", 1);

        }
        private void Start()
        {
            PlayerPrefs.SetInt("UnitySelectMonitor", 1);
        }


        private void FixedUpdate()
        {
            if (pview.IsMine)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    Debug.Log("resetou");
                    PhotonNetwork.Destroy(gameObject);
                }
                // pass the input to the car!
                float h = CrossPlatformInputManager.GetAxis("Horizontal");
                float v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
                float handbrake = CrossPlatformInputManager.GetAxis("Jump");
                m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
            }
            
#endif
            }
        }
    }
}
