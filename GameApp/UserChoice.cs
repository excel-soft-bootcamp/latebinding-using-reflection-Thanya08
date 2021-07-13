using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp
{
    class UserChoice
    {
        public int invalidInput = 0;
        public void ReadUserInput()
        {

            string displayMessage = $"Enter Your Choice {(int)Options.BASIC}->Basic,{(int)Options.INTERMEDIATE}->Intermediate,{(int)Options.ADVANCED}->Advanced";
            Console.WriteLine(displayMessage);
            try
            {
                {

                    Options _choice = (Options)Int32.Parse(Console.ReadLine());
                    invalidInput++;
                    if (invalidInput <= 2)
                        if (_choice != Options.BASIC && _choice != Options.INTERMEDIATE && _choice != Options.ADVANCED)
                        {
                            Console.WriteLine("Please enter valid number");
                            ReadUserInput();
                        }
                    CheckConditionType check = new CheckConditionType();
                    check.CheckCondition(_choice);
                }
            }
            catch
            {
                invalidInput++;
                if (invalidInput <= 2)
                {
                    Console.WriteLine("Please Enter Integer Value");

                    ReadUserInput();
                }
            }
        }
    }
}
