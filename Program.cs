using System;

namespace Day3_CSharp_Task_NoInheritance
{
    public class Program
    {
        // ------------------ Calc ------------------
        class Calc
        {
            public int Sum(int a, int b) => a + b;
            public double Sum(double a, double b) => a + b;
            public int Sub(int a, int b) => a - b;
            public double Sub(double a, double b) => a - b;
            public int Mul(int a, int b) => a * b;
            public double Mul(double a, double b) => a * b;
            public int Div(int a, int b)
            {
                if (b == 0) return 0;
                return a / b;
            }

            public double Div(double a, double b)
            {
                if (b == 0) return 0;
                return a / b;
            }
        }

        // ------------------ Question ------------------
        class Question
        {
            public string Header { get; set; }
            public string Body { get; set; }
            public int Mark { get; set; }
            public Question() { }
            public Question(string header, string body, int mark)
            {
                Header = header;
                Body = body;
                Mark = mark;
            }
            public void Show()
            {
                Console.WriteLine($"\n[ {Header} ]");
                Console.WriteLine(Body);
                Console.WriteLine($"Mark: {Mark}");
            }
        }

        // ------------------ MCQ ------------------
        class MCQ
        {
            public string Header { get; set; }
            public string Body { get; set; }
            public int Mark { get; set; }
            public string[] Choices { get; set; }
            public int CorrectIndex { get; set; } //I added it to calculate the result

            public MCQ() { }

            public MCQ(string header, string body, int mark, string[] choices, int correctIndex)
            {
                Header = header;
                Body = body;
                Mark = mark;
                Choices = choices;
                CorrectIndex = correctIndex;
            }

            public void Show()
            {
                Console.WriteLine($"\n[ {Header} ]");
                Console.WriteLine(Body);
                Console.WriteLine($"Mark: {Mark}");
                Console.WriteLine("Choices:");
                for (int i = 0; i < Choices.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {Choices[i]}");
                }
            }
        }

        // ------------------ Main ------------------
        public static void Main(string[] args)
        {
            Calc c = new Calc();
            Console.WriteLine("Sum: " + c.Sum(5, 10));
            Console.WriteLine("Mul: " + c.Mul(3.5, 2.0));
            Console.WriteLine("---------------------");

            MCQ mcq = new MCQ("Math Q", "What is 2+2?", 5, new string[] { "2", "3", "4", "5" }, 2);
            mcq.Show();

            Console.Write("Enter your choice (1-4): ");
            int ans = int.Parse(Console.ReadLine());
            if (ans - 1 == mcq.CorrectIndex)
                Console.WriteLine("Correct!");
            else
                Console.WriteLine("Wrong!");

            Console.WriteLine("---------------------");

            Console.Write("How many questions? ");
            int n = int.Parse(Console.ReadLine());

            MCQ[] exam = new MCQ[n];
            int total = 0, score = 0;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Enter Question {i + 1} ---");

                Console.Write("Header: ");
                string header = Console.ReadLine();

                Console.Write("Body: ");
                string body = Console.ReadLine();

                Console.Write("Mark: ");
                int mark = int.Parse(Console.ReadLine());

                Console.Write("How many choices? ");
                int m = int.Parse(Console.ReadLine());
                string[] choices = new string[m];

                for (int j = 0; j < m; j++)
                {
                    Console.Write($"Choice {j + 1}: ");
                    choices[j] = Console.ReadLine();
                }

                Console.Write("Correct choice (index 1..m): ");
                int correct = int.Parse(Console.ReadLine()) - 1;

                exam[i] = new MCQ(header, body, mark, choices, correct);
            }

            Console.WriteLine("\n--- Exam Start ---");
            foreach (var ques in exam)
            {
                ques.Show();
                Console.Write("Your answer: ");
                int answer = int.Parse(Console.ReadLine());

                total += ques.Mark;
                if (answer - 1 == ques.CorrectIndex)
                    score += ques.Mark;
            }

            Console.WriteLine($"\nYour result: {score}/{total}");
        }
    }
}
