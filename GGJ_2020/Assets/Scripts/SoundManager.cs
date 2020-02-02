using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public void PlayASoundOnRemove(string name)
    {
        switch (name)
        {
            case "Antenna" :
                AkSoundEngine.PostEvent("Saw", Camera.main.gameObject);
                break;
            case "Flipper" :
                AkSoundEngine.PostEvent("Scalpel", Camera.main.gameObject);
                break;
            case "Nail" :
                AkSoundEngine.PostEvent("Crowbar", Camera.main.gameObject);
                break;
            case "Plug" :
                AkSoundEngine.PostEvent("Crokcrew", Camera.main.gameObject);
                break;
            case "Screw" :
                AkSoundEngine.PostEvent("Screwdriver", Camera.main.gameObject);
                break;
            case "Sparadras" :
                AkSoundEngine.PostEvent("Hand", Camera.main.gameObject);
                break;
            case "Button" :
                AkSoundEngine.PostEvent("Pliers", Camera.main.gameObject);
                break;
            case "Banana" :
                AkSoundEngine.PostEvent("Monkey", Camera.main.gameObject);
                break;
        }
    }
    
    public void PlayASoundOnAdd(string name)
    {
        switch (name)
        {
            case "Antenna" :
                AkSoundEngine.PostEvent("Antenna", Camera.main.gameObject);
                break;
            case "Flipper" :
                AkSoundEngine.PostEvent("Fish", Camera.main.gameObject);
                break;
            case "Nail" :
                AkSoundEngine.PostEvent("Nail", Camera.main.gameObject);
                break;
            case "Plug" :
                AkSoundEngine.PostEvent("Bouchon", Camera.main.gameObject);
                break;
            case "Screw" :
                AkSoundEngine.PostEvent("Screw", Camera.main.gameObject);
                break;
            case "Sparadras" :
                AkSoundEngine.PostEvent("Sparadrap", Camera.main.gameObject);
                break;
            case "Button" :
                AkSoundEngine.PostEvent("Bouton", Camera.main.gameObject);
                break;
            case "Banana" :
                AkSoundEngine.PostEvent("Banana", Camera.main.gameObject);
                break;
        }
    }
}
