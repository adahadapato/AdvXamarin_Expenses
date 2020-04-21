﻿using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using ExpensesApp.iOS.Effects;
using UIKit;
using System.ComponentModel;

[assembly: ResolutionGroupName("zayun")]
[assembly: ExportEffect(typeof(SelectedEffect), "SelectedEffect")]
namespace ExpensesApp.iOS.Effects
{
    public class SelectedEffect : PlatformEffect
    {
        UIColor selectedColor;

        protected override void OnAttached()
        {
            selectedColor = new UIColor(176/ 255, 152 / 255, 164 / 255, 255 / 255);
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if (args.PropertyName == "IsFocused")
            {
                if(Control.BackgroundColor !=selectedColor)
                {
                    Control.BackgroundColor = selectedColor;
                }
                else
                {
                    Control.BackgroundColor = UIColor.White;
                }
            }
        }
        protected override void OnDetached()
        {
            
        }
    }
}
