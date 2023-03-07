using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class AddClasses : MonoBehaviour
{
    public string ClassesCommaSeparated;
    List<string> classes = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        // gameObject.AddToClassList("test");
        // visualElement.AddToClassList("test");
        // UIElement vis = gameObject.GetComponent<UIElement>();
        // vis.AddToClassList("test");
        if (ClassesCommaSeparated.Length > 0) {
            // string[] classArr = ClassesCommaSeparated.Split(',');
            classes = ClassesCommaSeparated.Split(',').ToList();
            // Debug.Log(classArr[0]);
            Debug.Log(classes[0]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
