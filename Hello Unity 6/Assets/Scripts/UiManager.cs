using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public int CurrentIndex { get; private set; }

    [SerializeField] private Text _info;

    private int _numberOfPrefabs;

    public void Inititalize(int numberOfPrefabs)
    {
        _numberOfPrefabs = numberOfPrefabs; 
    }

    public void SwapLeft()
    {
        CurrentIndex = Mathf.Clamp(CurrentIndex - 1, 0, _numberOfPrefabs - 1);
        UpdateTextInfo();
    }

    public void SwapRight()
    {
        CurrentIndex = Mathf.Clamp(CurrentIndex + 1, 0, _numberOfPrefabs - 1);
        UpdateTextInfo();
    }

    private void UpdateTextInfo()
    {
        _info.text = CurrentIndex.ToString();
    }
}