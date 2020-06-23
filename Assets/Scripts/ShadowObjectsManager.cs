using System.Collections.Generic;
using UnityEngine;

namespace UniformAcceleration
{
    public class ShadowObjectsManager
    {
        private int shadowNum = 100;
        private int showNum = 0;
        private List<GameObject> shadowObjects = new List<GameObject>();


        public void Init(GameObject gameObject)
        {
            for (int i = 0; i < shadowNum; i++)
            {
                GameObject go = GameObject.Instantiate(gameObject);
                go.SetActive(false);
                shadowObjects.Add(go);
            }
        }

        public void UnableAllObjects()
        {
            showNum = 0;
            foreach (var shadow in shadowObjects)
            {
                shadow.SetActive(false);
            }
        }

        public void AbleObject(Vector3 position)
        {
            if (showNum == shadowNum)
            {
                return;
            }

            shadowObjects[showNum].transform.position = position;
            shadowObjects[showNum].SetActive(true);
            showNum++;
        }
    }
}