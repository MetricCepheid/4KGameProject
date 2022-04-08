 using UnityEngine;
 using UnityEngine.Events;
 
 public class CheatCodes : MonoBehaviour
 {
 private string[] cheatCode;
 private int index;

 public GameObject VideoTestButton;
 
 void Start() {
     // Code is "idkfa", user needs to input this in the right order
     cheatCode = new string[] { "v", "i", "d", "e", "o" };
     index = 0;    
 }
 
 void Update() {
     // Check if any key is pressed
     if (Input.anyKeyDown) {
         // Check if the next key in the code is pressed
         if (Input.GetKeyDown(cheatCode[index])) {
             // Add 1 to index to check the next key in the code
             index++;
         }
         // Wrong key entered, we reset code typing
         else {
             index = 0;    
         }
     }
     
     // If index reaches the length of the cheatCode string, 
     // the entire code was correctly entered
     if (index == cheatCode.Length) {
         // Cheat code successfully inputted!
         // Unlock crazy cheat code stuff
        VideoTestButton.SetActive(true);
     }
 }
 }