using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelScore : MonoBehaviour
{
   
    
    [SerializeField] private Image _blankElements;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private SO_intValue _value;

    private void FixedUpdate()
    {
            
        if (_value.Value >= 3) _value.Value = 3;
        
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
        for (int item = 0; item < _value.Value; item++)
        {
            _blankElements.sprite = _sprite;
            Instantiate(_blankElements, this.transform);
        }
    }
}
