using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CursachInf.Domain.Entities;
using CursachInf.Models.ViewComponents;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CursachInf.Controllers
{
    public class HomeController : Controller
    {
        private double r;

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Parser(IFormFile file)
        {
            var Calculations = new List<Koefficient>();
            var lstModel = new List<SimpleReportViewModel>();
            var SquareXList = new List<double>();
            var SquareYList = new List<double>();
            var MultXY = new List<double>();
            var ListOfXPoints = new List<int>();
            var ListOfYPoints = new List<int>();
            if (file.FileName.EndsWith(".csv"))
            {
                using (var sreader = new StreamReader(file.OpenReadStream()))
                {
                    string[] headers = sreader.ReadToEnd().Split('\n');
                    for (int i = 0; i < headers.Length; i++)
                    {
                        if (headers[i].Contains('\r'))
                            headers[i] = headers[i].Trim('\r');
                    }

                    List<int> ElementsList = new List<int>();
                    var StringArray = new List<string>();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            if (headers[i].IndexOf(';') != -1)
                            {
                                StringArray.Add(GetStrBfSign(headers[i]));
                                headers[i] = headers[i].Substring(headers[i].IndexOf(';') + 1);
                            }
                            else break;
                        }

                    }

                    for (int i = 0; i < StringArray.Count; i++)
                    {

                        if (!IsNumber(StringArray[i]))
                        {
                            if (i % 2 == 0) StringArray.RemoveRange(i, 2);
                            else
                            {
                                StringArray.RemoveAt(i);
                                StringArray.RemoveAt(i - 1);
                            }
                        }
                    }
                    foreach (var elem in StringArray)
                    {

                        int.TryParse(elem, out int num);
                        ElementsList.Add(num);
                        /*ElementsList.Sort();*/

                    }

                    for (int i = 0; i < ElementsList.Count - 1; i += 2)
                    {
                        ListOfXPoints.Add(ElementsList[i]);
                        ListOfYPoints.Add(ElementsList[i + 1]);
                    }
                    for (int i = 0; i < ListOfXPoints.Count - 1; i++)
                    {
                        int count = 0;
                        for (int j = 0; j < ListOfXPoints.Count - 1; j++)
                        {
                            if (ListOfXPoints[i] == ListOfXPoints[j])
                            {
                                if (ListOfYPoints[i] == ListOfYPoints[j])
                                {
                                    count++;
                                }
                            }
                            if (count == 2)
                            {
                                ListOfXPoints.RemoveAt(j);
                                ListOfYPoints.RemoveAt(j);
                            }
                        }

                    }
                    ListOfXPoints.Sort();
                    ListOfYPoints.Sort();

                    if (ListOfXPoints.Count == ListOfYPoints.Count)
                    {
                        for (int i = 0; i < ListOfXPoints.Count; i++)
                            lstModel.Add(new SimpleReportViewModel
                            {
                                X = ListOfXPoints[i],
                                Y = ListOfYPoints[i]
                            });
                    }
                    else return NotFound();

                    for (int i = 0; i < ListOfXPoints.Count; i++)
                    {
                        SquareXList.Add(Math.Pow(ListOfXPoints[i], 2.0));
                        SquareYList.Add(Math.Pow(ListOfYPoints[i], 2.0));
                        MultXY.Add(ListOfXPoints[i] * ListOfYPoints[i]);

                    }

                    r = Calculate_r(ListOfXPoints, Avg(ListOfXPoints), ListOfYPoints, Avg(ListOfYPoints));
                    for (int i = 0; i < ListOfXPoints.Count; i++)
                    {
                        Calculations.Add(new Koefficient
                        {
                            X = ListOfXPoints[i],
                            Y = ListOfYPoints[i],
                            SquareX = SquareXList[i],
                            SquareY = SquareYList[i],
                            XmultY = MultXY[i],
                            SumX = Sum(ListOfXPoints),
                            SumY = Sum(ListOfYPoints),
                            SumSqrX = Sum(SquareXList),
                            SumSqrY = Sum(SquareYList),
                            SumXmultY = Sum(MultXY),
                            AvgX = Avg(ListOfXPoints),
                            AvgY = Avg(ListOfYPoints),
                            AvgSqrX = Avg(SquareXList),
                            AvgSqrY = Avg(SquareYList),
                            AvgXmultY = Avg(MultXY),
                            r = Calculate_r(ListOfXPoints, Avg(ListOfXPoints), ListOfYPoints, Avg(ListOfYPoints)),
                            Connection = ConnectionPower(r)
                        }) ;

                    }


                    var listX = new List<double>();
                    var listY = new List<double>();
                    foreach (var item in lstModel) { listX.Add(item.X); listY.Add(item.Y); }
                    ViewBag.DataPoints1 = listX;
                    ViewBag.DataPoints2 = listY;

                }
                return View(Calculations);
                /* return View(lstModel);*/

            }
            else return RedirectToAction("Index");

        }



        private double Calculate_r(List<int> listOfXPoints, double avgX, List<int> listOfYPoints, double avgY)
        {
            double Summa = 0.0;
            double SummX = 0.0;
            double SummY = 0.0;
            for (int i = 0; i < listOfXPoints.Count - 1; i++)
            {
                Summa += (listOfXPoints[i] - avgX) * (listOfYPoints[i] - avgY); //Подсчёт суммы числителя
            }
            for (int i = 0; i < listOfXPoints.Count - 1; i++)
            {
                SummX += Math.Pow(listOfXPoints[i] - avgX, 2.0);
                SummY += Math.Pow(listOfYPoints[i] - avgY, 2.0);//Подсчёт знаменателя
            }
            double result = Summa / (Math.Sqrt(SummX * SummY));
            return Math.Round(result,2);
        }

        private double Sum(List<int> listOfXPoints)
        {
            double Summa = 0.0;
            foreach (var item in listOfXPoints)
            {
                Summa += item;
            }
            return Math.Round(Summa, 2);
        }
        private double Sum(List<double> listOfXPoints)
        {
            double Summa = 0.0;
            foreach (var item in listOfXPoints)
            {
                Summa += item;
            }
            return Math.Round(Summa, 2);
        }
        private double Avg(List<double> listOfPoints)
        {
            double Summa = 0.0;

            foreach (var item in listOfPoints)
            {
                Summa += item;
            }
            var result=Summa / listOfPoints.Count;
            return Math.Round(result, 2);
        }
        private double Avg(List<int> listOfPoints)
        {
            double Summa = 0.0;

            foreach (var item in listOfPoints)
            {
                Summa += item;
            }
            var result = Summa / listOfPoints.Count;
            return Math.Round(result,2);
        }


        public bool IsNumber(string InputStr)
        {

            return Regex.IsMatch(InputStr, @"^\d+$", RegexOptions.IgnoreCase);


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


    }
}
