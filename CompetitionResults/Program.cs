
namespace CompetitionResults
{
    public class Program
    {
        static void Main(string[] args)
        {
            int DataParts = int.Parse(Console.ReadLine());                  //Количество наборов входных данных в тесте

            for (int i = 0; i < DataParts; i++)
            {
                int TotalRunners = int.Parse(Console.ReadLine());           //Первая строка каждого набора входных данных — количество спортсменов

                string[] RunnersTimeString = new string[TotalRunners];
                RunnersTimeString = Console.ReadLine().Split(' ');          //Вторая строка набора — время в секундах, сразу разбивается на массив string

                int[] RunnersTimeArray = new int[RunnersTimeString.Length];
                for (int j = 0; j < RunnersTimeString.Length; j++)           //Преобразование массива строк в массив INT32 - время каждого спортсмена в секундах
                {
                    RunnersTimeArray[j] = int.Parse(RunnersTimeString[j]);
                }

                DisplayResult(RunnersTimeArray, TotalRunners);
            }
        }

        //на входе имеем массив int32 - время каждого спортсмена
        //_runnersTime.Length - количество спортсменов (= TotalRunners)

        static void DisplayResult(int[] _runnersTime, int _totalRunners)
        {
            Runner[] FinalResult = new Runner[_totalRunners];
            ScoreBoard ScoreBoardRun = new ScoreBoard(_totalRunners);

            for (int i = 0; i < _runnersTime.Length; i++)
            {
                ScoreBoardRun.runners[i] = new Runner(i, _runnersTime[i]);
            }

            FinalResult = ScoreBoardRun.PositionDistribution(ScoreBoardRun.runners);
            foreach (var result in FinalResult)
            {
                Console.Write(result.Place + " ");
            }
            Console.WriteLine();
        }

    }

    public class Runner
    {
        public Runner(int _id, int _time, int _place = 1)
        {
            ID = _id;
            Time = _time;
            Place = _place;
        }
        public int ID { get; set; }
        public int Time { get; set; }
        public int Place { get; set; }
    }

    public class ScoreBoard
    {
        public ScoreBoard(int _totalRunners)
        {
            runners = new Runner[_totalRunners];
        }

        public Runner[] runners;

        public Runner[] PositionDistribution(Runner[] _runners)
        {
            var OrderedRunners = _runners.OrderBy(runner => runner.Time).ToArray();

            for (int i = 0; i < OrderedRunners.Length - 1; i++)
            {
                if (OrderedRunners[i].Time == OrderedRunners[i + 1].Time || OrderedRunners[i].Time + 1 == OrderedRunners[i + 1].Time)
                {
                    OrderedRunners[i + 1].Place = OrderedRunners[i].Place;
                }
                else
                {
                    OrderedRunners[i + 1].Place = i + 2;
                }
            }

            var _finalResult = OrderedRunners.OrderBy(runner => runner.ID).ToArray();

            return _finalResult;
        }

    }
}



//      В соревновании по бегу приняли участие n спортсменов:
//
//      i - й из них пробежал дистанцию за ti секунд.
//      Жюри хочет назначить места участникам по следующим
//      правилам:
//
//      - места пронумерованы от 1 и далее (лучшее место — первое);
//      
//      - если у двух спортсменов результаты одинаковые или отличаются на одну секунду,
//        то они делят место (в этом случае считаем, что они делят лучшее
//        из поделенных мест);
//      
//      - участники делят место только в результате применения предыдущего правила (возможно, несколько раз);
//      
//      - если k участников делят место p, то места следующих 
//        за ними участников нумеруются начиная с k + p.
//
//      Рассмотрите следующие примеры, чтобы понять 
//      принцип назначения мест:
//
//      - допустим, n = 4 и t = [20, 10, 20, 30], тогда места 
//        имеют вид [2,1,2,4] (второй спортсмен прибежал первым — у него первое место, первый и
//        третий поделили второе место, четвёртый занял последнее четвёртое место);
//
//      - допустим, n = 3 и t = [5, 7, 6],
//        тогда места имеют вид [1,1,1] (так как t1 = 5 и t3 = 6 отличаются на 1, то первый и третий спортсмены должны
//        занять одинаковое место, аналогично со вторым и третьим спортсменами, следовательно,
//        все трое делят первое место);
//
//      - допустим, n = 5 и t = [6, 3, 4, 3, 1], тогда места имеют вид [5,2,2,2,1] ;
//        допустим, n = 5 и t = [200, 10, 100, 11, 200], тогда места имеют вид [4,1,3,1,4].
//
//      По заданным значениям n и t1, t2,…, tn выведите последовательность мест, занятых спортсменами.
//
//      Неполные решения этой задачи (например, недостаточно 
//      эффективные) могут быть оценены частичным баллом.
//
//      Входные данные
//      В первой строке записано целое число t (1 ≤ t ≤ 1000) — количество наборов входных данных в тесте.
//      Наборы входных данных в тесте независимы. Друг на друга они никак не влияют.
//      Первая строка каждого набора входных данных содержит целое число n (1 ≤ n ≤ 2 * 10^5) — количество спортсменов.
//      Вторая строка набора содержит последовательность целых чисел t1, t2,…, tn (1 ≤ ti ≤ 10^9), где ti — время в секундах,
//      за которое i -й спортсмен пробежал дистанцию.
//      Сумма значений n по всем наборам входных данных теста не превосходит 2 ⋅ 105.
//
//      Выходные данные
//      Для каждого набора входных данных выведите n положительных чисел r1, r2,…, rn, где ri — место i-го спортсмена.
//
//
//      входные данные
//      6
//      4	
//      20 10 20 30
//      3
//      5 7 6
//      5
//      6 3 4 3 1
//      5
//      200 10 100 11 200
//      1
//      1000000000
//      11
//      13 8 12 1 7 10 1 8 10 2 17
//
//      выходные данные
//      2 1 2 4 
//      1 1 1 
//      5 2 2 2 1 
//      4 1 3 1 4 
//      1 
//      9 4 9 1 4 7 1 4 7 1 11 
