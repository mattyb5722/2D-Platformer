using UnityEngine;

public class DontDestroy : MonoBehaviour {
    /// <summary>
    /// Do not destroy this object when switching scenes
    /// </summary>
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject); 
    }
}
