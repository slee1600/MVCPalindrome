using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSpinutech.Controllers
{
    public class PalindromeController : Controller
    {
        public IActionResult Index()
        {            
            return View();
        }

        public IActionResult Check(string inputNumber)
        {
            int num = 0;
            inputNumber = inputNumber.Replace(",", "");
            try
            {
                num = int.Parse(inputNumber);
            }
            catch
            {
                //Given a little more time, there is a better way to do this (with a javascript function in the view)
                ViewBag.ReturnValue = "Please enter a valid number"; 
                return View("Index");
            }

            string answer;
            if (checkPalindrome(num)) { answer = "The number entered is a palindrome"; }
            else answer = "The number entered is not a palindrome";

            ViewBag.ReturnValue = answer;
            return View("Index");

            //return View();
        }

        private bool checkPalindrome(int numbertoCheck)
        {
            int remainder = 0, newnum = 0;

            int input = Convert.ToInt32(numbertoCheck);
            for (int i = input; i > 0; i = (i / 10))
            {
                remainder = i % 10;
                newnum = (newnum * 10) + remainder;
            }

            if (newnum == input)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
