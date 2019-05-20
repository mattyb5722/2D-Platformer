using UnityEngine;

public class CameraMovement : MonoBehaviour {

    /// <summary>
    /// Manages the Camera Movement
    /// </summary>

    private float incromentor = 0;          // Amount the camera moves

    private void FixedUpdate () {
        gameObject.transform.position += new Vector3(incromentor, 0, 0);
        incromentor += .02f/800f;           // Incroment Camera
    }
    /*
    // Reset Camera
    public void Reset() {
        gameObject.transform.position = new Vector3(0f, 0f, -100f);
        incromentor = 0;
    }
    */

}
