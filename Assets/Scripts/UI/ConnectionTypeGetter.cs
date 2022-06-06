using UnityEngine;
using Fusion;
using TMPro;

public class ConnectionTypeGetter : MonoBehaviour
{
    private NetworkRunner _runner;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (_runner == null)
        {
            _runner = FindObjectOfType<NetworkRunner>();
        }

        if (_runner != null)
        {
            _text.text = "Connection type: " + _runner.CurrentConnectionType.ToString();
        }
    }
}
