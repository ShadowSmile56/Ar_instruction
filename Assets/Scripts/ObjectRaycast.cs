using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class ObjectRaycast : MonoBehaviour
{
    //--------------����������----------------------------
    // ������, ������� ����� ����������� �� �������
    public GameObject Anchor;
    public GameObject Nout;
    public GameObject InteractableObject;
    public GameObject NB;
    public GameObject Base;
    public GameObject Bolt_in1;
    public GameObject Bolt_in2;
    public GameObject Bolt_in3;
    public GameObject Bolt_in4;
    public GameObject Bolt_in5;
    public GameObject Bolt_in6;
    public GameObject OZU_1;
    public GameObject OZU_2;
    public GameObject SSD;
    public GameObject HDD;
    public GameObject ACUM;
    public GameObject Vid;
    public TextMeshProUGUI Opisanie;
    public GameObject Vent_1;
    public GameObject Vent_2;
    public VideoPlayer videoPlayer;
    private bool isactive=false;
    private int run=0;


    // ���������� ������, �� ������� ����� �������� ����

    private Vector2 TouchPosition;
    private bool y=false;
    public Camera cameraAR;

    public bool SetAnchor;
    public bool ObjectCreated = false;

    private Quaternion YRotation;

    private ARTrackedImageManager ARTrackedImageManagerScript;
    public Animator animator;


    private string currentAnimation;

    private void Awake()
    {
        // �������� ������ �� ������, , ���������� �� ������������ ����������� (�����) 
        ARTrackedImageManagerScript = FindObjectOfType<ARTrackedImageManager>();
        //animator = GetComponent<Animator>();
    }
    void Start()
    {
        

    }
    void ChangeAnimation(string animation)
    {
        if (currentAnimation == animation) return;
        animator.Play(animation);
        currentAnimation = animation;
    }
    //----------------------------------------------------
    void Update()
    {
       
        Anchor = GameObject.FindWithTag("Anchor");
        Anchor.name = "Anchor";
        // Vid = GameObject.FindWithTag("VID");
        //Vid.SetActive(false);
        //videoPlayer = Vid.GetComponent<VideoPlayer>();
        if (SetAnchor)
        {
            Instantiate(Nout, Anchor.transform.position, Anchor.transform.rotation);
            Opisanie.text = "����� ������� �������, ������� �� ������ ������ ";
            ARTrackedImageManagerScript.SetTrackablesActive(false);
            //Opisanie.GetComponent<Text>().text = "����� ������� �������, ������� �� ������ ������ ";
            SetAnchor = false;
            ObjectCreated = true;
            Vid = GameObject.FindWithTag("VID");
            Vid.SetActive(false);
            videoPlayer = Vid.GetComponent<VideoPlayer>();
        }

        if (!SetAnchor || ObjectCreated )
        {
           
            //Opisanie.text = "����� ������� ��������� �� ������ ������-�� �������������� ������� �� ��� �������������";
            InteractableObject = GameObject.FindWithTag("InteractableObject");
            InteractableObject.name = "InteractableObject";
            NB = GameObject.FindWithTag("NB");
            NB.name = "NB";
            Base = GameObject.Find("NB/BASE");
            Vent_1 = GameObject.Find("NB/Vent_1");
            Vent_2 = GameObject.Find("NB/Vent_2");
            Bolt_in1 = GameObject.Find("NB/BOLTS/Bolt_in1");
            Bolt_in2 = GameObject.Find("NB/BOLTS/Bolt_in2");
            Bolt_in3 = GameObject.Find("NB/BOLTS/Bolt_in3");
            Bolt_in4 = GameObject.Find("NB/BOLTS/Bolt_in4");
            Bolt_in5 = GameObject.Find("NB/BOLTS/Bolt_in5");
            Bolt_in6 = GameObject.Find("NB/BOLTS/Bolt_in6");
            OZU_1 = GameObject.FindWithTag("OZU_1");
            OZU_1.name = "OZU_1";
            OZU_2 = GameObject.FindWithTag("OZU_2");
            OZU_2.name = "OZU_2";
            SSD = GameObject.Find("NB/SSD");
            HDD = GameObject.Find("NB/HDD");
            ACUM = GameObject.FindWithTag("ACUM");
            ACUM.name = "ACUM";
            animator = NB.GetComponent<Animator>();

            bool isAnimating = animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f;
            if (y) {
                if (!isactive) { 
            if (!isAnimating)
            {
                    Opisanie.text = "����� ������� ��������� �� ������ ������-�� ��������������, ������� �� ��� �������������";
                }
            }
            }
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    Ray ray = cameraAR.ScreenPointToRay(touch.position);
                    RaycastHit hitObject;

                    if (Physics.Raycast(ray, out hitObject))
                    {
                        if (hitObject.transform.name == "BASE" )
                        {
                            Base.transform.position+= new Vector3(0,0.25f,0);
                            ChangeAnimation("B_I_O");
                            Opisanie.text = "���������� ������� � ������� ������";
                            y = true;
                        }
                        if (hitObject.transform.name == "OZU_2" || hitObject.transform.name == "OZU_1")
                        {
                            ChangeAnimation("OZU");
                            Opisanie.text = "��������� ���������� ����� � ��������� ���";
                        }
                        if (hitObject.transform.name == "SSD")
                        {
                            ChangeAnimation("SSD");
                            Opisanie.text = "���������� ������ � ��������� SSD";
                        }
                        if (hitObject.transform.name == "HDD")
                        {
                            ChangeAnimation("HDD");
                            Opisanie.text = "���������� ������ � ��������� HDD, ����� ��������� ������� � ������� � �������� HDD �� �����";
                        }
                        if (hitObject.transform.name == "ACUM")
                        {
                            ChangeAnimation("ACUM");
                            Opisanie.text = "��������� ������� � ���������� �������, ����� ����� �������� ����������";
                        }
                        if (hitObject.transform.name == "Vent_1" || hitObject.transform.name == "Vent_2")
                        {

                            if (!isactive) {
                                Opisanie.text = "����� ��������� ����� �� ����� ������� �� ����, ����� ���������, ������� �� ������ ��� ���";
                                Vid.SetActive(true);
                                videoPlayer.Play();
                                isactive = true;
                            }
                            else
                            {
                                videoPlayer.Stop();
                                Vid.SetActive(false);
                                isactive = false;
                            }
                        }
                        if (hitObject.transform.name == "Vid")
                        {
                            if (videoPlayer.isPlaying)
                            {
                                videoPlayer.Pause();
                            }
                            else
                            {
                                videoPlayer.Play();
                            }
                            
                        }
                    }

                }
                
            }
        }
    }
}