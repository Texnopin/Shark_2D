using UnityEngine;
using UnityEngine.UI;

public class PartTwo : MonoBehaviour
{
    public GeneralControl Controller;
    public ScreenOrientation screenOrientation;
    public GameObject foundation;

    public Animator iconWood;
    [SerializeField] public Animator buttonsSpawn;
    public Animator garbage;
    public Animator tapToPlay;
    public Animator success;
    [SerializeField] public TMPro.TextMeshProUGUI success_text;
    public Animator outOfMaterial;

    public GameObject HUD;

    [Header("Objects")]
    [SerializeField] public GameObject water;
    public GameObject fire;
    public GameObject door;
    public GameObject stairs;
    public GameObject hammock;
    public GameObject flag;

    private Button _buttonWater;
    private Button _buttonFire;
    private Button _buttonDoor;
    private Button _buttonStairs;
    private Button _buttonHammock;
    private Button _buttonFlag;

    [Header("Objects spawn when press button")]
    [SerializeField] public GameObject objSpawnWhenPressWater;
    public GameObject objSpawnWhenPressFire;
    public GameObject objSpawnWhenPressDoor;
    public GameObject objSpawnWhenPressStairs;

    public GameObject select_1;
    public GameObject select_2;
    public GameObject select_3;

    [Header("Tutorial Hand")]
    [SerializeField] private Animator _tutorial;

    private RectTransform _rectTransform_vertical;
    private Vector3 originalLocalPosition;

    private void Start()
    {
        
        _rectTransform_vertical = buttonsSpawn.gameObject.GetComponent<RectTransform>();
        originalLocalPosition = _rectTransform_vertical.localPosition;

        HUD.SetActive(true);
        _buttonWater = water.GetComponent<Button>();
        _buttonFire = fire.GetComponent<Button>();
        _buttonDoor = door.GetComponent<Button>();
        _buttonStairs = stairs.GetComponent<Button>();
        _buttonHammock = hammock.GetComponent<Button>();
        _buttonFlag = flag.GetComponent<Button>();

        buttonsSpawn.Play("ButtonSpawn");
        garbage.Play("red_Indication");

        tapToPlay.gameObject.SetActive(true);
        tapToPlay.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "You need \nfood and water!";
        tapToPlay.Play("Scale");

        _tutorial.gameObject.GetComponent<RectTransform>().position = water.gameObject.GetComponent<RectTransform>().position;
        Invoke("Tutorial", 5f);
    }

    private void FixedUpdate()
    {
        _tutorial.gameObject.GetComponent<RectTransform>().position = water.gameObject.GetComponent<RectTransform>().position;
    }

    private void Update()
    {
        

        if (screenOrientation.isLandscape)
        {
            RestoreOriginalPosition();
            foundation.transform.localScale = Vector3.one;
        }
        else
        {
            CenterHorizontal();
            foundation.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        }
    }

    void CenterHorizontal()
    {
        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);

        Camera uiCamera = null;
        Canvas canvas = _rectTransform_vertical.GetComponentInParent<Canvas>();
        if (canvas != null && canvas.renderMode == RenderMode.ScreenSpaceCamera)
        {
            uiCamera = canvas.worldCamera;
        }

        Vector2 localPoint;
        RectTransform parentRect = _rectTransform_vertical.parent as RectTransform;

        bool success = RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentRect,
            screenCenter,
            uiCamera,
            out localPoint);

        if (success)
        {
            Vector3 currentPos = _rectTransform_vertical.localPosition;
            _rectTransform_vertical.localPosition = new Vector3(localPoint.x, currentPos.y, currentPos.z);
        }
    }

    public void RestoreOriginalPosition()
    {
        _rectTransform_vertical.localPosition = originalLocalPosition;
    }

    public void ShowObjWhenPressWater()
    {
        if(objSpawnWhenPressFire.activeSelf == false && objSpawnWhenPressWater.activeSelf == false)
        {
            _tutorial.SetBool("TapAnim", false);
            tapToPlay.gameObject.SetActive(false);
            objSpawnWhenPressWater.SetActive(true);
            water.SetActive(false);
            fire.SetActive(false);
            door.SetActive(true);
            stairs.SetActive(true);
            select_1.SetActive(false);
            select_2.SetActive(true);
            iconWood.Play("WasteOfResources");
            Invoke("GoodChoise", 0.1f);
            Invoke("NextChoise", 1.5f);
            Invoke("Tutorial", 5f);
        }
    }

    public void ShowObjWhenPressFire()
    {
        _tutorial.SetBool("TapAnim", false);
        tapToPlay.gameObject.SetActive(false);
        objSpawnWhenPressFire.SetActive(true);
        water.SetActive(false);
        fire.SetActive(false);
        door.SetActive(true);
        stairs.SetActive(true);
        select_1.SetActive(false);
        select_2.SetActive(true);
        iconWood.Play("WasteOfResources");
        Invoke("GoodChoise", 0.1f);
        Invoke("NextChoise", 1.5f);
        Invoke("Tutorial", 5f);
    }

    public void ShowObjWhenPressDoor()
    {
        if(objSpawnWhenPressStairs.activeSelf == false && objSpawnWhenPressDoor.activeSelf == false)
        {
            _tutorial.SetBool("TapAnim", false);
            objSpawnWhenPressDoor.SetActive(true);
            select_2.SetActive(false);
            select_3.SetActive(true);
            door.SetActive(false);
            stairs.SetActive(false);
            hammock.SetActive(true);
            flag.SetActive(true);
            iconWood.Play("WasteOfResources_1");
            iconWood.Play("EmptyWoodResources");
            buttonsSpawn.Play("idle");
            Invoke("WellDone", 0.1f);
            Invoke("NextChoise", 1.5f);
            Invoke("Tutorial", 5f);
        }
    }

    public void ShowObjWhenPressStairs()
    {
        if(objSpawnWhenPressDoor.activeSelf == false && objSpawnWhenPressStairs.activeSelf == false)
        {
            _tutorial.SetBool("TapAnim", false);
            objSpawnWhenPressStairs.SetActive(true);
            select_2.SetActive(false);
            select_3.SetActive(true);
            door.SetActive(false);
            stairs.SetActive(false);
            hammock.SetActive(true);
            flag.SetActive(true);
            iconWood.Play("WasteOfResources_1");
            iconWood.Play("EmptyWoodResources");
            buttonsSpawn.Play("idle");
            Invoke("WellDone", 0.1f);
            Invoke("NextChoise", 1.5f);
            Invoke("Tutorial", 5f);
        }
    }

    public void ShowObjWhenPressHammock()
    {
        _tutorial.SetBool("TapAnim", false);
        _buttonHammock.gameObject.SetActive(false);
        _buttonFlag.gameObject.SetActive(false);
        Invoke("OutOfMaterial", 0.5f);
    }

    public void ShowObjWhenPressFlag()
    {
        _tutorial.SetBool("TapAnim", false);
        _buttonHammock.gameObject.SetActive(false);
        _buttonFlag.gameObject.SetActive(false);
        Invoke("OutOfMaterial", 0.5f);
    }

    public void GoodChoise()
    {
        success.gameObject.SetActive(true);
        success_text.text = "Good choice!";
        success.Play("Success");
    }
    public void WellDone()
    {
        success.gameObject.SetActive(true);
        success_text.text = "Well done!";
        success.Play("Success");
    }

    public void NextChoise()
    {
        success.Play("idleSuccess");
        success.gameObject.SetActive(false);
    }

    public void OutOfMaterial()
    {
        _tutorial.SetBool("TapAnim", false);
        outOfMaterial.gameObject.SetActive(true);
        outOfMaterial.Play("outOfMaterial");
        Invoke("NextPart", 1.5f);
    }

    public void NextPart()
    {
        hammock.SetActive(false);
        flag.SetActive(false);
        outOfMaterial.gameObject.SetActive(false);
        _tutorial.gameObject.SetActive(false);
        _tutorial.SetBool("TapAnim", false);
        Controller.Complite(this.gameObject);
    }

    private void Tutorial()
    {
        if(water.activeSelf == false && fire.activeSelf == false && door.activeSelf == false && stairs.activeSelf == false && hammock.activeSelf == false && flag.activeSelf == false) return; //todo: add other obj (if need)

        _tutorial.gameObject.SetActive(true);
        _tutorial.SetBool("TapAnim", true);
    }
}
