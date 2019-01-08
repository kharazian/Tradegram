﻿using System;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Volo.Abp.AspNetCore.App
{
    public class LocalizationTestController : AbpController
    {
        public IActionResult HelloJohn()
        {
            return View();
        }

        public IActionResult PersonForm()
        {
            return View(new PersonModel());
        }

        public class PersonModel
        {
            //[Display(Name = nameof(BirthDate))]
            public string BirthDate { get; set; }

            public PersonModel()
            {
                BirthDate = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
    }
}
