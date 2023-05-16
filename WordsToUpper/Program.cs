namespace WordsToUpper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string testString = Console.ReadLine();
            Solution(testString);
            Console.ReadLine();
        }

        static void Solution(string testString)
        {
            string[] startWords = testString.Split(' ');
            List<string> Words = new List<string>();
            for (int i = 0; i < startWords.Length; i++)
            {
                Words.Add(startWords[i]);
            }

            var result = Words.Select(word => new string(word.ToLower()
                              .Select((letter, index) => index == 0 ? Char.ToUpper(letter) : Char.ToLower(letter)).ToArray())).ToArray<string>();

            Console.WriteLine(string.Join(' ', result));

        }
    }
}

//Слова с прописной буквы

//Условие
//На стандартный вход подается строка, содержащая слова, разделенные пробелами.
//Необходимо сделать заглавной буквой начало каждого слова в строке.
//Вывести на стандартный вывод

//Формат входных данных

//Строка

//Формат выходных данных

//Строка

//Примеры

//Входные данные:

//hEllo world!  

//Выходные данные:

//Hello World!