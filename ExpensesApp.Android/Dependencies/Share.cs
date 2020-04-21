﻿using System;
using System.Threading.Tasks;
using ExpensesApp.Interfaces;
using Xamarin.Forms;
using ExpensesApp.Droid.Dependencies;
using Android.Content;
using Android.Support.V4.Content;

[assembly: Dependency(typeof(Share))]
namespace ExpensesApp.Droid.Dependencies
{
    public class Share :IShare
    {
        [Obsolete]
        public Task Show(string title, string message, string filePath)
        {
            var intent = new Intent(Intent.ActionSend);
            intent.SetType("text/plain");
            var documentUrl = FileProvider.GetUriForFile(Forms.Context.ApplicationContext, "com.zayun.biz.expensesapp.provider", new Java.IO.File(filePath));
            intent.PutExtra(Intent.ExtraStream, documentUrl);
            intent.PutExtra(Intent.ExtraText, title);
            intent.PutExtra(Intent.ExtraSubject, message);

            var chooserIntent = Intent.CreateChooser(intent, title);
            chooserIntent.SetFlags(ActivityFlags.GrantReadUriPermission);
            Android.App.Application.Context.StartActivity(chooserIntent);

            return Task.FromResult(true);
        }
    }
}
