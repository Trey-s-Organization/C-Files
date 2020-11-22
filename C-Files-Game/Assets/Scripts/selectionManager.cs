﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "selectable";
    [SerializeField] private Material highlightedMaterial;
    [SerializeField] private Material defaultMaterial;
    private Transform _selection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;

        }
        //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var ray = Camera.current.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightedMaterial;
                }
                _selection = selection;
            }
        }
    }
}
