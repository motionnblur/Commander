using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class Commander
{
    public List<Command> commandList = new List<Command>();


    public void AddCommand(Action method)
    {
        Command command = new Command(method);
        commandList.Add(command);
    }
    public void AddCommand(Action method, float seconds, MonoBehaviour monoBehaviour)
    {
        Command command = new Command(method, seconds, monoBehaviour);
        commandList.Add(command);
    }

    public void RemoveCommand(Command command)
    {
        commandList.Remove(command);
    }

    public void ExecuteCommands()
    {
        foreach (Command command in commandList.ToList())
        {
            command.Execute();
        }
    }
}

class Command
{
    Action method;
    float seconds;
    MonoBehaviour monoBehaviour;

    public Command(Action method)
    {
        this.method = method;
    }
    public Command(Action method, float seconds, MonoBehaviour monoBehaviour)
    {
        this.method = method;
        this.seconds = seconds;
        this.monoBehaviour = monoBehaviour;
    }

    public void Execute()
    {
        if (monoBehaviour == null)
        {
            method();
        }
        else
        {
            monoBehaviour.StartCoroutine(ExecuteCoroutine());
        }

    }
    public IEnumerator ExecuteCoroutine()
    {
        yield return new WaitForSeconds(seconds);
        method();
    }
}