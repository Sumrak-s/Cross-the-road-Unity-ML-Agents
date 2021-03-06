using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class PlayerAgent : Agent
{
    private float moveSpeed = 3f;
    private float turnSpeed = 5f;
    private float lastDistance;
    private float currentDistance;

    private Animator animator;
    private SkinnedMeshRenderer skinnedMeshRenderer;

    [SerializeField] private Color defaultColor;
    [SerializeField] private Color winColor;


    public override void Initialize()
    {
        animator = GetComponent<Animator>();
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    public override void OnEpisodeBegin()
    {
        transform.localPosition = new Vector3(-2f, 0.5f, Random.Range(45, 55));
        transform.localRotation = Quaternion.Euler(0f, Random.Range(-180f, 180f), 0f);

        lastDistance = 22f - transform.localPosition.x;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition); // 3
        sensor.AddObservation(transform.localRotation); // 4
        sensor.AddObservation(currentDistance); // 1
    }
    
    /// <summary>
    /// dActions[0] | (0) - Nothing, (1) - Running forward, (2) - Running back
    /// dActions[1] | (0) - Turn left, (1) - Turn right, (2) - Nothing
    /// </summary>
    /// <param name="actions"></param>
    public override void OnActionReceived(ActionBuffers actions)
    {
        var dActions = actions.DiscreteActions;

        if (dActions[0] == 0)
        {
            animator.SetBool("isRunning", false);
        }
        else if (dActions[0] == 1)
        {
            animator.SetBool("isRunning", true);
            transform.Translate(Vector3.forward * moveSpeed * Time.fixedDeltaTime);
        }
        else if (dActions[0] == 2)
        {
            animator.SetBool("isRunning", true);
            transform.Translate(-Vector3.forward * (moveSpeed / 2f) * Time.fixedDeltaTime);
        }

        if (dActions[1] == 0) transform.Rotate(new Vector3(0f, -1f, 0f) * turnSpeed);
        else if(dActions[1] == 1) transform.Rotate(new Vector3(0f, 1f, 0f) * turnSpeed);

        currentDistance = 22f - transform.localPosition.x;

        if (currentDistance < lastDistance)
        {
            AddReward(0.05f);
            lastDistance = currentDistance;
        }
        else
        {
            AddReward(-0.005f);
        }

        if (transform.localPosition.x > 22f)
        {
            AddReward(5f);
            skinnedMeshRenderer.material.color = winColor;
            EndEpisode();
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var actions = actionsOut.DiscreteActions;

        if (Input.GetKey(KeyCode.W))
        {
            actions[0] = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            actions[0] = -1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            actions[0] = 2;
        }

        actions[1] = 2;

        if (Input.GetKey(KeyCode.A))
        {
            actions[1] = 0;
        }
        if (Input.GetKey(KeyCode.D))
        {
            actions[1] = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car") || other.gameObject.CompareTag("EndRoad"))
        {
            AddReward(-5f);
            skinnedMeshRenderer.material.color = defaultColor;
            EndEpisode();
        }
    }
}
