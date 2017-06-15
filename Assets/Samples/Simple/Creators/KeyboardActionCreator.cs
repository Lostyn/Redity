using UnityEngine.UI;
using React;

public class KeyboardActionCreator {

	public static ExpendoObject ToggleMaj()
    {
        ExpendoObject action = new ExpendoObject();
        action["type"] = KeyboardActionTypes.TOOGLE_MAJ;

        return action;
    }

    public static ExpendoObject RemoveChar()
    {
        ExpendoObject action = new ExpendoObject();
        action["type"] = KeyboardActionTypes.REMOVE_CHAR;

        return action;
    }

    public static ExpendoObject AddChar(string letter)
    {
        ExpendoObject action = new ExpendoObject();
        action["type"] = KeyboardActionTypes.ADD_CHAR;
        action["char"] = letter;

        return action;
    }

    public static ExpendoObject SetTarget(Text text)
    {
        ExpendoObject action = new ExpendoObject();
        action["type"] = KeyboardActionTypes.SET_TARGET;
        action["target"] = text;

        return action;
    }

    public static ExpendoObject Valid()
    {
        ExpendoObject action = new ExpendoObject();
        action["type"] = KeyboardActionTypes.VALID;

        return action;
    }
}
