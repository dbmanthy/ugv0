using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
//dervied classes will be put on game objects so maintain : MonoBehaviour
public class Entity : MonoBehaviour
{
    public StateMachine stateMachine { get; private set; }
    public Animator animator { get; private set; }

    //[SerializeField]
    protected ScriptableObject entityData; 
     
    public virtual void Awake()
    {
        stateMachine = new StateMachine();
    }

    public virtual void Start()
    {
        animator = GetComponent<Animator>();
        //cant initialize state machine without a state . done in subclasses
    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }
}
