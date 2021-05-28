using CursachInf.Domain;
using CursachInf.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CursachInf.Models.ViewComponents
{
    public class ClassWithMethods
    {
        public double GetTableValueForF(double[] massive, int size)
        {
            double F_table;

            F_table = 0;
            if (size >= 1 && size < 20) F_table = massive[size - 1];
            else if (size >= 20 && size < 22) F_table = massive[19];
            else if (size >= 22 && size < 24) F_table = massive[20];
            else if (size >= 24 && size < 26) F_table = massive[21];
            else if (size >= 26 && size < 28) F_table = massive[22];
            else if (size >= 28 && size < 30) F_table = massive[23];
            else if (size >= 30 && size < 40) F_table = massive[24];
            else if (size >= 40 && size < 60) F_table = massive[25];
            else if (size >= 60 && size < 120) F_table = massive[26];
            else if (size >= 120) F_table = massive[27];
            return F_table;
        }
        public void GetTableValue(double[] massive, int size, out double t_table, out int v)
        {
            v = 0;
            t_table = 0;
            if (size == 1) v = size;
            else if (size == 2) v = 1;
            else v = size - 2;
            if (v >= 1 && v <= 80) t_table = massive[v - 1];
            else if (v > 80 && v < 90) t_table = massive[v - 1];
            else if (v >= 90 && v < 100) t_table = massive[80];
            else if (v >= 100 && v < 110) t_table = massive[81];
            else if (v >= 110 && v < 120) t_table = massive[82];

            else if (v >= 120 && v < 130) t_table = massive[83];
            else if (v >= 130 && v < 140) t_table = massive[84];
            else if (v >= 140 && v < 150) t_table = massive[85];
            else if (v >= 150 && v < 200) t_table = massive[86];

            else if (v >= 200 && v < 250) t_table = massive[87];
            else if (v >= 250 && v < 300) t_table = massive[88];
            else if (v >= 300 && v < 350) t_table = massive[89];

            else if (v >= 350) t_table = massive[90];
        }
        public RegParams GetParams(List<Koefficient> Calculations, string typeEquation = "line")
        {
            double a, a1, a2;
            a = a1 = a2 = 0.0;
            var koef = Calculations[0];
            if (typeEquation == "line")
            {
                a = ((koef.SumY * koef.SumSqrX) - (koef.SumXmultY * koef.SumX)) / ((Calculations.Count * koef.SumSqrX) - Math.Pow(koef.SumX, 2));
                a1 = ((Calculations.Count * koef.SumXmultY) - (koef.SumX * koef.SumY)) / ((Calculations.Count * koef.SumSqrX) - Math.Pow(koef.SumX, 2));
            }
            else if (typeEquation == "pokazat")
            {
                a = ((koef.SumY * koef.SumSqrX) - (koef.SumXmultY * koef.SumX)) / ((Calculations.Count * koef.SumSqrX) - Math.Pow(koef.SumX, 2));
                a1 = ((Calculations.Count * koef.SumXmultY) - (koef.SumX * koef.SumY)) / ((Calculations.Count * koef.SumSqrX) - Math.Pow(koef.SumX, 2));
                a = Math.Pow(10.0, a);
                a1 = Math.Pow(10.0, a1);
            }
            else if (typeEquation == "log")
            {
                double SumSquareLogX, SumLogXY, SumLogX;
                SumLogX = SumLogXY = SumSquareLogX = 0.0;
                foreach (var item in Calculations)
                {
                    var param = Math.Round(Math.Log(item.X), 3);
                    SumLogX += param;
                    SumLogXY += Math.Round(param * item.Y, 3);
                    SumSquareLogX += Math.Round(Math.Pow(param, 2.0), 3);
                }
                a = ((koef.SumY * SumSquareLogX) - (SumLogXY * SumLogX)) / ((Calculations.Count * SumSquareLogX) - Math.Pow(SumLogX, 2));
                a1 = ((Calculations.Count * SumLogXY) - (SumLogX * koef.SumY)) / ((Calculations.Count * SumSquareLogX) - Math.Pow(SumLogX, 2));
            }
            else if (typeEquation == "hyper")
            {
                double SumSquareX, SumXY, SumX;
                SumX = SumXY = SumSquareX = 0.0;
                foreach (var item in Calculations)
                {
                    var param = Math.Round((double)1 / item.X, 3);
                    SumX += param;
                    SumXY += Math.Round(param * item.Y, 3);
                    SumSquareX += Math.Round(Math.Pow(param, 2.0), 3);
                }
                a = ((koef.SumY * SumSquareX) - (SumXY * SumX)) / ((Calculations.Count * SumSquareX) - Math.Pow(SumX, 2));
                a1 = ((Calculations.Count * SumXY) - (SumX * koef.SumY)) / ((Calculations.Count * SumSquareX) - Math.Pow(SumX, 2));
            }
            else if (typeEquation == "parabola")
            {
                double SumXIn4, SumXIn2Y;
                SumXIn4 = SumXIn2Y = 0.0;
                foreach (var item in Calculations)
                {
                    var param = Math.Round(item.X, 3);
                    SumXIn2Y += Math.Round(Math.Pow(param, 2) * item.Y, 3);
                    SumXIn4 += Math.Round(Math.Pow(param, 4.0), 3);
                }
                a = ((SumXIn4 * koef.SumY) - (SumXIn2Y * koef.SumSqrX)) / ((Calculations.Count * SumXIn4) - (koef.SumSqrX * koef.SumSqrX));
                a1 = koef.SumXmultY / koef.SumSqrX;
                a2 = ((Calculations.Count * SumXIn2Y) - (koef.SumY * koef.SumSqrX)) / ((Calculations.Count * SumXIn4) - (koef.SumSqrX * koef.SumSqrX));
            }
            return new RegParams { A = a, A1 = a1, A2 = a2 };
        }
        public List<string> GetEquations(List<RegParams> param)
        {
            var equationArray = new List<string>();


            equationArray.Add("y=" + Math.Round(param[0].A, 3).ToString() + "+" + Math.Round(param[0].A1, 3).ToString() + "x");
            equationArray.Add("y=" + Math.Round(param[1].A, 5).ToString() + "+" + Math.Round(param[1].A1, 5).ToString() + "x" + "+" + Math.Round(param[1].A2, 6).ToString() + "x*x");
            equationArray.Add("y=" + Math.Round(param[2].A, 3).ToString() + "+" + Math.Round(param[2].A1, 3).ToString() + "1/x");
            equationArray.Add("y=" + Math.Round(param[3].A, 3).ToString() + " * " + Math.Round(param[3].A1, 3).ToString() + "^x");
            equationArray.Add("y=" + Math.Round(param[4].A, 3).ToString() + "+" + Math.Round(param[4].A1, 3).ToString() + "ln x");


            return equationArray;
        }
        public List<double> getListValEqua(RegParams item, List<Koefficient> calc, string type)
        {
            var temp = new List<double>();

            if (type == "line")
            {
                foreach (var num in calc)
                {
                    var ValueAtX = item.A + (item.A1 * num.X);
                    temp.Add(ValueAtX);
                }
            }
            else if (type == "parabola")
            {
                foreach (var num in calc)
                {
                    var ValueAtX = item.A + (item.A1 * num.X) + (item.A2 * Math.Pow(num.X, 2));
                    temp.Add(ValueAtX);
                }
            }
            else if (type == "hyper")
            {
                foreach (var num in calc)
                {
                    var ValueAtX = item.A + (item.A1 * (1 / num.X));
                    temp.Add(ValueAtX);
                }

            }
            else if (type == "pokazat")
            {
                foreach (var num in calc)
                {
                    var ValueAtX = item.A * (Math.Pow(item.A1, num.X));
                    temp.Add(ValueAtX);
                }

            }
            else if (type == "log")
            {
                foreach (var num in calc)
                {
                    var ValueAtX = item.A + (item.A1 * Math.Log(num.X));
                    temp.Add(ValueAtX);
                }

            }
            return temp;
        }
        public List<double> GetAproxError(List<RegParams> paramList, List<Koefficient> calc)
        {
            var tmpLstOfAprx = new List<double>();
            var ListOfYInX = new List<double>();
            if (paramList != null)
            {
                foreach (var item in paramList)
                {
                    if (item == paramList[0]) { ListOfYInX = getListValEqua(item, calc, "line"); }
                    if (item == paramList[1]) { ListOfYInX = getListValEqua(item, calc, "parabola"); }
                    if (item == paramList[2]) { ListOfYInX = getListValEqua(item, calc, "hyper"); }
                    if (item == paramList[3]) { ListOfYInX = getListValEqua(item, calc, "pokazat"); }
                    if (item == paramList[4]) { ListOfYInX = getListValEqua(item, calc, "log"); }
                    double SummaDif = 0;
                    for (int i = 0; i < calc.Count; i++)
                    {
                        SummaDif += Math.Abs(calc[i].Y - ListOfYInX[i]);
                    }
                    tmpLstOfAprx.Add(SummaDif / calc[0].SumY);
                }
            }
            return tmpLstOfAprx;
        }
        private List<SimpleReportViewModel> getArrrayOfValues(RegParams item, string type)
        {
            var temp = new List<SimpleReportViewModel>();

            if (type == "line")
            {
                for (int i = 0; i < 100; i++)
                {
                    var ValueAtX = item.A + (item.A1 * i);
                    temp.Add(new SimpleReportViewModel { X = i, Y = ValueAtX });
                }
            }
            else if (type == "parabola")
            {
                for (int i = 0; i < 100; i++)
                {
                    var ValueAtX = item.A + (item.A1 * i) + (item.A2 * Math.Pow(i, 2));
                    temp.Add(new SimpleReportViewModel { X = i, Y = ValueAtX });
                }
            }
            else if (type == "hyper")
            {
                for (int i = 1; i < 100; i++)
                {
                    var ValueAtX = item.A + (item.A1 * (1 / i));
                    temp.Add(new SimpleReportViewModel { X = i, Y = ValueAtX });
                }

            }
            else if (type == "pokazat")
            {
                for (int i = 0; i < 100; i++)
                {

                    var ValueAtX = item.A * (Math.Pow(item.A1, i));
                    temp.Add(new SimpleReportViewModel { X = i, Y = ValueAtX });
                }

            }
            else if (type == "log")
            {
                for (int i = 0; i < 100; i++)
                {
                    var ValueAtX = item.A + (item.A1 * Math.Log(i));
                    temp.Add(new SimpleReportViewModel { X = i, Y = ValueAtX });
                }

            }
            return temp;
        }
        public List<SimpleReportViewModel> GetArrayForGraphic(string type, RegParams equation)
        {
            var ListForReturn = new List<SimpleReportViewModel>();
            if (type == "line")
            {
                ListForReturn = getArrrayOfValues(equation, "line");

            }
            else if (type == "parabola") ListForReturn = getArrrayOfValues(equation, "parabola");
            else if (type == "hyperbola") ListForReturn = getArrrayOfValues(equation, "hyper");
            else if (type == "pokazatelnaya") ListForReturn = getArrrayOfValues(equation, "pokazat");
            else if (type == "logarifmicheskaya") ListForReturn = getArrrayOfValues(equation, "log");
            return ListForReturn;
        }
        public bool CheckString(string[] values)
        {
            int count = 0;
            try
            {
                foreach (var item in values)
                {
                    if (Convert.ToDouble(item) == Convert.ToDouble(item))
                    {
                        count++;

                    }


                }

            }
            catch (FormatException ex) { count = -1; }
            if (count == values.Length) return true;
            else return false;


        }

        public void check(double r, int n, out double result, out double AvgError)
        {
            double temp = 0;
            if (n >= 30) { temp = Math.Sqrt(1 - Math.Pow(r, 2)) / Math.Sqrt(n); }
            else { temp = Math.Sqrt(1 - Math.Pow(r, 2)) / Math.Sqrt(n - 2); }
            AvgError = temp;
            result = Math.Round(Math.Abs(r) / temp, 2);
        }

        public double Calculate_r(List<double> listOfXPoints, double avgX, List<double> listOfYPoints, double avgY)
        {
            double Summa = 0.0;
            double SummX = 0.0;
            double SummY = 0.0;
            for (int i = 0; i <= listOfXPoints.Count - 1; i++)
            {
                Summa += (listOfXPoints[i] - avgX) * (listOfYPoints[i] - avgY); //Подсчёт суммы числителя
            }

            for (int i = 0; i <= listOfXPoints.Count - 1; i++)
            {
                SummX += Math.Pow(listOfXPoints[i] - avgX, 2.0);
                SummY += Math.Pow(listOfYPoints[i] - avgY, 2.0);//Подсчёт знаменателя
            }
            double result = Summa / (Math.Sqrt(SummX * SummY));
            return Math.Round(result, 3);
        }

        public double Sum(List<int> listOfXPoints)
        {
            double Summa = 0.0;
            foreach (var item in listOfXPoints)
            {
                Summa += item;
            }
            return Math.Round(Summa, 2);
        }
        public double Sum(List<double> listOfXPoints)
        {
            double Summa = 0.0;
            foreach (var item in listOfXPoints)
            {
                Summa += item;
            }
            return Math.Round(Summa, 2);
        }
        public double Avg(List<double> listOfPoints)
        {
            double Summa = 0.0;

            foreach (var item in listOfPoints)
            {
                Summa += item;
            }
            var result = Summa / listOfPoints.Count;
            return Math.Round(result, 2);
        }
        public double Avg(List<int> listOfPoints)
        {
            double Summa = 0.0;

            foreach (var item in listOfPoints)
            {
                Summa += item;
            }
            var result = Summa / listOfPoints.Count;
            return Math.Round(result, 2);
        }


        public bool IsNumber(string InputStr)
        {

            return Regex.IsMatch(InputStr, @"[+-]?(\d+([.]\d*)?([eE][+-]?\d+)?|[.]\d+([eE][+-]?\d+)?)", RegexOptions.IgnoreCase);


        }
        public bool Check(string InputStr)
        {
            Regex r = new Regex(@"[0-9.]");

            return r.IsMatch(InputStr);


        }
        public string GetStrBfSign(string InputStr)
        {
            return InputStr.Substring(0, InputStr.IndexOf(';'));

        }
        public string ConnectionPower(double InputNumber)
        {
            var r = Math.Abs(InputNumber);
            string result = null;
            if (r > 0 && r < 0.3) result += "Cлабая";
            else if (r >= 0.3 && r <= 0.7)
            {
                result += "Средняя";
            }
            else result += "Сильная";
            if (InputNumber > 0) result += " прямая связь";
            else result += " обратная связь";
            return result;

        }
        public string GetEquationType(int index)
        {
            string result = "";
            if (index == 0) result = "line";
            else if (index == 1) result = "parabola";
            else if (index == 2) result = "hyperbola";
            else if (index == 3) result = "pokazatelnaya";
            else if (index == 4) result = "logarifmicheskaya";
            return result;
        }
        public void DeleteFiles(string filePath)
        {
            if (filePath != null)
            {
                var arrayOfPaths = Directory.GetFiles(filePath);
                if (arrayOfPaths != null)
                {
                    foreach (var item in arrayOfPaths)
                    {
                        System.IO.File.Delete(item);
                    }
                }

            }
        }

        public List<double> Rank(List<double> NumbersList, List<double> RankList)
        {
            int p = 1;
            int count = 0;

            double summ = 0;
            for (int i = 0; i < NumbersList.Count - 1; i++)
            {
                if (NumbersList[i] == NumbersList[i + 1]) { summ += p; count++; p++; }
                else if (summ != 0)
                {
                    summ += i + 1;
                    count++;
                    for (int r = 0; r < count; r++)
                    {
                        RankList.Add((double)summ / count);
                    }
                    summ = count = 0;
                    p++;
                }
                else { RankList.Add(p); p++; }
            }

            if (summ != 0)
            {
                summ += NumbersList.Count;
                RankList.Add((double)summ / (count + 1));
            }
            else { RankList.Add(NumbersList.Count); }
            return RankList;
        }
    }
}
