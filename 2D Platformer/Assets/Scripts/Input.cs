using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]private Canvas _pauseMenuPrefab;

    private KeyCode _requiredKey = KeyCode.Escape;

    private bool _enabled = false;

    private Canvas _pauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(_requiredKey) && _enabled == false)
        {
            _pauseMenu = Instantiate(_pauseMenuPrefab);
            _enabled = true;
        }
        else if (Input.GetKeyDown(_requiredKey) && _enabled == true)
        {
            Destroy(_pauseMenu.gameObject);
            _enabled = false;
        }
                           
    }
}
