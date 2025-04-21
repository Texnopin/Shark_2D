using UnityEngine;

public class ScreenOrientation : MonoBehaviour
{
    [SerializeField] private Camera cam;
    public bool isLandscape;
    private Vector3 posCam;

    [SerializeField] private GameObject[] parts;

    private void Start()
    {
        posCam = cam.transform.position;
    }

    private void Update()
    {
        isLandscape = IsLandscape();
        if (isLandscape)
        {
            //LandskapeScale();
        }
        else
        {
            //PortraitScale();
        }
    }

    bool IsLandscape()
    {
        return Screen.width > Screen.height;
    }

    private void LandskapeScale()
    {
        float h = Screen.height;
        float w = Screen.width;
        cam.orthographicSize = 3f + (h / w);
        if (parts[0].activeSelf == true || parts[2].activeSelf == true)
        {
            transform.position = new Vector3(posCam.x, posCam.y + (-0.5f * (w / h)), posCam.z);
        }
        else
        {
            transform.position = new Vector3(posCam.x, posCam.y + (0.2f*(w / h)), posCam.z);
        }
    }

    private void PortraitScale()
    {
        float h = Screen.height;
        float w = Screen.width;
        cam.orthographicSize = 2.5f + (h / w);
        if (parts[0].activeSelf == true ||  parts[2].activeSelf == true)
        {
            transform.position = new Vector3(posCam.x, posCam.y + (-0.07f * (w / h)), posCam.z);
        }
        else
        {
            transform.position = new Vector3(posCam.x, posCam.y + (0.2f * (w / h)), posCam.z);
        }
    }

}
