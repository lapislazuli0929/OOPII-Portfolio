using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1093369_洪醇耀
{
    class A1093369_1A2B
    {
        static void Main(string[] args)
        {
            Console.WriteLine("歡迎參加猜數字遊戲！");
            string answer = GameAnswer();
            bool gameRunning = true;

            while (gameRunning)
            {
                Console.Write("請輸入你的猜測（輸入Q退出遊戲）: ");
                string guess = Console.ReadLine().ToUpper();

                if (guess == "Q")
                {
                    Console.WriteLine("遊戲結束，正確答案是：" + answer);
                    gameRunning = false;
                }
                else if (guess == "AAAA")
                {
                    Console.WriteLine("恭喜回答正確！！！");
                }
                else if (IsValidGuess(guess))
                {
                    string result = CheckGuess(answer, guess);
                    Console.WriteLine("結果：" + result);
                }
                else
                {
                    Console.WriteLine("輸入格式錯誤請重新輸入（輸入Q退出遊戲）");
                }
            }

            Console.ReadKey();
        }

        //生成遊戲答案
        static string GameAnswer()
        {
            Random random = new Random();
            List<int> digits = new List<int>();

            while (digits.Count < 4)
            {
                int digit = random.Next(10);
                if (!digits.Contains(digit))//判斷是否重複數字
                {
                    digits.Add(digit);
                }
            }

            return string.Join("", digits);//回傳字串型態
        }


        static string CheckGuess(string answer, string guess)
        {
            int A = 0;
            int B = 0;

            for (int i = 0; i < 4; i++)
            {
                if (answer[i] == guess[i])
                {
                    A++;
                }
                else if (answer.Contains(guess[i]))
                {
                    B++;
                }
            }

            string check = A + "A" + B + "B";
            return check;
        }

        //判斷書入格式是否正確
        static bool IsValidGuess(string guess)
        {
            if (guess.Length != 4)
            {
                return false;
            }

            foreach (char c in guess)
            {
                if (!char.IsDigit(c) || guess.IndexOf(c) != guess.LastIndexOf(c)) //判斷書入是否都為數字以及判斷是否存在重複數字
                {
                    return false;
                }
            }

            return true;
        }
    }
}

