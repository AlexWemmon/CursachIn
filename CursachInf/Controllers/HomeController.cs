using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using ClosedXML.Excel;
using CursachInf.Domain.Entities;
using CursachInf.Models.ViewComponents;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace CursachInf.Controllers
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;

        }
        private double r;
        public IActionResult SecondStep()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot");
            var file = Directory.GetFiles(filePath);
            string fileName = null;
            if (file.Length > 1)
            {
                for (int i = 0; i < file.Length; i++)
                {
                    for (int j = 0; j < file.Length; j++)
                    {

                        var time_i = System.IO.File.GetCreationTime(file[i]);
                        var time_j = System.IO.File.GetCreationTime(file[j]);
                        if (time_i > time_j) fileName = file[i];
                        else fileName = file[j];
                    }
                }
            }
            else fileName = file[0];
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            var calc = JsonConvert.DeserializeObject<Koefficient>(System.IO.File.ReadAllText
                (Path.Combine(sWebRootFolder, fileName)));
            var Calculations = calc.Koefficients;
            var ListOfX = new List<double>();
            var ListOfY = new List<double>();
            var XRanks = new List<double>();
            var YRanks = new List<double>();
            var dRanks = new List<double>();
            var SquareDRanks = new List<double>();
            var SpearmanList = new List<SpearmanKoeff>();
            foreach (var item in Calculations)
            {
                ListOfX.Add(item.X);
                ListOfY.Add(item.Y);
            }

            var tempListY = new List<double>();
            foreach (var item in ListOfY) { tempListY.Add(item); }
            tempListY.Sort();
            var tempXRanks = Rank(ListOfX, XRanks);
            var tempYRanks = Rank(tempListY, YRanks);
            var list = new List<double>();
            foreach (var item in tempListY) { list.Add(item); }
            for (int i = 0; i < tempListY.Count; i++)
            {
                for (int j = 0; j < ListOfY.Count; j++)
                {
                    if (tempListY[i] == ListOfY[j]) { list[j] = tempXRanks[i]; }
                }
            }
            YRanks = list;

            double temp;
            double SummaSquad = 0;
            for (int i = 0; i < ListOfX.Count; i++)
            {
                temp = XRanks[i] - YRanks[i];
                dRanks.Add(temp);
                SquareDRanks.Add(Math.Pow(temp, 2));
            }
            foreach (var item in SquareDRanks) { SummaSquad += item; }
            double koefSpir;
            var n = ListOfX.Count;
            koefSpir = Math.Round(1 - ((6 * SummaSquad) / (n * (n * n - 1))), 2);
            if (ListOfX.Count == ListOfY.Count)
            {
                for (int i = 0; i < ListOfX.Count; i++)
                {
                    SpearmanList.Add(
                        new SpearmanKoeff
                        {
                            X = ListOfX[i],
                            Y = ListOfY[i],
                            Nx = XRanks[i],
                            Ny = YRanks[i],
                            Sub = dRanks[i],
                            Squared = SquareDRanks[i],
                            SummaSqrD = SummaSquad,
                            KoefSpearman = koefSpir
                        });
                }
            }
            else return NotFound();
            if (SpearmanList == null) return NotFound();
            else return View(SpearmanList);

        }

        private List<double> Rank(List<double> NumbersList, List<double> RankList)
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

        [HttpGet]
        [Route("Export")]
        public IActionResult Excel()
        {

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot");
            var file = Directory.GetFiles(filePath);
            string fileName = null;
            if (file.Length > 1)
            {
                for (int i = 0; i < file.Length; i++)
                {
                    for (int j = 1; i < file.Length; i++)
                    {

                        var time_i = System.IO.File.GetCreationTime(file[i]);
                        var time_j = System.IO.File.GetCreationTime(file[j]);
                        if (time_i < time_j) fileName = file[i];
                        else fileName = file[j];
                    }
                }
            }
            else fileName = file[0];



            string sWebRootFolder = _hostingEnvironment.WebRootPath;



            var calc = JsonConvert.DeserializeObject<Koefficient>(System.IO.File.ReadAllText
                (Path.Combine(sWebRootFolder, fileName)));

            var Calculations = calc.Koefficients;

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Расчёты");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "x";
                worksheet.Cell(currentRow, 2).Value = "y";

                worksheet.Cell(currentRow, 3).Value = "x^2";
                worksheet.Cell(currentRow, 4).Value = "y^2";


                worksheet.Cell(currentRow, 5).Value = "xy";

                worksheet.Cell(currentRow, 6).Value = "Σx";
                worksheet.Cell(currentRow, 7).Value = "Σy";

                worksheet.Cell(currentRow, 8).Value = "Σx^2";
                worksheet.Cell(currentRow, 9).Value = "Σy^2";

                worksheet.Cell(currentRow, 10).Value = "Σxy";
                worksheet.Cell(currentRow, 11).Value = "Средняя величина x";

                worksheet.Cell(currentRow, 12).Value = "Средняя величина y";
                worksheet.Cell(currentRow, 13).Value = "Средняя величина x^2";

                worksheet.Cell(currentRow, 14).Value = "Средняя величина y^2";
                worksheet.Cell(currentRow, 15).Value = "Cредняя величина xy";

                worksheet.Cell(currentRow, 16).Value = "r";
                worksheet.Cell(currentRow, 17).Value = "Связь";
                int count = 0;
                foreach (var user in Calculations)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = user.X;
                    worksheet.Cell(currentRow, 2).Value = user.Y;

                    worksheet.Cell(currentRow, 3).Value = user.SquareX;
                    worksheet.Cell(currentRow, 4).Value = user.SquareY;

                    worksheet.Cell(currentRow, 5).Value = user.XmultY;
                    if (count == 0)
                    {
                        worksheet.Cell(currentRow, 6).Value = user.SumX;

                        worksheet.Cell(currentRow, 7).Value = user.SumY;
                        worksheet.Cell(currentRow, 8).Value = user.SumSqrX;

                        worksheet.Cell(currentRow, 9).Value = user.SumSqrY;
                        worksheet.Cell(currentRow, 10).Value = user.SumXmultY;
                        worksheet.Cell(currentRow, 11).Value = user.AvgX;
                        worksheet.Cell(currentRow, 12).Value = user.AvgY;

                        worksheet.Cell(currentRow, 13).Value = user.AvgSqrX;
                        worksheet.Cell(currentRow, 14).Value = user.AvgSqrY;

                        worksheet.Cell(currentRow, 15).Value = user.AvgXmultY;
                        worksheet.Cell(currentRow, 16).Value = user.r;
                        worksheet.Cell(currentRow, 17).Value = user.Connection;
                        count++;
                    }
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "users.xlsx");
                }
            }
        }
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

                    for (int i = 0; i < lstModel.Count; i++)
                    {
                        for (int j = 0; j < lstModel.Count; j++)
                        {
                            if (lstModel[i].X < lstModel[j].X)
                            {
                                var temp = lstModel[i];
                                lstModel[i] = lstModel[j];
                                lstModel[j] = temp;
                            }
                        }
                    }
                    ListOfXPoints.Clear(); ListOfYPoints.Clear();
                    for (int i = 0; i < lstModel.Count; i++)
                    {
                        for (int j = i + 1; j < lstModel.Count; j++)
                        {
                            if (lstModel[i].X == lstModel[j].X)
                            {
                                if (lstModel[i].Y == lstModel[j].Y)
                                {
                                    lstModel.RemoveAt(j);
                                }
                            }
                        }

                    }
                    foreach (var item in lstModel) { ListOfXPoints.Add(item.X); ListOfYPoints.Add(item.Y); }




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
                        });

                    }


                    var listX = new List<double>();
                    var listY = new List<double>();

                    foreach (var item in lstModel) { listX.Add(item.X); listY.Add(item.Y); }
                    ViewBag.DataPoints1 = listX;
                    ViewBag.DataPoints2 = listY;

                    var CurrentUploadedFile = file.FileName;
                    Koefficient newEntity = new Koefficient();
                    newEntity.Koefficients = Calculations;
                    var filePath = Path.Combine(_hostingEnvironment.WebRootPath, CurrentUploadedFile);
                    System.IO.File.Delete(filePath);
                    using (StreamWriter fileswriter = System.IO.File.CreateText(filePath + ".json"))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(fileswriter, newEntity);
                    }
                    double t_tabl = 0;
                    check(r, listX.Count, out double t_calc);

                }
                return View(Calculations);
                /* return View(lstModel);*/

            }
            else return RedirectToAction("Index");

        }

        private void check(double r, int n, out double result)
        {
            double temp = 0;
            if (n >= 30) { temp = Math.Sqrt(1 - Math.Pow(r, 2)) / Math.Sqrt(n); }
            else { temp = Math.Sqrt(1 - Math.Pow(r, 2)) / Math.Sqrt(n - 2); }
            result = Math.Round(Math.Abs(r) / temp, 2);
        }

        private double Calculate_r(List<int> listOfXPoints, double avgX, List<int> listOfYPoints, double avgY)
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
            var result = Summa / listOfPoints.Count;
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
            return Math.Round(result, 2);
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
