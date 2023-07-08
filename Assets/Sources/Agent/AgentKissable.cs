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
            
            Debug.Log("Agent was kissed <3");
        }
    }
}