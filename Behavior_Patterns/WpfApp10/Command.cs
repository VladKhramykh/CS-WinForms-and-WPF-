using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp10
{
    class Command
    {
    }

    interface ICommand
    {
        void Execute();
        void Undo();
    }

    //receiver Определяет действия, которые должны выполняться в результате запроса
    class TV
    {
        public void On()
        {
            MessageBox.Show("TV turn on");
        }

        public void Off()
        {
            MessageBox.Show("TV turn off");
        }
    }

    class TVonCommand : ICommand
    {
        TV tv;
        public TVonCommand(TV tvSet)
        {
            tv = tvSet;
        }

        public void Execute()
        {
            tv.On();
        }

        public void Undo()
        {
            tv.Off();
        }
    }


    class Volume
    {
        public const int OFF = 0;
        public const int HIGH = 20;
        private int level;

        public Volume()
        {
            level = OFF;
        }

        public void RaiseLevel()
        {
            if (level < HIGH)
                level++;
            MessageBox.Show($"volume level: {level}");
        }

        public void DropLevel()
        {
            if (level > OFF)
                level--;
            MessageBox.Show($"volume level: {level}");
        }
    }

    class VolumeCommand : ICommand
    {
        Volume volume;
        public VolumeCommand(Volume v)
        {
            volume = v;
        }

        public void Execute()
        {
            volume.RaiseLevel();
        }

        public void Undo()
        {
            volume.DropLevel();
        }
    }

    class NoCommand : ICommand
    {
        public void Execute()
        {

        }
        
        public void Undo()
        {

        }
    }

    class MultiPult
    {
        ICommand[] buttons;
        Stack<ICommand> commandHistory;

        public MultiPult()
        {
            buttons = new ICommand[2];
            for(int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = new NoCommand();
            }
            commandHistory = new Stack<ICommand>();
        }

        public void SetCommand(int number, ICommand com)
        {
            buttons[number] = com;
        }

        public void PressButton(int number)
        {
            //push - paste object as upper element of stack
            buttons[number].Execute();
            commandHistory.Push(buttons[number]);
        }
    
        public void PressUndoButton()
        {
            if (commandHistory.Count > 0)
            {
                //pop - delete and return started element
                ICommand undoCommand = commandHistory.Pop();
                undoCommand.Undo();
            }
        }
    }
}
