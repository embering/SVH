using UnityEngine;
using VRC.SDKBase;
using VRC;

namespace Cirilla.Exploits
{
    internal class Fly
    {
        internal static bool uppiesUpdate = false; 
        internal static Player LocalPlayer => Player.prop_Player_0;
        internal static Transform trans;
        internal static int temp = 0;
        private static Vector3 originGrav;
        private static Vector3 originVel;

        public static void uppies(bool uppies)
        {
            try
            {
                if (uppies)
                {
                    if (RoomManager.field_Internal_Static_ApiWorld_0 != null)
                    {
                        if (VRCPlayer.field_Internal_Static_VRCPlayer_0 != null)
                        {
                            if (trans == null && Camera.main != null)
                            {
                                trans = Camera.main.transform;
                            }
                            if (temp == 0)
                            {
                                temp = 1;
                                originVel = Networking.LocalPlayer.GetVelocity();
                                originGrav = Physics.gravity;
                            }
                            Networking.LocalPlayer.SetVelocity(Vector3.zero);
                            Physics.gravity = Vector3.zero;

                            if (Input.GetKey(KeyCode.W))
                            {
                                LocalPlayer.transform.position += trans.transform.forward * 30f * Time.deltaTime;
                            }
                            else if (Input.GetKey(KeyCode.S))
                            {
                                LocalPlayer.transform.position += trans.transform.forward * -1f * 30f * Time.deltaTime;
                            }
                            if (Input.GetKey(KeyCode.A))
                            {
                                LocalPlayer.transform.position += trans.transform.right * -1f * 30f * Time.deltaTime;
                            }
                            else if (Input.GetKey(KeyCode.D))
                            {
                                LocalPlayer.transform.position += trans.transform.right * 30f * Time.deltaTime;
                            }
                            if (Input.GetKey(KeyCode.E))
                            {
                                LocalPlayer.transform.position += trans.transform.up * 30f * Time.deltaTime;
                            }
                            else if (Input.GetKey(KeyCode.Q))
                            {
                                LocalPlayer.transform.position += trans.transform.up * -1f * 30f * Time.deltaTime;
                            }
                        }
                    }
                }
                else
                {
                    temp = 0;
                    Physics.gravity = originGrav;
                    Networking.LocalPlayer.SetVelocity(originVel);

                    if (LocalPlayer != null)
                    {
                        var characterController = LocalPlayer.gameObject.GetComponent<CharacterController>();
                        if (characterController != null)
                        {
                            characterController.enabled = true;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"An error occurred in the Fly.uppies method: {ex.Message}");
                Debug.LogError($"Stack Trace: {ex.StackTrace}");
            }
        }
    }
}
