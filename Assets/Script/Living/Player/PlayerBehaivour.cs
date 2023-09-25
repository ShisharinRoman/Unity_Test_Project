using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaivour : BaseBehaivour
{
    protected override void dead()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        base.dead();
    }
}
