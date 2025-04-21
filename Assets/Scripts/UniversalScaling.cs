using UnityEngine;

public class UniversalScaling : MonoBehaviour
{
    /*[Header("���������")]
    [Tooltip("������������� ������ ������� ������� ������ � ������� ��������")]
    public float fixedWidth = 1920f;

    private Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
        if (!cam.orthographic)
        {
            Debug.LogWarning("������ ������ ���� ���������������!");
            cam.orthographic = true;
        }
        UpdateCameraSize();
    }

    void Update()
    {
        UpdateCameraSize();
    }

    void UpdateCameraSize()
    {
        // ������� ������ ������ (������ / ������)
        float screenAspect = (float)Screen.width / Screen.height;

        // ������ ��������������� ������ ������� ��������� ������ ������� �������
        // ����� orthographicSize ���, ����� ������ ������ ���� fixedWidth
        // ������ ������ = orthographicSize * 2 * aspect
        // => orthographicSize = fixedWidth / (2 * aspect)

        cam.orthographicSize = fixedWidth / (2f * screenAspect);
    }*/

    [Header("���������")]
    [Tooltip("������������� ������ ��� �������������� ���������� (� ������� ��������)")]
    public float fixedWidth = 1920f;

    [Tooltip("������������� ������ ��� ������������ ���������� (� ������� ��������)")]
    public float fixedHeight = 1080f;

    [Tooltip("�����, ������������ ������� ����������� ������ ���� ������ �� ��������� (������ ��� �������������� ����������)")]
    public Transform targetPositionPoint;

    private Camera cam;
    private Vector2 lastResolution;

    void Awake()
    {
        cam = GetComponent<Camera>();
        if (!cam.orthographic)
        {
            Debug.LogWarning("������ ������ ���� ���������������!");
            cam.orthographic = true;
        }
        UpdateCameraSizeAndPosition();
        lastResolution = new Vector2(Screen.width, Screen.height);
    }

    void Update()
    {
        UpdateCameraSizeAndPosition();
    }

    void UpdateCameraSizeAndPosition()
    {
        float screenAspect = (float)Screen.width / Screen.height;

        if (Screen.width >= Screen.height)
        {
            cam.orthographicSize = fixedWidth / (2f * screenAspect);

            AdjustCameraPositionToTarget();
        }
        else
        {
            cam.orthographicSize = fixedHeight / 2f;

            AdjustCameraPositionToTarget();

            // ��� ������������ ���������� ����� �������� ������� ������, ���� �����
            // ��������, ���������� �� Y:
            /*Vector3 pos = cam.transform.position;
            cam.transform.position = new Vector3(pos.x, 0f, pos.z);*/
        }
    }

    void AdjustCameraPositionToTarget()
    {
        if (targetPositionPoint == null)
            return;

        Vector3 camPos = cam.transform.position;

        float halfHeight = cam.orthographicSize;

        float cameraBottomY = camPos.y - halfHeight;

        float targetY = targetPositionPoint.position.y;

        float deltaY = cameraBottomY - targetY;

        cam.transform.position = new Vector3(camPos.x, camPos.y - deltaY, camPos.z);
    }
}
