using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using CSharpProfessional.Part1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpProfessional.Tests
{
    [TestClass]
    public class Part1Test
    {
        #region 1~7
        [TestMethod]
        public void TestDocumentManager()
        {
            var dm = new DocumentManager<Document>();
            dm.Add(new Document("Title A", "Sample A"));
            dm.Add(new Document("Title B", "Sample B"));

            string str = dm.DisplayAll();

            if (dm.IsAvailable)
                str = dm.Get().Content;
        }

        [TestMethod]
        public void TestVar()
        {
            var s1 = new
            {
                Name = "sanzhang",
                Age = 17,
                Sex = "男"
            };
            var s2 = new
            {
                Name = "pan",
                Age = 14,
                Sex = "女"
            };
            var s3 = s1;
            s2 = s3;
        }

        [TestMethod]
        public void TestStatic()
        {
            StaticDemo<string>.X = 4;
            StaticDemo<int>.X = 5;
            int i = StaticDemo<string>.X;
        }

        [TestMethod]
        public void TestShape()
        {
            ChildDemo demo = new ChildDemo();
            ChildDemo demo1 = new ChildDemo();
            BaseDemo demo2 = demo1.Get(demo); // 参数类型是协变的，方法的返回类型是抗变的
        }

        [TestMethod]
        public void TestRectangleCollection()
        {
            // 协变
            IIndex<Rectangle> rectangles = RectangleCollection.GetRectangles();
            IIndex<Shape> shapes = rectangles;
            for (int i = 0; i < shapes.Count; i++)
                Console.WriteLine(shapes[i]);

            // 抗变
            IDisplay<Shape> shapeDisplay = new ShapeDisplay();
            IDisplay<Rectangle> rectangleDisplay = shapeDisplay;
            string str = rectangleDisplay.Show(rectangles[0]);
        }

        [TestMethod]
        public void TestOperators()
        {
            int? a = null;
            int b = a ?? 10;
            a = 3;
            b = a ?? 10;
        }

        [TestMethod]
        public void TestOperatorsChecked()
        {
            byte b = 255;
            checked
            {
                b++;
            }
        }

        [TestMethod]
        public void TestVectorOperator()
        {
            Vector vect1, vect2, vect3;
            vect1 = new Vector(3.0, 3.0, 1.0);
            vect2 = new Vector(2.0, -4.0, -4.0);
            vect3 = vect1 + vect2;

            string s = "vect1 = " + vect1.ToString();
            s += "vect2 = " + vect2.ToString();
            s += "vect3 = " + vect3.ToString();
        }
        #endregion

        #region 8
        [TestMethod]
        public void TestDelegate()
        {
            int i = int.Parse("99");

            int x = 40;
            GetAString firstStringMethod = new GetAString(x.ToString);
            string s = firstStringMethod();

            firstStringMethod = x.ToString; // 委托推断：只传送地址的名称

            Currency balance = new Currency(34, 50);
            firstStringMethod = balance.ToString;
            s = firstStringMethod();

            firstStringMethod = new GetAString(Currency.GetCurrencyUnit);
            s = firstStringMethod();
        }

        [TestMethod]
        public void TestDelegate1()
        {
            //DoubleOp operation = new DoubleOp(MathsOperations.MultiplyByTwo);
            DoubleOp operation = MathsOperations.MultiplyByTwo;
            double result = operation(123);

            Func<double, double> operation1 = MathsOperations.MultiplyByTwo;
            double result1 = operation1(1123);

            //Delegate[] delegates = operation1.GetInvocationList(); // 迭代委托方法
            //foreach (Action d in delegates)
            //    d();
        }

        [TestMethod]
        public void TestBubbleSorter()
        {
            Employee[] employees =
            {
                new Employee("Bugs Bunny", 20000),
                new Employee("Elmer Fudd", 10000),
                new Employee("Daffy Duck", 25000),
                new Employee("Wile Coyote", 1000000.38m),
                new Employee("Foghorn Leghorn", 23000),
                new Employee("RoadRunner", 50000)
            };
            BubbleSorter.Sort(employees, Employee.CompareSalary);
            foreach (var employee in employees)
                Debug.WriteLine(employee);
        }

        [TestMethod]
        public void TestAnonymousMethods()
        {
            string mid = ", middle part,";
            Func<string, string> anonDel = delegate (string param)
            {
                param += mid;
                param += " and this was added to the string.";
                return param;
            };
            Debug.WriteLine(anonDel("Start of string"));
        }

        [TestMethod]
        public void TestLambda()
        {
            //Func<double, double, double> twoParams = (x, y) => { return x * y};
            Func<double, double, double> twoParams = (x, y) => x * y;
            twoParams(3, 2);
        }

        [TestMethod]
        public void TestWeakEvents()
        {
            var dealer = new CarDealer();

            var michael = new Consumer("Michael");
            WeakCarInfoEventManager.AddListener(dealer, michael);
            dealer.NewCar("Mercedes");

            var sebastian = new Consumer("Sebastian");
            WeakCarInfoEventManager.AddListener(dealer, sebastian);
            dealer.NewCar("Ferrari");

            WeakCarInfoEventManager.RemoveListener(dealer, michael);
            dealer.NewCar("Red Bull Racing");
        }
        #endregion

        #region 13
        [TestMethod]
        public void Linq()
        {
            var data = linqSampleData();

            //var res = (from x in data.AsParallel() where Math.Log(x) < 4 select x).Average();
            //var res1 = (from x in data where Math.Log(x) < 4 select x).Average();

            var res2 = (from x in Partitioner.Create(data, true).AsParallel() where Math.Log(x) < 4 select x).Average();
        }
        static List<int> linqSampleData()
        {
            const int arraySize = 50000000;
            var r = new Random();
            return Enumerable.Range(0, arraySize).Select(x => r.Next(140)).ToList();
        }

        [TestMethod]
        public void LinqTree()
        {
            var src = new List<Rectangle>() {
                new Rectangle() { Height = 10, Width = 5 },
                new Rectangle() { Height = 13, Width = 3 },
                new Rectangle() { Height = 20, Width = 5 },
                new Rectangle() { Height = 14, Width = 1 },
            };
            var dest = getR(src, m => m.Height > 10 && m.Width < 5);

            Func<Rectangle, bool> p = r => r.Height == 1;
            Expression<Func<Rectangle, bool>> p1 = r => r.Width == 5;
            p1 = m => m.Height > 10;
            //var d1 = getR(src, p1);
        }
        private IQueryable<Rectangle> getR(IEnumerable<Rectangle> src, Func<Rectangle, bool> s)
        {
            return src.Where(s).AsQueryable();
        }
        #endregion

        #region 19
        [TestMethod]
        public void TestCodeDriver()
        {
            var driver = new CodeDriver();

            bool isError;
            string input = "System.Text.StringBuilder sb = new System.Text.StringBuilder();"
                + "for (int i = 0; i < 5; i++)"
                    + "sb.Append(i.ToString());"
                + "Console.WriteLine(sb.ToString());";
            string output = driver.CompileAndRun(input, out isError);
        }

        [TestMethod]
        public void TestAppDomain()
        {
            AppDomain codeDomain = AppDomain.CreateDomain("CodeDriver");
            CodeDriver codeDriver = (CodeDriver)codeDomain.CreateInstanceAndUnwrap("CSharpProfessional", "CSharpProfessional.Part1.CodeDriver");

            bool isError;
            string input = "System.Text.StringBuilder sb = new System.Text.StringBuilder();"
                + "for (int i = 0; i < 5; i++)"
                    + "sb.Append(i.ToString());"
                + "Console.WriteLine(sb.ToString());";
            string result = codeDriver.CompileAndRun(input, out isError);
            AppDomain.Unload(codeDomain);
        }
        #endregion
    }
}
