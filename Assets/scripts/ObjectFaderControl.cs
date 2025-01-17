using System.Collections.Generic;
using UnityEngine;

/*
Put this script on the camera and it will work with the ObjectFader script to make the
Objects between the camera and the player fade
*/
public class ObjectFaderControl : MonoBehaviour
{
    private List<RaycastHit> notPlayerHits;
    private List<RaycastHit> notPlayerPreviousHits;
    void Start()
    {
        notPlayerPreviousHits = new List<RaycastHit>();
    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if(player != null) {
            Vector3 direction = player.transform.position - transform.position;
            Debug.DrawRay(transform.position, direction * 10, Color.red);
            Ray ray = new Ray(transform.position, direction);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit)) {
                // Debug.Log(hit.collider.gameObject);
                // Debug.Log(GameObject.FindGameObjectWithTag("Player"));
                if(hit.collider == null) {
                    return;
                }

                
                if(hit.collider.gameObject != player) {

                    notPlayerHits = new List<RaycastHit>(Physics.RaycastAll(ray));

                    //check if the previous objects that are between the camera and the player
                    //are still there. If not object fade = false
                    foreach(RaycastHit notPlayerPreviousHit in notPlayerPreviousHits) {
                        if(!notPlayerHits.Contains(notPlayerPreviousHit)){
                            ObjectFader notFade = notPlayerPreviousHit.collider.gameObject.GetComponent<ObjectFader>();
                            if(notFade != null){
                                notFade.doFade = false;
                            }
                        }
                    }

                    //make the objets that are between the player and the camera fade
                    foreach(RaycastHit notPlayerHit in notPlayerHits) {
                        ObjectFader trueFade = notPlayerHit.collider.gameObject.GetComponent<ObjectFader>();
                        if(trueFade != null) {
                            trueFade.doFade = true;
                        }
                    }

                    notPlayerPreviousHits.Clear();
                    notPlayerPreviousHits.AddRange(notPlayerHits);
                   
                } else {
                    foreach(RaycastHit notPlayerPreviousHit in notPlayerPreviousHits) {
                        ObjectFader notFade = notPlayerPreviousHit.collider.gameObject.GetComponent<ObjectFader>();
                        if(notFade != null) {
                            notFade.doFade = false;
                        }
                    }

                    notPlayerPreviousHits.Clear();
                }

            }
        } else {
            Debug.Log("Player not found!!!");
        }
    }
}
