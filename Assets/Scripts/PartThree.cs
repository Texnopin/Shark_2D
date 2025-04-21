using UnityEngine;
using UnityEngine.UI;

public class PartThree : MonoBehaviour
{
    [SerializeField] private ScreenOrientation screenOrientation;

    [SerializeField] private Animator tapToPlay;
    [SerializeField] private GameObject playerHook;
    private Vector3 posHook;
    [SerializeField] private Animator barrel;

    [SerializeField] private GameObject HUD;

    [SerializeField] private Animator canvas;
    [SerializeField] private RectTransform mainFoneImage;
    [SerializeField] private RectTransform playNowButton;
    [SerializeField] private Button finishButton;

    [SerializeField] private Animator _tutorial;

    [Header("Настройки L-orientation")]
    [SerializeField] public float x_pos_playButton_landskape = 500f;
    [SerializeField] public float y_pos_playButton_landskape = -190f;
    [SerializeField] public float width_playButton_landskape = 822f - 80f;
    [SerializeField] public float height_playButton_landskape = 232f - 22.579f;

    [Header("Настройки P-orientation")]
    [SerializeField] public float x_pos_playButton_portraint = 0f;
    [SerializeField] public float y_pos_playButton_portraint = -700f;
    [SerializeField] public float width_playButton_portraint = 822f;
    [SerializeField] public float height_playButton_portraint = 232;


    private float posOffset;

    private void Start()
    {
        posHook = new Vector3(184, -219.299988f, 0f);
        tapToPlay.gameObject.SetActive(true);
        tapToPlay.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Tap to collect!";
        tapToPlay.Play("Scale");
        _tutorial.gameObject.GetComponent<RectTransform>().position = tapToPlay.gameObject.GetComponent<RectTransform>().position;
        Invoke("Tutorial", 5f);
        posOffset = mainFoneImage.localPosition.y;
    }

    private void FixedUpdate()
    {
        _tutorial.gameObject.GetComponent<RectTransform>().position = tapToPlay.gameObject.GetComponent<RectTransform>().position;
    }

    private void Update()
    {
        float h = Screen.height;
        float w = Screen.width;
        if (mainFoneImage.gameObject.activeSelf)
        {
            if (screenOrientation.isLandscape)
            {
                mainFoneImage.localScale = new Vector3(3.1f+ (-3.5f*(h / w)), 3.1f + (-3.5f * (h / w)), 3.1f + (-3.5f * (h / w)));
                mainFoneImage.localPosition = new Vector3(mainFoneImage.localPosition.x, posOffset + 30f, mainFoneImage.localPosition.z);

                playNowButton.localPosition = new Vector3(x_pos_playButton_landskape, y_pos_playButton_landskape, 0);
                playNowButton.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width_playButton_landskape);
                playNowButton.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height_playButton_landskape);
            }
            else
            {
                mainFoneImage.localScale = new Vector3(0.58f+ (0.48f*(h / w)), 0.58f + (0.48f * (h / w)), 0.58f + (0.48f * (h / w)));
                mainFoneImage.localPosition = new Vector3(mainFoneImage.localPosition.x, posOffset, mainFoneImage.localPosition.z);

                playNowButton.localPosition = new Vector3(x_pos_playButton_portraint, y_pos_playButton_portraint, 0);
                playNowButton.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width_playButton_portraint);
                playNowButton.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height_playButton_portraint);


            }
        }
    }

    public void Collect()
    {
        if(mainFoneImage.gameObject.activeSelf == false && tapToPlay.gameObject.activeSelf == true)
        {
            _tutorial.gameObject.SetActive(false);
            _tutorial.SetBool("TapAnim", false);
            tapToPlay.gameObject.SetActive(false);
            barrel.Play("barrel");
            Invoke("FinishPlayble", 1f);
        }
    }

    public void FinishPlayble()
    {
        Destroy(_tutorial.gameObject);
        mainFoneImage.gameObject.SetActive(true);
        finishButton.gameObject.SetActive(true);
        canvas.Play("PlayNow");
    }

    private void Tutorial()
    {
        _tutorial.gameObject.SetActive(true);
        _tutorial.SetBool("TapAnim", true);
    }
}
