using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieInTaggedZone : MonoBehaviour
{
    [SerializeField]
    private string Tag;
    [SerializeField]
    private GameObject GameManager;
    private GameUIManager _gameUIManager;
    private bool _counted = false;
    public void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        _gameUIManager = GameManager.GetComponent<GameUIManager>();
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tag))
        {
            Destroy();
            if (!_counted)
            {
                _gameUIManager.IncrementScore();
                _counted = !_counted;
            }
        }
    }
}
