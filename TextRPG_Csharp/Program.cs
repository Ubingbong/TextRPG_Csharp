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

        struct Player
         {
            public int hp;
            public int attack;
         }

        enum RPGMonsterType
        { 
            None,
            Slime,
            Orc,
            Skeleton
        }

        struct Monster
        {
            public int hp;
            public int attack;
        }

        static RPGClassType ChooseClass( )
        {
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("숫자를 입력해 직업을 선택하십시오.");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 마법사");
            Console.WriteLine("");

            int selection = Convert.ToInt32(Console.ReadLine());
           
            switch (selection)
            {
                case (int)RPGClassType.Knight:
                    return RPGClassType.Knight;

                case (int)RPGClassType.Archer:
                    return RPGClassType.Archer;

                case (int)RPGClassType.Wizard:
                    return RPGClassType.Wizard;

                default:
                    return RPGClassType.None;
            }
        }
        static Player CreatePlayer(RPGClassType myClass )
        {
            Player retState = new Player();

            switch (myClass)
            {
                case RPGClassType.Knight:
                    retState.hp = 100;
                    retState.attack = 10;
                    break;

                case RPGClassType.Archer:
                    retState.hp = 75;
                    retState.attack = 12;
                    break; 

                case RPGClassType.Wizard:
                    retState.hp = 65;
                    retState.attack = 15;
                    break;
            }

            return retState;

        }
        static Monster CreateRandomMonster()
        {
            Monster rndMonster = new Monster();

            // 랜덤으로 1~3 몬스터 중 하나를 리스폰
            Random rand = new Random();
            int randNum = rand.Next(1, 4);

            switch (randNum)
            {
                case (int)RPGMonsterType.Slime:
                    Console.WriteLine("");
                    Console.WriteLine("슬라임이 나타났습니다!");
                    Console.WriteLine("");
                    rndMonster.hp = 20;
                    rndMonster.attack = 5;
                    break;

                case (int)RPGMonsterType.Orc:
                    Console.WriteLine("");
                    Console.WriteLine("오크가 나타났습니다!");
                    Console.WriteLine("");
                    rndMonster.hp = 50;
                    rndMonster.attack = 10;
                    break;

                case (int)RPGMonsterType.Skeleton:
                    Console.WriteLine("");
                    Console.WriteLine("스켈레톤이 나타났습니다!");
                    Console.WriteLine("");
                    rndMonster.hp = 25;
                    rndMonster.attack = 7;
                    break;
                default:
                    break;
            }
            
            return rndMonster;
        }
        static void Fight(ref Player myPlayer, ref Monster enemy)
        {
            while (true)
            {
                // 몬스터의 체력이 0 이하 :: 승리
                if (enemy.hp <= 0)
                {
                    Console.WriteLine("몬스터를 물리쳤습니다!");
                    Console.WriteLine("당신이 전투에서 승리했습니다!");
                    break;
                }
                if(myPlayer.hp <=0)
                {
                    Console.WriteLine("당신은 사망했습니다.");
                    Console.WriteLine("당신이 전투에서 패배했습니다");
                    break;
                }
                // 플레이어가 몬스터를 공격
                enemy.hp -= myPlayer.attack;
                Console.WriteLine($"몬스터의 현재 체력 : {enemy.hp}");
                // 몬스터가 플레이어를 공격
                myPlayer.hp -= enemy.attack;
                Console.WriteLine($"당신의 현재 체력 : {myPlayer.hp}");
            }
        }
        static void EnterField(ref Player myPlayer)
        {
            while (true)
            {
                if (myPlayer.hp <= 0)
                    return;

                Console.WriteLine("");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("블랙 체리 던전에 입장했습니다.");
                Console.WriteLine("-------------------------------------");

                Monster monster;
                monster = CreateRandomMonster();

                Console.WriteLine("[1] 전투 모드로 돌입");
                Console.WriteLine("[2] 마을로 도망");
                Console.WriteLine("");

                string input = Console.ReadLine();

                // 전투모드
                if (input == "1")
                {
                    Fight(ref myPlayer, ref monster);
                }
                // 33%의 확률로 도망
                else if (input == "2")
                {
                    Random rnd = new Random();
                    int randValue = rnd.Next(0, 100);

                    if (randValue <= 33)
                    {
                        Console.WriteLine("도망치는데 성공했습니다!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("도망치는데 실패했습니다! 전투모드에 돌입합니다");
                        Fight(ref myPlayer, ref monster);
                    }
                }
            }
        }
        static void EnterGame( ref Player myPlayer)
        {
            while (true)
            {
              
                Console.WriteLine("");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("캔들 마을에 오신 걸 환영합니다!!");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("[1] 블랙 체리 던전으로 간다");
                Console.WriteLine("[2] 로비로 돌아간다");
                Console.WriteLine("");

                string input = Console.ReadLine();

                switch (input)
                {
                    // 던전으로 접속
                    case "1":
                        EnterField(ref myPlayer);
                        break;

                    // 초기 메뉴로 돌아감
                    case "2":
                        return;
                }

                if (myPlayer.hp <= 0)
                    return;
            }
        }
        static void Main(string[] args)
        {
            // 플레이어 정보 저장할 변수
            RPGClassType myClass = RPGClassType.None;
            Player myPlayer;

            while (true)
            {
                // 직업 선택
                myClass = Program.ChooseClass();

                if (myClass != RPGClassType.None)
                {

                    // 캐릭터 생성
                    myPlayer = CreatePlayer(myClass);
                    Console.WriteLine($"HP {myPlayer.hp} Attack {myPlayer.attack}");

                    EnterGame(ref myPlayer);
                }
            }
        }
    }
}
