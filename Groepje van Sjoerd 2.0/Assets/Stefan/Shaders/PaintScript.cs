using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintScript : MonoBehaviour
{
    public OVRInput.Button button;

    public float range;

    [SerializeField] private GameObject originObject;
    [SerializeField] private Shader drawShader;

    private RenderTexture splatMap;
    private Material currentMaterial, drawMaterial;
    private RaycastHit hit;

    [SerializeField] [Range(1, 500)] private float size;
    [SerializeField] [Range(0, 1)] private float strength;

    private OVRGrabbable grabbable;
    // Start is called before the first frame update
    void Start()
    {
        grabbable = GetComponent<OVRGrabbable>();

        drawMaterial = new Material(drawShader);
        drawMaterial.SetVector("_Color", Color.red);

        currentMaterial = GetComponent<MeshRenderer>().material;

        splatMap = new RenderTexture(1024, 1024, 0, RenderTextureFormat.ARGBFloat);
        currentMaterial.SetTexture("SplatMap", splatMap);
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbable.isGrabbed && OVRInput.GetDown(button, grabbable.grabbedBy.GetController()))
        {
            if (Physics.Raycast(originObject.transform.position, originObject.transform.forward, out hit, range))
            {
                drawMaterial.SetVector("_Coordinates", new Vector4(hit.textureCoord.x, hit.textureCoord.y, 0, 0));
                drawMaterial.SetFloat("_Strength", strength);
                drawMaterial.SetFloat("_Size", size);
                RenderTexture temp = RenderTexture.GetTemporary(splatMap.width, splatMap.height, 0, RenderTextureFormat.ARGBFloat);
                Graphics.Blit(splatMap, temp);
                Graphics.Blit(temp, splatMap, drawMaterial);
                RenderTexture.ReleaseTemporary(temp);
            }
        }
    }
}
