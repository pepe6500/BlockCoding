using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variable
{
    public string name;
    public float val;
}

public class TextToNum
{
    static public List<Variable> variables = new List<Variable>();

    public static void SetVar(string name, float val)
    {
        foreach (Variable temp in variables)
        {
            if (name == temp.name)
            {
                temp.val = val;
                return;
            }
        }
        Variable variable = new Variable();
        variable.name = name;
        variable.val = val;
        variables.Add(variable);
        return;
    }

    public static void AddVar(string name, float val)
    {
        foreach (Variable temp in variables)
        {
            if (name == temp.name)
            {
                temp.val += val;
                return;
            }
        }
        Variable variable = new Variable();
        variable.name = name;
        variable.val = val;
        variables.Add(variable);
        return;
    }

    public static void MinusVar(string name, float val)
    {
        foreach (Variable temp in variables)
        {
            if (name == temp.name)
            {
                temp.val -= val;
                return;
            }
        }
        Variable variable = new Variable();
        variable.name = name;
        variable.val = -val;
        variables.Add(variable);
        return;
    }

    public static void ResetVar()
    {
        variables.Clear();
        return;
    }

    public static float pos(string text)
    {
        bool ch = false;
        

        if(text == "")
        {
            return 0;
        }
        if (text[0] == '\\')
        {
            foreach(Variable temp in variables)
            {
                if(text == temp.name)
                {
                    return temp.val;
                }
            }
            return 0;
        }
        for (int i = 0; i < text.Length; i++)
        {
            if(text[i] == '~')
            {
                ch = true;
                break;
            }
            if((text[i] < '0' || text[i] > '9') && (text[i] != '-') && (text[i] != '.'))
            {
                return 0;
            }
        }

        if(ch)
        {
            string[] temp = text.Split('~');
            return Random.Range(float.Parse(temp[0]), float.Parse(temp[1]));
        }

        return float.Parse(text);
    }
}
