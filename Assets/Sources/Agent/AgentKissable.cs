using System.Collections;
using UnityEngine;

namespace Sources.Agent
{
    public class AgentKissable: MonoBehaviour
    {
        public GameObject agent;

        private void Awake()
        {
            Debug.Assert(null != agent);
        }

        public void ReceiveKiss()
        {
            agent.GetComponent<MeshRenderer>().material.color = Color.red;
            agent.GetComponent<Agent>().pacified = true;

            StartCoroutine(BlinkAgent());
            
            Debug.Log("Agent was kissed <3");
        }

        IEnumerator BlinkAgent()
        {
            var renderer = agent.GetComponent<MeshRenderer>();
            var stopTime = Time.time + 2f;
            var initialColor = renderer.material.color;
            var flashColor = Color.gray;

            for (int i = 0; i < 5; i++)
            {
                renderer.material.color = flashColor;

                yield return new WaitForSeconds(0.4f);

                renderer.material.color = initialColor;

                yield return new WaitForSeconds(0.4f);
            }
        }
    }
}