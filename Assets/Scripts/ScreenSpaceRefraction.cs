using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ScreenSpaceRefraction : MonoBehaviour {
    [HideInInspector]
    [SerializeField]
    private Camera cam;
    public int downResFactor = 1;

    public string globalTextureName = "_GlobalRefractionTex";

    private void OnEnable() {
        GenerateRT();
    }

    void GenerateRT() {
        cam = GetComponent<Camera>();

        if (cam.targetTexture != null) {
            RenderTexture temp = cam.targetTexture;

            cam.targetTexture = null;
            DestroyImmediate(temp);
        }

        cam.targetTexture = new RenderTexture(cam.pixelWidth >> downResFactor, cam.pixelHeight >> downResFactor, 16);
        cam.targetTexture.filterMode = FilterMode.Bilinear;
        
        Shader.SetGlobalTexture(globalTextureName, cam.targetTexture);
    }
}
