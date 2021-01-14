using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG_Csharp.TextRPG2
{
    public enum GameMode
    { 
        None,
        Lobby,
        Town,
        Field
    }
    class Game
    {
        private GameMode mode = GameMode.Lobby;
        private Player player = null;
        private Monster monster = null;
        Random rand = new Random();

        public void Process()
        {
            switch (mode)
            {
                case GameMode.Lobby:
                    ProcessLobby();
                    break;

                case GameMode.Town:
                    ProcessTown();
                    break;

                case GameMode.Field:
                    ProcessField();
                    break;
            }
        }

        private void ProcessLobby()
        {
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("숫자를 입력해 직업을 선택하십시오.");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 마법사");
            Console.WriteLine("");

            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    player = new Knight();
                    mode = GameMode.Town;
                    break;
                case 2:
                    player = new Archer();
                    mode = GameMode.Town;
                    break;
                case 3:
                    player = new Mage();
                    mode = GameMode.Town;
                    break;
            }
        }
        private void ProcessTown()
        {
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("마을에 오신 걸 환영합니다!!");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("[1] 필드로 간다");
            Console.WriteLine("[2] 로비로 돌아간다");
            Console.WriteLine("");

            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    mode = GameMode.Field;
                    break;
                case 2:
                    mode = GameMode.Lobby;
                    break;
            }
        }
        private void ProcessField()
        {
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("필드에 입장했습니다.");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("[1] 전투 모드로 돌입");
            Console.WriteLine("[2] 마을로 돌아가기");
            Console.WriteLine("");

            CreateRandomMonster();

            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    ProcessFight();
                    break;
                case 2:
                    TryEscape();
                    break;
                    
            }
        }
        private void ProcessFight()
        {
            while (true)
            {
                int damage = player.GetAttack();
                monster.OnDamage(damage);
                Console.WriteLine("당신의 공격!");
                Console.WriteLine($"몬스터의 체력: {monster.GetHp()}");

                if (monster.IsDead())
                {
                    Console.WriteLine("승리했습니다.");
                    Console.WriteLine($"당신의 체력: {player.GetHp()}");
                    break;
                }

                damage = monster.GetAttack();
                player.OnDamage(damage);
                Console.WriteLine("몬스터의 공격!");
                Console.WriteLine($"당신의 체력: {player.GetHp()}");
                if (player.IsDead())
                {
                    Console.WriteLine("패배했습니다.");
                    mode = GameMode.Lobby;
                    break;
                }
            }
        }
        private void TryEscape()
        {
            int rndNum = rand.Next(0, 101);
            if (rndNum < 33)
            {
                Console.WriteLine("마을로 돌아가는데 성공했습니다.");
                mode = GameMode.Town;
            }
            else
            {
                Console.WriteLine("마을로 돌아가는데 실패했습니다.\n");
                Console.WriteLine("전투모드에 돌입합니다.");

                ProcessFight();
            }
        }
        private void CreateRandomMonster()
        {
            int rndNum = rand.Next(0, 3);

            switch (rndNum)
            {
                case 0:
                    monster = new Slime();
                    Console.WriteLine("슬라임이 생성되었습니다.");
                    break;
                case 1:
                    monster = new Orc();
                    Console.WriteLine("오크가 생성되었습니다.");
                    break;
                case 2:
                    monster = new Skeleton();
                    Console.WriteLine("해골이 생성되었습니다.");
                    break;
            }
        }
    }
}
