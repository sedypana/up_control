using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace REG_MARK_LIB
{
    public class Mark_Lib
    {
        public static bool ex = true;
        public static readonly HashSet<int> validRegions = new HashSet<int>
        {
            01, 101, 02, 102, 702, 03, 103, 04, 104, 05, 105, 06, 106, 07, 107, 08, 108, 09, 109, 10, 110, 11, 111, 12, 112, 13, 113, 14, 114,
            15, 115, 16, 116, 716, 17, 117, 18, 118, 19, 119, 21, 121, 22, 122, 23, 93, 123, 193, 24, 124, 25, 125, 26, 126, 27, 127, 28, 128,
            29, 129, 30, 130, 31, 131, 32, 132, 33, 133, 34, 134, 35, 135, 36, 136, 37, 137, 38, 138, 39, 139, 40, 140, 41, 141, 42, 142, 43,
            143, 44, 144, 45, 145, 46, 146, 47, 147, 48, 148, 49, 149, 50, 90, 150, 190, 750, 790, 51, 151, 52, 152, 252, 53, 153, 54, 154, 55,
            155, 56, 156, 57, 157, 58, 158, 59, 159, 60, 61, 161, 761, 62, 162, 63, 163, 763, 64, 164, 65, 165, 66, 96, 196, 67, 167, 68, 168,
            69, 169, 70, 170, 71, 171, 72, 172, 73, 173, 74, 174, 774, 75, 76, 77, 97, 99, 177, 197, 199, 777, 797, 799, 78, 98, 178, 198, 79,
            80, 180, 81, 181, 82, 83, 84, 184, 85, 185, 86, 186, 87, 88, 94, 89, 92, 95, 195, 995
        };
        public static readonly HashSet<char> lowlatter = new HashSet<char>
        {
            'а', 'в', 'е', 'к', 'м', 'н', 'о', 'р', 'с', 'т', 'у', 'х'
        };
        public static readonly HashSet<char> biglatter = new HashSet<char>
        {
            'А', 'В', 'Е', 'К', 'М', 'Н', 'О', 'Р', 'С', 'Т', 'У', 'Х'
        };

        public static Boolean CheckMark(string mark)
        {
            bool result = false;
            string patern = @"^[А, В, Е, К, М, Н, О, Р, С, Т, У, Х, а, в, е, к, м, н, о, р, с, т, у, х,A-Z,a-z]\d{3}[А, В, Е, К, М, Н, О, Р, С, Т, У, Х, а, в, е, к, м, н, о, р, с, т, у, х,A-Z,a-z]{2}(\d{2,3})$";
            Match match = Regex.Match(mark, patern);
            if (!match.Success)
            {
                result = false;
            }
            int region = int.Parse(match.Groups[1].Value);
            result = validRegions.Contains(region);
            return result;

        }

        public static string GetNextMarkAfter(string mark)
        {
            string patern = @"^([А, В, Е, К, М, Н, О, Р, С, Т, У, Х, а, в, е, к, м, н, о, р, с, т, у, х,A-Z,a-z])(\d{3})([А, В, Е, К, М, Н, О, Р, С, Т, У, Х, а, в, е, к, м, н, о, р, с, т, у, х,A-Z,a-z]{2})(\d{2,3})$";
            Match match = Regex.Match(mark, patern);
            if (!match.Success)
            {
                Console.WriteLine("некорректный ввод");
                return "uncorrect input";
            }

            string firstLatter = match.Groups[1].Value;
            int number = int.Parse(match.Groups[2].Value);
            string lastLatter = match.Groups[3].Value;
            int region = int.Parse(match.Groups[4].Value);

            ex = validRegions.Contains(region);
            if (ex)
            {
                if (number < 999)
                {
                    number++;
                }
                else
                {
                    lastLatter = Incrementlatter(lastLatter);
                    if (lastLatter == "AA" || lastLatter == "aa" || lastLatter == "АА" || lastLatter == "аа")
                    {
                        firstLatter = firstInclatter(firstLatter);
                    }
                }
                if (region > 99)
                {
                mark = $"{firstLatter}{number:d3}{lastLatter}{region:d3}";

                }
                else
                {
                    mark = $"{firstLatter}{number:d3}{lastLatter}{region:d2}";
                }
                return mark;
            }
            return "uncorrect input";
        }

        public static string Incrementlatter(string latter)
        {
            char first = latter[0];
            char second = latter[1];
            string pattern = @"^([a-z])([a-z])$";
            string pattern2 = @"^([A-Z])([A-Z])$";
            Match match = Regex.Match(latter, pattern);
            Match match2 = Regex.Match(latter, pattern2);
            bool ex = lowlatter.Contains(first);
            if (match.Success)
            {
                if (second < 'z')
                {
                    second++;
                }
                else
                {
                    second = 'a';
                    if (first < 'z')
                    {
                        first++;
                    }
                    else
                    {
                        return "aa";
                    }
                }
                return $"{first}{second}";
            }
            else if (match2.Success)
            {
                if (second < 'Z')
                {
                    second++;
                }
                else
                {
                    second = 'A';
                    if (first < 'Z')
                    {
                        first++;
                    }
                    else
                    {
                        return "AA";
                    }
                }
                return $"{first}{second}";
            }

            if (!ex)
            {

                if (second < 'Х')
                {
                    second++;
                }
                else
                {
                    second = 'А';
                    if (first < 'Х')
                    {
                        first++;
                    }
                    else
                    {
                        return "АА";
                    }
                }
                return $"{first}{second}";
            }
            else
            {
                if (second < 'х')
                {
                    second++;
                }
                else
                {
                    second = 'а';
                    if (first < 'х')
                    {
                        first++;
                    }
                    else
                    {
                        return "аа";
                    }
                }
                return $"{first}{second}";
            }
        }
        public static string firstInclatter(string latter)
        {
            char first = latter[0];
            string pattern = @"^[a-z]$";
            string pattern2 = @"^[A-Z]$";
            Match match = Regex.Match(latter, pattern);
            Match match2 = Regex.Match(latter, pattern2);
            bool ex = lowlatter.Contains(first);
            if (match.Success)
            {
                if (first < 'z')
                {
                    first++;
                }
                else
                {
                    first = 'a';
                }
            }
            else if (match2.Success)
            {
                if (first < 'Z')
                {
                    first++;
                }
                else
                {
                    first = 'A';
                }
            }
            else
            {
                if (!ex)
                {
                    if (first < 'Х')
                    {
                        first++;
                    }
                    else
                    {
                        first = 'А';
                    }
                }
                else
                {
                    if (first < 'х')
                    {
                        first++;
                    }
                    else
                    {
                        first = 'а';
                    }
                }

            }
            return $"{first}";
        }

        public static string GetNextMarkAfterInRange(string prevMark, string rangeStart, string rangeEnd)
        {
            if (!CheckMark(prevMark) || !CheckMark(rangeStart) || !CheckMark(rangeEnd))
            {
                Console.WriteLine("некорректный ввод");
                return prevMark;
            }

            string nextMark = IncrementMark(prevMark, rangeStart, rangeEnd);
            return nextMark;
        }

        static string IncrementMark(string mark, string rangeStart, string rangeEnd)
        {
            string patern = @"^([А, В, Е, К, М, Н, О, Р, С, Т, У, Х, а, в, е, к, м, н, о, р, с, т, у, х,A-Z,a-z])(\d{3})([А, В, Е, К, М, Н, О, Р, С, Т, У, Х, а, в, е, к, м, н, о, р, с, т, у, х,A-Z,a-z]{2})(\d{2,3})$";
            Match match = Regex.Match(mark, patern);
            Match match_min = Regex.Match(rangeStart, patern);
            Match match_max = Regex.Match(rangeEnd, patern);

            char firstLatter = match.Groups[1].Value[0];
            int number = int.Parse(match.Groups[2].Value);
            string lastLatter = match.Groups[3].Value;
            int region = int.Parse(match.Groups[4].Value);

            char firstLatter_min = match_min.Groups[1].Value[0];
            int number_min = int.Parse(match_min.Groups[2].Value);
            string lastLatter_min = match_min.Groups[3].Value;
            string region_min = match_min.Groups[4].Value;

            char firstLatter_max = match_max.Groups[1].Value[0];
            int number_max = int.Parse(match_max.Groups[2].Value);
            string lastLatter_max = match_max.Groups[3].Value;
            string region_max = match_max.Groups[4].Value;


            Mark_Lib.ex = true;
            if (number < number_max)
            {
                number++;
            }
            else if (lastLatter != "ZZ")
            {

                lastLatter = IncrementLetters(lastLatter, lastLatter_max, ex);
            }
            if(!ex)
            {
                if (firstLatter < firstLatter_max)
                {
                    firstLatter++;
                    lastLatter = "AA";
                    number = 001;
                }
                else
                {
                    return "out of stock";
                }
            }
            
            if (region > 99)
            {
            return $"{firstLatter}{number:d3}{lastLatter}{region:d3}";

            }
            else
            {
                return $"{firstLatter}{number:d3}{lastLatter}{region:d2}";
            }
        }

        static string IncrementLetters(string letters, string letters_max, bool ex)
        {
            char first = letters[0];
            char second = letters[1];

            char first_max = letters_max[0];
            char second_max = letters_max[1];

            if (second < second_max)
            {
                second++;
                return $"{first}{second}";
            }
            else if (first < first_max)
            {
                first++;
                second = 'A';
                return $"{first}{second}";
            }
            Mark_Lib.ex = false;
            return $"{first}{second}";
        }

        public static int GetCombinationsCountInRange(string mark1, string mark2)
        {
            int count = 0;

            while (mark1 != mark2)
            {
                mark1 = IncrementMark1(mark1, mark2);
                if (mark1 == "out of stock")
                {
                    break;
                }
                count++;
            }

            return count;
        }

        static string IncrementMark1(string mark, string mark2)
        {
            string patern = @"^([А, В, Е, К, М, Н, О, Р, С, Т, У, Х, а, в, е, к, м, н, о, р, с, т, у, х,A-Z,a-z])(\d{3})([А, В, Е, К, М, Н, О, Р, С, Т, У, Х, а, в, е, к, м, н, о, р, с, т, у, х,A-Z,a-z]{2})(\d{2,3})$";
            Match match = Regex.Match(mark, patern);
            char firstLatter = match.Groups[1].Value[0];
            int number = int.Parse(match.Groups[2].Value);
            string lastLatter = match.Groups[3].Value;
            int region = int.Parse(match.Groups[4].Value);

            Match match2 = Regex.Match(mark2, patern);
            char firstLatter2 = match2.Groups[1].Value[0];
            int number2 = int.Parse(match2.Groups[2].Value);
            string lastLatter2 = match2.Groups[3].Value;
            int region2 = int.Parse(match2.Groups[4].Value);

            Mark_Lib.ex = true;
            if (number < number2)
            {
                number++;
            }
            else if (lastLatter != lastLatter2 || lastLatter == lastLatter2)
            {

                lastLatter = IncrementLetters(lastLatter, lastLatter2, ex);
            }
            if (!ex)
            {
                if (firstLatter < firstLatter2)
                {
                    firstLatter++;
                    lastLatter = "AA";
                    number = 001;
                }
                else
                {
                    return "out of stock";
                }
            }


            return $"{firstLatter}{number:d3}{lastLatter}{region}";
        }
    }
}
