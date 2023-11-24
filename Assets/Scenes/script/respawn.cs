using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class respawn : MonoBehaviour
{
    public string tagName;
    public string sceneName = "";
    // Start is called before the first frame update
    private void OnControllerColliderHit(ControllerColliderHit collision)
    {
        if (collision.gameObject.tag == tagName)
        {
            {
                if (sceneName != "")
                {
                    SceneManager.LoadScene(sceneName);
                }
            }
        }
    }
}