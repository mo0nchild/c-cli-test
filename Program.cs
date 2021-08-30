using System;
using System.Collections.Generic;

namespace testApp
{

    class MenuApp
    {
        private string title;
        private List<string> args;
        private int index;
        public MenuApp(string title, List<string> args)
        {
            this.args = args;
            this.title = title;
            this.index = 0;
        }

        private void UpdateFrame()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0}. index:{1}", this.title, this.index);

            for(int i = 0; i < this.args.Count; i++)
            {
                Console.ForegroundColor = (this.index == i) ? 
                    ConsoleColor.Green : ConsoleColor.White;

                Console.WriteLine("{0}{1}", 
                    (this.index == i) ? " >> ": "    ", this.args[i]);
            }
        }

        public string Run()
        {
            ConsoleKey keyPressed = ConsoleKey.Spacebar;
            while(keyPressed != ConsoleKey.Enter)
            {
                this.UpdateFrame();
                keyPressed = Console.ReadKey(true).Key;

                switch(keyPressed)
                {
                    case ConsoleKey.DownArrow:  
                        this.index = (index == args.Count - 1) ? 
                            args.Count - 1 : index + 1; 
                    break;
                    case ConsoleKey.UpArrow: 
                        this.index = (index == 0) ? 0 : index - 1;
                    break;
                    default: break;
                }             
            }

            return args[index];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var app1 = new MenuApp(
                "Hello User!",
                new List<string>(){
                    "say hello",
                    "say bye",
                    "some info"
                }
            );
            string appAnswer = app1.Run();
            var app2 = new MenuApp(
                appAnswer + " is answer in last menu",
                new List<string>(){
                    "some text 1",
                    "some text 2",
                    "some text 3",
                    "some text 4",
                    "some text 5",
                }
            );
            Console.WriteLine("{0} + {1}", appAnswer, app2.Run());

        }
    }
}
