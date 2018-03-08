using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Data.Scripts
{
    public class ResourceController : MonoBehaviour
    {

        private UnityEvent addResourceEvent = new UnityEvent();
        private UnityEvent removeResourceEvent = new UnityEvent();

        public UnityEvent AddResourceEvent
        {
            get { return addResourceEvent; }
        }

        public UnityEvent RemoveResourceEvent
        {
            get { return removeResourceEvent; }
        }
        
        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update () {

        }

        public void AddResource()
        {
            addResourceEvent.Invoke();
        }
        public void RemoveResource()
        {
            removeResourceEvent.Invoke();
        }
    }
}
