using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp
{
    class Program
    {
        //Named Constants
        //Constant Value is - int
        public enum Options
        {
            BASIC = 1, INTERMEDIATE, ADVANCED
        }
        static void Main(string[] args)

        {
            int cnt = 0;
            Console.WriteLine("Word Guess Game");
            inputt();
            void inputt()
            {
                string message = string.Format("Enter Your Choice {0}->Basic , {1}->Intermediate ,{2}->Advanced", Options.BASIC, Options.INTERMEDIATE, Options.ADVANCED);// 1->Basic,2->Intermediate
                                                                                                                                                                         //String Interpollation 
                string displayMessage = $"Enter Your Choice {(int)Options.BASIC}->Basic,{(int)Options.INTERMEDIATE}->Intermediate,{(int)Options.ADVANCED}->Advanced";
                Console.WriteLine(displayMessage);
                int value = Int32.Parse(Console.ReadLine());
                //Options _choice = Options.value;
                if (value >= 4)
                {
                    cnt = cnt + 1;
                    if(cnt<=2)
                    { 
                    Console.WriteLine("Invalid choice");
                    inputt();
                        
                     }
                    return;
                    
                }
                switch (value)
                {
                    case 1:

                        Console.WriteLine("Basic Level");
                        //Use Reflection  
                        //Assembly Load
                        System.Reflection.Assembly basicLevelLib =
          System.Reflection.Assembly.LoadFile(@"C:\Users\thanya.n\source\repos\Example\LevelLibs\BasicLevelLib.dll");
                        // Search For Class - BasicLevelT
                        System.Type basicLevelTypeClassRef = basicLevelLib.GetType("BasicLevelLib.BasicLevelType");
                        
                        if (basicLevelTypeClassRef != null)
                        {
                            if (basicLevelTypeClassRef.IsClass)
                            {
                                //Instantiate Type
                                //BasicLevelLib.BasicLevelType objref=new BasicLevelLib.BasicLevelType() ; Early Binding
                                Object objRef = System.Activator.CreateInstance(basicLevelTypeClassRef); //LateBinding Code
                                                                                                         //Discove Method
                                System.Reflection.MethodInfo _methodRef = basicLevelTypeClassRef.GetMethod("Play");
                                if (!_methodRef.IsStatic)
                                {
                                    //Invoke NonStatic Method
                                    // string Play(string playerName, int earlierPoints){}
                                    //object result=  _methodRef.Invoke(objRef, new object[] {"Tom",20 });
                                    object result = _methodRef.Invoke(objRef, new object[] { });
                                    Console.WriteLine(result.ToString());
                                }

                            }

                        }
                        break;
                    case 2:
                        Console.WriteLine("Intermediate Level");
                        System.Reflection.Assembly intermediateLevelLib =
          System.Reflection.Assembly.LoadFile(@"C:\Users\thanya.n\source\repos\Example\LevelLibs\IntermediateLevelLib.dll");
                        System.Type intermediateLevelTypeClassRef = intermediateLevelLib.GetType("IntermediateLevelLib.IntermediateLevelType");
                        if (intermediateLevelTypeClassRef != null)
                        {
                            if (intermediateLevelTypeClassRef.IsClass)
                            {
                                Object objRef = System.Activator.CreateInstance(intermediateLevelTypeClassRef);
                                System.Reflection.MethodInfo _methodRef = intermediateLevelTypeClassRef.GetMethod("Start");
                                if (!_methodRef.IsStatic)
                                {
                                    object result = _methodRef.Invoke(objRef, new object[] {"Tom"});
                                    Console.WriteLine(result.ToString());
                                }
                            }
                        }

                            break;
                    case 3:
                        Console.WriteLine("Advanced Level");
                        System.Reflection.Assembly advancedLevelLib =
         System.Reflection.Assembly.LoadFile(@"C:\Users\thanya.n\source\repos\Example\LevelLibs\AdvancedLevelLib.dll");
                        System.Type advancedLevelTypeClassRef = advancedLevelLib.GetType("AdvancedLevelLib.AdvancedLevelType");
                        if (advancedLevelTypeClassRef != null)
                        {
                            if (advancedLevelTypeClassRef.IsClass)
                            {
                                Object objRef = System.Activator.CreateInstance(advancedLevelTypeClassRef);
                                System.Reflection.MethodInfo _methodRef = advancedLevelTypeClassRef.GetMethod("Begin");
                                if (!_methodRef.IsStatic)
                                {
                                    object result = _methodRef.Invoke(objRef, new object[] {"Mark",10 });
                                    Console.WriteLine(result.ToString());
                                }
                            }
                        }
                        break;

                }

                Console.ReadKey();
            }
        }
    }
}
