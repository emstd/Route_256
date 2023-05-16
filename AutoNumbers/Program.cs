using System.Text;

namespace AutoNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int InputData = int.Parse(Console.ReadLine());
            for (int i = 0; i < InputData; i++)
            {
                string _inputString = Console.ReadLine();
                TryToParse(_inputString);
            }
        }

        static void TryToParse(string InputString)
        {
            StringBuilder ResultString = new StringBuilder();

            int Pointer = 0;
            int endPointer = InputString.Length;

            List<char> IntermediateList = new List<char>();
            List<SymbolEnum> TransformatedQuantumList = new List<SymbolEnum>();

            List<SymbolEnum> FirstPattern = new List<SymbolEnum> {SymbolEnum.Letter,
                                                                  SymbolEnum.Number,
                                                                  SymbolEnum.Letter,
                                                                  SymbolEnum.Letter};

            List<SymbolEnum> SecondPattern = new List<SymbolEnum>() {SymbolEnum.Letter,
                                                                     SymbolEnum.Number,
                                                                     SymbolEnum.Number,
                                                                     SymbolEnum.Letter,
                                                                     SymbolEnum.Letter};
            if (endPointer >= FirstPattern.Count)
            {
                while (Pointer < endPointer - 1)
                {
                    IntermediateList.Clear();
                    TransformatedQuantumList.Clear();
                    for (int i = Pointer; i < Pointer + FirstPattern.Count; i++)
                    {
                        IntermediateList.Add(InputString[i]);
                    }
                    TransformatedQuantumList = ListTransformation(IntermediateList);
                    if (ListComparer(FirstPattern, TransformatedQuantumList))
                    {
                        for (int i = 0; i < IntermediateList.Count; i++)
                        {
                            ResultString.Append(IntermediateList[i]);
                        }
                        ResultString.Append(' ');
                        Pointer += 4;
                    }
                    else if (Pointer + SecondPattern.Count <= endPointer)
                    {
                        IntermediateList.Clear();
                        TransformatedQuantumList.Clear();
                        for (int i = Pointer; i < Pointer + SecondPattern.Count; i++)
                        {
                            IntermediateList.Add(InputString[i]);
                        }

                        TransformatedQuantumList = ListTransformation(IntermediateList);

                        if (ListComparer(SecondPattern, TransformatedQuantumList))
                        {
                            for (int i = 0; i < IntermediateList.Count; i++)
                            {
                                ResultString.Append(IntermediateList[i]);
                            }
                            ResultString.Append(' ');
                            Pointer += 5;
                        }
                        else
                        {
                            Pointer = 0;
                            ResultString.Clear().Append('-');
                            break;
                        }
                    }
                    else
                    {
                        Pointer = 0;
                        ResultString.Clear().Append('-');
                        break;
                    }
                }
            }

            if (endPointer > Pointer)
            {
                Console.WriteLine(ResultString.Clear().Append('-'));
            }
            else
            {
                Console.WriteLine(ResultString.ToString());
            }
        }


        static List<SymbolEnum> ListTransformation(List<char> Quantum)
        {
            List<SymbolEnum> _resultList = new List<SymbolEnum>();

            for (int i = 0; i < Quantum.Count; i++)
            {
                if (Char.IsLetter(Quantum[i]))
                {
                    _resultList.Add(SymbolEnum.Letter);
                }
                else if (Char.IsDigit(Quantum[i]))
                {
                    _resultList.Add(SymbolEnum.Number);
                }
            }

            return _resultList;
        }

        static bool ListComparer(List<SymbolEnum> _pattern, List<SymbolEnum> _quantumList)
        {
            bool CompareResult = Enumerable.SequenceEqual(_pattern, _quantumList);
            return CompareResult;
        }


        enum SymbolEnum
        {
            Letter,
            Number
        }
    }
}

//В Берляндии автомобильные номера состоят из цифр и прописных
//букв латинского алфавита. Они бывают двух видов:

//либо автомобильный номер имеет вид буква-цифра-цифра-
//буква-буква (примеры корректных номеров первого вида:
//R48FA, O00OO, A99OK);

//либо автомобильный номер имеет вид буква-цифра-буква-
//буква (примеры корректных номеров второго вида: T7RR, A9PQ,
//O0OO).

//Таким образом, каждый автомобильный номер является строкой либо
//первого, либо второго вида.
//Вам задана строка из цифр и прописных букв латинского алфавита.
//Можно ли разделить её пробелами на последовательность
//корректных автомобильных номеров? Иными словами, проверьте, что
//заданная строка может быть образована как последовательность
//корректных автомобильных номеров, которые записаны подряд без
//пробелов. В случае положительного ответа выведите любое такое
//разбиение.

//входные данные
//R48FAO00OOO0OOA99OKA99OK
//R48FAO00OOO0OOA99OKA99O
//A9PQ
//A9PQA
//A99AAA99AAA99AAA99AA
//AP9QA

//выходные данные
//R48FA O00OO O0OO A99OK A99OK
//-
//A9PQ
//-
//A99AA A99AA A99AA A99AA
//-