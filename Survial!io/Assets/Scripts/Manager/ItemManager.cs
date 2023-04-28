using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private GameManager _gameManager;

    public GameManager GameManager
    {
        private get => _gameManager;
        set
        {
            _gameManager = value;
        }
    }

}

