using UnityEngine;

namespace Sources.Agent
{
    public class AgentPettable: MonoBehaviour
    {
        public GameObject agent;

        private void Awake()
        {
            
            Debug.Assert(null != agent);
        }

        public void ReceivePetting()
        {
            agent.GetComponent<MeshRenderer>().material.color = Color.yellow;
            
            Debug.Log("Agent was petted <3");
        }
    }
}