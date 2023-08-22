using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetObject : MonoBehaviour
{
    // Start is called before the first frame update
    private Button Button;

    private ObjectRaycast ObjectRaycastScript;

    void Start()
    {
        ObjectRaycastScript = FindObjectOfType<ObjectRaycast>();

        Button = GetComponent<Button>();
        Button.onClick.AddListener(AnchorEnables);
    }

    // Update is called once per frame
    private void AnchorEnables()
    {
        ObjectRaycastScript.SetAnchor = true;
    }
}
