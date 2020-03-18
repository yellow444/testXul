using CefSharp;
using CefSharp.WinForms;
using Gecko;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testXul
{
    public partial class Form1 : Form
    {
        private ChromiumWebBrowser webBrowser1;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            Xpcom.Initialize("Firefox");
            var geckoWebBrowser = new GeckoWebBrowser { Dock = DockStyle.Fill };
            panel1.Controls.Add(geckoWebBrowser);
            geckoWebBrowser.Navigate("http://kad.arbitr.ru/Card/0823350f-6ea8-4f0f-897d-0e851ba93ac0");
            AutoJSContext context = new AutoJSContext(geckoWebBrowser.Window);
            string result;
            context.EvaluateScript(@"alert(' TEST '); ", out result);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var settings = new CefSettings();
            settings.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.130 Safari/537.36";
            if (CefSharp.Cef.IsInitialized == false)
                CefSharp.Cef.Initialize(settings);
            webBrowser1 = new ChromiumWebBrowser();
            var bs = new BrowserSettings();
            LifespanHandler life = new LifespanHandler();
            webBrowser1.LifeSpanHandler = life;
            webBrowser1.IsBrowserInitializedChanged += Browser_IsBrowserInitializedChangedAsync;
            webBrowser1.LoadingStateChanged += Browser_LoadingStateChanged;
            JsDialogHandler jss = new JsDialogHandler();
            webBrowser1.JsDialogHandler = jss;
            webBrowser1.Load("http://kad.arbitr.ru/Card/0823350f-6ea8-4f0f-897d-0e851ba93ac0");
            webBrowser1.Dock = DockStyle.Fill;
            panel1.Controls.Add(webBrowser1);
        }

        private void Browser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (!((ChromiumWebBrowser)sender).IsLoading)
            {
                ((ChromiumWebBrowser)sender).SetZoomLevel(-4.0);
            }
        }

        private async void Browser_IsBrowserInitializedChangedAsync(object sender, EventArgs e)
        {
            if (((ChromiumWebBrowser)sender).IsBrowserInitialized)
            {
                ((ChromiumWebBrowser)sender).IsBrowserInitializedChanged -= Browser_IsBrowserInitializedChangedAsync;
            }
        }


    }
}
