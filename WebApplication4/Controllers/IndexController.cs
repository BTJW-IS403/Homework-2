using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            Queue<string>   qMyQueue = new Queue<string>();
            Dictionary<string, int> sCustomer = new Dictionary<string, int>();

            for(int iCount = 0; iCount < 100; iCount++)
            {
                qMyQueue.Enqueue(randomName());
            }

            IEnumerator<string> myQueueEnumerator = qMyQueue.GetEnumerator();
            while (myQueueEnumerator.MoveNext())
            {
                string sCustomerName = myQueueEnumerator.Current;
                if(sCustomer.ContainsKey(sCustomerName))
                {

                    int iBurgerNum = sCustomer[sCustomerName];

                    sCustomer[sCustomerName] = iBurgerNum + randomNumberInRange();
                }
                
                else
                {
                    sCustomer.Add(sCustomerName, randomNumberInRange());
                }

            }

            var items = from pair in sCustomer
                        orderby pair.Value descending
                        select pair;

            ViewBag.Dict = sCustomer;


            foreach (KeyValuePair<string, int> entry in items)
            {
                ViewBag.Output += "<p>" + entry.Key + " : " + entry.Value + "</p>";
            }


            return View();
        }
        public static Random random = new Random();

        public static string randomName()
        {
            string[] names = new string[12] { "Dan Morain","James Stevens", "Brittany Fromm", "Taylor Rees", "Warren Rosengren", "Emily Bell", "Carol Roche", "Ann Rose", "John Miller", "Greg Anderson", "Arthur McKinney", "Joann Fisher" };
            int randomIndex = Convert.ToInt32(random.NextDouble() * 11);
            return names[randomIndex];
        }

        public static int randomNumberInRange()
        {
            return Convert.ToInt32(random.NextDouble() * 20);
        }

    }
}