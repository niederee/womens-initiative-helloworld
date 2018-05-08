using System;

namespace HelloWorld
{
    public class ConditionalService
    {
        public bool ConditionalBool(bool boolParam)
        {
            if (!boolParam)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ConditionalString(string stringParam)
        {
            Console.WriteLine("Evaluating " + stringParam);
            if (stringParam == "Hello World")
            {
                return true;
            }
            else if (stringParam == "Hello Class")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}