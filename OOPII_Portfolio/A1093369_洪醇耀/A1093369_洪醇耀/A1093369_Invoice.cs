using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1093369_洪醇耀
{
    class A1093369_Invoice
    {

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("請輸入發票號碼（輸入Q退出）: ");
                string userInput = Console.ReadLine();

                if (userInput.ToUpper() == "Q")
                {
                    Console.WriteLine("程式結束");
                    break;
                }

                if (userInput.Length != 8 || !IsNumeric(userInput))
                {
                    Console.WriteLine("發票號碼格式不正確，請輸入8位數字。");
                    continue;
                }

                string prize = LotteryRule(userInput);
                if (!string.IsNullOrEmpty(prize))
                {
                    Console.WriteLine("恭喜您獲得" + prize + "獎！");
                }
                else
                {
                    Console.WriteLine("沒中獎");
                }
            }

            Console.ReadKey();
        }
        //判斷輸入規則是否正確
        static bool IsNumeric(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        //判斷中獎等級
        static string LotteryRule(string userNumber)
        {
            string surpriseNo = "20783987";// 特別獎
            string specialNo = "04135859";// 特獎
            string lotteryNo1 = "94899145"; string lotteryNo2 = "71143793"; string lotteryNo3 = "41055355";// 頭獎

            if (userNumber == surpriseNo)
            {
                return "特別獎 1000萬元";
            }
            else if (userNumber == specialNo)
            {
                return "特獎 200萬元";
            }
            for (int i=0;i<5;i++) {

                string No = "";//變換頭獎號碼以利於判別
                switch (i) {
                    case 0:
                        No = lotteryNo1;
                        break;
                    case 1:
                        No = lotteryNo2;
                        break;
                    case 2:
                        No = lotteryNo3;
                        break;
                    case 3:
                        No = surpriseNo;
                        break;
                    case 4:
                        No = specialNo;
                        break;
                }

                if (userNumber == No)
                {
                    return "頭獎 20萬元";
                }
                else if (userNumber.Substring(1) == No.Substring(1))
                {
                    return "二獎 4萬元";
                }
                else if (userNumber.Substring(2) == No.Substring(2))
                {
                    return "三獎 1萬元";
                }
                else if (userNumber.Substring(3) == No.Substring(3))
                {
                    return "四獎 4千元";
                }
                else if (userNumber.Substring(4) == No.Substring(4))
                {
                    return "五獎 1千元";
                }
                else if (userNumber.Substring(5) == No.Substring(5))
                {
                    return "六獎 200元";
                }
            }
            return null;

        }
    }
}
