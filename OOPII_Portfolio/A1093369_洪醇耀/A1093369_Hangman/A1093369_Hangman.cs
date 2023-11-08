using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class A1093369_Hangman
{
    static void Main(string[] args)
    {
        List<string> wordLibrary = PrepareWordLibrary();
        string answer = GetRandomWord(wordLibrary);//獲得題目
        string guessedWord = new string(Enumerable.Repeat("[ ]", answer.Length).SelectMany(s => s).ToArray());
        string correctLetters = new string('_', answer.Length);//建立一個題目總長的替代字串，用以後續顯示題目用
        int incorrectGuesses = 0;
        List<char> guessedLetters = new List<char>();//存放猜過的字母

        Console.WriteLine("開始猜字遊戲、提示 " + answer.Length + " 長度為: " + guessedWord);

        while (incorrectGuesses < 5)
        {
            Console.Write("輸入你要猜的字母-a~z 任一個英文單字 ex:a : ");
            char guess = char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();

            if (!char.IsLetter(guess))
            {
                Console.WriteLine("輸入錯誤請重新輸入！");
                continue;
            }

            if (guessedLetters.Contains(guess))
            {
                Console.WriteLine("你已經猜過這個字母了。");
                continue;
            }

            //將猜過的字母儲存起來
            guessedLetters.Add(guess);

            if (answer.Contains(guess))
            {
                for (int i = 0; i < answer.Length; i++)
                {
                    if (answer[i] == guess)
                    {
                        correctLetters = correctLetters.Remove(i, 1).Insert(i, guess.ToString());
                    }
                }

                guessedWord = GetGuessedWord(answer, correctLetters);
                Console.WriteLine("你猜對了！: " + guessedWord);

                if (!guessedWord.Contains("[ ]"))
                {
                    Console.WriteLine("你猜對了！答案是 " + answer);
                    break;
                }
            }
            else
            {
                incorrectGuesses++;
                DrawHangman(incorrectGuesses);
                Console.WriteLine("你猜錯了！");

                if (incorrectGuesses == 5)
                {
                    Console.WriteLine("你輸了");
                }
            }
        }
        Console.ReadKey();
    }

    //隨機重提庫中抽出一個題目
    static string GetRandomWord(List<string> wordList)
    {
        Random random = new Random();
        int index = random.Next(wordList.Count);
        return wordList[index];
    }

    //把文字做替換，讓顯示出來的狀況是符合題目要求的
    static string GetGuessedWord(string answer, string correctLetters)
    {
        string guessedWord = "";
        //如果有出現猜對的字母就把原字串中的_改成[猜中的字]
        for (int i = 0; i < answer.Length; i++)
        {
            if (correctLetters[i] == '_')
            {
                guessedWord += "[ ]";
            }
            else
            {
                guessedWord += "[" + correctLetters[i] + "]";
            }
        }
        return guessedWord;
    }

    //建立題庫
    static List<string> PrepareWordLibrary()
    {
        List<string> wordLibrary = new List<string>
        {
            "onion", "apple", "banana", "cherry", "date", "fig", "grape"
        };
        return wordLibrary;
    }

    //畫圖並隨次數並更樣式
    private static void DrawHangman(int counter)
    {
        List<string> drawBase = new List<string>();
        drawBase.Add(@"--------");
        drawBase.Add(@"       |");
        drawBase.Add(@"       O");
        drawBase.Add(@"      /|\ ");
        drawBase.Add(@"      / \ ");
        Console.WriteLine("============");
        for (int i = 0; i < counter; i++)
        {
            Console.WriteLine(drawBase[i]);
        }
        Console.WriteLine("============");
    }
}


