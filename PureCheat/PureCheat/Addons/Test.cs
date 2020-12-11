using UnityEngine;
using PureCheat.API;
namespace PureCheat.Addons
{
    public class Test : PureModSystem
    {
        public override string ModName => "Test";

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.U))
                foreach (GameObject gameObject in PureUtils.GetAllGameObjects())
                    PureLogger.Log($"Name: [{gameObject.transform.name}] | Pos: ({gameObject.transform.position.x}, {gameObject.transform.position.y}, {gameObject.transform.position.z})");

            if (Input.GetKeyDown(KeyCode.T))
                foreach (GameObject gameObject in PureUtils.GetAllObjectsInSceneTree())
                    PureLogger.Log($"Name: [{gameObject.transform.name}] | Pos: ({gameObject.transform.position.x}, {gameObject.transform.position.y}, {gameObject.transform.position.z})");

            if (Input.GetKey(KeyCode.Tab) && Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                    PureLogger.Log(hit.transform.name);
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                foreach (GameObject gameObject in PureUtils.GetAllGameObjects())
                    if (gameObject != PureUtils.GetLocalPlayer())
                        gameObject.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                GameObject playerCamera = PureUtils.GetLocalPlayerCamera();

                Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
                RaycastHit[] hits = Physics.RaycastAll(ray);
                if (hits.Length > 0)
                {
                    RaycastHit raycastHit = hits[0];
                    PureLogger.Log(raycastHit.transform.name);
                }
            }
        }
    }
}
