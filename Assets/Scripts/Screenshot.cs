using System.IO;
using UnityEngine;

public class Screenshot : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {

            int width = Screen.width;
            int height = Screen.height;
            var texture = ScreenCapture.CaptureScreenshotAsTexture();
            Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
            tex = texture;
            byte[] bytes = tex.EncodeToPNG();
            File.WriteAllBytes("C:\\MyApps\\driftdesertrace" + "/screen.png", bytes);
        }
    }
}
