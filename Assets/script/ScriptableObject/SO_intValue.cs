using UnityEngine;


[CreateAssetMenu(fileName = "intValue", menuName = "Data/IntValue", order = 0)]
public class SO_intValue : ScriptableObject
{
    private int _value;

    public int Value
    {
        get => _value;
        set => _value = value;
    }
}
