using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]

public class PhotoCapture : MonoBehaviour
{

    Camera snapCam;
    int resWidth = 256;
    int resHeight = 256;

    // Start is called before the first frame update
    private void Awake()
    {
        snapCam = GetComponent<Camera>();
        if(snapCam.targetTexture == null)
        {
            snapCam.targetTexture = new RenderTexture(resWidth, resHeight, 24);
        }
        else
        {
            resWidth = snapCam.targetTexture.width;
            resHeight = snapCam.targetTexture.height;
        }
        snapCam.gameObject.SetActive(false);
    }

    // Update is called once per frame

    public void CallTakeSnapshot()
    {
        snapCam.gameObject.SetActive(true);
    }

    private void LateUpdate()
    {
        if (snapCam.gameObject.activeInHierarchy)
        {
            Texture2D snapshot = new Texture2D(resWidth, resHeight, TextureFormat.RGBA32, false);
            snapCam.Render();
            RenderTexture.active = snapCam.targetTexture;
            snapshot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            byte[] bytes = snapshot.EncodeToPNG();
            string fileName = SnapshotName();
            System.IO.File.WriteAllBytes(fileName, bytes);
            Debug.Log("Snapshot worked");
            snapCam.gameObject.SetActive(false);
        }
    }

    private string SnapshotName()
    {
        return string.Format("{0}/Snapshots/PokemonSnap_{1}x{2}_{3}.png", Application.dataPath, resWidth, resHeight, System.DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss"));
    }
}
