using UnityEngine;

public class PartOne : MonoBehaviour
{
    public GeneralControl Controller;
    public ScreenOrientation screenOrientation;
    public GameObject spear;

    public Animator player;
    public AudioSource playerAudio;

    public SpriteRenderer Shark;
    public Animator AnimationSharkBite;
    public Animator tapToPlay;


    public Animator success;

    public Animator _tutorial;

    private bool nextPart = false;

    private void Start()
    {
        tapToPlay.gameObject.SetActive(true);
        tapToPlay.Play("Scale");
        Invoke("Tutorial", 5f);
    }

    private void Update()
    {
        if (screenOrientation.isLandscape)
        {
            spear.transform.localPosition = new Vector3(4.39999962f, -1.74000001f, -1f);
        }
        else
        {
            spear.transform.localPosition = new Vector3(3.3499999f, -1.74000001f, -1f);
        }
    }

    public void Attack()
    {
        _tutorial.SetBool("TapAnim", false);
        _tutorial.gameObject.SetActive(false);
        tapToPlay.gameObject.SetActive(false);
        nextPart = true;
        player.Play("Attack");
        playerAudio.Play();
        SharkDied();
    }

    public void SharkDied()
    {
        AnimationSharkBite.StopPlayback();
        AnimationSharkBite.Play("Transparament");
        Invoke("NextPart", 1f);
    }

    private void AutomaticComplitePart()
    {
        if(!nextPart)
            Attack();
    }


    private void NextPart()
    {
        Shark.gameObject.SetActive(false);
        success.gameObject.SetActive(true);
        success.Play("Success");
        Invoke("Wait", 2f);
    }

    private void Wait() 
    {
        _tutorial.SetBool("TapAnim", false);
        success.gameObject.SetActive(false);
        Controller.Complite(this.gameObject);
    }

    private void Tutorial()
    {
        if (!nextPart)
        {
            _tutorial.gameObject.SetActive(true);
            _tutorial.SetBool("TapAnim", true);
        }
    }

}
