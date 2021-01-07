using System;

namespace TextRPG_Csharp
{
    class Program
    {
        enum RPGClassType
        {
            None,
            Knight,
            Archer,
            Wizard
        }

        class CharacterState
         {
            public int hp;
            public int attack;
         }

        static int ChoosingClass( )
        {
            Console.WriteLine("숫자를 입력해 직업을 선택하십시오.");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 마법사");

            int selection = Convert.ToInt32(Console.ReadLine());
           
            switch (selection)
            {
                case (int)RPGClassType.Knight:
                    return selection;

                case (int)RPGClassType.Archer:
                    return selection;

                case (int)RPGClassType.Wizard:
                    return selection;

                default:
                    return (int)RPGClassType.None;
            }
        }

        static CharacterState CreatePlayer(int myClass )
        {
            CharacterState retState = new CharacterState();

            switch (myClass)
            {
                case (int)RPGClassType.Knight:
                    retState.hp = 100;
                    retState.attack = 10;
                    break;

                case (int)RPGClassType.Archer:
                    retState.hp = 75;
                    retState.attack = 12;
                    break; 

                case (int)RPGClassType.Wizard:
                    retState.hp = 65;
                    retState.attack = 15;
                    break;
            }

            return retState;

        }

        static void Main(string[] args)
        {
            int myClass = (int)RPGClassType.None;
            CharacterState myState;

            // 직업 선택
            while (myClass == (int)RPGClassType.None)
                myClass = Program.ChoosingClass();

            // 캐릭터 생성
            myState = CreatePlayer(myClass);
            Console.WriteLine(myState.hp);
            Console.WriteLine(myState.attack);
        }
    }
}
