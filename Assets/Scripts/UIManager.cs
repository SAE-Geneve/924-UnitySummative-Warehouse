using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class UIManager : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI collectedBoxesCount;
    [SerializeField] private TextMeshProUGUI collectibleBoxesCount;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetCollectedBoxesCount(int count)
    {
        collectedBoxesCount.text = count.ToString();
        _animator.SetTrigger("FeedbackCount");
    }
    
    public void SetCollectibleBoxesCount(int count)
    {
        collectibleBoxesCount.text = count.ToString();
        // _animator.SetTrigger("FeedbackCount");
    }
}
