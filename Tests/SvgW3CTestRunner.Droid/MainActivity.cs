﻿using Android.App;
using Android.Widget;
using Android.OS;
using Svg;
using Svg.Droid;

namespace SvgW3CTestRunner.Droid
{
    [Activity(Label = "SvgW3CTestRunner.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource, and attach an event to it
            var button = FindViewById<Button>(Resource.Id.MyButton);
            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            //// ignore tests pertaining to javascript or xml reading
            //IEnumerable<string> result;
            //using (var sr = new StreamReader(Assets.Open("PassingTests.txt")))
            //{
            //    var passes = sr.ReadToEnd().Split(new char[]{'\r','\n'}).ToDictionary((f) => f, (f) => true);
            //    var files = (from f in
            //                     (from g in Assets.List("svg")
            //                      select Path.GetFileName(g))
            //                 where !f.StartsWith("animate-") && !f.StartsWith("conform-viewer") &&
            //                 !f.Contains("-dom-") && !f.StartsWith("linking-") && !f.StartsWith("interact-") &&
            //                 !f.StartsWith("script-")
            //                 orderby f
            //                 select f);
            //    result = files.Where((f) => !passes.ContainsKey(f));
            //}
            var pivSvg = FindViewById<ImageView>(Resource.Id.SvgImage);

            var img = new AndroidBitmap(480, 360);
            //using (var stream = Assets.Open("svg/shapes-circle-01-t.svg"))
            //{
            //    var doc = SvgDocument.Open<SvgDocument>(stream);
            //    doc.Draw(img);
            //    pivSvg.SetImageBitmap(img.Image);
            //}

            var doc = SvgDocument.Open<SvgDocument>("svg/shapes-circle-01-t.svg");
            doc.Draw(img);
            pivSvg.SetImageBitmap(img.Image);
        }
    }
}
