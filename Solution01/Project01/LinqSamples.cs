using Microsoft.VisualBasic.CompilerServices;
using Project01.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;

namespace Project01
{
    class LinqSamples
    {
        public static IEnumerable<Emp> Emps { get; set; }
        public static IEnumerable<Dept> Depts { get; set; }

        public LinqSamples()
        {
            LoadData();
        }

        public void LoadData()
        {
            var empsCol = new List<Emp>();
            var deptsCol = new List<Dept>();

            #region Load depts
            var d1 = new Dept
            {
                Deptno = 1,
                Dname = "Research",
                Loc = "Warsaw"
            };

            var d2 = new Dept
            {
                Deptno = 2,
                Dname = "Human Resources",
                Loc = "New York"
            };

            var d3 = new Dept
            {
                Deptno = 3,
                Dname = "IT",
                Loc = "Los Angeles"
            };

            deptsCol.Add(d1);
            deptsCol.Add(d2);
            deptsCol.Add(d3);
            Depts = deptsCol;
            #endregion

            #region Load emps
            var e1 = new Emp
            {
                Deptno = 1,
                Empno = 1,
                Ename = "Jan Kowalski",
                HireDate = DateTime.Now.AddMonths(-5),
                Job = "Backend programmer",
                Mgr = null,
                Salary = 2000
            };

            var e2 = new Emp
            {
                Deptno = 1,
                Empno = 20,
                Ename = "Anna Malewska",
                HireDate = DateTime.Now.AddMonths(-7),
                Job = "Frontend programmer",
                Mgr = e1,
                Salary = 4000
            };

            var e3 = new Emp
            {
                Deptno = 1,
                Empno = 2,
                Ename = "Marcin Korewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Frontend programmer",
                Mgr = null,
                Salary = 5000
            };

            var e4 = new Emp
            {
                Deptno = 2,
                Empno = 3,
                Ename = "Paweł Latowski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Frontend programmer",
                Mgr = e2,
                Salary = 5500
            };

            var e5 = new Emp
            {
                Deptno = 2,
                Empno = 4,
                Ename = "Michał Kowalski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Backend programmer",
                Mgr = e2,
                Salary = 5500
            };

            var e6 = new Emp
            {
                Deptno = 2,
                Empno = 5,
                Ename = "Katarzyna Malewska",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Manager",
                Mgr = null,
                Salary = 8000
            };

            var e7 = new Emp
            {
                Deptno = null,
                Empno = 6,
                Ename = "Andrzej Kwiatkowski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "System administrator",
                Mgr = null,
                Salary = 7500
            };

            var e8 = new Emp
            {
                Deptno = 2,
                Empno = 7,
                Ename = "Marcin Polewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Mobile developer",
                Mgr = null,
                Salary = 4000
            };

            var e9 = new Emp
            {
                Deptno = 2,
                Empno = 8,
                Ename = "Władysław Torzewski",
                HireDate = DateTime.Now.AddMonths(-9),
                Job = "CTO",
                Mgr = null,
                Salary = 12000
            };

            var e10 = new Emp
            {
                Deptno = 2,
                Empno = 9,
                Ename = "Andrzej Dalewski",
                HireDate = DateTime.Now.AddMonths(-4),
                Job = "Database administrator",
                Mgr = null,
                Salary = 9000
            };

            empsCol.Add(e1);
            empsCol.Add(e2);
            empsCol.Add(e3);
            empsCol.Add(e4);
            empsCol.Add(e5);
            empsCol.Add(e6);
            empsCol.Add(e7);
            empsCol.Add(e8);
            empsCol.Add(e9);
            empsCol.Add(e10);
            Emps = empsCol;

            #endregion
        }

        /*
            The purpose of the exercise is to implement the following methods.
            Each method should contain C# code, which with the help of LINQ will perform queries described using SQL.
        */

        /// <summary>
        /// SELECT * FROM Emps WHERE Job = "Backend programmer";
        /// </summary>
        #region Task1
        public void Task1()
        {
            //var res = new List<Emp>();
            //foreach(var emp in Emps)
            //{
            //    if (emp.Job == "Backend programmer") res.Add(emp);
            //}

            //1. Query syntax (SQL)
            var res = from emp in Emps
                      where emp.Job == "Backend programmer"
                      select new
                      {
                          Nazwisko = emp.Ename,
                          Zawod = emp.Job
                      };

            //2. Lambda and Extension methods
            var res2 = Emps.Where(e => e.Job == "Backend programmer").Select((e) => e.Ename + ": " + e.Job).ToList();
            res2.ForEach(i => Console.WriteLine(i));
            Console.WriteLine();
        }
        #endregion

        /// <summary>
        /// SELECT * FROM Emps Job = "Frontend programmer" AND Salary>1000 ORDER BY Ename DESC;
        /// </summary>
        #region Task2
        public void Task2()
        {
            var res = from emp in Emps
                      where emp.Job == "Frontend programmer" &&
                      emp.Salary > 1000
                      orderby emp.Ename descending
                      select emp;
            var res2 = Emps.Where((e) => e.Job == "Frontend programmer" && e.Salary > 1000)
                          .OrderByDescending(e => e.Ename).ToList();
            res2.ForEach(i => Console.WriteLine(i));
            Console.WriteLine();
        }
        #endregion

        /// <summary>
        /// SELECT MAX(Salary) FROM Emps;
        /// </summary>
        #region Task3
        public void Task3()
        {
            var max1 = (from emps in Emps
                        select emps.Salary).Max();

            var max2 = Emps.Max(e => e.Salary);
            Console.WriteLine($"{max2}\n");
        }
        #endregion

        /// <summary>
        /// SELECT * FROM Emps WHERE Salary=(SELECT MAX(Salary) FROM Emps);
        /// </summary>
        #region Task4
        public void Task4()
        {
            var res = from emps in Emps
                      where emps.Salary == (from emps2 in Emps
                                            select emps2.Salary).Max()
                      select emps;

            var maxSalary = Emps.Max(e => e.Salary);
            var result = Emps.Where(e => e.Salary == maxSalary).ToList();
            result.ForEach(i => Console.WriteLine(i));
        }
        #endregion

        /// <summary>
        /// SELECT ename AS FirstName, job AS EmployeeJob FROM Emps;
        /// </summary>
        #region Task5
        public void Task5()
        {
            var result = from emps in Emps
                         select new
                         {
                             FirstName = emps.Ename,
                                    };
            var res2 = Emps.Select(emps => new
            {
                FirstName = emps.Ename,
                EmployeeJob = emps.Job
            });
            foreach (var item in res2)
            {
                Console.WriteLine($"{item.FirstName}: {item.EmployeeJob}");
            }
            Console.WriteLine();
        }
        #endregion

        /// <summary>
        /// SELECT Emps.Ename, Emps.Job, Depts.Dname FROM Emps
        /// INNER JOIN Depts ON Emps.Deptno=Depts.Deptno
        /// Result: Joining collections Emps and Depts.
        /// </summary>
        #region Task6
        public void Task6()
        {
            var res1 = from emps in Emps
                       join depts in Depts on emps.Deptno equals depts.Deptno
                       select new
                       {
                           Ename = emps.Ename,
                           Job = emps.Job,
                           Dname = depts.Dname
                       };

            var res2 = Emps.Join(Depts, e => e.Deptno, q => q.Deptno, (r, w) => new { r, w })
                             .Select(w => new
                             {
                                 w.r.Ename,
                                 w.r.Job,
                                 w.w.Dname
                             });

            foreach (var item in res1)
            {
                Console.WriteLine($"{item.Ename} | {item.Job} | {item.Dname}");
            }
            Console.WriteLine();
        }
        #endregion

        /// <summary>
        /// SELECT Job AS EmployeeJob, COUNT(1) EmployeeNuber FROM Emps GROUP BY Job;
        /// </summary>
        #region Task7
        public void Task7()
        {
            var res = from emps in Emps
                      group emps by emps.Job into d
                      select new
                      {
                          EmployeeJob = d.Key,
                          Count = d.Count()
                      };

            var res2 = Emps.GroupBy(e => e.Job).Select(e => new
            {
                EmployeeJob = e.Key,
                Count = e.Count()
            });


            foreach (var item in res2)
            {
                Console.WriteLine($"{item.EmployeeJob} | ({item.Count})");
            }
        }
        #endregion 

        /// <summary>
        /// Return value "true" if at least one of 
        /// the elements of collection works as "Backend programmer".
        /// </summary>
        #region Task8
        public void Task8()
        {
            var exists = from emps in Emps
                         where emps.Job == "Backend programmer"
                         select emps.Ename;
            Console.WriteLine(exists.Any() ? "true" : "-");

            var exists2 = Emps.Any(e => e.Job == "Backend programmer");
            Console.WriteLine(exists2 == true ? "true" : "-");
            Console.WriteLine();
        }
        #endregion 

        /// <summary>
        /// SELECT TOP 1 * FROM Emp WHERE Job="Frontend programmer"
        /// ORDER BY HireDate DESC;
        /// </summary>
        #region Task9
        public void Task9()
        {
            var res1 = (from emps in Emps
                        where emps.Job == "Frontend programmer"
                        orderby emps.HireDate descending
                        select emps).Take(1).ToList();
            res1.ForEach(i => Console.WriteLine(i));
            Console.WriteLine();

            var res2 = Emps.Where(e => e.Job == "Frontend programmer")
                           .OrderByDescending(e => e.HireDate)
                           .Take(1)
                           .ToList();
            res2.ForEach(i => Console.WriteLine(i));
        }
        #endregion 

        /// <summary>
        /// SELECT Ename, Job, Hiredate FROM Emps
        /// UNION
        /// SELECT "No value", null, null;
        /// </summary>
        #region Task10
        public void Task10()
        {
            var res1 = (from emps in Emps
                        select new
                        {
                            ename = emps.Ename,
                            job = emps.Job,
                            hireDate = emps.HireDate
                        }).Union(from emps2 in Emps
                                 select new
                                 {
                                     ename = "No value",
                                     job = (string)null,
                                     hireDate = (DateTime?)null
                                 });
            foreach (var item in res1)
            {
                Console.WriteLine($"{item.ename} | {item.job} | {item.hireDate}");
            }
            Console.WriteLine();

            var res2 = Emps.Select(e => new { ename = e.Ename, job = e.Job, hireDate = e.HireDate })
                           .Union(Emps.Select(e => new { ename = "No value", job = (string)null, hireDate = (DateTime?)null }));
            foreach (var item in res2)
            {
                Console.WriteLine($"{item.ename} | {item.job} | {item.hireDate}");
            }
        }
        #endregion

        //Find the employee with the highest salary using the Aggregate () method
        #region Task11
        public void Task11()
        {
            var res = Emps.Aggregate((a, b) => a.Salary > b.Salary ? a : b);
            Console.WriteLine(res);
        }
        #endregion

        //Using the LINQ language and the SelectMany method, 
        //perform a CROSS JOIN join between collections Emps and Depts
        #region Task12
        public void Task12()
        {
            var res1 = from emps in Emps
                       from depts in Depts
                       select new
                       {
                           emps,
                           depts
                       };
            foreach (var i in res1)
            {
                Console.WriteLine($"{i.emps.Ename} || {i.depts.Dname}");
            }
            Console.WriteLine();

            var res2 = Emps.SelectMany(e => Depts, (e, d) => new { e, d });

            /*var res3 = Emps.SelectMany(e => Depts, (e, d) => new { e, d })
                           .Where(a => a.e.Deptno == a.d.Deptno)
                           .Select(a => new { a.e, a.d });*/
            foreach (var i in res2)
            {
                Console.WriteLine($"{i.e.Ename} || {i.d.Dname}");
            }
        }
        #endregion
    }
}
