﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace EFCAndroid
{
    class Person
    {
        public string Order { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
        public string Actions { get; set; }
    }
}